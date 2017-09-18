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
using System.Runtime.Caching;
using ViewEntity.toolstrackingsystem;
using common.toolstrackingsystem;
using dbentity.toolstrackingsystem;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace toolstrackingsystem
{
    public partial class FrmToolRepairedComlete : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(ToolRepairManageNew));
        public IToolRepairRecordService _toolRepairRecordService;
        public IToolInfoService _toolInfoService;
        public string dataBase = MemoryCache.Default.Get("clientName") != null ? MemoryCache.Default.Get("clientName").ToString() : CommonHelper.GetConfigValue("defaultDataBase");
        List<RepairedToolForReceiveEntity> resultList = new List<RepairedToolForReceiveEntity>();
        public event TransfDelegate transfDelegate;
        public FrmToolRepairedComlete()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void FrmToolRepairedComlete_Load(object sender, EventArgs e)
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
        private void tool_RepairdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewColumn column = tool_RepairdataGridView.Columns[e.ColumnIndex];
                    if (column is DataGridViewButtonColumn)
                    {
                        string toolCode = tool_RepairdataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                        //更新送修工具接收状态为2
                        t_ToolRepairRecord repairInfo = new t_ToolRepairRecord();
                        repairInfo = _toolRepairRecordService.GetToolRepairByToolCodeAndStatus(toolCode, 2);
                        if (repairInfo != null)
                        {
                            if (column.Name == "CompleteButton")
                            {
                                repairInfo.ToolStatus = 3;
                            }
                            else if (column.Name == "ScrapButton")
                            {
                                repairInfo.ToolStatus = 5;
                            }
                            if (_toolRepairRecordService.UpdateToolReceiveStatus(repairInfo))
                            {
                                MessageBox.Show("状态设置成功");
                                Search_buttonX_Click(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("状态设置失败");
                            }
                        }
                        else
                        {
                            MessageBox.Show("该工具送修记录不存在，请重新选择");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "FrmToolRepairedComlete--tool_RepairdataGridView_CellContentClick", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void Search_buttonX_Click(object sender, EventArgs e)
        {
            try
            {
                if (tool_RepairdataGridView.Columns.Count >= 9)
                {
                    tool_RepairdataGridView.Columns.RemoveAt(7);
                    tool_RepairdataGridView.Columns.RemoveAt(7);
                }
                t_ToolRepairRecord repairInfo = new t_ToolRepairRecord();
                repairInfo.TypeName = cbSearchBlong.SelectedValue.ToString() != "全部" ? cbSearchBlong.SelectedValue.ToString() : "";
                repairInfo.ChildTypeName = cbSearchcategory.SelectedValue.ToString() != "全部" ? cbSearchcategory.SelectedValue.ToString() : "";
                repairInfo.ToolCode = tbSearchCode.Text;
                repairInfo.ToolName = tbSearchName.Text;
                repairInfo.ToolStatus = 2;
                resultList = _toolRepairRecordService.GetRepairedToolForReceive(repairInfo);
                for (int i = 0; i < tool_RepairdataGridView.Columns.Count; i++)
                {
                    tool_RepairdataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
                //tool_RepairdataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                
                tool_RepairdataGridView.DataSource = resultList;
                tool_RepairdataGridView.Columns[0].HeaderText = "配属";
                tool_RepairdataGridView.Columns[1].HeaderText = "类别";
                tool_RepairdataGridView.Columns[2].HeaderText = "工具编码";
                tool_RepairdataGridView.Columns[3].HeaderText = "工具名称";
                tool_RepairdataGridView.Columns[4].HeaderText = "送修时间";
                tool_RepairdataGridView.Columns[5].HeaderText = "送修人员";
                tool_RepairdataGridView.Columns[6].HeaderText = "备注";
                DataGridViewButtonColumn buttonComplete = new DataGridViewButtonColumn();
                buttonComplete.HeaderText = "操作";
                buttonComplete.Text = "维修完成";
                buttonComplete.Name = "CompleteButton";
                buttonComplete.UseColumnTextForButtonValue = true;
                tool_RepairdataGridView.Columns.AddRange(buttonComplete);
                DataGridViewButtonColumn buttonScrap = new DataGridViewButtonColumn();
                buttonScrap.HeaderText = "操作";
                buttonScrap.Text = "报废";
                buttonScrap.Name = "ScrapButton";
                buttonScrap.UseColumnTextForButtonValue = true;
                tool_RepairdataGridView.Columns.AddRange(buttonScrap);
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "FrmToolRepairedComlete--Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void superTabStrip1_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
            string name = e.NewValue.Name;
            if (MemoryCacheHelper.SetMemoryCache(name))
            {
                transfDelegate();
            }
        }
        private void tool_RepairdataGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1); 
        }
    }
}
