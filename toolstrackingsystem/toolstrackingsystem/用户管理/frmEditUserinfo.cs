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
using log4net;
using service.toolstrackingsystem;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using ViewEntity.toolstrackingsystem;
using dbentity.toolstrackingsystem;

namespace toolstrackingsystem
{
    public partial class frmEditUserinfo : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FormLogin));
        private IUserManageService _userManageService;
        private IRoleManageService _roleManageService;
        private int selectIndex = 0;
        public frmEditUserinfo()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void frmEditUserinfo_Load(object sender, EventArgs e)
        {
            _userManageService = Program.container.Resolve<IUserManageService>() as UserManageService;
            _roleManageService = Program.container.Resolve<IRoleManageService>() as RoleManageService;
            #region 初始化combox角色下拉框
            try
            {
                List<Sys_User_Role> roleInfoList = _roleManageService.GetRoleInfoList();
                this.Rolelist_comboBox.DataSource = roleInfoList;
                this.Rolelist_comboBox.DisplayMember = "RoleName";
                this.Rolelist_comboBox.ValueMember = "RoleCode";
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmEditUser", ex.Message, ex.StackTrace, ex.Source);
            }
            #endregion
        }
        //查找用户
        private void Search_buttonX_Click(object sender, EventArgs e)
        {
            try
            {
                string UserCode = UserCode_textBox.Text;
                string UserName = UserName_textBox.Text;

                List<UserInfoEntity> resultEntity = _userManageService.GetUserInfo(UserCode, UserName, 1);

                UserList_dataGridViewX.DataSource = resultEntity;
                for (int i = 0; i < UserList_dataGridViewX.Columns.Count; i++)
                {
                    UserList_dataGridViewX.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
                UserList_dataGridViewX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                UserList_dataGridViewX.Columns[0].HeaderText = "用户编号";
                UserList_dataGridViewX.Columns[1].HeaderText = "用户名称";
                UserList_dataGridViewX.Columns[2].HeaderText = "用户角色";
                UserList_dataGridViewX.Columns[3].HeaderText = "是否有效";
                UserList_dataGridViewX.Columns[4].HeaderText = "说明";
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--frmEditUserinfo--Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void UserList_dataGridViewX_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);  
        }

        private void UserList_dataGridViewX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectIndex = e.RowIndex;
            Sys_User_Info userInfo = new Sys_User_Info();

            userInfo.UserCode = UserList_dataGridViewX.Rows[selectIndex].Cells[0].Value.ToString();
            userInfo.UserName = UserList_dataGridViewX.Rows[selectIndex].Cells[1].Value.ToString();
            userInfo.UserRole = UserList_dataGridViewX.Rows[selectIndex].Cells[2].Value.ToString();
            userInfo.IsActive = UserList_dataGridViewX.Rows[selectIndex].Cells[3].Value.ToString() == "是" ? 1 : 0;
            userInfo.Description = UserList_dataGridViewX.Rows[selectIndex].Cells[4].Value == null ? "" : UserList_dataGridViewX.Rows[selectIndex].Cells[4].Value.ToString();
            userInfo = _userManageService.GetUserInfo(UserList_dataGridViewX.Rows[selectIndex].Cells[0].Value.ToString());
            this.Tag = userInfo;
        }
        /// <summary>
        /// 单击修改用户信息事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edit_buttonX_Click(object sender, EventArgs e)
        {

            try
            {
                Sys_User_Info userInfo = (Sys_User_Info)this.Tag;
                if (userInfo != null)
                {
                    FrmEditUser formEditUser = new FrmEditUser();
                    formEditUser.Tag = userInfo;
                    formEditUser.ShowDialog();
                    if (formEditUser.DialogResult == DialogResult.OK)
                    {
                        Search_buttonX_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("请选中一个用户");
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--frmEditUserinfo--Edit_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void Delete_buttonX_Click(object sender, EventArgs e)
        {
            Sys_User_Info userInfo = (Sys_User_Info)this.Tag;
            try
            {
                if (MessageBox.Show("您确定要删除“" + userInfo.UserName + "”吗?", "询问", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (userInfo.UserCode == "admin")
                    {
                        MessageBox.Show("超级管理员不能删除!");
                        return;
                    }
                    if (_userManageService.DeleteUser(userInfo))
                    {
                        Search_buttonX_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--frmEditUserinfo--Delete_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }

        private void Add_buttonX_Click(object sender, EventArgs e)
        {
            try
            {
                Sys_User_Info userInfo = new Sys_User_Info();
                userInfo.UserCode = UserCode_Detail_textBox.Text;
                userInfo.UserName = UserName_Detail_textBox.Text;
                userInfo.UserRole = Rolelist_comboBox.SelectedValue.ToString();
                userInfo.PassWord = Password_detail_textBox.Text;
                userInfo.Description = description_detail_textBox.Text;
                if (string.IsNullOrEmpty(userInfo.UserCode))
                {
                    MessageBox.Show("用户名不能为空");
                    UserCode_Detail_textBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(userInfo.UserName))
                {
                    MessageBox.Show("用户名称不能为空");
                    UserName_Detail_textBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(userInfo.UserRole))
                {
                    MessageBox.Show("用户角色不能为空");
                    Rolelist_comboBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(userInfo.PassWord))
                {
                    MessageBox.Show("用户密码不能为空");
                    Password_detail_textBox.Focus();
                    return;
                }
                if (_userManageService.GetUserInfo(userInfo.UserCode) != null)
                {
                    MessageBox.Show("用户名“"+userInfo.UserCode+"”已存在，请重新输入");
                    UserCode_Detail_textBox.Focus();
                    return;
                }
                userInfo.CreateTime = DateTime.Now;
                if (_userManageService.InsertUserInfo(userInfo))
                {
                    MessageBox.Show("添加成功");
                    Search_buttonX_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--frmEditUserinfo--Add_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
    }
}
