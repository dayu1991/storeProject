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

namespace toolstrackingsystem
{
    public partial class FormMain : Office2007RibbonForm
    {
        private Sys_User_Info userInfo = MemoryCache.Default.Get("userinfo") as Sys_User_Info;
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
            label_login_user.Text = userInfo.UserName;
            #region 手动添加菜单项test
            RibbonTabItem tabItem = new RibbonTabItem();
            tabItem.Text = "基础数据";
            RibbonPanel rpanel = new RibbonPanel();
            rpanel.Dock = DockStyle.Fill;
            tabItem.Panel = rpanel;
            ribbonControl1.Controls.Add(rpanel);
            ribbonControl1.TitleText = "北京动车段工具管理应用系统v1.1[" + userInfo.UserName + "]";
            this.ribbonControl1.Items.Add(tabItem);
            RibbonBar rb = new RibbonBar();

            ButtonItem bi = new ButtonItem("bi");
            bi.Text = "用户管理";
            string path = "../../image/manage.ico";
            bi.Icon = new Icon(path);
            bi.ImagePosition = eImagePosition.Top;
            bi.Click += new EventHandler(button_suppliers_Click);
            rb.Items.Add(bi);
            rpanel.Controls.Add(rb);
            #endregion


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
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            SetTabShow("添加用户", "FormAddUsers");
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
            SetTabShow("查看用户", "FormEditUsers");
        }

        private void button_ClientFiles_Click(object sender, EventArgs e)
        {
            SetTabShow("客户档案", "FormClientFiles");
        }

        private void button_suppliers_Click(object sender, EventArgs e)
        {
            SetTabShow("客户管理", "frmEditUserinfo");
        }
    }
}
