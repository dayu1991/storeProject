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

namespace toolstrackingsystem
{
    public partial class FrmPrintScrapTools : Office2007Form
    {
        public FrmPrintScrapTools()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrmPrintScrapTools_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
            string defaultConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MPConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(defaultConnectionString))
            {
                string toolCode = this.Tag.ToString();
                string sql = "SELECT ToolCode,ToolName,ScrapTime,Remarks,OptionPerson FROM t_ScrapToolInfo WHERE 1=1 ";
                if (!string.IsNullOrEmpty(toolCode))
                {
                    sql += " AND ToolCode = '" + toolCode + "'";
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

                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", c_ds.Tables[0]));

                //显示报表

                this.reportViewer1.RefreshReport();
            }
        }
    }
}
