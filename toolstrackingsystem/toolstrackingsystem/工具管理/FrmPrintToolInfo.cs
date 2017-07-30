using dbentity.toolstrackingsystem;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toolstrackingsystem
{
    public partial class FrmPrintToolInfo : Office2007Form
    {
        public FrmPrintToolInfo()
        {
            this.EnableGlass = false;

            InitializeComponent();
        }

        private void FrmPrintToolInfo_Load(object sender, EventArgs e)
        {
            // TODO:  这行代码将数据加载到表“cangku_manage_dbDataSet.t_ToolInfo”中。您可以根据需要移动或删除它。
            //this.t_ToolInfoTableAdapter.Fill(this.cangku_manage_dbDataSet.t_ToolInfo);

            //this.reportViewer1.RefreshReport();



            string defaultConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MPConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(defaultConnectionString))
            {
                t_ToolInfo toolInfo = (t_ToolInfo)this.Tag;
                string sql = "select * from [dbo].[t_ToolInfo]  where 1=1 ";
                if (!string.IsNullOrEmpty(toolInfo.TypeName))
                {
                    sql += " and  [TypeName]=" + toolInfo.TypeName;
                }
                if (!string.IsNullOrEmpty(toolInfo.ChildTypeName))
                {
                    sql += " AND ChildTypeName = "+toolInfo.ChildTypeName;
                }
                if (!string.IsNullOrEmpty(toolInfo.ToolCode))
                {
                    sql += " AND ToolCode LIKE " + string.Format("'%{0}%'", toolInfo.ToolCode);
                }
                if (!string.IsNullOrEmpty(toolInfo.ToolName))
                {
                    sql += " AND ToolName LIKE " + string.Format("'%{0}%'", toolInfo.ToolName);
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
