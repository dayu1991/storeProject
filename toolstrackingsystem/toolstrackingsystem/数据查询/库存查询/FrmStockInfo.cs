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
using System.IO;

namespace toolstrackingsystem
{
    public partial class FrmStockInfo : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FormLogin));
        private IToolInfoService _toolInfoService;
        private IToolTypeService _toolTypeService;
        private List<ToolInfoForStockInfoEntity> resultList = new List<ToolInfoForStockInfoEntity>();
        public FrmStockInfo()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void FrmStockInfo_Load(object sender, EventArgs e)
        {
            _toolInfoService = Program.container.Resolve<IToolInfoService>() as ToolInfoService;
            _toolTypeService = Program.container.Resolve<IToolTypeService>() as ToolTypeService;
            #region 初始化配属下拉框
            var toolTypeList = _toolTypeService.GetToolTypeList();
            t_ToolType tooTypeInfo = new t_ToolType();
            tooTypeInfo.TypeName = "全部";
            toolTypeList.Add(tooTypeInfo);
            ToolType_comboBox.DataSource = toolTypeList;
            ToolType_comboBox.DisplayMember = "TypeName";
            ToolType_comboBox.ValueMember = "TypeName";
            ToolType_comboBox.SelectedValue = "全部";
            #endregion
            #region 初始化类别下拉框
            var toolChildTypeList = _toolTypeService.GetToolChildTypeList();
            t_ToolType tooChilidTypeInfo = new t_ToolType();
            tooChilidTypeInfo.TypeName = "全部";
            toolChildTypeList.Add(tooChilidTypeInfo);
            Tool_Child_Type_comboBox.DataSource = toolChildTypeList;
            Tool_Child_Type_comboBox.DisplayMember = "TypeName";
            Tool_Child_Type_comboBox.ValueMember = "TypeName";
            Tool_Child_Type_comboBox.SelectedValue = "全部";
            #endregion
        }

        private void TollList_dataGridViewX_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void Search_buttonX_Click(object sender, EventArgs e)
        {
            pagerControl1.OnPageChanged += new EventHandler(pagerControl1_OnPageChanged);
            LoadData();
        }
        private void LoadData()
        {
            t_ToolInfo toolInfo = new t_ToolInfo();
            toolInfo.TypeName = ToolType_comboBox.SelectedValue.ToString() == "全部" ? "" : ToolType_comboBox.SelectedValue.ToString();
            toolInfo.ChildTypeName = Tool_Child_Type_comboBox.SelectedValue.ToString() == "全部" ? "" : Tool_Child_Type_comboBox.SelectedValue.ToString();
            toolInfo.ToolCode = ToolCode_textBox.Text;
            toolInfo.ToolName = ToolName_textBox.Text;
            toolInfo.Location = Location_textBox.Text;
            toolInfo.Models = Model_textBox.Text;
            //数据总记录数
            long Count;
            //获取分页的数据
            resultList = _toolInfoService.GetToolInfoListForStock(toolInfo,pagerControl1.PageIndex,pagerControl1.PageSize,out Count);
            TollList_dataGridViewX.DataSource = resultList;
            pagerControl1.DrawControl(Convert.ToInt32(Count));
            for (int i = 0; i < TollList_dataGridViewX.Columns.Count; i++)
            {
                TollList_dataGridViewX.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            TollList_dataGridViewX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TollList_dataGridViewX.Columns[0].HeaderText = "配属";
            TollList_dataGridViewX.Columns[1].HeaderText = "类别";
            TollList_dataGridViewX.Columns[2].HeaderText = "工具编码";
            TollList_dataGridViewX.Columns[3].HeaderText = "工具名称";
            TollList_dataGridViewX.Columns[4].HeaderText = "入库时间";
            pagerControl1.DrawControl(Convert.ToInt32(Count));
        }
        /// <summary>
        /// 汇总总库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Count_sum_button_Click(object sender, EventArgs e)
        {
            t_ToolInfo toolInfo = new t_ToolInfo();
            toolInfo.TypeName = ToolType_comboBox.SelectedValue.ToString() == "全部" ? "" : ToolType_comboBox.SelectedValue.ToString();
            toolInfo.ChildTypeName = Tool_Child_Type_comboBox.SelectedValue.ToString() == "全部" ? "" : Tool_Child_Type_comboBox.SelectedValue.ToString();
            toolInfo.ToolCode = ToolCode_textBox.Text;
            toolInfo.ToolName = ToolName_textBox.Text;
            toolInfo.Location = Location_textBox.Text;
            toolInfo.Models = Model_textBox.Text;
            //获取分页的数据
            List<CountToolInfoEntity> resultEntity = _toolInfoService.GetCountInToolInfo(toolInfo);
            CountToolInfoEntity sumCountTool = new CountToolInfoEntity();
            sumCountTool.TypeName = "汇总";
            foreach (var item in resultEntity)
            {
                sumCountTool.Quantity += item.Quantity;
            }
            resultEntity.Add(sumCountTool);
            TollList_dataGridViewX.DataSource = resultEntity;
            pagerControl1.DrawControl(Convert.ToInt32(sumCountTool.Quantity));
            for (int i = 0; i < TollList_dataGridViewX.Columns.Count; i++)
            {
                TollList_dataGridViewX.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            TollList_dataGridViewX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TollList_dataGridViewX.Columns[0].HeaderText = "名称";
            TollList_dataGridViewX.Columns[1].HeaderText = "数量";
            pagerControl1.DrawControl(Convert.ToInt32(1));
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void export_button_Click(object sender, EventArgs e)
        {
            try
            {
                t_ToolInfo toolInfo = new t_ToolInfo();
                toolInfo.TypeName = ToolType_comboBox.SelectedValue.ToString() == "全部" ? "" : ToolType_comboBox.SelectedValue.ToString();
                toolInfo.ChildTypeName = Tool_Child_Type_comboBox.SelectedValue.ToString() == "全部" ? "" : Tool_Child_Type_comboBox.SelectedValue.ToString();
                toolInfo.ToolCode = ToolCode_textBox.Text;
                toolInfo.ToolName = ToolName_textBox.Text;
                toolInfo.Location = Location_textBox.Text;
                toolInfo.Models = Model_textBox.Text;
                //获取数据
                resultList = _toolInfoService.GetToolInfoListForStock(toolInfo);
                if (resultList.Count <= 0)
                {
                    MessageBox.Show("数据为空，无法导出");
                    return;
                }
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Filter = "Excel(*.xls)|*.xls|Excel(*.xlsx)|*.xlsx";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    NPOI.SS.UserModel.IWorkbook book = null;
                    if (fileDialog.FilterIndex == 1)
                    {
                        book = new NPOI.HSSF.UserModel.HSSFWorkbook();
                    }
                    else
                    {
                        book = new NPOI.XSSF.UserModel.XSSFWorkbook();
                    }
                    NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("信用列表");
                    // 添加表头
                    NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
                    for (int i = 0; i < TollList_dataGridViewX.Columns.Count; i++)
                    {
                        var item = TollList_dataGridViewX.Columns[i];
                        NPOI.SS.UserModel.ICell cell = row.CreateCell(i);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.HeaderText);
                    }

                    // 添加数据
                    for (int i = 0; i < resultList.Count; i++)
                    {
                        var item = resultList[i];
                        row = sheet.CreateRow(i + 1);
                        NPOI.SS.UserModel.ICell cell = row.CreateCell(0);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.TypeName);
                        cell = row.CreateCell(1);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.ChildTypeName);
                        cell = row.CreateCell(2);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell = row.CreateCell(3);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.ToolCode);
                        cell = row.CreateCell(4);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.ToolName);
                        cell = row.CreateCell(5);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.InStoreTime);
                    }
                    // 写入 
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    book.Write(ms);
                    book = null;
                    using (FileStream fs = new FileStream(fileDialog.FileName, FileMode.Create, FileAccess.Write))
                    {
                        byte[] data = ms.ToArray();
                        fs.Write(data, 0, data.Length);
                        fs.Flush();
                    }
                    ms.Close();
                    ms.Dispose();
                    MessageBox.Show("导出成功");
                    return;
                }

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmStockInfo--export_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }


        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Print_button_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPrintStockInfo printFrm = new FrmPrintStockInfo();
                t_ToolInfo toolInfo = new t_ToolInfo();
                toolInfo.TypeName = ToolType_comboBox.SelectedValue.ToString() == "全部" ? "" : ToolType_comboBox.SelectedValue.ToString();
                toolInfo.ChildTypeName = Tool_Child_Type_comboBox.SelectedValue.ToString() == "全部" ? "" : Tool_Child_Type_comboBox.SelectedValue.ToString();
                toolInfo.ToolCode = ToolCode_textBox.Text;
                toolInfo.ToolName = ToolName_textBox.Text;
                toolInfo.Location = Location_textBox.Text;
                printFrm.Tag = toolInfo;
                printFrm.ShowDialog();
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmStockInfo--Print_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
    }
}
