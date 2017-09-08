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
using common.toolstrackingsystem;
using System.Runtime.Caching;

namespace toolstrackingsystem
{
    public partial class FrmPrintNotBack : Office2007Form
    {
        public FrmPrintNotBack()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrmPrintNotBack_Load(object sender, EventArgs e)
        {
            // TODO:  这行代码将数据加载到表“cangku_manage_dbDataSet.t_ToolInfo”中。您可以根据需要移动或删除它。
            //this.t_ToolInfoTableAdapter.Fill(this.cangku_manage_dbDataSet.t_ToolInfo);

            //this.reportViewer1.RefreshReport();
            string defaultConnectionString = ConnectionHelper.defaultConnectionString;
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
                string sql = @"SELECT   ti.TypeName,
	                                ti.ChildTypeName,
	                                ti.PackCode,
	                                ti.PackName,
	                                ti.ToolCode,
	                                ti.ToolName,
		                            obs.PersonCode,
		                            obs.PersonName,
	                                obs.UserTimeInfo,
	                                OptionPerson = case when sui.UserCode is null then tpi.PersonName else sui.UserName end,
	                                obs.OutStoreTime,
	                                obs.outdescribes
                                from t_OutBackStore obs left join t_ToolInfo ti on obs.ToolCode = ti.ToolCode
	                            left join Sys_User_Info sui on obs.OptionPerson = sui.UserCode
	                            left join t_PersonInfo tpi on obs.OptionPerson = tpi.PersonCode
                                where 1=1 AND obs.IsBack='0'  ";
                if (!string.IsNullOrEmpty(countInfo.ToolCode))
                {
                    string str = " AND ti.ToolCode LIKE '" + countInfo.ToolCode + "'";
                    sql += str;
                }
                if (!string.IsNullOrEmpty(countInfo.PersonCode))
                {
                    string str = " AND obs.PersonCode LIKE '" + countInfo.PersonCode + "'";
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
