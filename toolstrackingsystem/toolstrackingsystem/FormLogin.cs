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
using common.toolstrackingsystem;

namespace toolstrackingsystem
{
    public partial class FormLogin : Office2007Form
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FormLogin));
        private IUserManageService _userManageService;
        private IAddressInfoService _addressInfoService;
        private IPersonManageService _personManageService;
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
            if (!scan_checkBox.Checked&&string.IsNullOrEmpty(Pass))
            {
                MessageBox.Show("密码不能为空");
                return;
            }
            try
            { 
                //登录成功后，登录窗体关闭，主窗体打开
                Sys_User_Info userInfo = new Sys_User_Info();
                if (!scan_checkBox.Checked)
                {
                    userInfo = _userManageService.GetUserInfo(UserCode, Pass);
                }
                else {
                    t_PersonInfo personInfo = new t_PersonInfo();
                    personInfo = _personManageService.GetPersonInfo(UserCode);
                    if (personInfo == null)
                    {
                        MessageBox.Show("用户名不存在");
                        return;
                    }
                    userInfo.UserCode = personInfo.PersonCode;
                    userInfo.UserName = personInfo.PersonName;
                    userInfo.UserRole = "SuperAuthority";
                    userInfo.IsActive = 1;
                }
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
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "FormLogin--LoginButton_Click", ex.Message, ex.StackTrace, ex.Source);
                
            }
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.styleManager1.ManagerStyle = eStyle.OfficeMobile2014;
            _userManageService = Program.container.Resolve<IUserManageService>() as UserManageService;
            _addressInfoService = Program.container.Resolve<IAddressInfoService>() as AddressInfoService;
            _personManageService = Program.container.Resolve<IPersonManageService>() as PersonManageService;
            #region 判断客户端是否注册过
            //string mac = CommonHelper.GetMacAddress();
            //if (string.IsNullOrEmpty(mac))
            //{
            //    MessageBox.Show("获取mac地址失败，请检查您的网络设备！");
            //    Application.Exit();
            //}
            //mac = mac.Replace(":", "-");
            //if (_addressInfoService.GetAddressInfoByMac(mac) == null)
            //{
            //    MessageBox.Show("该客户端尚未注册，请联系管理员！");
            //    Application.Exit();
            //}
            //string encode = CommonHelper.GetMd5(CommonHelper.GetMd5(mac));
            //if (!_addressInfoService.IsExistAddress(encode))
            //{
            //    MessageBox.Show("该客户端注册秘钥不正确，请联系管理员！");
            //    Application.Exit();
            //}
            #endregion
        }
        private void ResetButton_Click(object sender, EventArgs e)
        {
            textBox_UserName.Text="";
            textBox_PassWord.Text="";
        }
        private void textBox_UserName_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox_UserName_MouseLeave(object sender, EventArgs e)
        {


        }
        private void textBox_UserName_Leave(object sender, EventArgs e)
        {
            try
            {
                string UserCode = textBox_UserName.Text;
                if (scan_checkBox.Checked && !string.IsNullOrEmpty(UserCode))
                {
                    t_PersonInfo personInfo = new t_PersonInfo();
                    personInfo = _personManageService.GetPersonInfo(UserCode);
                    if (personInfo == null)
                    {
                        MessageBox.Show("用户名不存在");
                        return;
                    }
                    Sys_User_Info userInfo = new Sys_User_Info();
                    userInfo.UserCode = personInfo.PersonCode;
                    userInfo.UserName = personInfo.PersonName;
                    userInfo.UserRole = "scanRole";
                    userInfo.IsActive = 1;
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
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "FormLogin--textBox_UserName_TextChanged", ex.Message, ex.StackTrace, ex.Source);
            }
        }

        private void textBox_UserName_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                string UserCode = textBox_UserName.Text;
                if (scan_checkBox.Checked && !string.IsNullOrEmpty(UserCode)&&UserCode.Contains("BJ"))
                {
                    t_PersonInfo personInfo = new t_PersonInfo();
                    personInfo = _personManageService.GetPersonInfo(UserCode);
                    if (personInfo == null)
                    {
                        MessageBox.Show("用户名不存在");
                        return;
                    }
                    Sys_User_Info userInfo = new Sys_User_Info();
                    userInfo.UserCode = personInfo.PersonCode;
                    userInfo.UserName = personInfo.PersonName;
                    userInfo.UserRole = "scanRole";
                    userInfo.IsActive = 1;
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
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "FormLogin--textBox_UserName_TextChanged", ex.Message, ex.StackTrace, ex.Source);
            }
        }
    }
}
