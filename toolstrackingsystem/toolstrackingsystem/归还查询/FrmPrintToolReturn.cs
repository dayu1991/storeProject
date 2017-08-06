using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace toolstrackingsystem
{
    public partial class FrmPrintToolReturn : Office2007Form
    {
        public FrmPrintToolReturn()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrmPrintToolReturn_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
            string defaultConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DongSuo"].ConnectionString;
            #region 判断cache里是否有设置好的客户端连接字符串
            if (MemoryCache.Default.Get("clientName") != null)
            {
                string connName = MemoryCache.Default.Get("clientName").ToString();
                defaultConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connName].ConnectionString;
            }
            #endregion
            using (SqlConnection conn = new SqlConnection(defaultConnectionString))
            {
                string sql = "select  tl.TypeName as OutBackStoreID,tl.ChildTypeName as IsBack,tl.PackCode as OutStoreTime,tl.PackName as IsBack,obs.ToolCode,obs.ToolName,obs.BackPesonCode,obs.BackPersonName,obs.BackTime,obs.backdescribes,sui.UserName as OptionPerson from t_OutBackStore obs join t_ToolInfo tl on obs.ToolCode = tl.ToolCode join Sys_User_Info sui on obs.OptionPerson=sui.UserCode  WHERE 1=1 ";
                t_OutBackStore outbackInfo = this.Tag as t_OutBackStore;
                if (!string.IsNullOrWhiteSpace(outbackInfo.ToolCode))
                {
                    string str = " AND obs.ToolCode LIKE '" + outbackInfo.ToolCode + "'";
                    sql += str;
                }
                if (!string.IsNullOrWhiteSpace(outbackInfo.ToolName))
                {
                    string str = " AND obs.PersonCode LIKE '" + outbackInfo.ToolName + "'";
                }
                if (!string.IsNullOrWhiteSpace(outbackInfo.OutStoreTime))
                {
                    string str = " AND obs.BackTime >=  '" + outbackInfo.OutStoreTime + "'";
                    sql += str;
                }
                if (!string.IsNullOrWhiteSpace(outbackInfo.BackTime))
                {
                    string str = " AND obs.BackTime <=  '" + outbackInfo.BackTime + "'";
                    sql += str;
                }
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet c_ds = new DataSet();

                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    adapter.Fill(c_ds);
                }
                catch (Exception ex)
                {


                }
                //为报表浏览器指定报表文件

                //this.reportViewer1.LocalReport.ReportEmbeddedResource = "report.Report1.rdlc";

                //指定数据集,数据集名称后为表,不是DataSet类型的数据集

                this.reportViewer1.LocalReport.DataSources.Clear();

                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", c_ds.Tables[0]));

                //显示报表

                this.reportViewer1.RefreshReport();
            }


        }
    }
}
