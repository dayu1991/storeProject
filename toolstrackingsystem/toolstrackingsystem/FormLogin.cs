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
using service.toolstrackingsystem;
using System.Runtime.Caching;
using Microsoft.Practices.Unity;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;
using log4net;

namespace toolstrackingsystem
{
    public partial class FormLogin : Office2007Form
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FormLogin));
        private IUserManageService _userManageService;
        public FormLogin()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string UserCode = textBox_UserName.Text;
            string Pass = textBox_PassWord.Text;
            if (string.IsNullOrEmpty(UserCode))
            {
                MessageBox.Show("用户名不能为空");
                return;
            }

            if (string.IsNullOrEmpty(Pass))
            {
                MessageBox.Show("密码不能为空");
                return;
            }
            try
            { 
                //登录成功后，登录窗体关闭，主窗体打开
                Sys_User_Info userInfo = new Sys_User_Info();
                userInfo = _userManageService.GetUserInfo(UserCode, Pass);
                if (userInfo != null)
                {
                    ObjectCache oCache = MemoryCache.Default;
                    Sys_User_Info fileContents = oCache["userinfo"] as Sys_User_Info;
                    if (fileContents == null)
                    {
                        CacheItemPolicy policy = new CacheItemPolicy();
                        //policy.AbsoluteExpiration = DateTime.Now.AddMinutes(120);//取得或设定值，这个值会指定是否应该在指定期间过后清除
                        fileContents = userInfo; //这里赋值;
                        oCache.Set("userinfo", fileContents, policy);
                    }
                    this.DialogResult = DialogResult.OK;
                    //MemoryCache.Default.Set("userinfo",userInfo);
                    this.Tag = UserCode;
                }
                else
                {
                    MessageBox.Show("用户名或密码错误");
                }
            }
            catch(Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FormLogin", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.styleManager1.ManagerStyle = eStyle.Office2010Blue;
            _userManageService = Program.container.Resolve<IUserManageService>() as UserManageService;

        }
    }
}
