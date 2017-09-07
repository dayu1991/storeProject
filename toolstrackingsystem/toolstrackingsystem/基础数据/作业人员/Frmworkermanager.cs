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
using ViewEntity.toolstrackingsystem;
using dbentity.toolstrackingsystem;
using log4net;
using System.IO;
using System.Collections;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using toolstrackingsystem.loading;

namespace toolstrackingsystem
{
    public partial class FrmWorkerManager : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FormLogin));
        private IPersonManageService _personManageService;
        private int slectedIndex;
        public FrmWorkerManager()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void FrmWorkerManager_Load(object sender, EventArgs e)
        {
            _personManageService = Program.container.Resolve<IPersonManageService>() as PersonManageService;
            
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
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmWorkerManager--Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void PersonList_dataGridViewX_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
                LoadData();
        }
        private void LoadData()
        {
            PersonInfoEntity personInfo = new PersonInfoEntity();
            personInfo.PersonCode = PersonCode_textBox.Text;
            personInfo.PersonName = PersonName_textBox.Text;
            personInfo.IsReceive = Is_Receive_checkBox.Checked == true ? "1" : "0";
            //数据总记录数
            long Count;
            //获取分页的数据
            PersonList_dataGridViewX.DataSource = _personManageService.GetPersonInfoList(personInfo,pagerControl1.PageIndex,pagerControl1.PageSize,out Count);
            PersonList_dataGridViewX.MultiSelect = true;
            pagerControl1.DrawControl(Convert.ToInt32(Count));
            for (int i = 0; i < PersonList_dataGridViewX.Columns.Count; i++)
            {
                PersonList_dataGridViewX.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            PersonList_dataGridViewX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PersonList_dataGridViewX.Columns[0].HeaderText = "人员编码";
            PersonList_dataGridViewX.Columns[1].HeaderText = "人员名称";
            PersonList_dataGridViewX.Columns[2].HeaderText = "领用权限";
            PersonList_dataGridViewX.Columns[3].HeaderText = "备注";
            pagerControl1.DrawControl(Convert.ToInt32(Count));
        }
        private void Add_button_Click(object sender, EventArgs e)
        {
            try
            {
                t_PersonInfo personInfo = new t_PersonInfo();
                personInfo.PersonCode = PersonCode_Detail_textBox.Text;
                personInfo.PersonName = PersonName_Detail_textBox.Text;
                personInfo.IsReceive = Can_TakeOut_checkBox.Checked == true ? "1" : "0";
                personInfo.Remarks = Remark_textBox.Text;
                if (string.IsNullOrEmpty(personInfo.PersonCode))
                {
                    MessageBox.Show("人员编码不能为空");
                    PersonCode_Detail_textBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(personInfo.PersonName))
                {
                    MessageBox.Show("人员名称不能为空");
                    PersonName_Detail_textBox.Focus();
                    return;
                }
                if (_personManageService.GetPersonInfo(personInfo.PersonCode)!=null)
                {
                    MessageBox.Show("作业人员已存在，请重新输入");
                    PersonCode_Detail_textBox.Focus();
                    return;
                }
                if (_personManageService.InsertPersonInfo(personInfo))
                {
                    MessageBox.Show("添加成功");
                    PersonCode_Detail_textBox.Text = "";
                    PersonName_Detail_textBox.Text = "";
                    Can_TakeOut_checkBox.Checked = true;
                    Remark_textBox.Text = "";
                    Search_buttonX_Click(sender,e);
                }
                else
                {
                    MessageBox.Show("添加失败，请联系管理员");
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmWorkerManager--Add_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void PersonList_dataGridViewX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                slectedIndex = e.RowIndex;
                string personCode = PersonList_dataGridViewX.Rows[slectedIndex].Cells[0].Value.ToString();
                this.Tag = personCode;
            }
           
        }

        private void Edit_button_Click(object sender, EventArgs e)
        {
            try
            {
                string personCode = this.Tag.ToString();
                if (string.IsNullOrEmpty(personCode))
                {
                    MessageBox.Show("请选择需要修改的人员信息");
                    return;
                }
                FrmEditWorker frmeditworker = new FrmEditWorker();
                frmeditworker.Tag = personCode;
                frmeditworker.ShowDialog();
                if (frmeditworker.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show("修改成功");
                    Search_buttonX_Click(sender, e);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmWorkerManager--Edit_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }

        private void Print_button_Click(object sender, EventArgs e)
        {
            FrmPrint printFrm = new FrmPrint();
            PersonInfoEntity personInfo = new PersonInfoEntity();
            personInfo.PersonCode = PersonCode_textBox.Text;
            personInfo.PersonName = PersonName_textBox.Text;
            personInfo.IsReceive = Is_Receive_checkBox.Checked == true ? "1" : "0";
            printFrm.Tag = personInfo;
            printFrm.ShowDialog();
        }
        /// <summary>
        ///  导入excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pull_Out_button_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "Excel(*.xls)|*.xls|Excel(*.xlsx)|*.xlsx";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    //获取用户选择文件的后缀名
                    string extension = Path.GetExtension(fileDialog.FileName);
                    //声明允许的后缀名
                    string[] str = new string[] { ".xls", ".xlsx" };
                    if (!((IList)str).Contains(extension))
                    {
                        MessageBox.Show("仅能上传xls的文件！");
                    }
                    else
                    {
                        //获取用户选择的文件，并判断文件大小不能超过20K，fileInfo.Length是以字节为单位的
                        FileInfo fileInfo = new FileInfo(fileDialog.FileName);
                        if (fileInfo.Length > 20480000)
                        {
                            MessageBox.Show("上传的图片不能大于20000K");
                        }
                        else
                        {
                            //在这里就可以写获取到正确文件后的代码了
                            FileStream stream = fileInfo.Open(FileMode.Open, System.IO.FileAccess.Read);
                            //支持xls和xlsx格式的excel文件
                            IWorkbook workbook;
                            if (extension == ".xls")
                            {
                                workbook = new HSSFWorkbook(stream);
                            }
                            else if (extension == ".xlsx")
                            {
                                workbook = new XSSFWorkbook(stream);
                            }
                            else
                            {
                                MessageBox.Show("文件类型不对，只能导入xls,xlsx格式的文件"); ;
                                return;
                            }
                            if (workbook.NumberOfSheets <= 0) //表单数量
                            {
                                MessageBox.Show("文档没有数据");
                            }
                            ISheet sheet = workbook.GetSheetAt(0);
                            if (sheet == null)
                            {
                                MessageBox.Show("文档没有数据");
                                return;
                            }
                            IRow headerRow = sheet.GetRow(0);
                            if (headerRow == null)
                            {
                                MessageBox.Show("文档表头没有数据");
                                return;
                            }
                            int cellCount = headerRow.LastCellNum;
                            List<t_PersonInfo> personInfoList = new List<t_PersonInfo>();
                            for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum + 1; i++)
                            {
                                IRow row = sheet.GetRow(i);
                                if (row == null) //第一行为空
                                {
                                    if (i == 1)
                                    {
                                        MessageBox.Show("第一行数据为空");
                                    }
                                    continue;
                                }
                                var personInfo = new t_PersonInfo();
                                for (int j = row.FirstCellNum; j < cellCount; j++)
                                {
                                    var cellJ = row.GetCell(j);
                                    if (cellJ != null)
                                    {

                                        if (j == row.FirstCellNum)
                                        {
                                            personInfo.PersonCode = row.GetCell(j).ToString();
                                            if (string.IsNullOrEmpty(personInfo.PersonCode))
                                            {
                                                MessageBox.Show("人员编码不能为空");
                                                return;
                                            }
                                        }
                                        else if (j == row.FirstCellNum + 1)
                                        {
                                            personInfo.PersonName = row.GetCell(j).ToString();
                                            if (string.IsNullOrEmpty(personInfo.PersonName))
                                            {
                                                MessageBox.Show("人员名称不能为空");
                                                return;
                                            }
                                        }
                                        else if (j == row.FirstCellNum + 2)
                                        {
                                            personInfo.IsReceive = string.IsNullOrEmpty(row.GetCell(j).ToString()) ? "1" : row.GetCell(j).ToString();
                                            if (personInfo.IsReceive != "1" && personInfo.IsReceive != "0")
                                            {
                                                MessageBox.Show("领用权限格式不正确");
                                                return;
                                            }

                                        }
                                        else if (j == row.FirstCellNum + 3)
                                        {
                                            personInfo.Remarks = string.IsNullOrEmpty(row.GetCell(j).ToString()) ? "" : row.GetCell(j).ToString();
                                        }
                                    }
                                }
                                if (!string.IsNullOrEmpty(personInfo.PersonCode) && !string.IsNullOrEmpty(personInfo.PersonName))
                                {
                                    personInfoList.Add(personInfo);
                                }
                            }
                            if (personInfoList == null || personInfoList.Count <= 0)
                            {
                                MessageBox.Show("文档数据为空");
                                return;
                            }
                            bool IsSuccess = false;
                            LoadingHandler.Show(this, args =>
                            {
                                for (int i = 0; i < 100; i++)
                                {
                                    args.Execute(ex =>
                                    {
                                        IsSuccess = _personManageService.ImportExcel(personInfoList);
                                    });
                                }
                            });
                            if (IsSuccess)
                            {
                                MessageBox.Show("导入数据成功");
                                Search_buttonX_Click(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("导入数据失败");
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmWorkerManager--Pull_Out_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void Delete_button_Click(object sender, EventArgs e)
        {
            try
            {
                //string personCode = this.Tag.ToString();
                //if (string.IsNullOrEmpty(personCode))
                //{
                //    MessageBox.Show("请选择要删除的数据");
                //    return;
                //}
                //if (MessageBox.Show("您确定要删除“" + personCode + "”吗", "询问", MessageBoxButtons.OKCancel) == DialogResult.OK)
                //{
                //    if (_personManageService.DeletePersonInfo(personCode))
                //    {
                //        MessageBox.Show("删除成功");
                //        Search_buttonX_Click(sender, e);
                //    }
                //    else
                //    {
                //        MessageBox.Show("删除失败");
                //    }
                //}
                if (PersonList_dataGridViewX.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("请选择要删除的数据");
                    return;
                }
                bool IsSuccess = false;
                foreach (DataGridViewRow item in PersonList_dataGridViewX.SelectedRows)
                {
                    string personCode = item.Cells[0].Value.ToString();
                    IsSuccess = _personManageService.DeletePersonInfo(personCode);
                }
                if (IsSuccess)
                {
                    MessageBox.Show("删除成功");
                    Search_buttonX_Click(sender, e);
                }
                else {
                    MessageBox.Show("删除失败");
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmWorkerManager--Delete_button_Click", ex.Message, ex.StackTrace, ex.Source);
                MessageBox.Show("删除失败，请联系管理员");
            }
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Put_In_button_Click(object sender, EventArgs e)
        {
            try
            {
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
                    NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("人员列表");
                    // 添加表头
                    NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
                    for(int i=0;i<PersonList_dataGridViewX.Columns.Count;i++)
                    {
                        var item = PersonList_dataGridViewX.Columns[i];
                        NPOI.SS.UserModel.ICell cell = row.CreateCell(i);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.HeaderText);
                    }
                    //获取数据
                    List<PersonInfoEntity> personInfoEntity = new List<PersonInfoEntity>();
                    PersonInfoEntity personInfo = new PersonInfoEntity();
                    personInfo.PersonCode = PersonCode_textBox.Text;
                    personInfo.PersonName = PersonName_textBox.Text;
                    personInfo.IsReceive = Is_Receive_checkBox.Checked == true ? "1" : "0";
                    personInfoEntity = _personManageService.GetPersonInfoList(personInfo);
                    // 添加数据
                    for (int i = 0; i < personInfoEntity.Count; i++)
                    {
                        var item = personInfoEntity[i];
                        row = sheet.CreateRow(i + 1);
                        NPOI.SS.UserModel.ICell cell = row.CreateCell(0);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.PersonCode);
                        cell = row.CreateCell(1);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.PersonName);
                        cell = row.CreateCell(2);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.IsReceive=="1"?"是":"否");
                        cell = row.CreateCell(3);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.Remarks);
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
    }
}
