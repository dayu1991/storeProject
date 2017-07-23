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
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using service.toolstrackingsystem;
using log4net;
using dbentity.toolstrackingsystem;
using ViewEntity.toolstrackingsystem;

namespace toolstrackingsystem
{
    public partial class FrmToolPackManage:Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(frmEditUserinfo));
        public IToolPackManageService _toolPackManageService;
        private List<ToolInfoForPackEntity> resultEntity = new List<ToolInfoForPackEntity>();
        public FrmToolPackManage()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void FrmToolPackManage_Load(object sender, EventArgs e)
        {
            _toolPackManageService = Program.container.Resolve<IToolPackManageService>() as ToolPackManageService;
            #region 初始化combox角色下拉框
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("name");
                dt.Columns.Add("value");
                DataRow dr = dt.NewRow();

                dr[0] = "通用工具包";

                dr[1] = "1";

                dt.Rows.Add(dr); 

                this.type_comboBox.DataSource = dt;

                this.type_comboBox.DisplayMember = "name";

                this.type_comboBox.ValueMember = "value";

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmEditUser", ex.Message, ex.StackTrace, ex.Source);
            }
            #endregion
        }
        private void Search_buttonX_Click(object sender, EventArgs e)
        {
            try
            {
                t_ToolInfo toolInfo = new t_ToolInfo();
                toolInfo.PackCode = Pack_Code_textBox.Text;
                toolInfo.PackName = Pack_Name_textBox.Text;
                if (string.IsNullOrEmpty(toolInfo.PackName) && string.IsNullOrEmpty(toolInfo.PackCode))
                {
                    MessageBox.Show("包编码和包名称至少一个不为空");
                    Pack_Code_textBox.Focus();
                    return;
                }
                resultEntity = new List<ToolInfoForPackEntity>();
                resultEntity = _toolPackManageService.GetToolInfoForPack(toolInfo);
                ToolInfoList_dataGridViewX.DataSource = resultEntity;
                for (int i = 0; i < ToolInfoList_dataGridViewX.Columns.Count; i++)
                {
                    ToolInfoList_dataGridViewX.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
                ToolInfoList_dataGridViewX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                ToolInfoList_dataGridViewX.Columns[0].HeaderText = "工具配属";
                ToolInfoList_dataGridViewX.Columns[1].HeaderText = "工具类别";
                ToolInfoList_dataGridViewX.Columns[2].HeaderText = "编码";
                ToolInfoList_dataGridViewX.Columns[3].HeaderText = "名称";
                ToolInfoList_dataGridViewX.Columns[4].HeaderText = "型号";
                ToolInfoList_dataGridViewX.Columns[5].HeaderText = "位置";
                ToolInfoList_dataGridViewX.Columns[6].HeaderText = "备注";
                
                //foreach (var item in resultEntity)
                //{
                //    ToolInfoList_dataGridViewX.Rows.Add(item.ToolBelongName, item.ToolCategoryName, item.ToolCode, item.ToolName, item.ToolModels, item.Location, item.ToolRemarks);
                //}
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmToolPackManage--Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void ToolInfoList_dataGridViewX_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1); 
        }
        private void Add_button_Click(object sender, EventArgs e)
        {
            try
            {
                string toolCode = ToolInfoCode_Detail_textBox.Text;
                if (string.IsNullOrEmpty(toolCode))
                {
                    MessageBox.Show("工具编码不能为空");
                    ToolInfoCode_Detail_textBox.Focus();
                    return;
                }
                t_ToolInfo toolInfo = new t_ToolInfo();
                toolInfo = _toolPackManageService.GetToolInfoByToolCode(toolCode);
                if (toolInfo == null)
                {
                    MessageBox.Show("工具不存在，请输入正确的工具编码");
                    ToolInfoCode_Detail_textBox.Focus();
                    return;
                }
                ToolInfoForPackEntity result = new ToolInfoForPackEntity();
                result.ToolBelongName = toolInfo.ToolBelongName;
                result.ToolCategoryName = toolInfo.ToolCategoryName;
                result.ToolCode = toolInfo.ToolCode;
                result.ToolName = toolInfo.ToolName;
                result.ToolModels = toolInfo.ToolModels;
                result.ToolRemarks = toolInfo.ToolRemarks;
                result.Location = toolInfo.Location;
                resultEntity.Add(result);
                ToolInfoList_dataGridViewX.Rows.Clear();
                //return;
                ToolInfoList_dataGridViewX.DataSource=null;
                for (int i = 0; i < ToolInfoList_dataGridViewX.Columns.Count; i++)
                {
                    ToolInfoList_dataGridViewX.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
                ToolInfoList_dataGridViewX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex) {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmToolPackManage--Add_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
    }
}
