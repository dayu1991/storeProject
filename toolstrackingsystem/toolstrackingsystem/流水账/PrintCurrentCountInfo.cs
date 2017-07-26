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
using dbentity.toolstrackingsystem;

namespace toolstrackingsystem
{
    public partial class PrintCurrentCountInfo : Office2007Form
    {
        public PrintCurrentCountInfo()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void PrintCurrentCountInfo_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();

            string defaultConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MPConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(defaultConnectionString))
            {
                t_CurrentCountInfo countInfo = (t_CurrentCountInfo)this.Tag;
                string sql = @"SELECT [TypeName]
                        ,[ChildTypeName]
                        ,[PackCode]
                        ,[PackName]
                        ,[ToolCode]
                        ,[ToolName]
                        ,[Models]
                        ,[Location]
                        ,[Remarks]
                        ,[InStoreTime]
                        ,[OutStoreTime]
                        ,[BackTime]
                        ,[OptionType]
                        ,[PersonCode]
                        ,[PersonName]
                        ,[BackPesonCode]
                        ,[BackPersonName]
                        ,[describes]
                        ,[OptionPerson]
                    FROM [dbo].[t_CurrentCountInfo] WHERE 1=1 ";
                if (!string.IsNullOrEmpty(countInfo.OptionType))
                {
                    string str = " AND OptionType LIKE '"+countInfo.OptionType+"'";
                    sql += str;
                }
                if (!string.IsNullOrEmpty(countInfo.ToolCode))
                {
                    string str = " AND ToolCode LIKE '"+countInfo.ToolCode+"'";
                    sql += str;
                }
                if (!string.IsNullOrEmpty(countInfo.PersonCode))
                {
                    string str = " AND PersonCode LIKE '"+countInfo.PersonCode+"'";
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
