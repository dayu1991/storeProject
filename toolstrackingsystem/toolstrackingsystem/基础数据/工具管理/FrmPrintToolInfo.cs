using common.toolstrackingsystem;
using dbentity.toolstrackingsystem;
using DevComponents.DotNetBar;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewEntity.toolstrackingsystem;

namespace toolstrackingsystem
{
    public partial class FrmPrintToolInfo : Office2007Form
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(ToolInfoManage));

        public FrmPrintToolInfo()
        {
            this.EnableGlass = false;

            InitializeComponent();
        }

        private void FrmPrintToolInfo_Load(object sender, EventArgs e)
        {

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
                ToolInfoConditionExtend toolInfo = (ToolInfoConditionExtend)this.Tag;
                if (toolInfo.IsCheck)//要链接借用表
                {
                    string sql = @"select *,(case [IsBack] when '0' then '是' else '否' end) as IsBackString,(case [IsRepaired] when 1 then '是' else '否' end) as IsRepairedString from (
       select t.*, o.[UserTimeInfo],o.[PersonCode],o.[PersonName], ROW_NUMBER() OVER (ORDER BY t.ChildTypeName,t.[ToolId] desc) as rank from [dbo].[t_ToolInfo] as t 
left join  [dbo].[t_OutBackStore] o on t.ToolCode = o.ToolCode where t.IsBack=0 and  o.IsBack=0 
)  as t WHERE 1=1 {0}";
                    string sqlWhere = "";
                    if (!string.IsNullOrWhiteSpace(toolInfo.blongValue))
                    {
                        sqlWhere += " and  t.[TypeName]='" + toolInfo.blongValue + "'";

                    }
                    if (!string.IsNullOrWhiteSpace(toolInfo.categoryValue))
                    {
                        sqlWhere += " and t.[ChildTypeName] ='" + toolInfo.categoryValue + "' ";
                    }
                    if (!string.IsNullOrWhiteSpace(toolInfo.toolCode))
                    {
                        sqlWhere += " and t.[ToolCode] LIKE '%" + toolInfo.toolCode + "%' ";

                    }
                    if (!string.IsNullOrEmpty(toolInfo.toolName))
                    {
                        sqlWhere += " and t.[ToolName] LIKE '%" + toolInfo.toolName + "%' ";
                    }

                    if (toolInfo.IsRepair) //如果已经送修
                    {
                        sqlWhere += " and t.[IsRepaired] = 1";
                    }

                    sqlWhere += " and o.[UserTimeInfo]<>'' and o.[UserTimeInfo] <'" + DateTime.Now + "' ";

                    if (toolInfo.CheckTime != "0") //如果不为0，过滤检测时间
                    {
                        int daysLevel = int.Parse(toolInfo.CheckTime);
                        if (daysLevel == -1)//已过检修时间
                        {
                            sqlWhere += " and t.[CheckTime]<>''  and t.[CheckTime] < '" + DateTime.Now + "' ";
                        }
                        else
                        {
                            sqlWhere += " and t.[CheckTime]<>'' and t.[CheckTime]>='" + DateTime.Now.AddDays(daysLevel) + "' and t.[CheckTime] <='" + DateTime.Now + "' ";

                        }
                    }
                    sql = string.Format(sql, sqlWhere);
                }
                else //不用链接            
                {
                    string sql = @"select *,(case [IsBack] when '0' then '是' else '否' end) as IsBackString,(case [IsRepaired] when 1 then '是' else '否' end) as IsRepairedString from (
       select * from [dbo].[t_ToolInfo]  where 1=1 
)  as t WHERE 1=1 {0}";
                    string sqlWhere = "";

                    if (!string.IsNullOrWhiteSpace(toolInfo.blongValue))
                    {
                        sqlWhere += " and  t.[TypeName]='" + toolInfo.blongValue + "'";

                    }
                    if (!string.IsNullOrWhiteSpace(toolInfo.categoryValue))
                    {
                        sqlWhere += " and t.[ChildTypeName] ='" + toolInfo.categoryValue + "' ";
                    }
                    if (!string.IsNullOrWhiteSpace(toolInfo.toolCode))
                    {
                        sqlWhere += " and t.[ToolCode] LIKE '%" + toolInfo.toolCode + "%' ";

                    }
                    if (!string.IsNullOrEmpty(toolInfo.toolName))
                    {
                        sqlWhere += " and t.[ToolName] LIKE '%" + toolInfo.toolName + "%' ";
                    }

                    if (toolInfo.IsOut) //如果已经借出
                    {
                        sqlWhere += " and [IsBack] = 0";
                    }
                    if (toolInfo.IsRepair) //如果已经送修
                    {
                        sqlWhere += " and [IsRepaired] = 1";
                    }
                    if (toolInfo.CheckTime != "0") //如果不为0，过滤检测时间
                    {
                        int daysLevel = int.Parse(toolInfo.CheckTime);
                        if (daysLevel == -1)//已过检修时间
                        {
                            sqlWhere += " and [CheckTime]<>''  and [CheckTime] <'" + DateTime.Now + "' ";
                        }
                        else
                        {
                            sqlWhere += " and t.[CheckTime]<>'' and t.[CheckTime]>='" + DateTime.Now.AddDays(daysLevel) + "' and t.[CheckTime] <='" + DateTime.Now + "' ";
                        }
                    }
                    sql = string.Format(sql, sqlWhere);

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
                        //为报表浏览器指定报表文件

                        //this.reportViewer1.LocalReport.ReportEmbeddedResource = "report.Report1.rdlc";

                        //指定数据集,数据集名称后为表,不是DataSet类型的数据集

                        this.reportViewer1.LocalReport.DataSources.Clear();

                        this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", c_ds.Tables[0]));

                        //显示报表

                        this.reportViewer1.RefreshReport();
                    }
                    catch (Exception ex)
                    {
                        logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--frmprinttoolinfo--FrmPrintToolInfo_Load", ex.Message, ex.StackTrace, ex.Source);

                    }
                }
            }
        }
    }
}
