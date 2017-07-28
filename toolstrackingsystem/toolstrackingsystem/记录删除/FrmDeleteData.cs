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
using ViewEntity.toolstrackingsystem;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.IO;
using dbentity.toolstrackingsystem;

namespace toolstrackingsystem
{
    public partial class FrmDeleteData : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FormLogin));
        private IOutBackStoreService _outBackStoreService;
        private List<OutBackInfoForDeleteEntity> resultList = new List<OutBackInfoForDeleteEntity>();
        private int slectedIndex = 0;
        public FrmDeleteData()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void FrmDeleteData_Load(object sender, EventArgs e)
        {
            _outBackStoreService = Program.container.Resolve<IOutBackStoreService>() as OutBackStoreService; 
        }
        private void TollList_dataGridViewX_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            string toolCode = ToolCode_textBox.Text;
            string personCode = PersonCode_textBox.Text;
            //数据总记录数
            long Count;
            //获取分页的数据
            resultList = _outBackStoreService.GetOutBackInfoForDelete(toolCode,personCode, pagerControl1.PageIndex, pagerControl1.PageSize, out Count);
            TollList_dataGridViewX.DataSource = resultList;
            pagerControl1.DrawControl(Convert.ToInt32(Count));
            for (int i = 0; i < TollList_dataGridViewX.Columns.Count; i++)
            {
                TollList_dataGridViewX.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            TollList_dataGridViewX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TollList_dataGridViewX.Columns[0].HeaderText = "ID";
            TollList_dataGridViewX.Columns[1].HeaderText = "工具编码";
            TollList_dataGridViewX.Columns[2].HeaderText = "工具名称";
            TollList_dataGridViewX.Columns[3].HeaderText = "领用时间";
            TollList_dataGridViewX.Columns[4].HeaderText = "领用人员编码";
            TollList_dataGridViewX.Columns[5].HeaderText = "领用人员名称";
            TollList_dataGridViewX.Columns[6].HeaderText = "截止归还时间";
            TollList_dataGridViewX.Columns[7].HeaderText = "是否归还";
            TollList_dataGridViewX.Columns[8].HeaderText = "归还时间";
            TollList_dataGridViewX.Columns[9].HeaderText = "归还人员编码";
            TollList_dataGridViewX.Columns[10].HeaderText = "归还人员名称";
            TollList_dataGridViewX.Columns[11].HeaderText = "领用说明";
            TollList_dataGridViewX.Columns[12].HeaderText = "归还说明";
            TollList_dataGridViewX.Columns[13].HeaderText = "操作人员";
            pagerControl1.DrawControl(Convert.ToInt32(Count));
        }
        private void Search_buttonX_Click(object sender, EventArgs e)
        {
            try
            {
                pagerControl1.OnPageChanged += new EventHandler(pagerControl1_OnPageChanged);
                LoadData();
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmDeleteData--Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void TollList_dataGridViewX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            slectedIndex = e.RowIndex;
        }
        private void Delete_button_Click(object sender, EventArgs e)
        {
            string ID = TollList_dataGridViewX.Rows[slectedIndex].Cells[0].Value.ToString();
            if (string.IsNullOrEmpty(ID))
            {
                MessageBox.Show("请选择一条需要删除的记录");
                return;
            }
            if (MessageBox.Show("您确定要删除“" + TollList_dataGridViewX.Rows[slectedIndex].Cells[1].Value.ToString() + "”包信息吗", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (_outBackStoreService.DeleteOutBackInfo(ID))
                {
                    MessageBox.Show("删除成功");
                    Search_buttonX_Click(sender,e);
                }
            }
        }
    }
}
