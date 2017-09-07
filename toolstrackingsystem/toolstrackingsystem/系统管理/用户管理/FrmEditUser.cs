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
using ViewEntity.toolstrackingsystem;
using dbentity.toolstrackingsystem;
using service.toolstrackingsystem;
using log4net;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace toolstrackingsystem
{
    public partial class FrmEditUser : Office2007Form
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FrmEditUser));
        private IRoleManageService _roleManageService;
        private IUserManageService _userManageService;
        public FrmEditUser()
        {
            InitializeComponent();
        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void FrmEditUser_Load(object sender, EventArgs e)
        {
            _roleManageService = Program.container.Resolve<IRoleManageService>() as RoleManageService;
            _userManageService = Program.container.Resolve<IUserManageService>() as UserManageService;
            #region 初始化角色combox
            try
            {
                List<Sys_User_Role> roleInfoList = _roleManageService.GetRoleInfoList();
                this.role_comboBox.DataSource = roleInfoList;
                this.role_comboBox.DisplayMember = "RoleName";
                this.role_comboBox.ValueMember = "RoleCode";
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmEditUser", ex.Message, ex.StackTrace, ex.Source);
            }
            #endregion
            Sys_User_Info userInfo = (Sys_User_Info)this.Tag;
            UserCode_textBox.Text = userInfo.UserCode;
            userInfo = _userManageService.GetUserInfo(userInfo.UserCode);
            UserName_textBox.Text = userInfo.UserName;
            Description_textBox.Text = userInfo.Description;
            role_comboBox.SelectedText = "";
            role_comboBox.SelectedValue = userInfo.UserRole;

        }
        /// <summary>
        /// 保存修改信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Edit_button_Click(object sender, EventArgs e)
        {
            Sys_User_Info userInfo = new Sys_User_Info();
            userInfo.UserCode = UserCode_textBox.Text;
            userInfo.UserName = UserName_textBox.Text;
            userInfo.Description = Description_textBox.Text;
            userInfo.PassWord = Password_textBox.Text;
            userInfo.UserRole = role_comboBox.SelectedValue.ToString();
            if (_userManageService.UpdateUserInfo(userInfo))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Dispose();
            }
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
