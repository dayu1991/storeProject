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
    public partial class DlgEnterPersonMsg1 :  Office2007Form
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(DlgEditTool));
        private IUserManageService _userManageService;
        private IToolInfoService _toolInfoService;
        private IPersonManageService _personManageService;

        public DlgEnterPersonMsg1()
        {
            InitializeComponent();
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Save_Edit_button_Click(object sender, EventArgs e)
        {
            
        }

        private void tbEditPersonCode_TextChanged(object sender, EventArgs e)
        {

        }

        private bool GetPerson()
        {
            try
            {
                var personCode = this.tbEditPersonCode.Text;
                if (!string.IsNullOrWhiteSpace(personCode))
                {
                    var person = _userManageService.get
                }
                t_ToolInfo entity = (t_ToolInfo)this.Tag;
                if (entity != null)
                {
                    entity.TypeName = this.cbEditBlong.SelectedValue.ToString();
                    entity.ChildTypeName = this.cbEditCategory.SelectedValue.ToString();
                    entity.ToolName = this.tbEditToolName.Text;
                    entity.Location = this.tbEditLocation.Text;
                    if (cbEditCheckTime.Checked)
                    {
                        if (dtiCheckTime.Value < DateTime.Now)
                        {
                            MessageBox.Show("下次检测时间不能小于当前时间！");
                            return;
                        }
                        entity.CheckTime = dtiCheckTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    if (string.IsNullOrWhiteSpace(entity.ToolName))
                    {
                        MessageBox.Show("工具名称必须填写！");
                        this.tbEditToolName.Focus();
                        return;
                    }
                    entity.Models = this.tbEditModel.Text;
                    entity.Remarks = this.tbEditMemo.Text;
                    if (_toolInfoService.UpdateTool(entity))
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Dispose();
                    }
                }
                else
                {
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--DlgEnterPersonMsg1--GetPerson", ex.Message, ex.StackTrace, ex.Source);

            }
            
        }

        private void DlgEnterPersonMsg1_Load(object sender, EventArgs e)
        {
            _userManageService = Program.container.Resolve<IUserManageService>();
            _toolInfoService = Program.container.Resolve<IToolInfoService>();
            _personManageService = Program.container.Resolve<IPersonManageService>();
            this.tbEditPersonCode.Focus();
        }
    }
}
