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

namespace toolstrackingsystem
{
    public partial class FrmScrapToolManage : Office2007RibbonForm
    {
        private IScrapToolInfoService _scrapToolInfoService;
        private IToolInfoService _toolInfoService;
        private int selectIndex=0;
        public FrmScrapToolManage()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void FrmScrapToolManage_Load(object sender, EventArgs e)
        {
            _scrapToolInfoService  =Program.container.Resolve<IScrapToolInfoService>() as ScrapToolInfoService;
            _toolInfoService = Program.container.Resolve<IToolInfoService>() as ToolInfoService;
        }
        /// <summary>
        /// 工具文本框离开焦点时触发查找符合条件的工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pack_Code_textBox_TextChanged(object sender, EventArgs e)
        {
            string packCode = Pack_Code_textBox.Text;
            if (string.IsNullOrEmpty(packCode))
            { 
                //查找符合条件的工具信息
            }
            //获取数据进行绑定
            for (int i = 0; i < ToolInfo_dataGridView.Columns.Count; i++)
            {
                ToolInfo_dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            ToolInfo_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ToolInfo_dataGridView.Columns[0].HeaderText = "工具配属";
            ToolInfo_dataGridView.Columns[1].HeaderText = "工具类别";
            ToolInfo_dataGridView.Columns[2].HeaderText = "包编码";
            ToolInfo_dataGridView.Columns[3].HeaderText = "包名称";
            ToolInfo_dataGridView.Columns[4].HeaderText = "编码";
            ToolInfo_dataGridView.Columns[5].HeaderText = "名称";
            ToolInfo_dataGridView.Columns[6].HeaderText = "型号";
            ToolInfo_dataGridView.Columns[7].HeaderText = "位置";
            ToolInfo_dataGridView.Columns[7].HeaderText = "备注";
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
            selectIndex = e.RowIndex;
        }
    }
}
