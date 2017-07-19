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
    public partial class ToolInfoManage : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(ToolInfoManage));
        private IUserManageService _userManageService;
        private IToolInfoService _toolInfoService;

        private int selectIndex = 0;

        public ToolInfoManage()
        {
            var categorys = _toolInfoService.GetCategoryByClassify(1);
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
        }
    }
}
