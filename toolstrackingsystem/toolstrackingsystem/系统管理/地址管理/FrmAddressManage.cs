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
using log4net;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using dbentity.toolstrackingsystem;
using ViewEntity.toolstrackingsystem;

namespace toolstrackingsystem
{
    public partial class FrmAddressManage : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FormLogin));
        private IAddressInfoService _addressInfoService;
        private int selectedIndex = 0;
        public FrmAddressManage()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void FrmAddressManage_Load(object sender, EventArgs e)
        {
            _addressInfoService = Program.container.Resolve<IAddressInfoService>() as AddressInfoService;
        }
        private void Search_buttonX_Click(object sender, EventArgs e)
        {
            try
            {
                string macAddress = Address_textBox.Text;
                List<AddressInfoEntity> addressList = _addressInfoService.GetAddressList(macAddress);
                AddressList_dataGridViewX.DataSource = addressList;
                for (int i = 0; i < AddressList_dataGridViewX.Columns.Count; i++)
                {
                    AddressList_dataGridViewX.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
                AddressList_dataGridViewX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                AddressList_dataGridViewX.Columns[0].HeaderText = "MAC地址";
                AddressList_dataGridViewX.Columns[1].HeaderText = "加密地址";
                AddressList_dataGridViewX.Columns[2].HeaderText = "是否有效";
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmAddressManage-Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void AddressList_dataGridViewX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = e.RowIndex;
        }
        private void add_button_Click(object sender, EventArgs e)
        {
            try
            {
                Sys_AddressInfo addInfo = new Sys_AddressInfo();
                addInfo.MacAddress = macAddress_textBox.Text;
                addInfo.Address = jiami_textBox.Text;
                if (string.IsNullOrEmpty(addInfo.MacAddress))
                {
                    MessageBox.Show("MAC地址不能为空");
                    macAddress_textBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(addInfo.Address))
                {
                    MessageBox.Show("加密地址不能为空");
                    jiami_textBox.Focus();
                    return;
                }
                if (_addressInfoService.GetAddressInfoByMac(addInfo.MacAddress) != null)
                {
                    MessageBox.Show("不能添加已存在的地址");
                    return;
                }
                addInfo.IsActive = 1;
                if (_addressInfoService.InsertAddressInfo(addInfo))
                {
                    MessageBox.Show("添加成功");
                    Search_buttonX_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmAddressManage-add_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void edit_button_Click(object sender, EventArgs e)
        {
            try
            {
                object macadd = AddressList_dataGridViewX.Rows[selectedIndex].Cells[0].Value;
                if (macadd == null)
                {
                    MessageBox.Show("请选择需要编辑的地址");
                    return;
                }
                FrmEditAddress editFrm = new FrmEditAddress();
                editFrm.Tag = macadd.ToString();
                editFrm.ShowDialog();
                if (editFrm.DialogResult == DialogResult.OK)
                {
                    Search_buttonX_Click(sender,e);
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmAddressManage-edit_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void delete_button_Click(object sender, EventArgs e)
        {
            try
            {
                object macAddress = AddressList_dataGridViewX.Rows[selectedIndex].Cells[0].Value;
                if (macAddress == null)
                {
                    MessageBox.Show("请选择需要删除的记录");
                    return;
                }
                if (_addressInfoService.DeleteAddressInfo(macAddress.ToString()))
                {
                    MessageBox.Show("删除成功");
                    Search_buttonX_Click(sender, e);
                }
                else {
                    MessageBox.Show("删除失败，请联系管理员");
                    return;
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmAddressManage-delete_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
    }
}
