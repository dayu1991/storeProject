﻿using System;
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

namespace toolstrackingsystem
{
    public partial class FormMain : Office2007RibbonForm
    {
        private Sys_User_Info userInfo = MemoryCache.Default.Get("userinfo") as Sys_User_Info;
        private IRoleManageService _roleManageService;
        private IMenuManageService _menuManageService;
        public FormMain()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void FormTest_Load(object sender, EventArgs e)
        {
            //修改界面默认显示颜色
            this.styleManager1.ManagerStyle = eStyle.Office2010Silver;
            //默认清空所有的tab页
            SuperTabControl superTabControl = new SuperTabControl();
            superTabControl.Tabs.Clear();
            //获取用户信息
            Sys_User_Info userInfo = MemoryCache.Default.Get("userinfo") as Sys_User_Info;
            ribbonControl1.TitleText = "北京动车段工具管理应用系统v1.1[" + userInfo.UserName + "]";
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

            //获取用户角色权限
            _roleManageService = Program.container.Resolve<IRoleManageService>() as RoleManageService;
            _menuManageService = Program.container.Resolve<IMenuManageService>() as MenuManageService;
            Sys_User_Role roleInfo = _roleManageService.GetRoleInfo(userInfo.UserRole);
            
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
                    btnToolNew.Icon = new Icon("../../image/"+childitem.MenuICON+".ico");
                    btnToolNew.ImagePosition = eImagePosition.Top;
                    btnToolNew.Click += new EventHandler(Custom_Click);
                    btnToolNew.Tag = childitem.FileName;
                    rbNew.Items.Add(btnToolNew);
                }
                rpanelNew.Controls.Add(rbNew);
            }

            label_login_user.Text = userInfo.UserName;
            //timer启动
            this.timer1.Start();
            //判断连接服务器IP
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MPConnection"].ConnectionString;
            string ip = connStr.Split(';')[0].Split('=')[1].ToString();
            Message_label.Text = "连接到服务器" + ip;
        }
        private void SetTabShow(string tabName, string sfrmName)
        {
            bool isOpen = false;
            foreach (SuperTabItem item in superTabControl2.Tabs)
            {
                //已打开
                if (item.Name == tabName)
                {
                    superTabControl2.SelectedTab = item;
                    isOpen = true;
                    break;
                }
            }
            if (!isOpen)
            {
                //反射取得子窗体对象。
                object obj = Assembly.GetExecutingAssembly().CreateInstance("toolstrackingsystem." + sfrmName, false);
                //需要强转
                Form form = (Form)obj;
                //设置该子窗体不为顶级窗体，否则不能加入到别的控件中
                form.TopLevel = false;
                form.Visible = true;
                //布满父控件
                //form.Dock = DockStyle.Fill;
                //创建一个tab
                SuperTabItem item = superTabControl2.CreateTab(tabName);
                //设置显示名和控件名
                item.Text = tabName;
                item.Name = tabName;
                //将子窗体添加到Tab中
                item.AttachedControl.Controls.Add(form);
                //选择该子窗体。
                superTabControl2.SelectedTab = item;
            }
        }
        private void ToolInfo_Click(object sender, EventArgs e)
        {
            SetTabShow("常规工具", "ToolInfoManage");
        }
        private void FrmPerson(object sender, EventArgs e)
        {
            SetTabShow("常规工具", "ToolInfoManage");
        }
        #region 给动态添加的按钮绑定的事件
        private void Custom_Click(object sender, EventArgs e)
        {
            SetTabShow(sender.ToString(), ((ButtonItem)sender).Tag.ToString());
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
    }
}
