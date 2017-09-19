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
       
        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex >= 0)
            //    {
            //        DataGridViewColumn column = tool_RepairdataGridView.Columns[e.ColumnIndex];
            //        if (column is DataGridViewButtonColumn)
            //        {
            //            string toolCode = tool_RepairdataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            //            //更新送修工具接收状态为2
            //            t_ToolRepairRecord repairInfo = new t_ToolRepairRecord();
            //            repairInfo = _toolRepairRecordService.GetToolRepairByToolCodeAndStatus(toolCode, 1);
            //            if (repairInfo != null)
            //            {
            //                repairInfo.ToolStatus = 2;
            //                if (_toolRepairRecordService.UpdateToolReceiveStatus(repairInfo))
            //                {
            //                    MessageBox.Show("接收成功");
            //                    Search_buttonX_Click(sender, e);
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("该工具送修记录不存在，请重新选择");
            //                return;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "ToolRepairManageNew--dataGridViewX1_CellContentClick", ex.Message, ex.StackTrace, ex.Source);
            //}

        }
        private void Search_buttonX_Click(object sender, EventArgs e)
        {

        }
        private void tool_RepairdataGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1); 
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
            #endregion

            
        }
        
    }
}
