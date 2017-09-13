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
        ILog logger = log4net.LogManager.GetLogger(typeof(frmEditUserinfo));
        private Sys_User_Info userInfo = MemoryCache.Default.Get("userinfo") as Sys_User_Info;
        private List<t_ScrapToolInfo> infoList = new List<t_ScrapToolInfo>();
        private IScrapToolInfoService _scrapToolInfoService;
        private IToolInfoService _toolInfoService;
        private IOutBackStoreService _outBackStoreService;
        private IToolTypeService _toolTypeService;
        private int selectIndex=0;
        public FrmScrapToolManageDescribe()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void FrmScrapToolManage_Load(object sender, EventArgs e)
        {
            _scrapToolInfoService  =Program.container.Resolve<IScrapToolInfoService>() as ScrapToolInfoService;
            _toolInfoService = Program.container.Resolve<IToolInfoService>() as ToolInfoService;
            _outBackStoreService = Program.container.Resolve<IOutBackStoreService>() as OutBackStoreService;
            _toolTypeService = Program.container.Resolve<IToolTypeService>() as ToolTypeService;
            #region 初始化工具类别
            List<t_ToolType> resultList = _toolTypeService.GetToolChildTypeList();
            t_ToolType toolType = new t_ToolType();
            toolType.TypeName = "全部";
            resultList.Add(toolType);
            this.ChildTypeName_comboBox.DataSource = resultList;
            this.ChildTypeName_comboBox.DisplayMember = "TypeName";
            this.ChildTypeName_comboBox.ValueMember = "TypeName";
            this.ChildTypeName_comboBox.SelectedValue = "全部";
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
            selectIndex = e.RowIndex;
        }
        private void ScrapTool_dataGridViewX2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        /// <summary>
        /// 查询报废工具信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Scraptool_button_Click(object sender, EventArgs e)
        {
            try
            {
                pagerControl1.OnPageChanged += new EventHandler(pagerControl1_OnPageChanged);
                LoadData();
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmScrapToolManageDescribe--Scrap_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void LoadData()
        {
            string toolCode = Scrap_ToolInfoCode_Detail_textBox.Text;
            string ChildTypeName = ChildTypeName_comboBox.SelectedValue.ToString()!="全部"?ChildTypeName_comboBox.SelectedValue.ToString():"";
            //数据总记录数
            long Count;
            infoList = _scrapToolInfoService.GetScrapToolInfoList(toolCode, ChildTypeName, pagerControl1.PageIndex, pagerControl1.PageSize, out Count);
            ScrapTool_dataGridViewX2.DataSource = infoList;
            pagerControl1.DrawControl(Convert.ToInt32(Count));
            for (int i = 0; i < ScrapTool_dataGridViewX2.Columns.Count; i++)
            {
                ScrapTool_dataGridViewX2.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            ScrapTool_dataGridViewX2.MultiSelect = true;
            ScrapTool_dataGridViewX2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ScrapTool_dataGridViewX2.Columns[0].HeaderText = "ID";
            ScrapTool_dataGridViewX2.Columns[0].Visible = false;
            ScrapTool_dataGridViewX2.Columns[1].HeaderText = "配属";
            ScrapTool_dataGridViewX2.Columns[2].HeaderText = "工具类别";
            ScrapTool_dataGridViewX2.Columns[3].HeaderText = "工具编码";
            ScrapTool_dataGridViewX2.Columns[4].HeaderText = "名称";
            ScrapTool_dataGridViewX2.Columns[5].HeaderText = "包编码";
            ScrapTool_dataGridViewX2.Columns[6].HeaderText = "包名称";
            ScrapTool_dataGridViewX2.Columns[7].HeaderText = "报废时间";
            ScrapTool_dataGridViewX2.Columns[8].HeaderText = "备注";
            ScrapTool_dataGridViewX2.Columns[9].HeaderText = "操作人员";
            ScrapTool_dataGridViewX2.Columns[10].HeaderText = "备注操作人员";
            ScrapTool_dataGridViewX2.Columns[11].HeaderText = "备注时间";

        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                string toolCode = Scrap_ToolInfoCode_Detail_textBox.Text;
                string ChildTypeName = ChildTypeName_comboBox.SelectedValue.ToString() != "全部" ? ChildTypeName_comboBox.SelectedValue.ToString() : "";
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
                    NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("报废工具列表");
                    // 添加表头
                    NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
                    for (int i = 0; i < ScrapTool_dataGridViewX2.Columns.Count; i++)
                    {
                        var item = ScrapTool_dataGridViewX2.Columns[i];
                        NPOI.SS.UserModel.ICell cell = row.CreateCell(i);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.HeaderText);
                    }
                    //获取无分页数据
                    infoList = _scrapToolInfoService.GetScrapToolInfoList(toolCode, ChildTypeName);
                    // 添加数据
                    for (int i = 0; i < infoList.Count; i++)
                    {
                        var item = infoList[i];
                        row = sheet.CreateRow(i + 1);
                        NPOI.SS.UserModel.ICell cell = row.CreateCell(0);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.TypeName);
                        cell = row.CreateCell(1);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.ChildTypeName);
                        cell = row.CreateCell(2);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.ToolCode);
                        cell = row.CreateCell(3);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.ToolName);
                        cell = row.CreateCell(4);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.PackCode);
                        cell = row.CreateCell(5);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.PackName);
                        cell = row.CreateCell(6);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.ScrapTime);
                        cell = row.CreateCell(7);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.Remarks);
                        cell = row.CreateCell(8);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.OptionPerson);
                        cell = row.CreateCell(9);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.RemarkPerson);
                        cell = row.CreateCell(10);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.RemarkTime);
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
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmWorkerManager--Put_In_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }

        }
        /// <summary>
        /// 打印查询到的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            FrmPrintScrapTools printFrm = new FrmPrintScrapTools();
            printFrm.Tag = Scrap_ToolInfoCode_Detail_textBox.Text;
            printFrm.ShowDialog();
        }
        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        /// <summary>
        /// 设置报废工具为已补充
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Set_Instead_button_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = ScrapTool_dataGridViewX2.Rows[selectIndex].Cells[0].ToString();
                string remark = "已补充";
                if (string.IsNullOrEmpty(ID))
                {
                    MessageBox.Show("请选择需要补充的一条记录");
                    return;
                }
                bool IsSuccess = false;
                foreach (DataGridViewRow item in ScrapTool_dataGridViewX2.SelectedRows)
                {
                    if (!string.IsNullOrEmpty(item.Cells[5].ToString()))
                    {
                        MessageBox.Show(item.Cells[2].ToString() + "工具已补充过，无须再补充");
                    }
                    else
                    {
                        IsSuccess = _scrapToolInfoService.SetScrapToolRemark(ID, remark,LoginHelper.UserCode);
                    }
                }
                if (IsSuccess)
                {
                    MessageBox.Show("成功补充" + ScrapTool_dataGridViewX2.SelectedRows.Count + "件工具");
                    Search_Scraptool_button_Click(sender, e);
                }
                else
                {

                    MessageBox.Show("补充失败");
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmScrapToolManageDescribe--Set_Instead_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
    }
}
