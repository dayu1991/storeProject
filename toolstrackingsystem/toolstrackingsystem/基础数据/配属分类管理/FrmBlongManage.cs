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
    public partial class FrmBlongManage : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FrmBlongManage));
        private IUserManageService _userManageService;
        private IToolInfoService _toolInfoService;

        private int slectedIndex = 0;
        private string SelectedToolCode = "";

        public FrmBlongManage()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var name =this.tbEditName.Text.Trim();
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("名称不能为空！");
                    return;
                }
                bool isExist = _toolInfoService.IsExistCategoryByName(name, 1);
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
                if (isAdd > 0)
                {
                    LoadData();
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmBlongManage--btnAdd_Click", ex.Message, ex.StackTrace, ex.Source);

            }

        }

        private void Search_buttonX_Click(object sender, EventArgs e)
        {
            LoadData();

        }
        private void LoadData()
        {
            try
            {
                var name = this.tbSearchName.Text;

                var categorys = _toolInfoService.GetCategoryByClassify(1, name);

                this.dataGridViewX1.AutoGenerateColumns = false;
                this.dataGridViewX1.DataSource = categorys;
                this.dataGridViewX1.Rows[0].Selected = true;
                slectedIndex = 0;
                SelectedToolCode = dataGridViewX1.Rows[0].Cells[0].Value.ToString();


            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmBlongManage--Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }

    
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SelectedToolCode))
                {
                    MessageBox.Show("请选中一条记录");
                    return;
                }
                else
                {
                    t_ToolType toolEntity = _toolInfoService.GetCategoryById(SelectedToolCode);

                    if (toolEntity != null)
                    {
                        if (_toolInfoService.IsExistToolByType(toolEntity.TypeName, toolEntity.classification??1))
                        {
                            MessageBox.Show("该记录已经被工具引用，不能修改");
                            return;
                        }

                        FrmEditTypeDlg formEdit = new FrmEditTypeDlg();
                        formEdit.Tag = toolEntity;
                        formEdit.ShowDialog();
                        if (formEdit.DialogResult == DialogResult.OK)
                        {
                            LoadData();
                        }
                    }
                    else
                    {
                    MessageBox.Show("该记录不存在，可能已经被删除");
                    return;
                    }

                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmBlongManage--edit", ex.Message, ex.StackTrace, ex.Source);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SelectedToolCode))
                {
                    MessageBox.Show("请选中一条记录");
                    return;
                }
                else
                {

                    t_ToolType toolEntity = _toolInfoService.GetCategoryById(SelectedToolCode);

                    if (toolEntity != null)
                    {
                        if (_toolInfoService.IsExistToolByType(toolEntity.TypeName, toolEntity.classification ?? 1))
                        {
                            MessageBox.Show("该记录已经被工具引用，不能删除");
                            return;
                        }
                        _toolInfoService.DelTypeById(SelectedToolCode);
                    }
                    LoadData();

                           
                }
            }
            catch (Exception ex)
            {

                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmBlongManage--delete", ex.Message, ex.StackTrace, ex.Source);
            }
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                slectedIndex = e.RowIndex;
                SelectedToolCode = this.dataGridViewX1.Rows[slectedIndex].Cells[0].Value.ToString();
            }
        }

        private void dataGridViewX1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index+1);
        }

        private void FrmBlongManage_Load(object sender, EventArgs e)
        {
            _userManageService = Program.container.Resolve<IUserManageService>();
            _toolInfoService = Program.container.Resolve<IToolInfoService>();         
            LoadData();
        }
    }
}
