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

namespace toolstrackingsystem
{
    public partial class FrmWorkerManager : Office2007RibbonForm
    {
        private IPersonManageService _personManageService;
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
            pagerControl1.OnPageChanged += new EventHandler(pagerControl1_OnPageChanged);
            LoadData();
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
    }
}
