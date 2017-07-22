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
using ViewEntity.toolstrackingsystem;
using dbentity.toolstrackingsystem;
using log4net;

namespace toolstrackingsystem
{
    public partial class FrmWorkerManager : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FormLogin));
        private IPersonManageService _personManageService;
        private int slectedIndex;
        public FrmWorkerManager()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void FrmWorkerManager_Load(object sender, EventArgs e)
        {
            _personManageService = Program.container.Resolve<IPersonManageService>() as PersonManageService;
            
        }
        private void Search_buttonX_Click(object sender, EventArgs e)
        {
            try
            {
                pagerControl1.OnPageChanged += new EventHandler(pagerControl1_OnPageChanged);
                LoadData();
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmWorkerManager--Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void PersonList_dataGridViewX_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
                LoadData();
        }
        private void LoadData()
        {
            PersonInfoEntity personInfo = new PersonInfoEntity();
            personInfo.PersonCode = PersonCode_textBox.Text;
            personInfo.PersonName = PersonName_textBox.Text;
            personInfo.IsReceive = Is_Receive_radioButton.Checked == true ? "1" : "0";
            //数据总记录数
            long Count;
            //获取分页的数据
            PersonList_dataGridViewX.DataSource = _personManageService.GetPersonInfoList(personInfo,pagerControl1.PageIndex,pagerControl1.PageSize,out Count);
            pagerControl1.DrawControl(Convert.ToInt32(Count));
            for (int i = 0; i < PersonList_dataGridViewX.Columns.Count; i++)
            {
                PersonList_dataGridViewX.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            PersonList_dataGridViewX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PersonList_dataGridViewX.Columns[0].HeaderText = "人员编码";
            PersonList_dataGridViewX.Columns[1].HeaderText = "人员名称";
            PersonList_dataGridViewX.Columns[2].HeaderText = "领用权限";
            PersonList_dataGridViewX.Columns[3].HeaderText = "备注";
            pagerControl1.DrawControl(Convert.ToInt32(Count));
        }
        private void Add_button_Click(object sender, EventArgs e)
        {
            try
            {
                t_PersonInfo personInfo = new t_PersonInfo();
                personInfo.PersonCode = PersonCode_Detail_textBox.Text;
                personInfo.PersonName = PersonName_Detail_textBox.Text;
                personInfo.IsReceive = Can_TakeOuttradioButton.Checked == true ? "1" : "0";
                personInfo.Remarks = Remark_textBox.Text;
                if (string.IsNullOrEmpty(personInfo.PersonCode))
                {
                    MessageBox.Show("人员编码不能为空");
                    PersonCode_Detail_textBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(personInfo.PersonName))
                {
                    MessageBox.Show("人员名称不能为空");
                    PersonName_Detail_textBox.Focus();
                    return;
                }
                if (_personManageService.GetPersonInfo(personInfo.PersonCode)!=null)
                {
                    MessageBox.Show("作业人员已存在，请重新输入");
                    PersonCode_Detail_textBox.Focus();
                    return;
                }
                if (_personManageService.InsertPersonInfo(personInfo))
                {
                    MessageBox.Show("添加成功");
                    PersonCode_Detail_textBox.Text = "";
                    PersonName_Detail_textBox.Text = "";
                    Can_TakeOuttradioButton.Checked = true;
                    Remark_textBox.Text = "";
                    Search_buttonX_Click(sender,e);
                }
                else
                {
                    MessageBox.Show("添加失败，请联系管理员");
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmWorkerManager--Add_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }

        private void PersonList_dataGridViewX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                slectedIndex = e.RowIndex;
                string personCode = PersonList_dataGridViewX.Rows[slectedIndex].Cells[0].Value.ToString();
                this.Tag = personCode;
            }
           
        }

        private void Edit_button_Click(object sender, EventArgs e)
        {
            try
            {
                string personCode = this.Tag.ToString();
                if (string.IsNullOrEmpty(personCode))
                {
                    MessageBox.Show("请选择需要修改的人员信息");
                    return;
                }
                FrmEditWorker frmeditworker = new FrmEditWorker();
                frmeditworker.Tag = personCode;
                frmeditworker.ShowDialog();
                if (frmeditworker.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show("修改成功");
                    Search_buttonX_Click(sender, e);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmWorkerManager--Edit_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
    }
}
