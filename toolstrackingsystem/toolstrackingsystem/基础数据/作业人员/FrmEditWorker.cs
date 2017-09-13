using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using service.toolstrackingsystem;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using dbentity.toolstrackingsystem;
using log4net;

namespace toolstrackingsystem
{
    public partial class FrmEditWorker : Office2007Form
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(frmEditUserinfo));
        private IPersonManageService _personManageService;
        public FrmEditWorker()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrmEditWorker_Load(object sender, EventArgs e)
        {
            _personManageService = Program.container.Resolve<IPersonManageService>() as PersonManageService;
            try
            {
                string personCode = this.Tag.ToString();
                if (string.IsNullOrEmpty(personCode))
                {
                    MessageBox.Show("未选择任何人员信息");
                    return;
                }
                else {
                    t_PersonInfo personInfo = _personManageService.GetPersonInfo(personCode);
                    if (personInfo != null)
                    {
                        PersonCode_textBox.Text = personInfo.PersonCode;
                        PersonName_textBox.Text = personInfo.PersonName;
                        IsReceive_radiobutton.Checked = personInfo.IsReceive == "1" ? true : false;
                        Remark_textBox.Text = personInfo.Remarks;
                    }
                    else {
                        MessageBox.Show("人员信息不存在");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmEditWorker--FrmEditWorker_Load", ex.Message, ex.StackTrace, ex.Source);
            }
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void Save_Edit_button_Click(object sender, EventArgs e)
        {
            try
            {
                t_PersonInfo personInfo = new t_PersonInfo();
                personInfo.PersonCode = PersonCode_textBox.Text;
                personInfo.PersonName = PersonName_textBox.Text;
                personInfo.IsReceive = IsReceive_radiobutton.Checked ? "1" : "0";
                personInfo.Remarks = Remark_textBox.Text;
                if (string.IsNullOrEmpty(personInfo.PersonCode))
                {
                    MessageBox.Show("人员编码不能为空");
                    PersonCode_textBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(personInfo.PersonName))
                {
                    MessageBox.Show("人员名称不能为空");
                    PersonName_textBox.Focus();
                    return;
                }
                if (_personManageService.UpdatePersonInfo(personInfo))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmEditWorker--Save_Edit_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
    }
}
