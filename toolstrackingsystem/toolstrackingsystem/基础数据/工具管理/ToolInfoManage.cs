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
using System.Threading;
using System.Net.Sockets;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using toolstrackingsystem.loading;
using ViewEntity.toolstrackingsystem;
namespace toolstrackingsystem
{
    public partial class ToolInfoManage : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(ToolInfoManage));
        private IUserManageService _userManageService;
        private IToolInfoService _toolInfoService;

        private int slectedIndex = 0;
        private string SelectedToolCode = "";
        //private Thread threadClient;
        //private Socket socketClient = Program.SocketClient;
        ////代理用来设置text的值 （实现另一个线程操作主线程的对象）
        //private delegate void SetTextCallback(string text);
        private string orderBy = "ToolCode";
        private string orderByType = "asc";

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
                TypeName = "全部"

            });
            blongs.AddRange(categoryBlongs);

            this.cbSearchBlong.DataSource = blongs;
            this.cbSearchBlong.DisplayMember = "TypeName";
            this.cbSearchBlong.ValueMember = "TypeName";

            var cates = new List<t_ToolType>();
            cates.Add(new t_ToolType
            {

                TypeName = "全部"

            });
            cates.AddRange(categoryCategory);

            this.cbSearchcategory.DataSource = cates;
            this.cbSearchcategory.DisplayMember = "TypeName";
            this.cbSearchcategory.ValueMember = "TypeName";
            pagerControl1.OnPageChanged += new EventHandler(pagerControl1_OnPageChanged);

            this.dtiCheckTime.Value = DateTime.Now.AddMonths(1);

            //threadClient = new Thread(RecMsg);

            ////将窗体线程设置为与后台同步
            //threadClient.IsBackground = true;

            ////启动线程
            //threadClient.Start();



            var selectLists = new List<DropDownCtrolObj>();

            selectLists.Add(new DropDownCtrolObj
            {
                SelectText = "无限制",
                SelectValue = "0"
            });
            selectLists.Add(new DropDownCtrolObj
            {
                SelectText = "已超时",
                SelectValue = "-1"
            });
            selectLists.Add(new DropDownCtrolObj
            {
                SelectText = "7天内",
                SelectValue = "7"
            });
            selectLists.Add(new DropDownCtrolObj
            {
                SelectText = "15天内",
                SelectValue = "15"
            });
            selectLists.Add(new DropDownCtrolObj
            {
                SelectText = "30天内",
                SelectValue = "30"
            });
            selectLists.Add(new DropDownCtrolObj
            {
                SelectText = "60天内",
                SelectValue = "60"
            });
            this.cbCheckTime.DataSource = selectLists;
            this.cbCheckTime.DisplayMember = "SelectText";
            this.cbCheckTime.ValueMember = "SelectValue";
            this.cbCheckTime.SelectedValue = "0";
            LoadData();
            DataGridView dgv = dataGridViewX1 as DataGridView;

            dgv.Columns[4].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var toolInfo = new t_ToolInfo();
                toolInfo.TypeName = this.cbEditBlong.SelectedValue.ToString();
                toolInfo.ChildTypeName = this.cbEditCategory.SelectedValue.ToString();

                toolInfo.ToolName = this.tbEditToolName.Text;
                toolInfo.Location = this.tbEditLocation.Text;
                toolInfo.Models = this.tbEditModel.Text;

                toolInfo.Remarks = this.tbEditMemo.Text;
                toolInfo.IsActive = "1";
                toolInfo.OptionPerson = LoginHelper.UserCode;
                toolInfo.ToolCode = this.tbEditCode.Text;
                toolInfo.IsRepaired = 0;
                toolInfo.IsBack = "1";

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
                else
                {
                    toolInfo.CheckTime = "";
                }
                bool isExists = _toolInfoService.IsExistsByCode(toolInfo.ToolCode);
                if (isExists)
                {
                    MessageBox.Show("工具编号已经存在！");
                    this.tbEditCode.Focus();
                    return;
                }

                var result = _toolInfoService.AddToolInfo(toolInfo, "录入");
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
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--toolInfoManage--btnAdd_Click", ex.Message, ex.StackTrace, ex.Source);

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
                blongValue = blongValue == "全部" ? "" : blongValue;
                string categoryValue = cbSearchcategory.SelectedValue.ToString();
                categoryValue = categoryValue == "全部" ? "" : categoryValue;

                string toolCode = tbSearchCode.Text;
                string toolName = tbSearchName.Text;
                long Count;
                bool is_Out_checkBox = this.Is_Out_checkBox.Checked;
                bool is_OutTime_checkBox = this.Is_OutTime_checkBox.Checked;
                bool is_ToRepare_checkBox = this.Is_ToRepare_checkBox.Checked;

                string cbCheckTime = this.cbCheckTime.SelectedValue.ToString();
                List<ToolInfoExtend> resultEntity = _toolInfoService.GetToolList(blongValue, categoryValue, toolCode,
                    toolName, is_Out_checkBox, is_OutTime_checkBox, is_ToRepare_checkBox, cbCheckTime, 
                    pagerControl1.PageIndex, pagerControl1.PageSize,orderBy,orderByType, out Count);
                pagerControl1.DrawControl(Convert.ToInt32(Count));
                this.dataGridViewX1.AutoGenerateColumns = false;
                this.dataGridViewX1.DataSource = resultEntity;
                this.dataGridViewX1.Refresh();
                //for (int i = 0; i < dataGridViewX1.Columns.Count; i++)
                //{
                //    dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                //}
                dataGridViewX1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dataGridViewX1.Rows[0].Selected = true;
                slectedIndex = 0;
                SelectedToolCode = dataGridViewX1.Rows[0].Cells[4].Value.ToString();


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
                    else
                    {
                        MessageBox.Show("该工具信息已经被删除！");
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--Tool--edit", ex.Message, ex.StackTrace, ex.Source);

            }
        }


        private void btnDelete_Click_1(object sender, EventArgs e)
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
                    MessageBoxButtons messButton = MessageBoxButtons.OKCancel;

                    DialogResult dr = MessageBox.Show(string.Format("您确认要删除编号为:{0} 的工具吗?", SelectedToolCode), "删除确认", messButton);
                    if (dr == DialogResult.OK)//如果点击“确定”按钮
                    {
                        _toolInfoService.DelToolByCode(SelectedToolCode);
                        MessageBox.Show("删除成功");
                        LoadData();
                    }

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
                    NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("工具列表");
                    // 添加表头
                    NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
                    for (int i = 0; i < dataGridViewX1.Columns.Count; i++)
                    {

                        var item = dataGridViewX1.Columns[i];
                        NPOI.SS.UserModel.ICell cell = row.CreateCell(i);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.HeaderText);
                    }
                    //获取数据
                    string blongValue = cbSearchBlong.SelectedValue.ToString();
                    string categoryValue = cbSearchcategory.SelectedValue.ToString();
                    blongValue = blongValue == "全部" ? "" : blongValue;
                    categoryValue = categoryValue == "全部" ? "" : categoryValue;

                    string toolCode = tbSearchCode.Text;
                    string toolName = tbSearchName.Text;
                    List<t_ToolInfo> entitys = _toolInfoService.GetToolList(blongValue, categoryValue, toolCode, toolName);
                    // 添加数据
                    for (int i = 0; i < entitys.Count; i++)
                    {
                        var item = entitys[i];
                        row = sheet.CreateRow(i + 1);
                        row = sheet.CreateRow(i + 1);
                        NPOI.SS.UserModel.ICell cell = row.CreateCell(0);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.TypeName);
                        cell = row.CreateCell(1);
                        cell = row.CreateCell(1);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.ChildTypeName);
                        cell = row.CreateCell(2);
                        cell = row.CreateCell(2);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.PackCode);
                        cell = row.CreateCell(3);
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
                        cell.SetCellValue(item.Models);

                        cell = row.CreateCell(7);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.Location);

                        cell = row.CreateCell(8);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.Remarks);
                        //            if (item.CheckTime != null)
                        cell = row.CreateCell(9);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.CheckTime);

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
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--ToolInfoManage--ExcelOutBtn_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void ExcelIn_button_Click(object sender, EventArgs e)
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
                    if (!str.Contains(extension))
                    {
                        MessageBox.Show("仅能上传xls的文件！");
                    }
                    else
                    {
                        //获取用户选择的文件，并判断文件大小不能超过20K，fileInfo.Length是以字节为单位的
                        FileInfo fileInfo = new FileInfo(fileDialog.FileName);
                        if (fileInfo.Length > 20480000)
                        {
                            MessageBox.Show("上传的文件不能大于20000K");
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
                            List<t_ToolInfo> InfoList = new List<t_ToolInfo>();
                            var cates = _toolInfoService.GetCategoryByClassify(0);
                            List<t_ToolType> blongCates = cates.Where(v => v.classification == 1) == null ? new List<t_ToolType>() : cates.Where(v => v.classification == 1).ToList();
                            List<t_ToolType> cateGoryCates = cates.Where(v => v.classification == 2) == null ? new List<t_ToolType>() : cates.Where(v => v.classification == 2).ToList();
                            List<string> noReturnToolCodes = _toolInfoService.GetToolNotReturn();

                            for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum + 1; i++)
                            {
                                IRow row = sheet.GetRow(i);

                                var toolInfo = new t_ToolInfo();
                                bool checkSuccess = true;
                                for (int j = row.FirstCellNum; j < cellCount; j++)
                                {
                                    var cellJ = row.GetCell(j);
                                    if (cellJ != null)
                                    {

                                        if (j == row.FirstCellNum)// 配属
                                        {
                                            var blongName = row.GetCell(j).ToString().Trim();
                                            if (string.IsNullOrWhiteSpace(blongName))
                                            {
                                                checkSuccess = false;
                                                break;
                                            }
                                            var haveCate = blongCates.FirstOrDefault(v => v.TypeName == blongName);
                                            if (haveCate != null)
                                            {
                                                toolInfo.TypeName = blongName;
                                            }
                                            else
                                            {
                                                //增加配属
                                                var toolType = new t_ToolType();
                                                toolType.TypeName = blongName;
                                                toolType.OptionPerson = LoginHelper.UserCode;
                                                toolType.classification = 1;
                                                _toolInfoService.AddCateGory(toolType);
                                                blongCates.Add(toolType);
                                                toolInfo.TypeName = blongName;

                                            }
                                        }
                                        else if (j == row.FirstCellNum + 1) //分类
                                        {
                                            var thisValue = row.GetCell(j).ToString().Trim();
                                            if (string.IsNullOrWhiteSpace(thisValue))
                                            {
                                                checkSuccess = false;
                                                break;
                                            }
                                            var haveCate = cateGoryCates.FirstOrDefault(v => v.TypeName == thisValue);
                                            if (haveCate != null)
                                            {
                                                toolInfo.ChildTypeName = thisValue;
                                            }
                                            else
                                            {
                                                //增加分类
                                                var toolType = new t_ToolType();
                                                toolType.TypeName = thisValue;
                                                toolType.OptionPerson = LoginHelper.UserCode;
                                                toolType.classification = 2;
                                                _toolInfoService.AddCateGory(toolType);
                                                cateGoryCates.Add(toolType);
                                                toolInfo.ChildTypeName = thisValue;

                                            }
                                        }
                                        else if (j == row.FirstCellNum + 2)// 包编码
                                        {
                                            var thisValue = row.GetCell(j).ToString().Trim();
                                            toolInfo.PackCode = thisValue;
                                        }
                                        else if (j == row.FirstCellNum + 3)// 包名称
                                        {
                                            var thisValue = row.GetCell(j).ToString().Trim();
                                            toolInfo.PackName = thisValue;
                                        }
                                        else if (j == row.FirstCellNum + 4)//编码
                                        {
                                            var thisValue = row.GetCell(j).ToString().Trim();
                                            if (_toolInfoService.IsExistsByCode(thisValue))
                                            {
                                                checkSuccess = false;
                                                break;
                                            }
                                            toolInfo.ToolCode = thisValue;
                                        }
                                        else if (j == row.FirstCellNum + 5)//名称
                                        {
                                            var thisValue = row.GetCell(j).ToString().Trim();
                                            toolInfo.ToolName = thisValue;
                                        }
                                        else if (j == row.FirstCellNum + 6)//型号
                                        {
                                            var thisValue = row.GetCell(j).ToString().Trim();
                                            toolInfo.Models = thisValue;
                                        }
                                        else if (j == row.FirstCellNum + 7)//位置
                                        {
                                            var thisValue = row.GetCell(j).ToString().Trim();
                                            toolInfo.Location = thisValue;
                                        }
                                        else if (j == row.FirstCellNum + 8)//备注
                                        {
                                            var thisValue = row.GetCell(j).ToString().Trim();
                                            toolInfo.Remarks = thisValue;
                                        }
                                        else if (j == row.FirstCellNum + 9)//下次检测时间
                                        {
                                            var thisValue = row.GetCell(j).ToString().Trim();
                                            DateTime dt;
                                            if (DateTime.TryParse(thisValue, out dt))
                                            {
                                                toolInfo.CheckTime = dt.ToString("yyyy-MM-dd HH:mm:ss");
                                            }
                                            else
                                            {
                                                toolInfo.CheckTime = "";
                                            }
                                        }
                                    }
                                }

                                if (checkSuccess && !string.IsNullOrEmpty(toolInfo.ToolCode) && !string.IsNullOrEmpty(toolInfo.TypeName) && !string.IsNullOrEmpty(toolInfo.ChildTypeName))
                                {
                                    toolInfo.IsActive = "1";
                                    toolInfo.OptionPerson = LoginHelper.UserCode;
                                    toolInfo.IsRepaired = 0;
                                    if (noReturnToolCodes.Contains(toolInfo.ToolCode))  //同步未归还的数据状态
                                    {
                                        toolInfo.IsBack = "0";
                                    }
                                    else {
                                        toolInfo.IsBack = "1";
                                    }
                                    InfoList.Add(toolInfo);
                                }
                            }


                            if (InfoList == null || InfoList.Count <= 0)
                            {
                                MessageBox.Show("文档数据为空");
                                return;
                            }
                            //bool IsSuccess = false;
                            //LoadingHandler.Show(this, args =>
                            //{
                            //    for (int i = 0; i < 100; i++)
                            //    {
                            //        args.Execute(ex =>
                            //        {
                            //            IsSuccess = _toolInfoService.ImportToolInfoExcel(InfoList);
                            //            //if (_toolInfoService.ImportToolInfoExcel(InfoList))
                            //            //{
                            //            //    MessageBox.Show(string.Format("成功导入{0}条数据", InfoList.Count));
                            //            //    Search_buttonX_Click(sender, e);
                            //            //}
                            //            //else
                            //            //{
                            //            //    MessageBox.Show("导入数据失败");
                            //            //    return;
                            //            //}
                            //        });
                            //        System.Threading.Thread.Sleep(50);
                            //    }
                            //});
                            //if (IsSuccess)
                            //{
                            //    MessageBox.Show(string.Format("成功导入{0}条数据", InfoList.Count));
                            //    Search_buttonX_Click(sender, e);
                            //}
                            //else {
                            //    MessageBox.Show("导入数据失败");
                            //    return;
                            //}
                            if (_toolInfoService.ImportToolInfoExcel(InfoList))
                            {
                                MessageBox.Show(string.Format("成功导入{0}条数据", InfoList.Count));
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
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--toolInfoManage--ExcelIn_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }

        private void btnAddBlong_Click(object sender, EventArgs e)
        {
            DigAddBlongTo dig = new DigAddBlongTo();
            dig.ShowDialog();
            if (dig.DialogResult == DialogResult.OK)
            {
                ToolInfoManage_Load(sender, e);
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


        #region 接收服务端发来信息的方法
        //private void RecMsg()
        //{
        //    while (true) //持续监听服务端发来的消息
        //    {
        //        if (socketClient != null && socketClient.Connected && socketClient.Available > 0)
        //        {
        //            //定义一个1024*200的内存缓冲区 用于临时性存储接收到的信息
        //            byte[] arrRecMsg = new byte[1024 * 200];

        //            //将客户端套接字接收到的数据存入内存缓冲区, 并获取其长度
        //            int length = socketClient.Receive(arrRecMsg);

        //            string strData = Encoding.Default.GetString(arrRecMsg, 0, length);
        //            var totalText = strData;
        //            if (!string.IsNullOrWhiteSpace(totalText))
        //            {
        //                SetText(totalText);

        //            }
        //        }
        //        Thread.Sleep(200);
        //    }
        //}
        //private void SetText(string text)
        //{
        //    //获取当前有焦点的控件，然后给当前控件赋值
        //    Control ctl = this.ActiveControl;
        //    if (ctl is TextBox) //只给textbox赋值
        //    {
        //        // InvokeRequired需要比较调用线程ID和创建线程ID
        //        // 如果它们不相同则返回true
        //        if (ctl.InvokeRequired)
        //        {
        //            SetTextCallback d = new SetTextCallback(SetText);
        //            this.Invoke(d, new object[] { text });
        //        }
        //        else
        //        {
        //            ctl.Text = text;
        //        }
        //    }
        //}

        #endregion

        private void Print_button_Click(object sender, EventArgs e)
        {
            FrmPrintToolInfo printFrm = new FrmPrintToolInfo();
            ToolInfoConditionExtend toolExtend = new ToolInfoConditionExtend();
            string blongValue = cbSearchBlong.SelectedValue.ToString();
            toolExtend.blongValue = blongValue == "全部" ? "" : blongValue;
            string categoryValue = cbSearchcategory.SelectedValue.ToString();
            toolExtend.categoryValue = categoryValue == "全部" ? "" : categoryValue;

            toolExtend.toolCode = tbSearchCode.Text;
            toolExtend.toolName = tbSearchName.Text;
            toolExtend.IsCheck = this.Is_Out_checkBox.Checked;
            toolExtend.IsOut = this.Is_OutTime_checkBox.Checked;
            toolExtend.IsRepair = this.Is_ToRepare_checkBox.Checked;

            toolExtend.CheckTime = this.cbCheckTime.SelectedValue.ToString();

            printFrm.Tag = toolExtend;
            printFrm.ShowDialog();
        }

        private void Is_OutTime_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Is_OutTime_checkBox.Checked)
            {
                this.Is_Out_checkBox.Checked = true;
            }
        }

        private void Is_ToRepare_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Is_ToRepare_checkBox.Checked)
            {
                this.Is_Out_checkBox.Checked = false;
                this.Is_OutTime_checkBox.Checked = false;

            }
        }

        private void tbSearchCode_TextChanged(object sender, EventArgs e)
        {
            var codeText = this.tbSearchCode.Text;
            if (!string.IsNullOrWhiteSpace(codeText))
            {
                this.cbSearchBlong.SelectedValue = "全部";
                this.cbSearchcategory.SelectedValue = "全部";
            }
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                slectedIndex = e.RowIndex;
                SelectedToolCode = this.dataGridViewX1.Rows[slectedIndex].Cells[4].Value.ToString();
                btnEdit_Click(sender, e);
            }
        }

        private void btnToRepaire_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SelectedToolCode))
                {
                    MessageBox.Show("请先选中一条记录");
                    return;
                }
                else
                {
                    var toolInfo = _toolInfoService.GetToolByCode(SelectedToolCode);
                    {
                        if (toolInfo == null||string.IsNullOrWhiteSpace(toolInfo.ToolCode))
                        {
                            MessageBox.Show("此工具已经被删除");
                            return;
                        }
                        if (toolInfo.IsRepaired == 1)
                        {
                            MessageBox.Show("此工具已经被送修，不能重复送修！");
                            return;
                        }
                        if (toolInfo.IsBack == "0")
                        {
                            MessageBox.Show("此工具已经被借出，请归还后再送修！");
                            return;
                        }
                        MessageBoxButtons messButton = MessageBoxButtons.OKCancel;

                        DialogResult dr = MessageBox.Show(string.Format("您确认要送修编号为:{0} 的工具吗?", SelectedToolCode), "送修确认", messButton);
                        if (dr == DialogResult.OK)//如果点击“确定”按钮
                        {
                            bool isSuccess = _toolInfoService.ToRepaireTool(toolInfo);
                            MessageBox.Show("送修成功！");
                            LoadData();
                        }

                    }
                   

                }
            }
            catch (Exception ex)
            {

                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--Tool--Songxiu", ex.Message, ex.StackTrace, ex.Source);
            }
        }

        private void dataGridViewX1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.Programmatic)
            {
                string columnBindingName = dgv.Columns[e.ColumnIndex].DataPropertyName;
                switch (dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection)
                {
                    case System.Windows.Forms.SortOrder.None:
                    case System.Windows.Forms.SortOrder.Ascending:
                        orderBy = columnBindingName;
                        orderByType="desc";
                        LoadData();
                        dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Descending;
                        break;
                    case System.Windows.Forms.SortOrder.Descending:
                        orderBy = columnBindingName;
                        orderByType = "asc";
                        LoadData();
                        dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;
                        break;
                }
            }                  
        }

    }
}
