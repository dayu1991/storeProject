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
using ViewEntity.toolstrackingsystem.view;
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
                var categoryBlongs = categorys.Where(v => v.classification == 1).Any() ? categorys.Where(v => v.classification == 1).ToList() : new List<t_ToolType>();
                var categoryCategory = categorys.Where(v => v.classification == 2).Any() ? categorys.Where(v => v.classification == 2).ToList() : new List<t_ToolType>();
                t_ToolInfo  toolInfo = (t_ToolInfo)this.Tag;
                if (toolInfo != null)
                {
                    ToolInfoExtend toolInfoExtend = _toolInfoService.GetToolInfoExtend(toolInfo.ToolCode);
                    this.cbEditBlong.DataSource = categoryBlongs;
                    this.cbEditBlong.DisplayMember = "TypeName";
                    this.cbEditBlong.ValueMember = "TypeName";


                    this.cbEditCategory.DataSource = categoryCategory;
                    this.cbEditCategory.DisplayMember = "TypeName";
                    this.cbEditCategory.ValueMember = "TypeName";
                    tbEditToolName.Text = toolInfoExtend.ToolName;
                    tbEditLocation.Text = toolInfoExtend.Location;
                    if (string.IsNullOrWhiteSpace(toolInfoExtend.CheckTime))
                    {
                        cbEditCheckTime.Checked = false;
                        dtiCheckTime.Value = DateTime.Now.AddDays(1);
                        labDiffTime.Visible = false;

                    }
                    else
                    {
                        cbEditCheckTime.Checked = true;
                        DateTime checkTimeFor = DateTime.Parse(toolInfoExtend.CheckTime);
                        dtiCheckTime.Value = checkTimeFor;
                        if (checkTimeFor >= DateTime.Now.AddDays(7) && checkTimeFor <= DateTime.Now.AddDays(15))
                        {
                            dtiCheckTime.ForeColor = Color.Gold;
                            cbEditCheckTime.BackColor = Color.Gold;
                         
                        }
                        if (checkTimeFor > DateTime.Now && checkTimeFor <= DateTime.Now.AddDays(7))
                        {
                            dtiCheckTime.ForeColor = Color.Red;
                            cbEditCheckTime.BackColor = Color.Red;


                        }
                        var diffTime = checkTimeFor - DateTime.Now;
                        string showDiffText = "剩余";
                        if (diffTime.Days > 0)
                        {
                            showDiffText += diffTime.Days+"天";
                        }
                        showDiffText += diffTime.Hours+"小时";

                        
                        labDiffTime.Text = showDiffText; 
                        labDiffTime.Visible = true;

                    }
                    tbEditModel.Text = toolInfoExtend.Models;
                    tbEditMemo.Text = toolInfoExtend.Remarks;
                    cbEditBlong.SelectedValue = toolInfoExtend.TypeName;
                    cbEditCategory.SelectedValue = toolInfoExtend.ChildTypeName;
                    if (toolInfoExtend.IsBack == "0")//未归还
                    {
                        this.labIsOut.Text = "是";
                        this.labOutPersonValue.Text = toolInfoExtend.PersonName;
                        this.labOutTimesValue.Text = toolInfoExtend.UserTimeInfo;

                        var dateTime = DateTime.Parse(toolInfoExtend.UserTimeInfo);
                        if (dateTime < DateTime.Now)
                        {
                            this.labIsOutTimeValue.Text = "是";
                        }
                        else
                        {
                            this.labIsOutTimeValue.Text = "否";
                        }

                    }
                    else
                    {
                        this.labIsOut.Text = "否";
                        this.labIsOutTimeValue.Visible = false;
                        this.labOutTime.Visible = false;

                        this.laOutPerson.Visible = false;
                        this.labOutPersonValue.Visible = false;

                        this.labOutTimes.Visible = false;
                        this.labOutTimesValue.Visible = false;

                    }

                    if (toolInfoExtend.IsRepaired == 1)//如果已经送修啦
                    {
                        this.labIsToRepareValue.Text = "是";
                        this.labRepareTimeValue.Text = toolInfoExtend.RepairedTime.ToString("yyyy-MM-dd HH:mm:ss");

                    }
                    else
                    {
                        this.labIsToRepareValue.Text = "否";
                        this.labRepareTime.Visible = false;
                        this.labRepareTimeValue.Visible = false;

                    }
                    labToolCode.Text=toolInfoExtend.ToolCode;

                }
                else {
                    MessageBox.Show("请选择要编辑的记录！");
                    return;                
                }
                dtiCheckTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
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
            else {
                this.Dispose();
            }
           
        }
    }
}
