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
namespace toolstrackingsystem
{
    public partial class ToolInfoManage : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(ToolInfoManage));
        private IUserManageService _userManageService;
        private IToolInfoService _toolInfoService;

        private int slectedIndex = 0;
        private long ToolId = 0;


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
            var categoryBlongs = categorys.Where(v => v.Classification == 1).Any() ? categorys.Where(v => v.Classification == 1).ToList() : new List<t_ToolCategoryInfo>();
            var categoryCategory = categorys.Where(v => v.Classification == 2).Any() ? categorys.Where(v => v.Classification == 2).ToList() : new List<t_ToolCategoryInfo>();
            this.cbEditBlong.DataSource = categoryBlongs;
            this.cbEditBlong.DisplayMember = "CategoryName";
            this.cbEditBlong.ValueMember = "CategoryId";


            this.cbEditCategory.DataSource = categoryCategory;
            this.cbEditCategory.DisplayMember = "CategoryName";
            this.cbEditCategory.ValueMember = "CategoryId";

            var blongs = new List<t_ToolCategoryInfo>();
            blongs.Add(new t_ToolCategoryInfo
            {
                CategoryId = 0,
                CategoryName="请选择"
            
            });
            blongs.AddRange(categoryBlongs);

            this.cbSearchBlong.DataSource = blongs;
            this.cbSearchBlong.DisplayMember = "CategoryName";
             this.cbSearchBlong.ValueMember = "CategoryId";

             var cates = new List<t_ToolCategoryInfo>();
             cates.Add(new t_ToolCategoryInfo
             {
                 CategoryId = 0,
                 CategoryName = "请选择"

             });
             cates.AddRange(categoryCategory);

             this.cbSearchcategory.DataSource = cates;
            this.cbSearchcategory.DisplayMember = "CategoryName";
             this.cbSearchcategory.ValueMember = "CategoryId";
             pagerControl1.OnPageChanged += new EventHandler(pagerControl1_OnPageChanged);

             this.dtiCheckTime.Value = DateTime.Now.AddMonths(1); 
             LoadData();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var toolInfo = new t_ToolInfo();
                toolInfo.ToolBelongId = int.Parse(this.cbEditBlong.SelectedValue.ToString());
                toolInfo.ToolBelongName = this.cbEditBlong.Text;
                toolInfo.ToolCategoryId = int.Parse(this.cbEditCategory.SelectedValue.ToString());
                toolInfo.ToolCategoryName = this.cbEditCategory.Text;

                toolInfo.ToolName = this.tbEditToolName.Text;
                toolInfo.Location = this.tbEditLocation.Text;
                toolInfo.ToolModels = this.tbEditModel.Text;

                toolInfo.ToolRemarks = this.tbEditMemo.Text;
                toolInfo.AddTime = DateTime.Now;
                toolInfo.IsDelete = false;
                toolInfo.OperatorUserId = LoginHelper.ID;
                toolInfo.OperatorUserName = LoginHelper.UserCode;
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

                    toolInfo.CheckTime = dtiCheckTime.Value;
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
                else {
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

                int blongValue = int.Parse(cbSearchBlong.SelectedValue.ToString());
                int categoryValue = int.Parse(cbSearchcategory.SelectedValue.ToString());
                string toolCode = tbSearchCode.Text;
                string toolName = tbSearchName.Text;
                long Count;

                List<t_ToolInfo> resultEntity = _toolInfoService.GetToolList(blongValue, categoryValue, toolCode, toolName, pagerControl1.PageIndex, pagerControl1.PageSize, out Count);
                pagerControl1.DrawControl(Convert.ToInt32(Count));
                this.dataGridViewX1.AutoGenerateColumns = false;
                this.dataGridViewX1.DataSource = resultEntity;
                this.dataGridViewX1.Rows[0].Selected=true;
                slectedIndex = 0;
                ToolId = int.Parse(dataGridViewX1.Rows[0].Cells[0].Value.ToString());

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
                ToolId = int.Parse(this.dataGridViewX1.Rows[slectedIndex].Cells[0].Value.ToString());
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
                if (ToolId <= 0)
                {
                    MessageBox.Show("请选中一条记录");
                    return;
                }
                else {
                    t_ToolInfo toolEntity = _toolInfoService.GetToolById(ToolId);
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
                if (ToolId <= 0)
                {
                    MessageBox.Show("请选中一条记录");
                    return;
                }
                else
                {
                    bool toolEntity = _toolInfoService.DelToolById(ToolId);
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
    }
}
