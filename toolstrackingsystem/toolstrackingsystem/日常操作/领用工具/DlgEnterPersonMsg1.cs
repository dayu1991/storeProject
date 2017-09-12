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
            GetPerson(true);
        }

        private void tbEditPersonCode_TextChanged(object sender, EventArgs e)
        {
            GetPerson(false);
        }

        private void GetPerson(bool isAlert)
        {
            try
            {
                var personCode = this.tbEditPersonCode.Text;
                if (!string.IsNullOrWhiteSpace(personCode))
                {
                    var person = _personManageService.GetPersonInfo(personCode);
                    if (person != null && !string.IsNullOrWhiteSpace(person.PersonCode))
                    {
                        if (person.IsReceive == "1")
                        {
                            this.Tag = person;
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;

                            this.Dispose();
                        }
                        else {
                            MessageBox.Show("该人员没有领用权限，请开通领用权限！");
                        }
                        
                    }
                    else {
                        if (isAlert)
                        {
                            MessageBox.Show("找不到此人员，请检查人员编码是否录入正确！");
                        }
                    }
                }
                else{
                    if (isAlert) {
                        MessageBox.Show("请输入人员编码！");
                    }
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
