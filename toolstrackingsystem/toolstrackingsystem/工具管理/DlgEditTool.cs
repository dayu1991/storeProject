using dbentity.toolstrackingsystem;
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
namespace toolstrackingsystem
{
    public partial class DlgEditTool : Office2007Form
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(DlgEditTool));
        private IUserManageService _userManageService;
        private IToolInfoService _toolInfoService;
        public DlgEditTool()
        {
            InitializeComponent();
        }

        private void DlgEditTool_Load(object sender, EventArgs e)
        {
            _userManageService = Program.container.Resolve<IUserManageService>();
            _toolInfoService = Program.container.Resolve<IToolInfoService>();
            try
            {
                var categorys = _toolInfoService.GetCategoryByClassify(0);
                var categoryBlongs = categorys.Where(v => v.Classification == 1).Any() ? categorys.Where(v => v.Classification == 1).ToList() : new List<t_ToolCategoryInfo>();
                var categoryCategory = categorys.Where(v => v.Classification == 2).Any() ? categorys.Where(v => v.Classification == 2).ToList() : new List<t_ToolCategoryInfo>();
                t_ToolInfo  toolInfo = (t_ToolInfo)this.Tag;
                this.cbEditBlong.DataSource = categoryBlongs;
                this.cbEditBlong.DisplayMember = "CategoryName";
                this.cbEditBlong.ValueMember = "CategoryId";


                this.cbEditCategory.DataSource = categoryCategory;
                this.cbEditCategory.DisplayMember = "CategoryName";
                this.cbEditCategory.ValueMember = "CategoryId";
                tbEditToolName.Text = toolInfo.ToolName;
                tbEditLocation.Text = toolInfo.Location;
                if (string.IsNullOrWhiteSpace(toolInfo.CheckTime.ToString()))
                {
                    cbEditCheckTime.Checked = false;
                    dtiCheckTime.Value = toolInfo.CheckTime ?? DateTime.Now;

                }
                else
                {
                    cbEditCheckTime.Checked = true;
                    dtiCheckTime.Value = toolInfo.CheckTime??DateTime.Now;
                }
                tbEditModel.Text = toolInfo.ToolModels;
                tbEditMemo.Text = toolInfo.ToolRemarks;
                cbEditBlong.SelectedValue = toolInfo.ToolBelongId;
                cbEditCategory.SelectedValue = toolInfo.ToolCategoryId;

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--Tool--EditDig", ex.Message, ex.StackTrace, ex.Source);  
                
            }
           
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        private void Save_Edit_button_Click(object sender, EventArgs e)
        {
            t_ToolInfo entity = (t_ToolInfo)this.Tag;
            entity.ToolBelongId = int.Parse(this.cbEditBlong.SelectedValue.ToString());
            entity.ToolBelongName = this.cbEditBlong.Text;
            entity.ToolCategoryId = int.Parse(this.cbEditCategory.SelectedValue.ToString());
            entity.ToolCategoryName = this.cbEditCategory.Text;
            entity.ToolName = this.tbEditToolName.Text;
            entity.Location = this.tbEditLocation.Text;
            if (cbEditCheckTime.Checked)
            {
                if (dtiCheckTime.Value < DateTime.Now)
                {
                    MessageBox.Show("下次检测时间不能小于当前时间！");
                    return;
                }
                entity.CheckTime = dtiCheckTime.Value;
            }
            if (string.IsNullOrWhiteSpace(entity.ToolName))
            {
                MessageBox.Show("工具名称必须填写！");
                this.tbEditToolName.Focus();
                return;
            }
            entity.ToolModels = this.tbEditModel.Text;
            entity.ToolRemarks = this.tbEditMemo.Text;
            entity.ModifyTime = DateTime.Now;
            if (_toolInfoService.UpdateTool(entity))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Dispose();
            }
        }
    }
}
