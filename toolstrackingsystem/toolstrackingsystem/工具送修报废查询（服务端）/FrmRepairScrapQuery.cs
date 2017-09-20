using DevComponents.DotNetBar;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using service.toolstrackingsystem;
using System.Runtime.Caching;
using ViewEntity.toolstrackingsystem;
using common.toolstrackingsystem;
using dbentity.toolstrackingsystem;
using ViewEntity.toolstrackingsystem.view;

namespace toolstrackingsystem
{
    public partial class FrmRepairScrapQuery : Office2007RibbonForm
    {
       ILog logger = log4net.LogManager.GetLogger(typeof(ToolRepairManageNew));
        public IToolRepairRecordService _toolRepairRecordService;
        public IToolInfoService _toolInfoService;
        List<RepairedToolForReceiveEntity> resultList = new List<RepairedToolForReceiveEntity>();
        public FrmRepairScrapQuery()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }       
        
      
      
        private void FrmRepairScrapQuery_Load(object sender, EventArgs e)
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
            from_dateTimeInput.Value = DateTime.Now.AddMonths(-1);
            to_dateTimeInput.Value = DateTime.Now.AddMonths(1);



            LoadData();

            #endregion

            
        }

        private void Search_buttonX_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {

                string blongValue = cbSearchBlong.SelectedValue.ToString();
                blongValue = blongValue == "全部" ? "" : blongValue;
                string categoryValue = cbSearchcategory.SelectedValue.ToString();
                categoryValue = categoryValue == "全部" ? "" : categoryValue;

                string toolCode = tbSearchCode.Text;
                string toolName = tbSearchName.Text;
                long Count;

                var statTime = from_dateTimeInput.Value;
                var endTime = to_dateTimeInput.Value;
                List<ToolRepairRecordExtend> resultEntity = _toolRepairRecordService.GetListForQuery(blongValue, categoryValue, toolCode, toolName, statTime, endTime, pagerControl1.PageIndex, pagerControl1.PageSize, out Count);
                pagerControl1.DrawControl(Convert.ToInt32(Count));
                this.dataGridViewX1.AutoGenerateColumns = false;
                this.dataGridViewX1.DataSource = resultEntity;
                for (int i = 0; i < dataGridViewX1.Columns.Count; i++)
                {
                    dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
                dataGridViewX1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--Tool--Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }

        private void dataGridViewX1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var num = (pagerControl1.PageIndex - 1) * pagerControl1.PageSize + 1 + e.Row.Index;
            e.Row.HeaderCell.Value = string.Format("{0}", num);
        }
    }
}
