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
using service.toolstrackingsystem;

namespace toolstrackingsystem
{
    public partial class FrmPrepairTool : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FormLogin));
        private IToolPrepairRecordService _toolPrepairRecordService;
        private IPersonManageService _personManageService;

        List<ToolPrepairEntity> resultList = new List<ToolPrepairEntity>();
        public FrmPrepairTool()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void FrmPrepairTool_Load(object sender, EventArgs e)
        {
            _toolPrepairRecordService = Program.container.Resolve<IToolPrepairRecordService>() as ToolPrepairRecordService;
        }
        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            t_ToolPrepairRecord PrepairInfo = new t_ToolPrepairRecord();
            PrepairInfo.ToolCode = ToolCode_textBox.Text;
            //数据总记录数
            long Count;
            //获取分页的数据
            resultList = _toolPrepairRecordService.GetToolPrepairRecordList(PrepairInfo, pagerControl1.PageIndex, pagerControl1.PageSize, out Count);
            TollList_dataGridViewX.DataSource = resultList;
            pagerControl1.DrawControl(Convert.ToInt32(Count));
            for (int i = 0; i < TollList_dataGridViewX.Columns.Count; i++)
            {
                TollList_dataGridViewX.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            TollList_dataGridViewX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TollList_dataGridViewX.Columns[0].HeaderText = "工具编码";
            TollList_dataGridViewX.Columns[1].HeaderText = "工具名称";
            TollList_dataGridViewX.Columns[2].HeaderText = "送修时间";
            TollList_dataGridViewX.Columns[3].HeaderText = "返回时间";
            TollList_dataGridViewX.Columns[4].HeaderText = "送修操作人员";
            TollList_dataGridViewX.Columns[4].Width = 120;
            TollList_dataGridViewX.Columns[5].HeaderText = "返回操作人员";
            TollList_dataGridViewX.Columns[5].Width = 120;
            TollList_dataGridViewX.Columns[6].HeaderText = "是否可用";
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
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmPrepairTool--Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
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
                    NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("送修列表");
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
                    t_ToolPrepairRecord PrepairInfo = new t_ToolPrepairRecord();
                    PrepairInfo.ToolCode = ToolCode_textBox.Text;
                    resultList = _toolPrepairRecordService.GetToolPrepairRecordList(PrepairInfo);
                    // 添加数据
                    for (int i = 0; i < resultList.Count; i++)
                    {
                        var item = resultList[i];
                        row = sheet.CreateRow(i + 1);
                        NPOI.SS.UserModel.ICell cell = row.CreateCell(0);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.ToolCode);
                        cell = row.CreateCell(1);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.ToolName);
                        cell = row.CreateCell(2);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.PrepairTime);
                        cell = row.CreateCell(3);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.BackTime);
                        cell = row.CreateCell(4);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.OptionPerson);
                        cell = row.CreateCell(5);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.BackOptionPerson);
                        cell = row.CreateCell(6);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.IsActive);
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
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmPrepairTool--export_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }

        }
        private void Print_button_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPrintPrepairTool prepairFrm = new FrmPrintPrepairTool();
                t_ToolPrepairRecord PrepairInfo = new t_ToolPrepairRecord();
                PrepairInfo.ToolCode = ToolCode_textBox.Text;
                prepairFrm.Tag = PrepairInfo;
                prepairFrm.ShowDialog();
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmPrepairTool--Print_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
    }
}
