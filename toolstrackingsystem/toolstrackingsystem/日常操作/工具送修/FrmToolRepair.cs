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
using System.Runtime.Caching;

namespace toolstrackingsystem
{
    public partial class FrmToolRepair : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FrmToolRepair));
        private IToolInfoService _toolInfoService;
        private List<ToolInfoForRepairEntity> resultList = new List<ToolInfoForRepairEntity>();
        private Sys_User_Info userInfo = MemoryCache.Default.Get("userinfo") as Sys_User_Info;
        private IToolTypeService _toolTypeService;
        private int selectedIndex;
        public FrmToolRepair()
        {
            this.EnableGlass = false;
            InitializeComponent();
            
        }
        private void FrmToolRepair_Load(object sender, EventArgs e)
        {
            _toolInfoService = Program.container.Resolve<IToolInfoService>() as ToolInfoService;
            _toolTypeService = Program.container.Resolve<IToolTypeService>() as ToolTypeService;
            #region 初始化工具类别
            List<t_ToolType> resultList = _toolTypeService.GetToolChildTypeList();
            t_ToolType toolType = new t_ToolType();
            toolType.TypeName = "全部";
            resultList.Add(toolType);
            this.ToolType_comboBox.DataSource = resultList;
            this.ToolType_comboBox.DisplayMember = "TypeName";
            this.ToolType_comboBox.ValueMember = "TypeName";
            this.ToolType_comboBox.SelectedValue = "全部";
            #endregion
        }
        private void TollList_dataGridViewX_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
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
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmToolRepair--Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void LoadData()
        {
            string toolCode = ToolCode_textBox.Text;
            //数据总记录数
            long Count;
            //获取分页的数据
            resultList =_toolInfoService.GetToolInfoForRepair(toolCode, pagerControl1.PageIndex, pagerControl1.PageSize, out Count);
            //如果查询的数据存在，则清空对话框内容
            if (resultList.Count > 0)
            {
                ToolCode_textBox.Text = "";
            }
            else {
                MessageBox.Show("工具不存在，请重新输入工具编码！");
                return;
            }
            TollList_dataGridViewX.DataSource = resultList;
            pagerControl1.DrawControl(Convert.ToInt32(Count));
            for (int i = 0; i < TollList_dataGridViewX.Columns.Count; i++)
            {
                TollList_dataGridViewX.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            TollList_dataGridViewX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TollList_dataGridViewX.Columns[0].HeaderText = "配属";
            TollList_dataGridViewX.Columns[1].HeaderText = "类别";
            TollList_dataGridViewX.Columns[2].HeaderText = "包编码";
            TollList_dataGridViewX.Columns[3].HeaderText = "包名称";
            TollList_dataGridViewX.Columns[4].HeaderText = "工具编码";
            TollList_dataGridViewX.Columns[5].HeaderText = "工具名称";
            TollList_dataGridViewX.Columns[6].HeaderText = "型号";
            TollList_dataGridViewX.Columns[7].HeaderText = "位置";
            TollList_dataGridViewX.Columns[8].HeaderText = "检测时间";
            TollList_dataGridViewX.Columns[9].HeaderText = "是否有效";
            TollList_dataGridViewX.Columns[8].HeaderText = "操作人";
            pagerControl1.DrawControl(Convert.ToInt32(Count));
        }
        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void export_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (TollList_dataGridViewX.Rows[selectedIndex].Cells[4].Value == null)
                {
                    MessageBox.Show("请选择要送修的工具");
                    return;
                }
                string toolCode = TollList_dataGridViewX.Rows[selectedIndex].Cells[4].Value.ToString();
                if (_toolInfoService.UpdateToolRepared(toolCode,userInfo.UserCode))
                {
                    MessageBox.Show("设置成功");
                    Search_buttonX_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmToolRepair--export_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void TollList_dataGridViewX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = e.RowIndex;
        }
        private void Reset_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (TollList_dataGridViewX.Rows[selectedIndex].Cells[4].Value == null)
                {
                    MessageBox.Show("请选择要恢复的工具");
                    return;
                }
                string toolCode = TollList_dataGridViewX.Rows[selectedIndex].Cells[4].Value.ToString();
                if (_toolInfoService.UpdateToolReparedIsActive(toolCode,userInfo.UserCode))
                {
                    MessageBox.Show("恢复成功");
                    Search_buttonX_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmToolRepair--Reset_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        /// <summary>
        /// 清空对话框和列表内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_button_Click(object sender, EventArgs e)
        {
            ToolCode_textBox.Text = "";
            TollList_dataGridViewX.DataSource = "";
        }
    }
}
