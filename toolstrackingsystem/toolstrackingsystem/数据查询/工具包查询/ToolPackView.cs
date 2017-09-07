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
using ViewEntity.toolstrackingsystem;
using System.IO;

namespace toolstrackingsystem
{
    public partial class ToolPackView : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(ToolPackView));
        private IToolInfoService _toolInfoService;
        private List<ToolPackViewEntity> resultList;
        public ToolPackView()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void ToolPackView_Load(object sender, EventArgs e)
        {
            _toolInfoService = Program.container.Resolve<IToolInfoService>() as ToolInfoService;
        }
        private void ToolPackList_dataGridViewX_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
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
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--ToolPackView--Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }

        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string packCode = ToolPackCode_textBox.Text;
            string packName = ToolPackName_textBox.Text;
            //数据总记录数
            long Count;
            //获取分页的数据
            resultList = _toolInfoService.GetPackInfoList(packCode,packName,pagerControl1.PageIndex,pagerControl1.PageSize,out Count);
            ToolPackList_dataGridViewX.DataSource = resultList;
            pagerControl1.DrawControl(Convert.ToInt32(Count));
            for (int i = 0; i < ToolPackList_dataGridViewX.Columns.Count; i++)
            {
                ToolPackList_dataGridViewX.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            ToolPackList_dataGridViewX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ToolPackList_dataGridViewX.Columns[0].HeaderText = "包编码";
            ToolPackList_dataGridViewX.Columns[1].HeaderText = "包名称";
            ToolPackList_dataGridViewX.Columns[2].HeaderText = "工具数量";
            pagerControl1.DrawControl(Convert.ToInt32(Count));
        }
        private void Export_button_Click(object sender, EventArgs e)
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
                    NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("工具包列表");
                    // 添加表头
                    NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
                    for (int i = 0; i < ToolPackList_dataGridViewX.Columns.Count; i++)
                    {
                        var item = ToolPackList_dataGridViewX.Columns[i];
                        NPOI.SS.UserModel.ICell cell = row.CreateCell(i);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.HeaderText);
                    }
                    //获取数据
                    string packCode = ToolPackCode_textBox.Text;
                    string packName = ToolPackName_textBox.Text;
                    //获取分页的数据
                    resultList = _toolInfoService.GetPackInfoList(packCode,packName);
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
                        cell.SetCellValue(item.Number);
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
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--ToolPackView--Export_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }

        }
    }
}
