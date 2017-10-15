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
using System.Net;

namespace toolstrackingsystem
{
    public partial class FrmReturnTool : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FrmReturnTool));
        private IUserManageService _userManageService;
        private IToolInfoService _toolInfoService;
        private IPersonManageService _personManageService;
        private List<OutBackStoreEntity> ToolInfoList = new List<OutBackStoreEntity>();


        private Thread threadClientR;
        private Thread threadClientConR = null;

        public bool IsConnect = true;
        public bool IsListening = true;


        //代理用来设置text的值 （实现另一个线程操作主线程的对象）
        private delegate void SetTextCallback(string text);
        private delegate bool GetBoolCallback();

        private static Socket SocketClient;
        private static string ScanIpAddress = CommonHelper.GetConfigValue("scanAddress");
        private static string ScanPort = CommonHelper.GetConfigValue("scanPort");
        public FrmReturnTool()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void btnAddTool_Click(object sender, EventArgs e)
        {
            LoadToolData();
        }
        private void LoadToolData()
        {
            var toolCode = this.tbEditCode.Text;
            if (!string.IsNullOrWhiteSpace(toolCode))
            {
                var tool = _toolInfoService.GetToolByCode(toolCode);
                if (tool != null && string.IsNullOrWhiteSpace(tool.PackCode))
                {
                    var toolOut = _toolInfoService.GetToolOutByCode(toolCode);
                    if (toolOut != null && toolOut.IsBack == "0")
                    {
                        bool isContain = false;
                        foreach (var item in ToolInfoList)
                        {
                            if (item != null && item.ToolCode == toolOut.ToolCode)
                            {
                                isContain = true;
                            }
                        }
                        if (!isContain)
                        {
                            OutBackStoreEntity entity = new OutBackStoreEntity();
                            entity.TypeName = tool.TypeName;
                            entity.ChildTypeName = tool.ChildTypeName;
                            entity.PackCode = tool.PackCode;
                            entity.PackName = tool.PackName;
                            entity.ToolCode = tool.ToolCode;
                            entity.ToolName = tool.ToolName;
                            entity.Models = tool.Models;
                            entity.Location = tool.Location;
                            entity.Remarks = tool.Remarks;
                            entity.OutStoreTime = toolOut.OutStoreTime;
                            entity.OutDescribes = toolOut.outdescribes;
                            entity.PersonCode = toolOut.PersonCode;
                            entity.PersonName = toolOut.PersonName;
                            entity.OutBackStoreID = toolOut.OutBackStoreID;
                            entity.OptionPersonCode = LoginHelper.UserCode;
                            entity.OptionPersonName = LoginHelper.UserName;
                            ToolInfoList.Add(entity);
                            this.dataGridViewX1.DataSource = ToolInfoList.ToArray();
                        }

                    }
                    else
                    {
                        MessageBox.Show("该工具已经归还！");
                        this.tbEditCode.Text = "";
                        return;
                    }
                }

                else //包
                {
                    var tools = _toolInfoService.GetToolByCodeOrPackCode(toolCode);
                    if (tools.Any())
                    {
                        bool isAnyBack = false;
                        List<OutBackStoreEntity> outBack_List = new List<OutBackStoreEntity>();
                        foreach (var item in tools)
                        {
                            var toolOut = _toolInfoService.GetToolOutByCode(item.ToolCode);
                            if (toolOut != null&&toolOut.IsBack == "0")
                            {
                               
                                    bool isContain = false;
                                    foreach (var itemHave in ToolInfoList)
                                    {
                                        if (itemHave != null && itemHave.ToolCode == toolOut.ToolCode)
                                        {
                                            isContain = true;
                                        }
                                    }
                                    if (!isContain)
                                    {
                                        OutBackStoreEntity entity = new OutBackStoreEntity();
                                        entity.TypeName = item.TypeName;
                                        entity.ChildTypeName = item.ChildTypeName;
                                        entity.PackCode = item.PackCode;
                                        entity.PackName = item.PackName;
                                        entity.ToolCode = item.ToolCode;
                                        entity.ToolName = item.ToolName;
                                        entity.Models = item.Models;
                                        entity.Location = item.Location;
                                        entity.Remarks = item.Remarks;
                                        entity.OutStoreTime = toolOut.OutStoreTime;
                                        entity.OutDescribes = toolOut.outdescribes;
                                        entity.PersonCode = toolOut.PersonCode;
                                        entity.PersonName = toolOut.PersonName;
                                        entity.OutBackStoreID = toolOut.OutBackStoreID;
                                        entity.OptionPersonCode = LoginHelper.UserCode;
                                        entity.OptionPersonName = LoginHelper.UserName;

                                        outBack_List.Add(entity);
                                    }
                            }
                            else //已经归还
                            {
                                isAnyBack = true;
                            }
                        }
                        if (isAnyBack)
                        {
                            MessageBox.Show("该工具包已经归还！");
                            this.tbEditCode.Text = "";
                            return;
                        }
                        if (outBack_List.Any())
                        {
                            ToolInfoList.AddRange(outBack_List);
                            this.dataGridViewX1.DataSource = ToolInfoList.ToArray();
                        }
                    }
                }
                this.tbEditCode.Text = "";
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (ToolInfoList == null || ToolInfoList.Count == 0)
            {
                MessageBox.Show("请先增加需要归还的工具信息");
                return;
            }
                DlgEnterPersonMsg1 dlgEnterPersonMsg = new DlgEnterPersonMsg1();
                dlgEnterPersonMsg.ShowDialog();
                if (dlgEnterPersonMsg.DialogResult == DialogResult.OK)
                {
                    var person = dlgEnterPersonMsg.Tag as t_PersonInfo;
                    if (person != null && !string.IsNullOrWhiteSpace(person.PersonCode))
                    {
                        if (ToolInfoList == null || ToolInfoList.Count == 0)
                        {
                            MessageBox.Show("请先增加需要归还的工具信息");
                            return;
                        }
                        if (person.IsReceive == "1")
                        {
                            string desc = tbEditoutdescribes.Text;

                            int successCount = 0;
                            foreach (var entity in ToolInfoList)
                            {

                                if (_toolInfoService.IsExistsOutStoreByCode(entity.ToolCode, "0") && _toolInfoService.BackStore(entity, person, LoginHelper.UserCode, desc))
                                {
                                    successCount += 1;
                                }
                            }

                            MessageBox.Show(string.Format("归还成功，成功归还{0}件工具，归还人:{1}！", successCount,person.PersonName));
                            ToolInfoList = new List<OutBackStoreEntity>();
                            this.dataGridViewX1.DataSource = ToolInfoList.ToArray();
                            tbEditCode.Text = "";
                            //tbEditPersonCode.Text = person.PersonCode;
                            //tbEditPersonName.Text =person.PersonName;
                            tbEditoutdescribes.Text = "";

                        }
                        else {
                            MessageBox.Show("用户没有领用归还权限！");
                            return;
                        }
                    }
                    else {
                        MessageBox.Show("此用户可能已经被删除！");
                        return;
                    }
                   
                }
            
        }
        private void btnReturnContinue_Click(object sender, EventArgs e)
        {
            ToolInfoList = new List<OutBackStoreEntity>();
            this.dataGridViewX1.DataSource = ToolInfoList.ToArray();
            tbEditCode.Text = "";
            //tbEditPersonCode.Text = "";
            //tbEditPersonName.Text = "";
            tbEditoutdescribes.Text = "";
        }
        private void FrmReturnTool_Load(object sender, EventArgs e)
        {
            StartScanListion(logger);
            _userManageService = Program.container.Resolve<IUserManageService>();
            _toolInfoService = Program.container.Resolve<IToolInfoService>();
            _personManageService = Program.container.Resolve<IPersonManageService>();
            this.dataGridViewX1.AutoGenerateColumns = false;
            threadClientR = new Thread(RecMsg);
            //人员编码默认获取焦点
            //将窗体线程设置为与后台同步
            threadClientR.IsBackground = true;

            //启动线程
            threadClientR.Start();
        }
        #region 接收服务端发来信息的方法
        private void RecMsg()
        {
            while (true) //持续监听服务端发来的消息
            {
                if (IsListening)
                {
                    if (SocketClient != null && SocketClient.Connected && SocketClient.Available > 0)
                    {
                        //定义一个1024*200的内存缓冲区 用于临时性存储接收到的信息
                        byte[] arrRecMsg = new byte[1024 * 200];

                        //将客户端套接字接收到的数据存入内存缓冲区, 并获取其长度
                        int length = SocketClient.Receive(arrRecMsg);

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
                else {
                    try
                    {
                        //if (threadClientO != null)
                        //    threadClientO.Abort();
                        if (SocketClient != null && SocketClient.Connected)
                        {
                            //关闭Socket之前，首选需要把双方的Socket Shutdown掉
                            SocketClient.Shutdown(SocketShutdown.Both);

                            //Shutdown掉Socket后主线程停止10ms，保证Socket的Shutdown完成
                            System.Threading.Thread.Sleep(10);

                            //关闭客户端Socket,清理资源
                            SocketClient.Close();
                        }
                    }
                    catch (Exception ex)
                    {

                        logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "frmReturnTool--shutdown", ex.Message, ex.StackTrace, ex.Source);

                    }
                    Thread.Sleep(2000);
                }
            }
        }

        private bool IsForcus()
        {
            if (tbEditCode.InvokeRequired)
            {
                GetBoolCallback d = new GetBoolCallback(IsForcus);
                return bool.Parse(this.Invoke(d).ToString());
            }
            else
            {
                return tbEditCode.Focused;
            }
        }
        private void SetText(string text)
        {
           
                if (tbEditCode.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    tbEditCode.Text = text;
                }
            
            
        }

        #endregion
        private void tbEditCode_TextChanged(object sender, EventArgs e)
        {
            LoadToolData();

        }
       
        private void StartScanListion(ILog logger)
        {
            if (string.IsNullOrWhiteSpace(ScanIpAddress) || string.IsNullOrWhiteSpace(ScanPort))
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1}", "program--StartScanListion", "您必须完善您的智能相机配置!");
                return;
            }
            try
            {

                Thread threadClient = new Thread(new ParameterizedThreadStart(ConnectTo)); //链接重试

                //将窗体线程设置为与后台同步
                threadClient.IsBackground = true;

                //启动线程
                threadClient.Start(logger);

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "program--StartScanListion", ex.Message, ex.StackTrace, ex.Source);

            }
        }
        private void ConnectTo(object loggerObj)
        {
            var logger = loggerObj as ILog;


            while (true)
            {
                if (IsConnect)
                {
                    if (!(SocketClient != null && SocketClient.Connected))
                    {
                        try
                        {
                            SocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                            IPAddress ipaddressObj = IPAddress.Parse(ScanIpAddress);
                            //将获取的ip地址和端口号绑定到网络节点endpoint上
                            IPEndPoint endpoint = new IPEndPoint(ipaddressObj, int.Parse(ScanPort));

                            //这里客户端套接字连接到网络节点(服务端)用的方法是Connect 而不是Bind
                            SocketClient.Connect(endpoint);
                            logger.ErrorFormat("智能相机链接成功Ip:{0}port:{1}", ScanIpAddress, ScanPort);

                            Thread.Sleep(5000);
                        }
                        catch (Exception ex)
                        {
                            logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "program--StartScanListion", ex.Message, ex.StackTrace, ex.Source);
                            Thread.Sleep(2000);
                        }
                    }
                    else
                    {
                        Thread.Sleep(2000);//10s
                    }

                }
                else {
                    Thread.Sleep(2000);
                }
            }
        }
        private void FrmReturnTool_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsConnect = false;
            IsListening = false;
            this.Dispose();
        }

        private void FrmReturnTool_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                this.btnReturn_Click(sender, e);//触发button事件  
            }  
        }


    }
}
