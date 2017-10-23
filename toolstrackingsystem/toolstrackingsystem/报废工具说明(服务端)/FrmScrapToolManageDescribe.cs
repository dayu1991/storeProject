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
using service.toolstrackingsystem;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using log4net;
using dbentity.toolstrackingsystem;
using System.Runtime.Caching;
using ViewEntity.toolstrackingsystem;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using common.toolstrackingsystem;

namespace toolstrackingsystem
{
    public partial class FrmScrapToolManageDescribe : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FrmScrapToolManageDescribe));
        public IToolRepairRecordService _toolRepairRecordService;
        public IToolInfoService _toolInfoService;
        public string dataBase = MemoryCache.Default.Get("clientName") != null ? MemoryCache.Default.Get("clientName").ToString() : CommonHelper.GetConfigValue("defaultDataBase");
        List<ToolScrapedEntity> resultList = new List<ToolScrapedEntity>();
        public event TransfDelegate transfDelegate;
        public FrmScrapToolManageDescribe()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void FrmScrapToolManage_Load(object sender, EventArgs e)
        {
            _toolInfoService = Program.container.Resolve<IToolInfoService>();
            _toolRepairRecordService = Program.container.Resolve<ToolRepairRecordService>();
            #region 初始化配属，类别combox
            var categorys = _toolInfoService.GetCategoryByClassify(0);
            var categoryBlongs = categorys.Where(v => v.classification == 1).Any() ? categorys.Where(v => v.classification == 1).ToList() : new List<t_ToolType>();
            var blongs = new List<t_ToolType>();
            blongs.Add(new t_ToolType
            {
                TypeName = "全部"

            });
            blongs.AddRange(categoryBlongs);
            var categoryCategory = categorys.Where(v => v.classification == 2).Any() ? categorys.Where(v => v.classification == 2).ToList() : new List<t_ToolType>();
            var cates = new List<t_ToolType>();
            cates.Add(new t_ToolType
            {

                TypeName = "全部"

            });
            cates.AddRange(categoryCategory);
            this.cbSearchBlong.DataSource = blongs;
            this.cbSearchBlong.DisplayMember = "TypeName";
            this.cbSearchBlong.ValueMember = "TypeName";

            this.cbSearchcategory.DataSource = cates;
            this.cbSearchcategory.DisplayMember = "TypeName";
            this.cbSearchcategory.ValueMember = "TypeName";
            #endregion

            #region 初始化supertab默认选择的数据库
            foreach (SuperTabItem tab in superTabStrip1.Tabs)
            {
                if (tab.Name == dataBase)
                {
                    superTabStrip1.SelectedTab = tab;
                }
            }
            #endregion
        }
        private void ToolInfo_dataGridView_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {

        }
        private void ToolInfo_dataGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1); 
        }

        private void ToolInfo_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ScrapTool_dataGridViewX2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        private void tool_RepairdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Search_buttonX_Click(object sender, EventArgs e)
        {
            try
            {
                t_ToolRepairRecord repairInfo = new t_ToolRepairRecord();
                repairInfo.TypeName = cbSearchBlong.SelectedValue.ToString() != "全部" ? cbSearchBlong.SelectedValue.ToString() : "";
                repairInfo.ChildTypeName = cbSearchcategory.SelectedValue.ToString() != "全部" ? cbSearchcategory.SelectedValue.ToString() : "";
                repairInfo.ToolCode = tbSearchCode.Text;
                repairInfo.ToolName = tbSearchName.Text;
                repairInfo.ToolStatus = ToolStatusResultEntity.IsScraped;
                resultList = _toolRepairRecordService.GetRepairedToolRorScrap(repairInfo);
                for (int i = 0; i < tool_RepairdataGridView.Columns.Count; i++)
                {
                    tool_RepairdataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
                tool_RepairdataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                tool_RepairdataGridView.DataSource = resultList;

                tool_RepairdataGridView.Columns[0].HeaderText = "ID";
                tool_RepairdataGridView.Columns[0].Visible = false;
                tool_RepairdataGridView.Columns[1].HeaderText = "配属";
                tool_RepairdataGridView.Columns[2].HeaderText = "类别";
                tool_RepairdataGridView.Columns[3].HeaderText = "工具编码";
                tool_RepairdataGridView.Columns[4].HeaderText = "工具名称";
                tool_RepairdataGridView.Columns[5].HeaderText = "送修时间";
                tool_RepairdataGridView.Columns[6].HeaderText = "送修人员";
                tool_RepairdataGridView.Columns[7].HeaderText = "送修备注";
                tool_RepairdataGridView.Columns[8].HeaderText = "报废时间";
                tool_RepairdataGridView.Columns[9].HeaderText = "报废人员";
                tool_RepairdataGridView.Columns[10].HeaderText = "报废备注";
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "FrmScrapToolManageDescribe--Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void tool_RepairdataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int id = Convert.ToInt32(tool_RepairdataGridView.Rows[e.RowIndex].Cells[0].Value);
                    t_ToolRepairRecord entity = new t_ToolRepairRecord();
                    entity = _toolRepairRecordService.GetToolRepairByToolCodeById(id);
                    if (entity == null)
                    {
                        MessageBox.Show("工具查询失败，请重新选择");
                        return;
                    }
                    FrmAddRemarkForScrapedTool toolFrm = new FrmAddRemarkForScrapedTool();
                    toolFrm.Tag = entity;
                    toolFrm.ShowDialog();
                    if (toolFrm.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        Search_buttonX_Click(sender,e);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "FrmScrapToolManageDescribe--tool_RepairdataGridView_CellContentDoubleClick", ex.Message, ex.StackTrace, ex.Source);
            }
        }

        private void superTabStrip1_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
            try
            {
                string name = e.NewValue.Name;
                if (MemoryCacheHelper.SetMemoryCache(name))
                {
                    //1.刷新datagridview页面
                    Search_buttonX_Click(sender, e);
                    //2.更新显示数据库名称
                    transfDelegate();
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "FrmScrapToolManageDescribe--superTabStrip1_SelectedTabChanged", ex.Message, ex.StackTrace, ex.Source);
            }
            
        }
    }
}
