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

        private void labelX8_Click(object sender, EventArgs e)
        {

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

            this.cbSearchBlong.DataSource = categoryBlongs;
            this.cbSearchBlong.DisplayMember = "CategoryName";
             this.cbSearchBlong.ValueMember = "CategoryId";

            this.cbSearchcategory.DataSource = categoryCategory;
            this.cbSearchcategory.DisplayMember = "CategoryName";
             this.cbSearchcategory.ValueMember = "CategoryId";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var toolInfo = new t_ToolInfo();
            toolInfo.ToolBelongId = int.Parse(this.cbEditBlong.SelectedValue.ToString());
            toolInfo.ToolBelongName = this.cbEditBlong.SelectedText;
            toolInfo.ToolCategoryId = int.Parse(this.cbEditCategory.SelectedValue.ToString()); 
            toolInfo.ToolCategoryName = this.cbEditCategory.SelectedText;

            toolInfo.ToolName= this.tbEditToolName.Text;
            toolInfo.Location = this.tbEditLocation.Text;
            toolInfo.ToolModels = this.tbEditModel.Text;

            toolInfo.ToolRemarks = this.tbEditMemo.Text;
            toolInfo.AddTime = DateTime.Now;
            toolInfo.IsDelete = false;
            toolInfo.OperatorUserId =1;
            toolInfo.OperatorUserName = "adming";
            toolInfo.ToolCode = "7011";
            var result =  _toolInfoService.AddToolInfo(toolInfo);

        }
    }
}
