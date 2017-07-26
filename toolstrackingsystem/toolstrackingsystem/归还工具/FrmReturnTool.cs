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
using ViewEntity.toolstrackingsystem.view;
using System.IO;
using NPOI.SS.UserModel;
using ViewEntity.toolstrackingsystem;

namespace toolstrackingsystem
{
    public partial class FrmReturnTool : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FrmReturnTool));
        private IUserManageService _userManageService;
        private IToolInfoService _toolInfoService;
        private IPersonManageService _personManageService;
        private List<OutBackStoreEntity> ToolInfoList = new List<OutBackStoreEntity>();
        public FrmReturnTool()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void btnAddTool_Click(object sender, EventArgs e)
        {
            var toolCode = this.tbEditCode.Text;
            if (string.IsNullOrWhiteSpace(toolCode))
            {
                MessageBox.Show("请填入工具编码");
                return;
            }
            var tool = _toolInfoService.GetToolByCode(toolCode);
            if (tool != null && !string.IsNullOrWhiteSpace(tool.ToolCode) && tool.IsActive == "1")
            {
                if (string.IsNullOrWhiteSpace(tool.PackCode)) //不存在包
                {
                    var toolOut = _toolInfoService.GetToolOutByCode(toolCode);
                    if (toolOut != null && toolOut.IsBack == "0")
                    {
                        OutBackStoreEntity entity = new OutBackStoreEntity();
                        entity.TypeName = tool.TypeName;
                        entity.ChildTypeName = tool.ChildTypeName;
                        entity.PackCode = tool.PackCode;
                        entity.PackName = tool.PackName;
                        entity.ToolCode = tool.ToolCode;
                        entity.ToolName = tool.ToolName;
                        entity.Models = tool.Models;
                        entity.Location = tool.Location;
                        entity.Remarks = tool.Remarks;
                        entity.OutStoreTime = toolOut.OutStoreTime;
                        entity.PersonCode = toolOut.PersonCode;
                        entity.PersonName = toolOut.PersonName;
                        entity.OutBackStoreID = toolOut.OutBackStoreID;
                        entity.OptionPersonCode =LoginHelper.UserCode;
                        entity.OptionPersonName = LoginHelper.UserName;

                        ToolInfoList.Add(entity);
                        this.dataGridViewX1.DataSource = ToolInfoList.ToArray();
                    }
                    else {
                        MessageBox.Show("不存在工具的领用信息！");
                        return;
                    }                   
                }
                else
                {
                    MessageBox.Show("此编码的工具已经被打包！");
                    return;
                }
            }
            else
            {
                MessageBox.Show("不存在此编码的常规工具！");
                return;
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (ToolInfoList.Count == 0)
            {
                MessageBox.Show("请先增加领用信息");
                return;
            }
            var userCode = tbEditPersonCode.Text;

            if (string.IsNullOrWhiteSpace(userCode))
            {
                MessageBox.Show("请填写人员编码！");
                return;
            }
            var person = _personManageService.GetPersonInfo(userCode);
            if (person == null || string.IsNullOrWhiteSpace(person.PersonCode))
            {
                MessageBox.Show("不存在的人员编码！");
                return;
            }
            if (person.IsReceive == "1")
            {
                string desc = tbEditoutdescribes.Text;

                var successCodes = "";
                foreach (var entity in ToolInfoList)
                {

                    if (_toolInfoService.IsExistsOutStoreByCode(entity.ToolCode, "0") && _toolInfoService.BackStore(entity, person, LoginHelper.UserCode, desc))
                    {
                        successCodes += entity.ToolCode;
                    }
                }

                MessageBox.Show(string.Format("归还成功，领用成功工具{0}！", successCodes));
                ToolInfoList = new List<OutBackStoreEntity>();
                this.dataGridViewX1.DataSource = ToolInfoList.ToArray();
                return;
            }
            else
            {
                MessageBox.Show("用户没有领用权限！");
                return;
            }
        }

        private void btnReturnContinue_Click(object sender, EventArgs e)
        {
            ToolInfoList = new List<OutBackStoreEntity>();
            this.dataGridViewX1.DataSource = ToolInfoList.ToArray();
        }

        private void FrmReturnTool_Load(object sender, EventArgs e)
        {
            _userManageService = Program.container.Resolve<IUserManageService>();
            _toolInfoService = Program.container.Resolve<IToolInfoService>();
            _personManageService = Program.container.Resolve<IPersonManageService>();
            this.dataGridViewX1.AutoGenerateColumns = false;
        }
    }
}
