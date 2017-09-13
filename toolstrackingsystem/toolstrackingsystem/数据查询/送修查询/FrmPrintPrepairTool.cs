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
using dbentity.toolstrackingsystem;

namespace toolstrackingsystem
{
    public partial class FrmPrintPrepairTool : Office2007Form
    {
        public FrmPrintPrepairTool()
        {
            InitializeComponent();
        }

        private void FrmPrintPrepairTool_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
            string defaultConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MPConnection"].ConnectionString;
            #region 判断cache里是否有设置好的客户端连接字符串
            if (MemoryCache.Default.Get("clientName") != null)
            {
                string connName = MemoryCache.Default.Get("clientName").ToString();
                defaultConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connName].ConnectionString;
            }
            #endregion
            using (SqlConnection conn = new SqlConnection(defaultConnectionString))
            {
                t_ToolRepairRecord prepairInfo = (t_ToolRepairRecord)this.Tag;
                string sql = @"SELECT tpr.[ToolCode]
                                      ,tpr.[ToolName]
                                      ,tpr.[PrepairTime]
                                      ,tpr.[BackTime]
                                      ,sui.UserName as [OptionPerson]
                                      ,sui1.UserName as [BackOptionPerson]
                                      ,[IsActive] = case tpr.IsActive WHEN 0 THEN '送修' WHEN 1 THEN '可用' END
                                  FROM [t_ToolPrepairRecord] tpr join Sys_User_Info sui on tpr.OptionPerson = sui.UserCode join Sys_User_Info sui1 on tpr.BackOptionPerson = sui1.UserCode WHERE 1=1";
                if (!string.IsNullOrEmpty(prepairInfo.ToolCode))
                {
                    string str = " AND tpr.ToolCode LIKE '" + prepairInfo.ToolCode + "'";
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
