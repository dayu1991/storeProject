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
using common.toolstrackingsystem;

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
                t_OutBackStore countInfo = (t_OutBackStore)this.Tag;
                string sql = @"select   ti.TypeName,
		                                ti.ChildTypeName,
		                                ti.PackCode,
		                                ti.PackName,
		                                obs.ToolCode,
		                                obs.ToolName,
		                                IsBack = case obs.IsBack when '1' then '是' else '否' end,
		                                obs.PersonCode,
		                                obs.PersonName,
		                                obs.OutStoreTime,
		                                obs.outdescribes,
		                                obs.BackPesonCode,
		                                obs.BackPersonName,
		                                obs.BackTime,
		                                obs.backdescribes,
		                                OptionPerson = case when sui.UserName is null then tpi1.PersonName else sui.UserName end
                                    from t_OutBackStore obs left join t_ToolInfo ti on obs.ToolCode = ti.ToolCode
	                                left join Sys_User_Info sui on obs.OptionPerson = sui.UserCode
	                                left join t_PersonInfo tpi1 on obs.OptionPerson = tpi1.PersonCode
                                    where 1=1  ";
                if (!string.IsNullOrEmpty(countInfo.ToolCode))
                {
                    string str = " AND obs.ToolCode LIKE '" + countInfo.ToolCode + "'";
                    sql += str;
                }
                if (!string.IsNullOrEmpty(countInfo.PersonCode))
                {
                    string str = " AND obs.PersonCode LIKE '" + countInfo.PersonCode + "'";
                    sql += str;
                }
                if (!string.IsNullOrEmpty(countInfo.OutStoreTime))
                {
                    string str = " AND obs.OutStoreTime >= '" + countInfo.OutStoreTime + "'";
                    sql += str;
                }
                if (!string.IsNullOrEmpty(countInfo.BackTime))
                {
                    string str = " AND obs.OutStoreTime <= '" + countInfo.BackTime + "'";
                    sql += str;
                }
                //if (!string.IsNullOrEmpty(countInfo.OutStoreTime) && !string.IsNullOrEmpty(countInfo.BackTime))
                //{
                //    string str = " AND((tci.OutStoreTime>= '" + countInfo.OutStoreTime + "' AND tci.OutStoreTime<='" + countInfo.BackTime + "') OR (tci.BackTime>= '" + countInfo.OutStoreTime + "'  AND tci.BackTime<='" + countInfo.BackTime + "'))";
                //    sql += str;
                //}
                //else if (string.IsNullOrEmpty(countInfo.OutStoreTime) && !string.IsNullOrEmpty(countInfo.BackTime))
                //{
                //    string str = " AND(tci.OutStoreTime<='" + countInfo.BackTime + "' OR tci.BackTime<='" + countInfo.BackTime + "')";
                //    sql += str;
                //}
                //else if (!string.IsNullOrEmpty(countInfo.OutStoreTime) && string.IsNullOrEmpty(countInfo.BackTime))
                //{
                //    string str = " AND(tci.OutStoreTime>='" + countInfo.OutStoreTime + "' OR tci.BackTime>='" + countInfo.OutStoreTime + "')";
                //    sql += str;
                //}
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
