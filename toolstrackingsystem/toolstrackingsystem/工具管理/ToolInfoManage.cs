using DevComponents.DotNetBar;
using log4net;
using service.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using dbentity.toolstrackingsystem;
using common.toolstrackingsystem;
using ViewEntity.toolstrackingsystem.view;
using System.IO;
using NPOI.SS.UserModel;
namespace toolstrackingsystem
{
    public partial class ToolInfoManage : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(ToolInfoManage));
        private IUserManageService _userManageService;
        private IToolInfoService _toolInfoService;

        private int slectedIndex = 0;
        private string SelectedToolCode ="";


        public ToolInfoManage()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }


        private void ToolInfoManage_Load(object sender, EventArgs e)
        {
            
            _userManageService = Program.container.Resolve<IUserManageService>();
            _toolInfoService = Program.container.Resolve<IToolInfoService>();
            var categorys = _toolInfoService.GetCategoryByClassify(0);
            var categoryBlongs = categorys.Where(v => v.classification == 1).Any() ? categorys.Where(v => v.classification == 1).ToList() : new List<t_ToolType>();
            var categoryCategory = categorys.Where(v => v.classification == 2).Any() ? categorys.Where(v => v.classification == 2).ToList() : new List<t_ToolType>();
            this.cbEditBlong.DataSource = categoryBlongs;
            this.cbEditBlong.DisplayMember = "TypeName";
            this.cbEditBlong.ValueMember = "TypeName";


            this.cbEditCategory.DataSource = categoryCategory;
            this.cbEditCategory.DisplayMember = "TypeName";
            this.cbEditCategory.ValueMember = "TypeName";

            var blongs = new List<t_ToolType>();
            blongs.Add(new t_ToolType
            {
                TypeName = "请选择"

            });
            blongs.AddRange(categoryBlongs);

            this.cbSearchBlong.DataSource = blongs;
            this.cbSearchBlong.DisplayMember = "TypeName";
            this.cbSearchBlong.ValueMember = "TypeName";

            var cates = new List<t_ToolType>();
            cates.Add(new t_ToolType
            {

                TypeName = "请选择"

            });
            cates.AddRange(categoryCategory);

            this.cbSearchcategory.DataSource = cates;
            this.cbSearchcategory.DisplayMember = "TypeName";
            this.cbSearchcategory.ValueMember = "TypeName";
            pagerControl1.OnPageChanged += new EventHandler(pagerControl1_OnPageChanged);

            this.dtiCheckTime.Value = DateTime.Now.AddMonths(1);
            LoadData();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var toolInfo = new t_ToolInfo();
                toolInfo.TypeName = this.cbEditBlong.SelectedValue.ToString();
                toolInfo.ChildTypeName =this.cbEditCategory.SelectedValue.ToString();

                toolInfo.ToolName = this.tbEditToolName.Text;
                toolInfo.Location = this.tbEditLocation.Text;
                toolInfo.Models = this.tbEditModel.Text;

                toolInfo.Remarks = this.tbEditMemo.Text;
                toolInfo.IsActive ="1";
                toolInfo.OptionPerson = LoginHelper.UserCode;
                toolInfo.ToolCode = this.tbEditCode.Text;

                if (string.IsNullOrWhiteSpace(toolInfo.ToolCode))
                {
                    MessageBox.Show("工具编号必须填写！");
                    this.tbEditCode.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(toolInfo.ToolName))
                {
                    MessageBox.Show("工具名称必须填写！");
                    this.tbEditToolName.Focus();
                    return;
                }
                if (cbEditCheckTime.Checked == true)
                {
                    if (dtiCheckTime.Value < DateTime.Now)
                    {
                        MessageBox.Show("下次检测时间不能小于当前时间！");
                        return;

                    }

                    toolInfo.CheckTime = dtiCheckTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                }
                bool isExists = _toolInfoService.IsExistsByCode(toolInfo.ToolCode);
                if (isExists)
                {
                    MessageBox.Show("工具编号已经存在！");
                    this.tbEditCode.Focus();
                    return;
                }

                var result = _toolInfoService.AddToolInfo(toolInfo);
                if (result > 0)
                {
                    LoadData();

                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--RrmEditRoleInfo--Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);

            }


        }

        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void Search_buttonX_Click(object sender, EventArgs e)
        {
            LoadData();


        }

        private void LoadData()
        {
            try
            {

                string blongValue = cbSearchBlong.SelectedValue.ToString();
                blongValue = blongValue == "请选择" ? "" : blongValue;
                string categoryValue = cbSearchcategory.SelectedValue.ToString();
                categoryValue = categoryValue == "请选择" ? "" : categoryValue;

                string toolCode = tbSearchCode.Text;
                string toolName = tbSearchName.Text;
                long Count;

                List<t_ToolInfo> resultEntity = _toolInfoService.GetToolList(blongValue, categoryValue, toolCode, toolName, pagerControl1.PageIndex, pagerControl1.PageSize, out Count);
                pagerControl1.DrawControl(Convert.ToInt32(Count));
                this.dataGridViewX1.AutoGenerateColumns = false;
                this.dataGridViewX1.DataSource = resultEntity;
                this.dataGridViewX1.Rows[0].Selected = true;
                slectedIndex = 0;
                SelectedToolCode =dataGridViewX1.Rows[0].Cells[4].Value.ToString();

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--Tool--Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                slectedIndex = e.RowIndex;
                SelectedToolCode = this.dataGridViewX1.Rows[slectedIndex].Cells[4].Value.ToString();
            }

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.tbEditToolName.Text = "";
            this.tbEditLocation.Text = "";
            this.tbEditModel.Text = "";
            this.tbEditMemo.Text = "";
            this.tbEditCode.Text = "";
            this.cbEditCheckTime.Checked = false;
            this.dtiCheckTime.Value = DateTime.Now.AddMonths(1);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SelectedToolCode))
                {
                    MessageBox.Show("请选中一条记录");
                    return;
                }
                else
                {
                    t_ToolInfo toolEntity = _toolInfoService.GetToolByCode(SelectedToolCode);
                    if (toolEntity != null)
                    {
                        DlgEditTool formEdit = new DlgEditTool();
                        formEdit.Tag = toolEntity;
                        formEdit.ShowDialog();
                        if (formEdit.DialogResult == DialogResult.OK)
                        {
                            LoadData();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--Tool--edit", ex.Message, ex.StackTrace, ex.Source);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SelectedToolCode))
                {
                    MessageBox.Show("请选中一条记录");
                    return;
                }
                else
                {
                    bool toolEntity = _toolInfoService.DelToolByCode(SelectedToolCode);
                    LoadData();
                }
            }
            catch (Exception ex)
            {

                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--Tool--delete", ex.Message, ex.StackTrace, ex.Source);
            }
        }

        private void dataGridViewX1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var num = (pagerControl1.PageIndex - 1) * pagerControl1.PageSize + 1 + e.Row.Index;
            e.Row.HeaderCell.Value = string.Format("{0}", num);
        }

        private void ExcelOut_button_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    SaveFileDialog fileDialog = new SaveFileDialog();
            //    fileDialog.Filter = "Excel(*.xls)|*.xls|Excel(*.xlsx)|*.xlsx";
            //    if (fileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        NPOI.SS.UserModel.IWorkbook book = null;
            //        if (fileDialog.FilterIndex == 1)
            //        {
            //            book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //        }
            //        else
            //        {
            //            book = new NPOI.XSSF.UserModel.XSSFWorkbook();
            //        }
            //        NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("工具列表");
            //        // 添加表头
            //        NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
            //        for (int i = 1; i < dataGridViewX1.Columns.Count; i++)
            //        {

            //            var item = dataGridViewX1.Columns[i];
            //            NPOI.SS.UserModel.ICell cell = row.CreateCell(i - 1);
            //            cell.SetCellType(NPOI.SS.UserModel.CellType.String);
            //            cell.SetCellValue(item.HeaderText);
            //        }
            //        //获取数据
            //        int blongValue = int.Parse(cbSearchBlong.SelectedValue.ToString());
            //        int categoryValue = int.Parse(cbSearchcategory.SelectedValue.ToString());
            //        string toolCode = tbSearchCode.Text;
            //        string toolName = tbSearchName.Text;
            //        List<t_ToolInfo> entitys = _toolInfoService.GetToolList(blongValue, categoryValue, toolCode, toolName);
            //        // 添加数据
            //        for (int i = 0; i < entitys.Count; i++)
            //        {
            //            var item = entitys[i];
            //            row = sheet.CreateRow(i + 1);
            //            NPOI.SS.UserModel.ICell cell = row.CreateCell(0);
            //            cell.SetCellType(NPOI.SS.UserModel.CellType.String);
            //            cell.SetCellValue(item.ToolBelongName);
            //            cell = row.CreateCell(1);
            //            cell.SetCellType(NPOI.SS.UserModel.CellType.String);
            //            cell.SetCellValue(item.ToolCategoryName);
            //            cell = row.CreateCell(2);
            //            cell.SetCellType(NPOI.SS.UserModel.CellType.String);
            //            cell.SetCellValue(item.PackCode);
            //            cell = row.CreateCell(3);
            //            cell.SetCellType(NPOI.SS.UserModel.CellType.String);
            //            cell.SetCellValue(item.PackName);

            //            cell = row.CreateCell(4);
            //            cell.SetCellType(NPOI.SS.UserModel.CellType.String);
            //            cell.SetCellValue(item.ToolCode);

            //            cell = row.CreateCell(5);
            //            cell.SetCellType(NPOI.SS.UserModel.CellType.String);
            //            cell.SetCellValue(item.ToolName);

            //            cell = row.CreateCell(6);
            //            cell.SetCellType(NPOI.SS.UserModel.CellType.String);
            //            cell.SetCellValue(item.ToolModels);

            //            cell = row.CreateCell(7);
            //            cell.SetCellType(NPOI.SS.UserModel.CellType.String);
            //            cell.SetCellValue(item.Location);

            //            cell = row.CreateCell(8);
            //            cell.SetCellType(NPOI.SS.UserModel.CellType.String);
            //            cell.SetCellValue(item.ToolRemarks);
            //            if (item.CheckTime != null)
            //            {
            //                cell = row.CreateCell(9);
            //                cell.SetCellType(NPOI.SS.UserModel.CellType.String);
            //                cell.SetCellValue((item.CheckTime ?? DateTime.Now).ToString("yyyy-MM-dd"));
            //            }

            //        }
            //        // 写入 
            //        System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //        book.Write(ms);
            //        book = null;
            //        using (FileStream fs = new FileStream(fileDialog.FileName, FileMode.Create, FileAccess.Write))
            //        {
            //            byte[] data = ms.ToArray();
            //            fs.Write(data, 0, data.Length);
            //            fs.Flush();
            //        }
            //        ms.Close();
            //        ms.Dispose();
            //        MessageBox.Show("导出成功");
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--ToolInfoManage--ExcelOutBtn_Click", ex.Message, ex.StackTrace, ex.Source);
            //}
        }

        private void ExcelIn_button_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    OpenFileDialog fileDialog = new OpenFileDialog();
            //    fileDialog.Filter = "Excel(*.xls)|*.xls|Excel(*.xlsx)|*.xlsx";
            //    if (fileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        //获取用户选择文件的后缀名
            //        string extension = Path.GetExtension(openFileDialog.FileName);
            //        //声明允许的后缀名
            //        string[] str = new string[] { ".xls", ".xlsx" };
            //        if (!((IList)str).Contains(extension))
            //        {
            //            MessageBox.Show("仅能上传xls的文件！");
            //        }
            //        else
            //        {
            //            //获取用户选择的文件，并判断文件大小不能超过20K，fileInfo.Length是以字节为单位的
            //            FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
            //            if (fileInfo.Length > 20480)
            //            {
            //                MessageBox.Show("上传的图片不能大于20K");
            //            }
            //            else
            //            {
            //                //在这里就可以写获取到正确文件后的代码了
            //                FileStream stream = fileInfo.Open(FileMode.Open, System.IO.FileAccess.Read);
            //                //支持xls和xlsx格式的excel文件
            //                IWorkbook workbook;
            //                if (extension == ".xls")
            //                {
            //                    workbook = new HSSFWorkbook(stream);
            //                }
            //                else if (extension == ".xlsx")
            //                {
            //                    workbook = new XSSFWorkbook(stream);
            //                }
            //                else
            //                {
            //                    MessageBox.Show("文件类型不对，只能导入xls,xlsx格式的文件"); ;
            //                    return;
            //                }
            //                if (workbook.NumberOfSheets <= 0) //表单数量
            //                {
            //                    MessageBox.Show("文档没有数据");
            //                }
            //                ISheet sheet = workbook.GetSheetAt(0);
            //                if (sheet == null)
            //                {
            //                    MessageBox.Show("文档没有数据");
            //                    return;
            //                }
            //                IRow headerRow = sheet.GetRow(0);
            //                if (headerRow == null)
            //                {
            //                    MessageBox.Show("文档表头没有数据");
            //                    return;
            //                }
            //                int cellCount = headerRow.LastCellNum;
            //                List<t_ToolInfo> InfoList = new List<t_ToolInfo>();
            //                var cates = _toolInfoService.GetCategoryByClassify(0);
            //                List<t_ToolType> blongCates = cates.Where(v => v.Classification = 1) == null ? new List<t_ToolType>() : cates.Where(v => v.Classification = 1).ToList();
            //                List<t_ToolType> cateGoryCates = cates.Where(v => v.Classification = 2) == null ? new List<t_ToolType>() : cates.Where(v => v.Classification = 2).ToList();

            //                bool isCheckSuccess = true;
            //                string alertMsg = "";

            //                for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum + 1; i++)
            //                {
            //                    IRow row = sheet.GetRow(i);
            //                    if (row == null)
            //                    {
            //                        if (i == (sheet.FirstRowNum + 1))
            //                        {
            //                            isCheckSuccess = false;
            //                            alertMsg += string.Format("第{0}行不能为空", i);
            //                            break;
            //                        }
            //                        break;
            //                    }
            //                    var toolInfo = new t_ToolInfo();
            //                    for (int j = row.FirstCellNum; j < cellCount; j++)
            //                    {
            //                        var cellJ = row.GetCell(j);
            //                        if (cellJ != null)
            //                        {
            //                            switch()

            //                            if (j == row.FirstCellNum)
            //                            {
            //                                var blongName = row.GetCell(j).ToString().Trim();
            //                                if (string.IsNullOrWhiteSpace(blongName))
            //                                {
            //                                    alertMsg += string.Format("第{0}行配属不能为空", i);
            //                                    isCheckSuccess = false;
            //                                    return;
            //                                }
            //                                var haveCate = blongCates.FirstOrDefault(v=>v.CategoryName=blongName);
            //                                if (haveCate != null && haveCate.CategoryId > 0)
            //                                {
            //                                    toolInfo = row.GetCell(j).ToString();
            //                                }
            //                                else { 
                                            
            //                                }
            //                                if (string.IsNullOrEmpty(personInfo.PersonCode))
            //                                {
            //                                    MessageBox.Show("人员编码不能为空");
            //                                    return;
            //                                }
            //                            }
            //                            else if (j == row.FirstCellNum + 1)
            //                            {
            //                                personInfo.PersonName = row.GetCell(j).ToString();
            //                                if (string.IsNullOrEmpty(personInfo.PersonName))
            //                                {
            //                                    MessageBox.Show("人员名称不能为空");
            //                                    return;
            //                                }
            //                            }
            //                            else if (j == row.FirstCellNum + 2)
            //                            {
            //                                personInfo.IsReceive = string.IsNullOrEmpty(row.GetCell(j).ToString()) ? "1" : row.GetCell(j).ToString();
            //                                if (personInfo.IsReceive != "1" && personInfo.IsReceive != "0")
            //                                {
            //                                    MessageBox.Show("领用权限格式不正确");
            //                                    return;
            //                                }

            //                            }
            //                            else if (j == row.FirstCellNum + 3)
            //                            {
            //                                personInfo.Remarks = string.IsNullOrEmpty(row.GetCell(j).ToString()) ? "" : row.GetCell(j).ToString();
            //                            }
            //                        }
            //                    }
            //                    if (!string.IsNullOrEmpty(personInfo.PersonCode) && !string.IsNullOrEmpty(personInfo.PersonName))
            //                    {
            //                        personInfoList.Add(personInfo);
            //                    }
            //                }
            //                if (personInfoList == null || personInfoList.Count <= 0)
            //                {
            //                    MessageBox.Show("文档数据为空");
            //                    return;
            //                }
            //                if (_personManageService.ImportExcel(personInfoList))
            //                {
            //                    MessageBox.Show("导入数据成功");
            //                    Search_buttonX_Click(sender, e);
            //                }
            //                else
            //                {
            //                    MessageBox.Show("导入数据失败");
            //                    return;
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmWorkerManager--Pull_Out_button_Click", ex.Message, ex.StackTrace, ex.Source);
            //}
        }

        private void btnAddBlong_Click(object sender, EventArgs e)
        {
            DigAddBlongTo dig = new DigAddBlongTo();
            dig.ShowDialog();
            if (dig.DialogResult == DialogResult.OK)
            {
                ToolInfoManage_Load(sender,e);
            }
        }

        private void btnAddCate_Click(object sender, EventArgs e)
        {
            DlgAddCategory dig = new DlgAddCategory();
            dig.ShowDialog();
            if (dig.DialogResult == DialogResult.OK)
            {
                ToolInfoManage_Load(sender, e);
            }
        }

    }
}
