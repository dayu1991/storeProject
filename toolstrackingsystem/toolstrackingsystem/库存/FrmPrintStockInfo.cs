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
using System.Runtime.Caching;

namespace toolstrackingsystem
{
    public partial class FrmPrintStockInfo : Office2007Form
    {
        public FrmPrintStockInfo()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrmPrintStockInfo_Load(object sender, EventArgs e)
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
                t_ToolInfo toolInfo = (t_ToolInfo)this.Tag;
                string sql = @"SELECT  [ToolID]
                                  ,[TypeName]
                                  ,[ChildTypeName]
                                  ,[PackCode]
                                  ,[PackName]
                                  ,[CarGroupInfo]
                                  ,[ToolCode]
                                  ,[ToolName]
                                  ,[Models]
                                  ,[Location]
                                  ,[Remarks]
                                  ,[CheckTime]
                                  ,[IsActive]
                                  ,[OptionPerson]
                              FROM [cangku_manage_db].[dbo].[t_ToolInfo] WHERE IsAcTive=1";
                if (!string.IsNullOrWhiteSpace(toolInfo.TypeName))
                {
                    string str = " AND TypeName LIKE  '"+toolInfo.TypeName+"'";
                    sql += str;
                }
                if (!string.IsNullOrWhiteSpace(toolInfo.ChildTypeName))
                {
                    string str = " AND ChildTypeName LIKE '"+toolInfo.ChildTypeName+"'";
                    sql += str;
                }
                if (!string.IsNullOrWhiteSpace(toolInfo.ToolCode))
                {
                    string str = " AND ToolCode LIKE  '"+toolInfo.ToolCode+"'";
                    sql += str;
                }
                if (!string.IsNullOrWhiteSpace(toolInfo.ToolName))
                {
                    string str = " AND ToolName LIKE '"+toolInfo.ToolName+"'";
                    sql += str;
                }
                if (!string.IsNullOrWhiteSpace(toolInfo.Models))
                {
                    string str = " AND Models LIKE '"+toolInfo.Models+"'";
                    sql += str;
                }
                if (!string.IsNullOrWhiteSpace(toolInfo.Location))
                {
                    string str = " AND Location LIKE '"+toolInfo.Location+"'";
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
