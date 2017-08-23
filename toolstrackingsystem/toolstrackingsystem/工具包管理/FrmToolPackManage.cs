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
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using service.toolstrackingsystem;
using log4net;
using dbentity.toolstrackingsystem;
using ViewEntity.toolstrackingsystem;

namespace toolstrackingsystem
{
    public partial class FrmToolPackManage:Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(frmEditUserinfo));
        public IToolPackManageService _toolPackManageService;
        public IToolInfoService _toolInfoService;
        public IOutBackStoreService _outBackStoreService;
        private List<ToolInfoForPackEntity> resultEntity = new List<ToolInfoForPackEntity>();
        private int selectIndex;
        public FrmToolPackManage()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void FrmToolPackManage_Load(object sender, EventArgs e)
        {
            _toolPackManageService = Program.container.Resolve<IToolPackManageService>() as ToolPackManageService;
            _toolInfoService = Program.container.Resolve<IToolInfoService>() as ToolInfoService;
            _outBackStoreService = Program.container.Resolve<IOutBackStoreService>() as OutBackStoreService;
            #region 初始化combox角色下拉框
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("name");
                dt.Columns.Add("value");
                DataRow dr = dt.NewRow();

                dr[0] = "通用工具包";

                dr[1] = "1";

                dt.Rows.Add(dr);

                DataRow dr1 = dt.NewRow();

                dr1[0] = "乘务工具包";

                dr1[1] = "2";

                dt.Rows.Add(dr1);

                this.type_comboBox.DataSource = dt;

                this.type_comboBox.DisplayMember = "name";

                this.type_comboBox.ValueMember = "value";

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmEditUser", ex.Message, ex.StackTrace, ex.Source);
            }
            #endregion
        }
        private void Search_buttonX_Click(object sender, EventArgs e)
        {
            try
            {
                t_ToolInfo toolInfo = new t_ToolInfo();
                toolInfo.PackCode = Pack_Code_textBox.Text;
                toolInfo.PackName = Pack_Name_textBox.Text;
                if (string.IsNullOrEmpty(toolInfo.PackName) && string.IsNullOrEmpty(toolInfo.PackCode))
                {
                    MessageBox.Show("包编码和包名称至少一个不为空");
                    Pack_Code_textBox.Focus();
                    return;
                }
                resultEntity = new List<ToolInfoForPackEntity>();
                List<t_ToolInfo> toolInfoList = new List<t_ToolInfo>();
                toolInfoList = _toolPackManageService.GetToolInfoInPack(toolInfo);
                foreach (var item in toolInfoList)
                {
                    ToolInfoForPackEntity toolInfoInPack = new ToolInfoForPackEntity();
                    toolInfoInPack.TypeName = item.TypeName;
                    toolInfoInPack.ChildTypeName = item.ChildTypeName;
                    toolInfoInPack.ToolCode = item.ToolCode;
                    toolInfoInPack.ToolName = item.ToolName;
                    toolInfoInPack.Models = item.Models;
                    toolInfoInPack.Location = item.Location;
                    toolInfoInPack.Remarks = item.Remarks;
                    resultEntity.Add(toolInfoInPack);
                }
                //resultEntity = _toolPackManageService.GetToolInfoForPack(toolInfo);
                if (resultEntity.Count > 0)
                {
                    Pack_Code_textBox.Text = toolInfoList[0].PackCode;
                    Pack_Name_textBox.Text = toolInfoList[0].PackName;
                    if (!string.IsNullOrEmpty(toolInfoList[0].CarGroupInfo))
                    {
                        type_comboBox.SelectedValue = "2";
                        cargroupinfo_textBox.Text = toolInfoList[0].CarGroupInfo;
                    }
                }
                ToolInfoList_dataGridViewX.DataSource = resultEntity;
                for (int i = 0; i < ToolInfoList_dataGridViewX.Columns.Count; i++)
                {
                    ToolInfoList_dataGridViewX.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
                ToolInfoList_dataGridViewX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                ToolInfoList_dataGridViewX.Columns[0].HeaderText = "工具配属";
                ToolInfoList_dataGridViewX.Columns[1].HeaderText = "工具类别";
                ToolInfoList_dataGridViewX.Columns[2].HeaderText = "编码";
                ToolInfoList_dataGridViewX.Columns[3].HeaderText = "名称";
                ToolInfoList_dataGridViewX.Columns[4].HeaderText = "型号";
                ToolInfoList_dataGridViewX.Columns[5].HeaderText = "位置";
                ToolInfoList_dataGridViewX.Columns[6].HeaderText = "备注";
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmToolPackManage--Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void ToolInfoList_dataGridViewX_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1); 
        }
        private void Add_button_Click(object sender, EventArgs e)
        {
            try
            {
                string toolCode = ToolInfoCode_Detail_textBox.Text;
                if (ToolInfoList_dataGridViewX.Columns.Count <= 0)
                {
                    MessageBox.Show("请先输入工具包信息查询");
                    Pack_Code_textBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(toolCode))
                {
                    MessageBox.Show("工具编码不能为空");
                    ToolInfoCode_Detail_textBox.Focus();
                    return;
                }
                t_ToolInfo toolInfo = new t_ToolInfo();
                toolInfo = _toolPackManageService.GetToolInfoByToolCode(toolCode);
                if (toolInfo == null)
                {
                    MessageBox.Show("工具不存在，请输入正确的工具编码");
                    ToolInfoCode_Detail_textBox.Focus();
                    return;
                }
                ToolInfoForPackEntity result = new ToolInfoForPackEntity();
                result.TypeName = toolInfo.TypeName;
                result.ChildTypeName = toolInfo.ChildTypeName;
                result.ToolCode = toolInfo.ToolCode;
                result.ToolName = toolInfo.ToolName;
                result.Models = toolInfo.Models;
                result.Remarks = toolInfo.Remarks;
                result.Location = toolInfo.Location;
                foreach (var item in resultEntity)
                {
                    if (item.ToolCode == result.ToolCode)
                    {
                        MessageBox.Show("工具已在工具包内，请重新添加");
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(toolInfo.PackCode))
                {
                    MessageBox.Show("该工具已经被组合到“"+toolInfo.PackName+"”"+"中");
                    return;
                }
                resultEntity.Add(result);
                ToolInfoList_dataGridViewX.DataSource = null;
                ToolInfoList_dataGridViewX.DataSource = resultEntity;
                for (int i = 0; i < ToolInfoList_dataGridViewX.Columns.Count; i++)
                {
                    ToolInfoList_dataGridViewX.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
                ToolInfoList_dataGridViewX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                ToolInfoList_dataGridViewX.Columns[0].HeaderText = "工具配属";
                ToolInfoList_dataGridViewX.Columns[1].HeaderText = "工具类别";
                ToolInfoList_dataGridViewX.Columns[2].HeaderText = "编码";
                ToolInfoList_dataGridViewX.Columns[3].HeaderText = "名称";
                ToolInfoList_dataGridViewX.Columns[4].HeaderText = "型号";
                ToolInfoList_dataGridViewX.Columns[5].HeaderText = "位置";
                ToolInfoList_dataGridViewX.Columns[6].HeaderText = "备注";
<<<<<<< HEAD
                ToolInfoList_dataGridViewX.FirstDisplayedScrollingRowIndex = ToolInfoList_dataGridViewX.RowCount-1;
=======
                //光标定位到最下行
                ToolInfoList_dataGridViewX.FirstDisplayedScrollingRowIndex = ToolInfoList_dataGridViewX.RowCount - 1;
>>>>>>> 48e3576962c93a89bf5e210be9769fb8a7e3b49c
            }
            catch (Exception ex) {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmToolPackManage--Add_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }

        private void Print_button_Click(object sender, EventArgs e)
        {
            ToolInfoCode_Detail_textBox.Text = "";
        }

        private void ToolInfoList_dataGridViewX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectIndex = e.RowIndex;
            this.Tag = ToolInfoList_dataGridViewX.Rows[selectIndex].Cells[2].Value.ToString();
        }
        private void Delete_button_Click(object sender, EventArgs e)
        {
            if (ToolInfoList_dataGridViewX.Rows.Count <= 0)
            {
                return;
            }
            string toolCode = ToolInfoList_dataGridViewX.Rows[selectIndex].Cells[2].Value.ToString();
            if (string.IsNullOrEmpty(toolCode))
            {
                MessageBox.Show("请选择一条数据");
                return;
            }
            //判断要删除的工具是否已借出，借出提示先归还再删除
            if (_outBackStoreService.GetToolInfoNotBackByToolCode(toolCode) != null)
            {
                MessageBox.Show("该工具还未归还，请先归还，再操作");
                return;
            }
            //更新工具信息去掉包编码，包名称
            var toolInfo = _toolPackManageService.GetToolInfoByToolCode(toolCode);
            toolInfo.PackCode = "";
            toolInfo.PackName = "";
            _toolInfoService.UpdateTool(toolInfo);
            foreach (var item in resultEntity)
            {
                if (item.ToolCode == toolCode)
                {
                    resultEntity.Remove(item);
                    break;
                }
            }
            ToolInfoList_dataGridViewX.DataSource = null;
            ToolInfoList_dataGridViewX.DataSource = resultEntity;
            for (int i = 0; i < ToolInfoList_dataGridViewX.Columns.Count; i++)
            {
                ToolInfoList_dataGridViewX.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            ToolInfoList_dataGridViewX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ToolInfoList_dataGridViewX.Columns[0].HeaderText = "工具配属";
            ToolInfoList_dataGridViewX.Columns[1].HeaderText = "工具类别";
            ToolInfoList_dataGridViewX.Columns[2].HeaderText = "编码";
            ToolInfoList_dataGridViewX.Columns[3].HeaderText = "名称";
            ToolInfoList_dataGridViewX.Columns[4].HeaderText = "型号";
            ToolInfoList_dataGridViewX.Columns[5].HeaderText = "位置";
            ToolInfoList_dataGridViewX.Columns[6].HeaderText = "备注";
            MessageBox.Show("删除成功");
            if (ToolInfoList_dataGridViewX.Rows.Count == selectIndex)
            {
                selectIndex = 0;
            }
            else if (selectIndex!=0)
            {
                selectIndex -= 1;
            }

        }

        private void Delete_button_CheckedChanged(object sender, EventArgs e)
        {
            //selectIndex = ;
            //this.Tag = ToolInfoList_dataGridViewX.Rows[selectIndex].Cells[2].Value.ToString();
        }

        private void ToolInfoList_dataGridViewX_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
        }
        /// <summary>
        /// 完成组包
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edit_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (ToolInfoList_dataGridViewX.Rows.Count <= 0)
                {
                    MessageBox.Show("包中工具为空，不能保存");
                    return;
                }
                string packCode = Pack_Code_textBox.Text;
                string packName = Pack_Name_textBox.Text;
                if (string.IsNullOrEmpty(packCode))
                {
                    MessageBox.Show("包编码不能为空");
                    Pack_Code_textBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(packName))
                {
                    MessageBox.Show("包名称不能为空");
                    Pack_Name_textBox.Focus();
                    return;
                }
                if (type_comboBox.SelectedValue.ToString() == "2")
                {
                    if (cargroupinfo_textBox.Text == "")
                    {
                        MessageBox.Show("车组号不能为空");
                        return;
                    }
                }
                string carGroupInfo = cargroupinfo_textBox.Text;
                if (_toolPackManageService.CompleteToolPack(resultEntity, packCode, packName, carGroupInfo))
                {
                    MessageBox.Show("组包完成");
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmToolPackManage--Edit_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        /// <summary>
        /// 删除包
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Pack_button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要删除“" + Pack_Code_textBox.Text + "”包信息吗", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            { 
                string packCode = Pack_Code_textBox.Text;
                if(string.IsNullOrEmpty(packCode))
                {
                    MessageBox.Show("请输入有效的包编码");
                    Pack_Code_textBox.Focus();
                    return;
                }
                //判断如果删除的包是还未归还的信息，则提示
                if (_outBackStoreService.GetToolInfoNotBackByPackCode(packCode).Count <= 0)
                {
                    MessageBox.Show("该包已经借出，请先归还后再删除包信息");
                    return;
                }
                if (_toolPackManageService.DeletePackInfo(packCode))
                {
                    MessageBox.Show("删除成功");
                    Search_buttonX_Click(sender, e);
                }
            }
        }

        private void type_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (type_comboBox.SelectedValue.ToString() == "2")
            {
                cargroupinfo_textBox.Enabled = true;
            }
            else {
                cargroupinfo_textBox.Text = "";
                cargroupinfo_textBox.Enabled = false;
            }
        }
    }
}
