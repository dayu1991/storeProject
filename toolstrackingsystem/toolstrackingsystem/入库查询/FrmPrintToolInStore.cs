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
using common.toolstrackingsystem;

namespace toolstrackingsystem
{
    public partial class FrmPrintToolInStore : Office2007Form
    {
        public FrmPrintToolInStore()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void FrmPrintToolInStore_Load(object sender, EventArgs e)
        {
            // TODO:  这行代码将数据加载到表“cangku_manage_dbDataSet.t_ToolInfo”中。您可以根据需要移动或删除它。
            //this.t_ToolInfoTableAdapter.Fill(this.cangku_manage_dbDataSet.t_ToolInfo);

            //this.reportViewer1.RefreshReport();

            string defaultConnectionString = MemoryCacheHelper.GetConnectionStr(); ;
            #region 判断cache里是否有设置好的客户端连接字符串
            if (MemoryCache.Default.Get("clientName") != null)
            {
                string connName = MemoryCache.Default.Get("clientName").ToString();
                defaultConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connName].ConnectionString;
            }
            #endregion
            using (SqlConnection conn = new SqlConnection(defaultConnectionString))
            {
                string  toolCode = this.Tag.ToString();
                string sql = @"select  ins.InStoreTime as CarGroupInfo,tool.OptionPerson,tool.TypeName,tool.ChildTypeName,tool.Models,tool.Location,tool.PackCode,tool.PackName,tool.ToolCode,tool.ToolName,tool.Remarks,tool.CheckTime from t_InStore ins join t_ToolInfo tool on ins.ToolCode = tool.ToolCode WHERE 1=1 ";
                if (!string.IsNullOrEmpty(toolCode))
                {
                    string str = " AND ToolCode LIKE '" + toolCode + "'";
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
