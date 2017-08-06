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
using System.Data.SqlClient;
using System.Runtime.Caching;

namespace toolstrackingsystem
{
    public partial class FrmPrintPersonCreditRecord : Office2007Form
    {
        public FrmPrintPersonCreditRecord()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrmPrintPersonCreditRecord_Load(object sender, EventArgs e)
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
                string personCode = this.Tag.ToString();
                string sql = @"SELECT [PackCode]
                                  ,[PackName]
                                  ,[ToolCode]
                                  ,[ToolName]
                                  ,[PersonCode]
                                  ,[PersonName]
                                  ,[OutStoreTime]
                                  ,[UserTimeInfo]
                                  ,[OptionTime]
                              FROM [dbo].[t_PersonCreditRecord] WHERE 1=1";
                if (!string.IsNullOrEmpty(personCode))
                {
                    string str = " AND PersonCode LIKE @personCode ";
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
