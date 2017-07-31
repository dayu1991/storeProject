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
        private Thread threadClient;
        private Socket socketClient = Program.SocketClient;
        //代理用来设置text的值 （实现另一个线程操作主线程的对象）
        private delegate void SetTextCallback(string text);

        public FrmOutTool()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            if (ToolInfoList.Count == 0)
            {
                MessageBox.Show("请先增加工具信息");
                return;
            }
            var userCode = tbEditPersonCode.Text;

            if (string.IsNullOrWhiteSpace(userCode))
            {
                MessageBox.Show("请填写人员编码！");
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
                var selectValue = this.cbEditOutTime.SelectedText;
                if (selectValue == "自定义")
                {
                    endDate = dtiSelect.Value.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else {
                    var hours = this.cbEditOutTime.SelectedValue.ToString();
                    endDate = DateTime.Now.AddHours(int.Parse(hours)).ToString("yyyy-MM-dd HH:mm:ss");
                }
                var successCodes = "";
                foreach (var entity in ToolInfoList)
                {

                    if (_toolInfoService.IsExistsInStoryByCode(entity.ToolCode) && _toolInfoService.OutStore(entity, person, LoginHelper.UserCode, endDate, desc))
                    {
                        successCodes += entity.ToolCode;
                    }
                }

                MessageBox.Show(string.Format("领用成功，领用成功工具{0}！", successCodes));
                ToolInfoList = new List<t_ToolInfo>();
                this.dataGridViewX1.DataSource = ToolInfoList.ToArray();
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
            this.tbEditCode.Text = "";
            this.tbEditoutdescribes.Text = "";
            this.cbEditOutTime.SelectedText = "1小时";
        }

        private void btnAddTool_Click(object sender, EventArgs e)
        {
            var toolCode = this.tbEditCode.Text;
            if (string.IsNullOrWhiteSpace(toolCode))
            {
                MessageBox.Show("请填入工具编码");
                return;
            }
            var tool = _toolInfoService.GetToolByCode(toolCode);
            if (tool != null && !string.IsNullOrWhiteSpace(tool.ToolCode)&&tool.IsActive=="1")
            {
                if (string.IsNullOrWhiteSpace(tool.PackCode)) //不存在包
                {
                    if (_toolInfoService.IsExistsInStoryByCode(toolCode)) //有库存
                    {
                        tool.OptionPerson = LoginHelper.UserName;
                        ToolInfoList.Add(tool);
                        this.dataGridViewX1.DataSource = ToolInfoList.ToArray();
                    }
                    else {
                        MessageBox.Show("此编码的工具仓库中已经没有啦！");
                        return;
                    }
                }
                else {
                    MessageBox.Show("此编码的工具已经被打包！");
                    return;
                }
            }
            else {
                MessageBox.Show("不存在此编码的常规工具！");
                return;
            }
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

            threadClient = new Thread(RecMsg);

            //将窗体线程设置为与后台同步
            threadClient.IsBackground = true;

            //启动线程
            threadClient.Start();
        }

        private void cbEditOutTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectValue = this.cbEditOutTime.SelectedText;
            if (selectValue == "自定义")
            {
                this.dtiSelect.Visible = true;
            }
        }

        #region 接收服务端发来信息的方法
        private void RecMsg()
        {
            while (true) //持续监听服务端发来的消息
            {
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
                        SetText(totalText);

                    }
                }
                Thread.Sleep(200);
            }
        }
        private void SetText(string text)
        {
            //获取当前有焦点的控件，然后给当前控件赋值
            Control ctl = this.ActiveControl;
            if (ctl is TextBox) //只给textbox赋值
            {
                // InvokeRequired需要比较调用线程ID和创建线程ID
                // 如果它们不相同则返回true
                if (ctl.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    ctl.Text = text;
                }
            }
        }

        #endregion

        private void FrmOutTool_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
       
    }
}
