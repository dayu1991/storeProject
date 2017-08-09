using DevComponents.DotNetBar;
using log4net;
using service.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using dbentity.toolstrackingsystem;
using common.toolstrackingsystem;
using ViewEntity.toolstrackingsystem.view;
using System.IO;
using NPOI.SS.UserModel;
using ViewEntity.toolstrackingsystem;
using System.Threading;
using System.Net.Sockets;
namespace toolstrackingsystem
{
    public partial class FrmOutTool : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FrmOutTool));
        private IUserManageService _userManageService;
        private IToolInfoService _toolInfoService;
        private IPersonManageService _personManageService;
        private List<t_ToolInfo> ToolInfoList = new List<t_ToolInfo>();
        private Thread threadClientO;
        //代理用来设置text的值 （实现另一个线程操作主线程的对象）
        private delegate void SetTextCallback(string text);
        private delegate bool GetBoolCallback();

        public FrmOutTool()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        
        private void btnOut_Click(object sender, EventArgs e)
        {
            if (ToolInfoList==null||ToolInfoList.Count == 0)
            {
                MessageBox.Show("请先增加工具信息");
                return;
            }
            var userCode = tbEditPersonCode.Text;

            if (string.IsNullOrWhiteSpace(userCode))
            {
                MessageBox.Show("请填写人员编号！");
                return;
            }
            var person = _personManageService.GetPersonInfo(userCode);
            if (person == null || string.IsNullOrWhiteSpace(person.PersonCode))
            {
                MessageBox.Show("不存在的人员编码！");
                return;
            }
            if (person.IsReceive == "1")
            {
                string desc = tbEditoutdescribes.Text;
                string endDate = "";
                var selectValue = this.cbEditOutTime.SelectedValue.ToString();
                if (selectValue == "0")
                {
                    endDate = dtiSelect.Value.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else {
                    var hours = this.cbEditOutTime.SelectedValue.ToString();
                    endDate = DateTime.Now.AddHours(int.Parse(hours)).ToString("yyyy-MM-dd HH:mm:ss");
                }
                int successCount = 0;
                foreach (var entity in ToolInfoList)
                {

                    if (_toolInfoService.IsExistsInStoryByCode(entity.ToolCode) && _toolInfoService.OutStore(entity, person, LoginHelper.UserCode, endDate, desc))
                    {
                        successCount += 1;
                    }
                }

                MessageBox.Show(string.Format("领用成功，领用成功{0}件工具！", successCount));
                ToolInfoList = new List<t_ToolInfo>();
                this.dataGridViewX1.DataSource = ToolInfoList.ToArray();
                tbEditCodeOut.Text = "";
                tbEditPersonCode.Text = "";
                tbEditPersonName.Text = "";
                cbEditOutTime.SelectedValue = "1";
                tbEditoutdescribes.Text = "";
                return;
            }
            else {
                MessageBox.Show("用户没有领用权限！");
                return;
            }
        }

        private void btnOutContinue_Click(object sender, EventArgs e)
        {
            ToolInfoList = new List<t_ToolInfo>();
            this.dataGridViewX1.DataSource = ToolInfoList.ToArray();
            tbEditCodeOut.Text = "";
            tbEditPersonCode.Text = "";
            tbEditPersonName.Text = "";
            cbEditOutTime.SelectedValue = "1";
            tbEditoutdescribes.Text = "";
        }

        private void btnAddTool_Click(object sender, EventArgs e)
        {
            LoadToolData();
        }

        private void FrmOutTool_Load(object sender, EventArgs e)
        {
            _userManageService = Program.container.Resolve<IUserManageService>();
            _toolInfoService = Program.container.Resolve<IToolInfoService>();
            _personManageService = Program.container.Resolve<IPersonManageService>();

           

            var blongs = new List<DropDownCtrolObj>();
            blongs.Add(new DropDownCtrolObj
            {
                SelectText="1小时",
                SelectValue="1"
            });
            blongs.Add(new DropDownCtrolObj
            {
                SelectText = "2小时",
                SelectValue = "2"
            });
            blongs.Add(new DropDownCtrolObj
            {
                SelectText = "3小时",
                SelectValue = "3"
            });
            blongs.Add(new DropDownCtrolObj
            {
                SelectText = "6小时",
                SelectValue = "6"
            });
            blongs.Add(new DropDownCtrolObj
            {
                SelectText = "12小时",
                SelectValue = "12"
            });
            blongs.Add(new DropDownCtrolObj
            {
                SelectText = "一天",
                SelectValue = "24"
            });
            blongs.Add(new DropDownCtrolObj
            {
                SelectText = "一周",
                SelectValue = "168"
            });
            blongs.Add(new DropDownCtrolObj
            {
                SelectText = "自定义",
                SelectValue = "0"
            });
            this.cbEditOutTime.DataSource = blongs;
            this.cbEditOutTime.DisplayMember = "SelectText";
            this.cbEditOutTime.ValueMember = "SelectValue";
            this.dataGridViewX1.AutoGenerateColumns = false;

            threadClientO = new Thread(RecMsg);

            //将窗体线程设置为与后台同步
            threadClientO.IsBackground = true;

            //启动线程
            threadClientO.Start();
        }

        private void cbEditOutTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectValue = this.cbEditOutTime.SelectedValue.ToString();
            if (selectValue == "0")
            {
                this.dtiSelect.Visible = true;
            }
            else {
                this.dtiSelect.Visible = false;

            }
        }

        #region 接收服务端发来信息的方法
        private void RecMsg()
        {
            while (true) //持续监听服务端发来的消息
            {
                Socket socketClient = Program.SocketClient;
                if (socketClient != null && socketClient.Connected && socketClient.Available > 0)
                {
                    //定义一个1024*200的内存缓冲区 用于临时性存储接收到的信息
                    byte[] arrRecMsg = new byte[1024 * 200];

                    //将客户端套接字接收到的数据存入内存缓冲区, 并获取其长度
                    int length = socketClient.Receive(arrRecMsg);

                    string strData = Encoding.Default.GetString(arrRecMsg, 0, length);
                    var totalText = strData;
                    if (!string.IsNullOrWhiteSpace(totalText))
                    {
                        //if (IsForcus())
                        //{
                            SetText(totalText);
                        //}
                    }
                }
                Thread.Sleep(100);
            }
        }
        private bool IsForcus()
        {
            if (tbEditCodeOut.InvokeRequired)
            {
                GetBoolCallback d = new GetBoolCallback(IsForcus);
                return bool.Parse(this.Invoke(d).ToString());
            }
            else
            {               
                return tbEditCodeOut.Focused;              
            }
        }
        private void SetText(string text)
        {
            //获取当前有焦点的控件，然后给当前控件赋值
            //Control ctl = this.ActiveControl;
            //if (ctl is TextBox) //只给textbox赋值
            //{
            //    // InvokeRequired需要比较调用线程ID和创建线程ID
            //    // 如果它们不相同则返回true
            //    if (ctl.InvokeRequired)
            //    {
            //        SetTextCallback d = new SetTextCallback(SetText);
            //        this.Invoke(d, new object[] { text });
            //    }
            //    else
            //    {
            //        ctl.Text = text;
            //        btnAddTool_Click(null, null);
                    
            //    }
            //}
               if (tbEditCodeOut.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    //if (tbEditCode.Focused)
                    //{
             
                    //tbEditCode.Text = "";
                    tbEditCodeOut.Text = text;
                    //}
                    //btnAddTool_Click(null, null);
                }
            
           
        }

        #endregion

        private void tbEditCode_TextChanged(object sender, EventArgs e)
        {
            LoadToolData();
        }
        private void LoadToolData()
        {
            var toolCode = this.tbEditCodeOut.Text.Trim();
            if (!string.IsNullOrWhiteSpace(toolCode))
            {
                var tool = _toolInfoService.GetToolByCode(toolCode);
                if (tool != null &&string.IsNullOrWhiteSpace(tool.PackCode)) //工具
                {
                    if (tool.IsActive == "1") //不存在包
                    {
                        if (_toolInfoService.IsExistsInStoryByCode(toolCode)) //有库存
                        {
                            bool isContain = false;
                            foreach (var item in ToolInfoList)
                            {
                                if (item != null && item.ToolCode == tool.ToolCode)
                                {
                                    isContain = true;
                                }
                            }
                            if (!isContain)
                            {
                                tool.OptionPerson = LoginHelper.UserName;
                                ToolInfoList.Add(tool);
                                this.dataGridViewX1.DataSource = ToolInfoList.ToArray();
                            }

                        }
                        else
                        {
                            MessageBox.Show("此编码的工具仓库中已经没有啦！");
                            return;
                        }
                    }
                    else {
                        MessageBox.Show("该工具不能被领用！");
                        return;
                    }
                   
                }
                else //包
                {
                    var tools = _toolInfoService.GetToolByCodeOrPackCode(toolCode);
                    if (tools.Any())
                    {
                        foreach (var item in tools)
                        {
                            if (_toolInfoService.IsExistsInStoryByCode(item.ToolCode)) //有库存
                            {
                                bool isContain = false;
                                foreach (var itemHave in ToolInfoList)
                                {
                                    if (itemHave != null && itemHave.ToolCode == item.ToolCode)
                                    {
                                        isContain = true;
                                    }
                                }
                                if (!isContain)
                                {
                                    item.OptionPerson = LoginHelper.UserName;
                                    ToolInfoList.Add(item);
                                }

                            }
                        }
                        this.dataGridViewX1.DataSource = ToolInfoList.ToArray();
                    }

                }                         
            }
            
        }

        private void tbEditPersonCode_TextChanged(object sender, EventArgs e)
        {
            tbEditPersonName.Text = "";
            var personCode = tbEditPersonCode.Text;
            if (!string.IsNullOrWhiteSpace(personCode))
            {
                var person = _personManageService.GetPersonInfo(personCode);
                if (person != null)
                {
                    if (person.IsReceive == "1")
                    {
                        tbEditPersonName.Text = person.PersonName;
                    }
                    else {
                        MessageBox.Show("没有领用权限！");
                        return;
                    }
                }               

            }
        }

        private void FrmOutTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("没有领用权限！");
        }

    }
}
