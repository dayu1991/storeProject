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
using System.Data.SqlClient;
using ViewEntity.toolstrackingsystem;

namespace toolstrackingsystem
{
    public partial class FrmPrintRepairQuery : Office2007Form
    {
        public FrmPrintRepairQuery()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrmPrintRepairQuery_Load(object sender, EventArgs e)
        {

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
                string sql = @"select TypeName,ChildTypeName,PackCode,PackName,ToolCode,ToolName,ToRepairedTime,ReceiveTime,CompleteTime,PullTime,HandleTime,(case ToolStatus when 1 then '已送修' when 2 then '已接收' when 3 then '已修复' when 4 then '已领回' when 5 then '已报废' else '未知' end) as StatusStr from  [t_ToolRepairRecord]    where 1=1  ";
                ToolRepairConditions model = this.Tag as ToolRepairConditions;
                if (!string.IsNullOrWhiteSpace(model.TypeName))
                {
                    sql += "AND [TypeName] = '" + model.TypeName+"' ";

                }
                if (!string.IsNullOrWhiteSpace(model.ChildTypeName))
                {
                    sql += "AND [ChildTypeName] ='" + model.ChildTypeName + "' ";
                }
                if (!string.IsNullOrWhiteSpace(model.ToolCode))
                {
                    sql += "ToolCode LIKE '"+string.Format("%{0}%",model.ToolCode)+"' ";

                }
                if (!string.IsNullOrEmpty(model.ToolName))
                {
                    sql += "AND ToolName LIKE '" + string.Format("%{0}%", model.ToolName) + "' ";
                }
                sql += " and [ToRepairedTime]>'"+model.StartTime+"' and [ToRepairedTime]<'"+model.EndTime+"'";
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

                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Report12.rdlc";

                //指定数据集,数据集名称后为表,不是DataSet类型的数据集

                this.reportViewer1.LocalReport.DataSources.Clear();

                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", c_ds.Tables[0]));


                //显示报表

                this.reportViewer1.RefreshReport();
            }
        }
    }
}
