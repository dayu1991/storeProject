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
    public partial class FrmCreditQuery : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FormLogin));
        private IPersonCreditRecordService _personCreditRecordService;
        private List<PersonCreditRecordEntity> resultList = new List<PersonCreditRecordEntity>();
        public FrmCreditQuery()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrmCreditQuery_Load(object sender, EventArgs e)
        {
            this._personCreditRecordService = Program.container.Resolve<IPersonCreditRecordService>() as PersonCreditRecordService;
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
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmCreditQuery--Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void LoadData()
        {
            t_PersonCreditRecord personInfo = new t_PersonCreditRecord();
            personInfo.PersonCode = PersonCode_textBox.Text;
            //数据总记录数
            long Count;
            //获取分页的数据
            resultList = _personCreditRecordService.GetPersonCreditRecordList(personInfo, pagerControl1.PageIndex, pagerControl1.PageSize, out Count);
            TollList_dataGridViewX.DataSource = resultList;
            pagerControl1.DrawControl(Convert.ToInt32(Count));
            for (int i = 0; i < TollList_dataGridViewX.Columns.Count; i++)
            {
                TollList_dataGridViewX.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            TollList_dataGridViewX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TollList_dataGridViewX.Columns[0].HeaderText = "包编码";
            TollList_dataGridViewX.Columns[1].HeaderText = "包名称";
            TollList_dataGridViewX.Columns[2].HeaderText = "工具编码";
            TollList_dataGridViewX.Columns[3].HeaderText = "工具名称";
            TollList_dataGridViewX.Columns[4].HeaderText = "人员编码";
            TollList_dataGridViewX.Columns[5].HeaderText = "人员名称";
            TollList_dataGridViewX.Columns[6].HeaderText = "领用时间";
            TollList_dataGridViewX.Columns[7].HeaderText = "截止归还时间";
            TollList_dataGridViewX.Columns[7].Width = 120;
            TollList_dataGridViewX.Columns[8].HeaderText = "检测时间";
            pagerControl1.DrawControl(Convert.ToInt32(Count));
        }
        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            LoadData();
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
                    //获取数据
                    t_PersonCreditRecord personInfo = new t_PersonCreditRecord();
                    personInfo.PersonCode = PersonCode_textBox.Text;
                    resultList = _personCreditRecordService.GetPersonCreditRecordList(personInfo);
                    // 添加数据
                    for (int i = 0; i < resultList.Count; i++)
                    {
                        var item = resultList[i];
                        row = sheet.CreateRow(i + 1);
                        NPOI.SS.UserModel.ICell cell = row.CreateCell(0);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.PackCode);
                        cell = row.CreateCell(1);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.PackName);
                        cell = row.CreateCell(2);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.ToolCode);
                        cell = row.CreateCell(3);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.ToolName);
                        cell = row.CreateCell(4);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.PersonCode);
                        cell = row.CreateCell(5);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.PersonName);
                        cell = row.CreateCell(6);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.OutStoreTime);
                        cell = row.CreateCell(7);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.UserTimeInfo);
                        cell = row.CreateCell(8);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.OptionTime);
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
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmInStoreManage--export_button_Click", ex.Message, ex.StackTrace, ex.Source);
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
                FrmPrintPersonCreditRecord personFrm = new FrmPrintPersonCreditRecord();
                personFrm.Tag = PersonCode_textBox.Text;
                personFrm.ShowDialog();
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmInStoreManage--Print_button_Click", ex.Message, ex.StackTrace, ex.Source);                
            }
        }

        private void TollList_dataGridViewX_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
