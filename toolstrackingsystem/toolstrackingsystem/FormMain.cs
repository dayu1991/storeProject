using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using dbentity.toolstrackingsystem;
using System.Reflection;
using System.Runtime.Caching;
using System.IO;
using service.toolstrackingsystem;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using ViewEntity.toolstrackingsystem;
using log4net;
using common.toolstrackingsystem;

namespace toolstrackingsystem
{
    public partial class FormMain : Office2007RibbonForm
    {
        private IRoleManageService _roleManageService;
        private IMenuManageService _menuManageService;
        ILog logger = log4net.LogManager.GetLogger(typeof(FormMain));
        private Dictionary<string, string> tablItemDic = new Dictionary<string, string>();
        private int i = 0;
        public FormMain()
        {
            this.EnableGlass = false;
            InitializeComponent();
            this.IsMdiContainer = true;
        }
        private void FormTest_Load(object sender, EventArgs e)
        {
            //修改界面默认显示颜色
            this.styleManager1.ManagerStyle = eStyle.OfficeMobile2014;
            //默认清空所有的tab页
            SuperTabControl superTabControl = new SuperTabControl();
            superTabControl.Tabs.Clear();
            ////获取用户信息
            //Sys_User_Info userInfo = MemoryCache.Default.Get("userinfo") as Sys_User_Info;
            ribbonControl1.TitleText = "北京动车段工具管理应用系统v1.1[" + LoginHelper.UserName + "]";
            label_login_user.Text = LoginHelper.UserName;

            #region 手动添加菜单项test
            //RibbonTabItem tabItem = new RibbonTabItem();
            //tabItem.Text = "基础数据";
            //RibbonPanel rpanel = new RibbonPanel();
            //rpanel.Dock = DockStyle.Fill;
            //tabItem.Panel = rpanel;
            //ribbonControl1.Controls.Add(rpanel);
            //ribbonControl1.TitleText = "北京动车段工具管理应用系统v1.1[" + userInfo.UserName + "]";
            //this.ribbonControl1.Items.Add(tabItem);
            //RibbonBar rb = new RibbonBar();

            //ButtonItem btnTool = new ButtonItem("bi2");
            //btnTool.Text = "常规工具";
            //btnTool.Icon = new Icon("../../image/manage.ico");
            //btnTool.ImagePosition = eImagePosition.Top;
            //btnTool.Click += new EventHandler(ToolInfo_Click);
            //rb.Items.Add(btnTool);
            //rpanel.Controls.Add(rb);

            #endregion

            #region 获取用户角色权限
            _roleManageService = Program.container.Resolve<IRoleManageService>() as RoleManageService;
            _menuManageService = Program.container.Resolve<IMenuManageService>() as MenuManageService;
            Sys_User_Role roleInfo = _roleManageService.GetRoleInfo(LoginHelper.UserRole);
            
            List<MenuInfoEntity> resultEntity = _menuManageService.GetUserMenuInfoList(roleInfo.MenuID);
            foreach (var item in resultEntity)
            {
                RibbonTabItem tabItemNew = new RibbonTabItem();
                tabItemNew.Text = item.ParentMenuInfo.NavigationTitle;
                RibbonPanel rpanelNew = new RibbonPanel();
                rpanelNew.Dock = DockStyle.Fill;
                tabItemNew.Panel = rpanelNew;
                this.ribbonControl1.Items.Add(tabItemNew);
                ribbonControl1.Controls.Add(rpanelNew);
                RibbonBar rbNew = new RibbonBar();
                foreach (var childitem in item.ChildMenuInfoList)
                {
                    ButtonItem btnToolNew = new ButtonItem(childitem.FileName);
                    btnToolNew.Text = childitem.NavigationTitle;
                    //btnToolNew.Icon = new Icon("../../image/"+childitem.MenuICON+".ico");
                    btnToolNew.Icon = new Icon("./image/" + childitem.MenuICON + ".ico");
                    btnToolNew.ImagePosition = eImagePosition.Top;
                    btnToolNew.Click += new EventHandler(Custom_Click);
                    btnToolNew.Tag = childitem.FileName;
                    rbNew.Items.Add(btnToolNew);
                }
                rpanelNew.Controls.Add(rbNew);
            }

            #endregion

            #region 判断用户是否为服务端用户
            if (LoginHelper.UserRole != "ServerRole")
            {
                Select_buttonItem.Visible = false;
            }
            #endregion

            #region 判断连接服务器IP
            string connStr = MemoryCacheHelper.GetConnectionStr();
            string ip = connStr.Split(';')[0].Split('=')[1].ToString();
            string dataBase = connStr.Split(';')[1].Split('=')[1].ToString();
            switch (dataBase)
            {
                case "toolInfo_DongSuo":
                    dataBase = "东所";
                    break;
                case "toolInfo_XiSuo":
                    dataBase = "西所";
                    break;
                case "toolInfo_NanSuo":
                    dataBase = "南所";
                    break;
                case "toolInfo_ShiJiaZhuang":
                    dataBase = "石家庄所";
                    break;
                case "toolInfo_SheBei":
                    dataBase = "设备";
                    break;
                default:
                    dataBase = "东所";
                    break;
            }
            Message_label.Text = "连接到服务器" + ip+" 当前数据库："+dataBase;
            #endregion

            //timer启动
            this.timer1.Start();           
        }
        private void SetTabShow(string tabName,Type formType)
        {
            
            try
            {
                bool isOpen = false;

                string dataBase = MemoryCache.Default.Get("clientName") != null ? MemoryCache.Default.Get("clientName").ToString() : CommonHelper.GetConfigValue("defaultDataBase");
                foreach (SuperTabItem item in superTabControl2.Tabs)
                {
                    if (tabName == EnumHelper.MenuName.领用工具.ToString())
                    {
                        if (item.Text == EnumHelper.MenuName.归还工具.ToString())
                        {
                            //关闭领用
                            FrmReturnTool toolFrm = (FrmReturnTool)item.AttachedControl.Controls[0];
                            toolFrm.IsConnect = false;
                            toolFrm.IsListening = false;
                        }
                        if (item.Text == EnumHelper.MenuName.工具包管理.ToString())
                        {
                            //关闭工具包
                            FrmToolPackManage toolFrm = (FrmToolPackManage)item.AttachedControl.Controls[0];
                            toolFrm.IsConnect = false;
                            toolFrm.IsListening = false;
                        }
                    }
                    else if (tabName == EnumHelper.MenuName.归还工具.ToString())
                    {
                        if (item.Text == EnumHelper.MenuName.领用工具.ToString())
                        {
                            //关闭领用
                            FrmOutTool toolFrm = (FrmOutTool)item.AttachedControl.Controls[0];
                            toolFrm.IsConnect = false;
                            toolFrm.IsListening = false;
                        }
                        if (item.Text == EnumHelper.MenuName.工具包管理.ToString())
                        {
                            //关闭工具包管理
                            FrmToolPackManage toolFrm = (FrmToolPackManage)item.AttachedControl.Controls[0];
                            toolFrm.IsConnect = false;
                            toolFrm.IsListening = false;
                        }
                    }
                    else if (tabName == EnumHelper.MenuName.工具包管理.ToString())
                    {
                        if (item.Text == EnumHelper.MenuName.领用工具.ToString())
                        {
                            //关闭领用
                            FrmOutTool toolFrm = (FrmOutTool)item.AttachedControl.Controls[0];
                            toolFrm.IsConnect = false;
                            toolFrm.IsListening = false;
                        }
                        if (item.Text == EnumHelper.MenuName.归还工具.ToString())
                        {
                            //关闭归还
                            FrmReturnTool toolFrm = (FrmReturnTool)item.AttachedControl.Controls[0];
                            toolFrm.IsConnect = false;
                            toolFrm.IsListening = false;
                        }
                    }
                    //已打开
                    if (item.Name == tabName)
                    {
                        if (tabName == EnumHelper.MenuName.送修工具接收.ToString())
                        {
                            ToolRepairManageNew toolFrm = (ToolRepairManageNew)item.AttachedControl.Controls[0];
                            foreach (SuperTabItem tab in toolFrm.superTabStrip1.Tabs)
                            {
                                if (tab.Name == dataBase)
                                {
                                    toolFrm.superTabStrip1.SelectedTab = tab;
                                }
                            }
                        }
                        else if (tabName == EnumHelper.MenuName.送修工具待完成.ToString())
                        {
                            FrmToolRepairedComlete toolFrm = (FrmToolRepairedComlete)item.AttachedControl.Controls[0];
                            foreach (SuperTabItem tab in toolFrm.superTabStrip1.Tabs)
                            {
                                if (tab.Name == dataBase)
                                {
                                    toolFrm.superTabStrip1.SelectedTab = tab;
                                }
                            }
                        }
                        else if (tabName == EnumHelper.MenuName.送修工具领取.ToString())
                        {
                            FrmlPullRepairedTool toolFrm = (FrmlPullRepairedTool)item.AttachedControl.Controls[0];
                            foreach (SuperTabItem tab in toolFrm.superTabStrip1.Tabs)
                            {
                                if (tab.Name == dataBase)
                                {
                                    toolFrm.superTabStrip1.SelectedTab = tab;
                                }
                            }
                        }
                        else if (tabName == EnumHelper.MenuName.送修工具领取.ToString())
                        {
                            FrmScrapToolManageDescribe toolFrm = (FrmScrapToolManageDescribe)item.AttachedControl.Controls[0];
                            foreach (SuperTabItem tab in toolFrm.superTabStrip1.Tabs)
                            {
                                if (tab.Name == dataBase)
                                {
                                    toolFrm.superTabStrip1.SelectedTab = tab;
                                }
                            }
                        }
                        else if (tabName == EnumHelper.MenuName.送修查询.ToString())
                        {
                            FrmRepairScrapQuery toolFrm = (FrmRepairScrapQuery)item.AttachedControl.Controls[0];
                            foreach (SuperTabItem tab in toolFrm.superTabStrip1.Tabs)
                            {
                                if (tab.Name == dataBase)
                                {
                                    toolFrm.superTabStrip1.SelectedTab = tab;
                                }
                            }
                        }
                        superTabControl2.SelectedTab = item;
                        isOpen = true;
                        break;
                    }
                }
                if (!isOpen)
                {
                    ////需要强转
                    DevComponents.DotNetBar.Office2007RibbonForm form = ChildWinManagement.LoadMdiForm(this, formType) as DevComponents.DotNetBar.Office2007RibbonForm;
                    //设置该子窗体不为顶级窗体，否则不能加入到别的控件中form.TopLevel = false;
                    form.Visible = true;
                    //解决textbox里的内容无法被鼠标选中的问题
                    form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    //布满父控件
                    form.Dock = DockStyle.Fill;
                    if (tabName == EnumHelper.MenuName.送修工具接收.ToString())
                    {
                        //设置委托绑定到赋值方法上
                        ((ToolRepairManageNew)form).transfDelegate += setText;
                    }
                    else if (tabName == EnumHelper.MenuName.送修工具待完成.ToString())
                    {
                        //设置委托绑定到赋值方法上
                        ((FrmToolRepairedComlete)form).transfDelegate += setText;
                    }
                    else if (tabName == EnumHelper.MenuName.送修工具领取.ToString())
                    {
                        //设置委托绑定到赋值方法上
                        ((FrmlPullRepairedTool)form).transfDelegate += setText;
                    }
                    else if (tabName == EnumHelper.MenuName.报废工具补充说明.ToString())
                    {
                        //设置委托绑定到赋值方法上
                        ((FrmScrapToolManageDescribe)form).transfDelegate += setText;
                    }
                    else if (tabName == EnumHelper.MenuName.送修查询.ToString())
                    {
                        //设置委托绑定到赋值方法上
                        ((FrmRepairScrapQuery)form).transfDelegate += setText;
                    }
                    //创建一个tab
                    SuperTabItem item = superTabControl2.CreateTab(tabName);
                    //设置显示名和控件名
                    item.Text = tabName;
                    item.Name = tabName;
                    //将子窗体添加到Tab中
                    item.AttachedControl.Controls.Add(form);
                    //选择该子窗体。
                    superTabControl2.SelectedTab = item;
                    if (!tablItemDic.ContainsKey(tabName))
                    {
                        tablItemDic.Add(tabName, form.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FormMain--SetTabShow", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        #region 给动态添加的按钮绑定的事件
        private void Custom_Click(object sender, EventArgs e)
        {
            //SetTabShow(sender.ToString(), ((ButtonItem)sender).Tag.ToString());
            //反射取得子窗体对象。
            object obj = Assembly.GetExecutingAssembly().CreateInstance("toolstrackingsystem." + ((ButtonItem)sender).Tag.ToString(), false);
            SetTabShow(sender.ToString(), obj.GetType());
            i++;
        }
        #endregion
        private void buttonItem7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要注销登录啊?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private void login_buttonItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要注销登录啊?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Current_Time_label.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
        }
        private void applicationButton1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 选择数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Select_buttonItem_Click(object sender, EventArgs e)
        {

            try
            {
                FrmSelectClient FrmClient = new FrmSelectClient();
                if (LoginHelper.UserRole == "ServerRole")
                {
                    FrmClient.ShowDialog();
                    if (FrmClient.DialogResult == DialogResult.OK)
                    {
                        #region 判断cache里是否有设置好的客户端连接字符串
                        if (MemoryCache.Default.Get("clientName") != null)
                        {
                            setText();
                            MessageBox.Show("设置成功");
                        }
                        #endregion
                    }
                }
                else
                {
                    MessageBox.Show("您没有权限选择客户端");
                }
            }
            catch (Exception ex)
            {

                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FormMain--Select_buttonItem_Click", ex.Message, ex.StackTrace, ex.Source);

            }
        }
        private void superTabControl2_TabItemClose(object sender, SuperTabStripTabItemCloseEventArgs e)
        {
            string slectedTab = e.Tab.Text; ;//获取当前TabItem的显示文本
            
            string controlName = null;

            tablItemDic.TryGetValue(slectedTab, out controlName);//获取当前TabItem中内嵌的Form的Name属性值
            var frms = this.superTabControl2.Controls.Find(controlName, true);
            if(frms!=null&&frms.Length>0)
            {
                Form frm = frms[0] as Form;//获取内嵌的Form对象

                frm.Close(); //调用form的close事件，即触发了内嵌窗体的关闭事件
                
            }
            //this.superTabControl2.SelectedPanel.Controls.Find()     
        }
        private void superTabControl2_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
            if (i != 0)
            {
                string dataBase = MemoryCache.Default.Get("clientName") != null ? MemoryCache.Default.Get("clientName").ToString() : CommonHelper.GetConfigValue("defaultDataBase");
                if (this.superTabControl2.SelectedTab.Text == EnumHelper.MenuName.领用工具.ToString())
                {
                    foreach (SuperTabItem item in superTabControl2.Tabs)
                    {
                            if(item.Text == EnumHelper.MenuName.归还工具.ToString())
                            {
                                //关闭归还
                                FrmReturnTool toolFrm = (FrmReturnTool)item.AttachedControl.Controls[0];
                                toolFrm.IsConnect = false;
                                toolFrm.IsListening = false;
                            }
                            if (item.Text == EnumHelper.MenuName.工具包管理.ToString())
                            { 
                                //关闭工具包
                                FrmToolPackManage toolFrm = (FrmToolPackManage)item.AttachedControl.Controls[0];
                                toolFrm.IsConnect = false;
                                toolFrm.IsListening = false;
                            }
                    }
                    if (this.superTabControl2.SelectedTab.AttachedControl.Controls.Count>0)
                    {
                         FrmOutTool frmTool = (FrmOutTool)this.superTabControl2.SelectedTab.AttachedControl.Controls[0];
                         frmTool.IsConnect = true;
                         frmTool.IsListening = true;
                         return;
                    }
                }
                else if (this.superTabControl2.SelectedTab.Text == EnumHelper.MenuName.归还工具.ToString())
                {
                    foreach (SuperTabItem item in superTabControl2.Tabs)
                    {
                        if (item.Text == EnumHelper.MenuName.领用工具.ToString())
                        {
                            //关闭领用
                            FrmOutTool toolFrm = (FrmOutTool)item.AttachedControl.Controls[0];
                            toolFrm.IsConnect = false;
                            toolFrm.IsListening = false;
                        }
                        if (item.Text == EnumHelper.MenuName.工具包管理.ToString())
                        {
                            //关闭工具包
                            FrmToolPackManage toolFrm = (FrmToolPackManage)item.AttachedControl.Controls[0];
                            toolFrm.IsConnect = false;
                            toolFrm.IsListening = false;
                        }
                    }
                    if (this.superTabControl2.SelectedTab.AttachedControl.Controls.Count>0)
                    {
                        FrmReturnTool frmTool = (FrmReturnTool)this.superTabControl2.SelectedTab.AttachedControl.Controls[0];
                        frmTool.IsConnect = true;
                        frmTool.IsListening = true;
                    }
                }
                else if (this.superTabControl2.SelectedTab.Text == EnumHelper.MenuName.工具包管理.ToString())
                {
                    foreach (SuperTabItem item in superTabControl2.Tabs)
                    {
                        if (item.Text == EnumHelper.MenuName.领用工具.ToString())
                        {
                            //关闭领用
                            FrmOutTool toolFrm = (FrmOutTool)item.AttachedControl.Controls[0];
                            toolFrm.IsConnect = false;
                            toolFrm.IsListening = false;
                        }
                        if (item.Text == EnumHelper.MenuName.归还工具.ToString())
                        {
                            //关闭归还
                            FrmReturnTool toolFrm = (FrmReturnTool)item.AttachedControl.Controls[0];
                            toolFrm.IsConnect = false;
                            toolFrm.IsListening = false;
                        }
                    }
                    if (this.superTabControl2.SelectedTab.AttachedControl.Controls.Count > 0)
                    {
                        FrmToolPackManage frmTool = (FrmToolPackManage)this.superTabControl2.SelectedTab.AttachedControl.Controls[0];
                        frmTool.IsConnect = true;
                        frmTool.IsListening = true;
                    }
                }
                else if (this.superTabControl2.SelectedTab.Text == EnumHelper.MenuName.送修工具接收.ToString() && this.superTabControl2.SelectedTab.AttachedControl.Controls.Count > 0)
                {
                    ToolRepairManageNew toolFrm = (ToolRepairManageNew)this.superTabControl2.SelectedTab.AttachedControl.Controls[0];
                    foreach (SuperTabItem tab in toolFrm.superTabStrip1.Tabs)
                    {
                        if (tab.Name == dataBase)
                        {
                            toolFrm.superTabStrip1.SelectedTab = tab;
                        }
                    }
                }
                else if (this.superTabControl2.SelectedTab.Text == EnumHelper.MenuName.送修工具待完成.ToString() && this.superTabControl2.SelectedTab.AttachedControl.Controls.Count > 0)
                {
                    FrmToolRepairedComlete toolFrm = (FrmToolRepairedComlete)this.superTabControl2.SelectedTab.AttachedControl.Controls[0];
                    foreach (SuperTabItem tab in toolFrm.superTabStrip1.Tabs)
                    {
                        if (tab.Name == dataBase)
                        {
                            toolFrm.superTabStrip1.SelectedTab = tab;
                        }
                    }
                }
                else if (this.superTabControl2.SelectedTab.Text == EnumHelper.MenuName.送修工具领取.ToString() && this.superTabControl2.SelectedTab.AttachedControl.Controls.Count > 0)
                {
                    FrmlPullRepairedTool toolFrm = (FrmlPullRepairedTool)this.superTabControl2.SelectedTab.AttachedControl.Controls[0];
                    foreach (SuperTabItem tab in toolFrm.superTabStrip1.Tabs)
                    {
                        if (tab.Name == dataBase)
                        {
                            toolFrm.superTabStrip1.SelectedTab = tab;
                        }
                    }
                }
                else if (this.superTabControl2.SelectedTab.Text == EnumHelper.MenuName.报废工具补充说明.ToString() && this.superTabControl2.SelectedTab.AttachedControl.Controls.Count > 0)
                {
                    FrmScrapToolManageDescribe toolFrm = (FrmScrapToolManageDescribe)this.superTabControl2.SelectedTab.AttachedControl.Controls[0];
                    foreach (SuperTabItem tab in toolFrm.superTabStrip1.Tabs)
                    {
                        if (tab.Name == dataBase)
                        {
                            toolFrm.superTabStrip1.SelectedTab = tab;
                        }
                    }
                }
                else
                {
                    foreach (SuperTabItem item in superTabControl2.Tabs)
                    {
                        if (item.Text == EnumHelper.MenuName.领用工具.ToString())
                        {
                            //关闭领用
                            FrmOutTool toolFrm = (FrmOutTool)item.AttachedControl.Controls[0];
                            toolFrm.IsConnect = false;
                            toolFrm.IsListening = false;
                        }
                        if (item.Text == EnumHelper.MenuName.归还工具.ToString())
                        {
                            //关闭归还
                            FrmReturnTool toolFrm = (FrmReturnTool)item.AttachedControl.Controls[0];
                            toolFrm.IsConnect = false;
                            toolFrm.IsListening = false;
                        }
                        if (item.Text == EnumHelper.MenuName.工具包管理.ToString())
                        {
                            //关闭工具包管理
                            FrmToolPackManage toolFrm = (FrmToolPackManage)item.AttachedControl.Controls[0];
                            toolFrm.IsConnect = false;
                            toolFrm.IsListening = false;
                        }
                    }
                }
            }

        }
        private void setText()
        {
            string connName = MemoryCache.Default.Get("clientName").ToString();
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings[connName].ConnectionString;
            string ip = connStr.Split(';')[0].Split('=')[1].ToString();
            string dataBase = MemoryCache.Default.Get("clientName").ToString();
            int value = (int)Enum.Parse(typeof(EnumHelper.DataBaseType), dataBase);
            dataBase = Enum.GetName(typeof(EnumHelper.DataBaseName), value);
            string txtStr = "连接到服务器：" + ip + " 当前数据库：" + dataBase;
            Message_label.Text = txtStr;
        }
    }
}
