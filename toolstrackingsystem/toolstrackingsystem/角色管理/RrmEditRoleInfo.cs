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

namespace toolstrackingsystem
{
    public partial class RrmEditRoleInfo : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FormLogin));
        private IRoleManageService _roleManageService;
        public RrmEditRoleInfo()
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
                RoleList_dataGridViewX.Columns[0].HeaderText = "序号";
                RoleList_dataGridViewX.Columns[1].HeaderText = "角色代码";
                RoleList_dataGridViewX.Columns[2].HeaderText = "角色名称";
                RoleList_dataGridViewX.Columns[2].HeaderText = "角色MenuID";
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--RrmEditRoleInfo--Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
    }
}
