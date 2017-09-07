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

    public partial class FrmEditTypeDlg : Office2007Form
    {

        ILog logger = log4net.LogManager.GetLogger(typeof(DigAddBlongTo));
        private IUserManageService _userManageService;

        private IToolInfoService _toolInfoService;
        private t_ToolType t_Type;

        public FrmEditTypeDlg()
        {
            InitializeComponent();
        }

      

        private void Cancel_button_Click_1(object sender, EventArgs e)
        {
            this.Dispose();

        }

        private void Save_Edit_button_Click_1(object sender, EventArgs e)
        {
            try
            {
                var name = tbEditName.Text.Trim();
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("名称不能为空！");
                    return;
                }
                bool isExist = _toolInfoService.IsExistCategoryByName(name, t_Type.classification ?? 1);
                if (isExist)
                {
                    MessageBox.Show("名称已经存在！");
                    return;
                }

                if (_toolInfoService.IsExistToolByType(t_Type.TypeName, t_Type.classification ?? 1))
                {
                    MessageBox.Show("该记录已经被工具引用，不能修改");
                    return;
                }
                var type = _toolInfoService.GetCategoryById(t_Type.TypeID.ToString());
                if (type == null || string.IsNullOrWhiteSpace(type.TypeName))
                {
                    MessageBox.Show("该记录已经被删除！");
                    return;
                }


                type.TypeName = name;
                bool issuccess = _toolInfoService.UpdateType(type);
                if (issuccess)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmEditTypeDlg--Save", ex.Message, ex.StackTrace, ex.Source);

            }
        }

        private void FrmEditTypeDlg_Load(object sender, EventArgs e)
        {
            _userManageService = Program.container.Resolve<IUserManageService>();
            _toolInfoService = Program.container.Resolve<IToolInfoService>();
            t_Type = (t_ToolType)this.Tag;
            tbEditName.Text = t_Type.TypeName;
        }
    }
}
