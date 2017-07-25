using common.toolstrackingsystem;
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
    public partial class DigAddBlongTo : Office2007Form
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(DigAddBlongTo));
        private IToolInfoService _toolInfoService;
        public DigAddBlongTo()
        {
            InitializeComponent();
        }

        private void Save_Edit_button_Click(object sender, EventArgs e)
        {
            try
            {
                var name = tbEditName.Text.Trim();
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("名称不能为空！");
                    return;
                }
                bool isExist = _toolInfoService.IsExistCategoryByName(name,1);
                if (isExist)
                {
                    MessageBox.Show("名称已经存在！");
                    return;
                }
                var category = new t_ToolType();
                category.TypeName = name;
                category.OptionPerson = LoginHelper.UserCode;

                category.classification = 1;
                long isAdd = _toolInfoService.AddCateGory(category);
                if (isAdd>0)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                              logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--DigAddBlongTo--Save", ex.Message, ex.StackTrace, ex.Source);

            }
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        private void DigAddBlongTo_Load(object sender, EventArgs e)
        {
            _toolInfoService = Program.container.Resolve<IToolInfoService>();
        }
    }
}
