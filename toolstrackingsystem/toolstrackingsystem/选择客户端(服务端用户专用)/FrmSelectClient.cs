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
using common.toolstrackingsystem;
using System.Runtime.Caching;
using log4net;

namespace toolstrackingsystem
{
    public partial class FrmSelectClient :Office2007Form
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FormLogin));
        public FrmSelectClient()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        /// <summary>
        /// 初始化可选择的客户端数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSelectClient_Load(object sender, EventArgs e)
        {
            string[] clientsArr = CommonHelper.GetConfigValue("clients").Split(',');
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("value");
            foreach (var item in clientsArr)
            {
                DataRow dr = dt.NewRow();
                dr[0] = item.Split(':')[0];
                dr[1] = item.Split(':')[1];
                dt.Rows.Add(dr);
            }

            this.Clients_comboBox.DataSource = dt;

            this.Clients_comboBox.DisplayMember = "name";

            this.Clients_comboBox.ValueMember = "value";
            if (MemoryCache.Default.Get("clientName") != null)
            {
                this.Clients_comboBox.SelectedValue = MemoryCache.Default.Get("clientName").ToString();
            }
            else {
                string connStr = MemoryCacheHelper.GetConnectionStr();
                string dataBase = connStr.Split(';')[1].Split('=')[1].ToString();
                this.Clients_comboBox.SelectedValue = dataBase.Split('_')[1].ToString();
            }
        }
        /// <summary>
        /// 确定选择哪个客户端后，把value值存进memoryCache中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirm__button_Click(object sender, EventArgs e)
        {
            try
            {
                ObjectCache oCache = MemoryCache.Default;
                object fileContents = oCache["clientName"];
                CacheItemPolicy policy = new CacheItemPolicy();
                if (fileContents == null)
                {
                    //policy.AbsoluteExpiration = DateTime.Now.AddMinutes(120);//取得或设定值，这个值会指定是否应该在指定期间过后清除

                    fileContents = this.Clients_comboBox.SelectedValue.ToString(); //这里赋值;
                    oCache.Set("clientName", fileContents, policy);
                }
                else {
                    fileContents = this.Clients_comboBox.SelectedValue.ToString(); //这里赋值;
                    oCache.Set("clientName", fileContents, policy);
                }
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmSelectClient-confirm__button_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
