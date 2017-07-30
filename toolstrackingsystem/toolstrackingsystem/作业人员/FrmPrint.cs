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
using log4net;
using service.toolstrackingsystem;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using dbentity.toolstrackingsystem;
using ViewEntity.toolstrackingsystem;
using System.Data.SqlClient;

namespace toolstrackingsystem
{
    public partial class FrmPrint : Office2007Form
    {
        public FrmPrint()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrmPrint_Load(object sender, EventArgs e)
        {

            // TODO:  这行代码将数据加载到表“cangku_manage_dbDataSet.t_PersonInfo”中。您可以根据需要移动或删除它。
            //this.t_PersonInfoTableAdapter.Fill(this.cangku_manage_dbDataSet.t_PersonInfo);

            //this.reportViewer1.RefreshReport();


            string defaultConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MPConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(defaultConnectionString))
            {
                PersonInfoEntity personInfo = (PersonInfoEntity)this.Tag;
                string sql = "SELECT PersonCode,PersonName,IsReceive=case IsReceive when '1' then '是' when '0' then '否' end,Remarks FROM t_PersonInfo WHERE 1=1 ";
                if (!string.IsNullOrEmpty(personInfo.PersonCode))
                {
                    sql += " AND PersonCode LIKE " + string.Format("'%{0}%'", personInfo.PersonCode);
                }
                if (!string.IsNullOrEmpty(personInfo.PersonName))
                {
                    sql += " AND PersonName LIKE " + string.Format("'%{0}%'", personInfo.PersonName);
                }
                if (!string.IsNullOrEmpty(personInfo.IsReceive))
                {
                    sql += " AND IsReceive= " + personInfo.IsReceive;
                }
                SqlCommand cmd = new SqlCommand(sql,conn);
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
                catch(Exception ex)
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
