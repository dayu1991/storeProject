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
using log4net;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using dbentity.toolstrackingsystem;
using ViewEntity.toolstrackingsystem;
using System.IO;

namespace toolstrackingsystem
{
    public partial class FrmCurrentCountManage : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FormLogin));
        private ICurrentCountInfoService _CurrentCountInfoService;
        private IOutBackStoreService _outBackStoreService;
        private List<CurrentToolInfoEntity> resultList = new List<CurrentToolInfoEntity>();
        public FrmCurrentCountManage()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void FrmCurrentCountManage_Load(object sender, EventArgs e)
        {
            this._CurrentCountInfoService = Program.container.Resolve<ICurrentCountInfoService>() as CurrentCountInfoService;
            this._outBackStoreService = Program.container.Resolve<IOutBackStoreService>() as OutBackStoreService;
            //#region 初始化combox下拉框
            //try
            //{
            //    DataTable dt = new DataTable();
            //    dt.Columns.Add("name");
            //    dt.Columns.Add("value");
            //    DataRow dr = dt.NewRow();

            //    dr[0] = "全部";

            //    dr[1] = "1";

            //    dt.Rows.Add(dr);

            //    DataRow dr1 = dt.NewRow();

            //    dr1[0] = "导入";  

            //    dr1[1] = "导入";

            //    dt.Rows.Add(dr1);

            //    DataRow dr2 = dt.NewRow();

            //    dr2[0] = "入库";

            //    dr2[1] = "入库";

            //    dt.Rows.Add(dr2);

            //    DataRow dr3 = dt.NewRow();

            //    dr3[0] = "领用";

            //    dr3[1] = "领用";

            //    dt.Rows.Add(dr3);

            //    DataRow dr4 = dt.NewRow();

            //    dr4[0] = "归还";

            //    dr4[1] = "归还";

            //    dt.Rows.Add(dr4);


            //    this.OptionType_comboBox.DataSource = dt;

            //    this.OptionType_comboBox.DisplayMember = "name";

            //    this.OptionType_comboBox.ValueMember = "value";

            //}
            //catch (Exception ex)
            //{
            //    logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmEditUser", ex.Message, ex.StackTrace, ex.Source);
            //}
            //#endregion
            #region 初始化日期选择控件
            from_dateTimeInput.ShowUpDown = true;
            to_dateTimeInput.ShowUpDown = true;
            from_dateTimeInput.CustomFormat = "yyyy-MM-dd";
            to_dateTimeInput.CustomFormat = "yyyy-MM-dd";
            #endregion
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
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmCurrentCountManage--Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string personCode = PersonCode_textBox.Text;
            string toolCode = ToolCode_textBox.Text;
            string packCode = this.txtpackCode.Text;

            string dateTimeFrom = from_dateTimeInput.Text;
            string dateTimeTo = to_dateTimeInput.Text;
            //数据总记录数
            long Count;
            //获取分页的数据
            resultList = _outBackStoreService.GetCurrentToolInfoList(toolCode, packCode, personCode, dateTimeFrom, dateTimeTo, pagerControl1.PageIndex, pagerControl1.PageSize, out Count);
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
            TollList_dataGridViewX.Columns[6].HeaderText = "是否归还";
            TollList_dataGridViewX.Columns[7].HeaderText = "人员编码";
            TollList_dataGridViewX.Columns[8].HeaderText = "人员名称";
            TollList_dataGridViewX.Columns[9].HeaderText = "领用时间";
            TollList_dataGridViewX.Columns[10].HeaderText = "领用说明";
            TollList_dataGridViewX.Columns[11].HeaderText = "归还人员编码";
            TollList_dataGridViewX.Columns[11].Width = 120;
            TollList_dataGridViewX.Columns[12].HeaderText = "归还人员名称";
            TollList_dataGridViewX.Columns[12].Width = 120;
            TollList_dataGridViewX.Columns[13].HeaderText = "归还时间";
            TollList_dataGridViewX.Columns[14].HeaderText = "归还说明";
            TollList_dataGridViewX.Columns[15].HeaderText = "操作人";
            pagerControl1.DrawControl(Convert.ToInt32(Count));
        }
        private void TollList_dataGridViewX_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        private void export_button_Click(object sender, EventArgs e)
        {
            try
            {
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
                    NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("流水账列表");
                    // 添加表头
                    NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
                    for (int i = 0; i < TollList_dataGridViewX.Columns.Count; i++)
                    {
                        var item = TollList_dataGridViewX.Columns[i];
                        NPOI.SS.UserModel.ICell cell = row.CreateCell(i);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.HeaderText);
                    }
                    //获取数据
                    string personCode = PersonCode_textBox.Text;
                    string toolCode = ToolCode_textBox.Text;
                    string dateTimeFrom = from_dateTimeInput.Text;
                    string dateTimeTo = to_dateTimeInput.Text;
                    resultList = _outBackStoreService.GetCurrentToolInfoForExport(toolCode,personCode,dateTimeFrom,dateTimeTo);
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
                        cell.SetCellValue(item.PackCode);
                        cell = row.CreateCell(3);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.PackName);
                        cell = row.CreateCell(4);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.ToolCode);
                        cell = row.CreateCell(5);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.ToolName);
                        cell = row.CreateCell(6);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.IsBack);
                        cell = row.CreateCell(7);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.PersonCode);
                        cell = row.CreateCell(8);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.PersonName);
                        cell = row.CreateCell(9);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.OutStoreTime);
                        cell = row.CreateCell(10);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.outdescribes);
                        cell = row.CreateCell(11);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.BackPesonCode);
                        cell = row.CreateCell(12);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.BackPersonName);
                        cell = row.CreateCell(13);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.BackTime);
                        cell = row.CreateCell(14);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.backdescribes);
                        cell = row.CreateCell(15);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.OptionPerson);
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
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmCurrentCountManage--export_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void Print_button_Click(object sender, EventArgs e)
        {
            try
            {
                string personCode = PersonCode_textBox.Text;
                string toolCode = ToolCode_textBox.Text;
                string dateTimeFrom = from_dateTimeInput.Text;
                string dateTimeTo = to_dateTimeInput.Text;
                t_OutBackStore countInfo = new t_OutBackStore();
                countInfo.PersonCode = personCode;
                countInfo.ToolCode = toolCode;
                countInfo.OutStoreTime = dateTimeFrom;
                countInfo.BackTime = dateTimeTo;
                PrintCurrentCountInfo printFrm = new PrintCurrentCountInfo();
                printFrm.Tag = countInfo;
                printFrm.ShowDialog();
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmCurrentCountManage--export_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
    }
}
