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
    public partial class FrmEditAddress : Office2007Form
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FormLogin));
        private IAddressInfoService _addressInfoService;
        public FrmEditAddress()
        {
            InitializeComponent();
        }
        private void FrmEditAddress_Load(object sender, EventArgs e)
        {
            try
            {
                _addressInfoService = Program.container.Resolve<IAddressInfoService>() as AddressInfoService;
                string macAddress = this.Tag.ToString();
                if (string.IsNullOrEmpty(macAddress))
                {
                    MessageBox.Show("请选中一条数据");
                    this.Dispose();
                }
                Sys_AddressInfo addInfo = _addressInfoService.GetAddressInfoByMac(macAddress);
                if (addInfo == null)
                {
                    MessageBox.Show("不存在该条数据");
                    this.Dispose();
                }
                macAddress_textBox.Text = addInfo.MacAddress;
                jiami_textBox.Text = addInfo.Address;
                IsActive_checkBox.Checked = addInfo.IsActive == 1 ? true : false;
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmEditAddress-FrmEditAddress_Load", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void save_button_Click(object sender, EventArgs e)
        {
            try
            {
                string macAddress = macAddress_textBox.Text;
                var addInfo = _addressInfoService.GetAddressInfoByMac(macAddress);
                if (addInfo == null)
                {
                    MessageBox.Show("不存在该mac地址");
                    return;
                }
                addInfo.Address = jiami_textBox.Text;
                addInfo.IsActive = IsActive_checkBox.Checked ? 1 : 0;
                if (_addressInfoService.UpdateAddressInfo(addInfo))
                {
                    MessageBox.Show("更新成功");
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmEditAddress-save_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
