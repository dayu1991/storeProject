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
namespace toolstrackingsystem
{
    public partial class ToolInfoManage : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(ToolInfoManage));
        private IUserManageService _userManageService;
        private IToolInfoService _toolInfoService;

        private int selectIndex = 0;

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

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var toolInfo = new t_ToolInfo();
                toolInfo.ToolBelongId = int.Parse(this.cbEditBlong.SelectedValue.ToString());
                toolInfo.ToolBelongName = this.cbEditBlong.SelectedText;
                toolInfo.ToolCategoryId = int.Parse(this.cbEditCategory.SelectedValue.ToString());
                toolInfo.ToolCategoryName = this.cbEditCategory.SelectedText;

                toolInfo.ToolName = this.tbEditToolName.Text;
                toolInfo.Location = this.tbEditLocation.Text;
                toolInfo.ToolModels = this.tbEditModel.Text;

                toolInfo.ToolRemarks = this.tbEditMemo.Text;
                toolInfo.AddTime = DateTime.Now;
                toolInfo.IsDelete = false;
                toolInfo.OperatorUserId = LoginHelper.ID;
                toolInfo.OperatorUserName = LoginHelper.UserName;
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
                    Search_buttonX_Click(sender, e);

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

        private void Search_buttonX_Click(object sender, EventArgs e)
        {
            try
            {
                int blongValue = int.Parse(cbSearchBlong.SelectedValue.ToString());
                int categoryValue = int.Parse(cbSearchcategory.SelectedValue.ToString());
                string toolCode = tbSearchCode.Text;
                string toolName = tbSearchName.Text;

                List<t_ToolInfo> resultEntity = _toolInfoService.GetToolList(blongValue, categoryValue, toolCode, toolName);

                this.dataGridViewX1.DataSource = resultEntity;
                for (int i = 0; i < dataGridViewX1.Columns.Count; i++)
                {
                    dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
                dataGridViewX1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewX1.Columns[0].HeaderText = "工具配属";
                dataGridViewX1.Columns[1].HeaderText = "工具类别";
                dataGridViewX1.Columns[2].HeaderText = "包编码";
                dataGridViewX1.Columns[3].HeaderText = "包名称";
                dataGridViewX1.Columns[4].HeaderText = "编码";
                dataGridViewX1.Columns[5].HeaderText = "名称";

                dataGridViewX1.Columns[6].HeaderText = "型号";
                dataGridViewX1.Columns[7].HeaderText = "位置";
                dataGridViewX1.Columns[8].HeaderText = "备注";
                dataGridViewX1.Columns[9].HeaderText = "下次检测时间";


            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--frmEditUserinfo--Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
    }
}
