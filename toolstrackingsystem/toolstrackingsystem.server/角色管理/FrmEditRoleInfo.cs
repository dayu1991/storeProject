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
using dbentity.toolstrackingsystem;
using ViewEntity.toolstrackingsystem;

namespace toolstrackingsystem.server
{
    public partial class FrmEditRoleInfo : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FormLogin));
        private IRoleManageService _roleManageService;
        private int selectIndex = 0;
        public FrmEditRoleInfo()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void RrmEditRoleInfo_Load(object sender, EventArgs e)
        {
            _roleManageService = Program.container.Resolve<IRoleManageService>() as RoleManageService;
        }
        private void Search_buttonX_Click(object sender, EventArgs e)
        {
            try
            {
                string roleCode = RoleCode_textBox.Text;
                string roleName = RoleName_textBox.Text;
                List<RoleInfoEntity> roleInfoList = _roleManageService.GetRoleInfoList(roleCode,roleName);
                RoleList_dataGridViewX.DataSource = roleInfoList;
                for (int i = 0; i < RoleList_dataGridViewX.Columns.Count; i++)
                {
                    RoleList_dataGridViewX.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
                RoleList_dataGridViewX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                RoleList_dataGridViewX.Columns[0].HeaderText = "角色代码";
                RoleList_dataGridViewX.Columns[1].HeaderText = "角色名称";
                RoleList_dataGridViewX.Columns[2].HeaderText = "角色MenuID";
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--RrmEditRoleInfo--Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_buttonX_Click(object sender, EventArgs e)
        {
            Sys_User_Role roleInfo = new Sys_User_Role();
            roleInfo.RoleCode = RoleCode_Detail_textBox.Text;
            roleInfo.RoleName = RoleName_Detail_textBox.Text;
            if (string.IsNullOrEmpty(roleInfo.RoleCode))
            {
                MessageBox.Show("角色代码不能为空");
                RoleCode_Detail_textBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(roleInfo.RoleName))
            {
                MessageBox.Show("角色名称不能为空");
                RoleName_Detail_textBox.Focus();
                return;
            }
            MenuInfoTree menuTree = new MenuInfoTree();
            menuTree.Tag = roleInfo;
            menuTree.ShowDialog();
            if (menuTree.DialogResult == DialogResult.OK)
            {
                Search_buttonX_Click(sender,e);
                RoleCode_Detail_textBox.Text = "";
                RoleName_Detail_textBox.Text = "";
            }
        }
        private void Edit_buttonX_Click(object sender, EventArgs e)
        {
            string roleCode = this.Tag.ToString();
            FrmEditRole frmeditRole = new FrmEditRole();
            frmeditRole.Tag = roleCode;
            frmeditRole.ShowDialog();
            if (frmeditRole.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                Search_buttonX_Click(sender,e);
            }
        }
        private void RoleList_dataGridViewX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectIndex = e.RowIndex;
            string roleCode = RoleList_dataGridViewX.Rows[selectIndex].Cells[0].Value.ToString();
            this.Tag = roleCode;
        }
        private void Delete_buttonX_Click(object sender, EventArgs e)
        {
            string roleCode = this.Tag.ToString();
            if (string.IsNullOrEmpty(roleCode))
            {
                MessageBox.Show("请选择一行数据进行操作");
                return;
            }
            if(MessageBox.Show("您确定要删除“" + roleCode + "”吗?", "询问", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if(_roleManageService.DeleteRoleInfo(roleCode))
                {
                    MessageBox.Show("删除成功");
                    Search_buttonX_Click(sender,e);
                }
            }
        }

        private void RoleList_dataGridViewX_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void RoleList_dataGridViewX_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}
