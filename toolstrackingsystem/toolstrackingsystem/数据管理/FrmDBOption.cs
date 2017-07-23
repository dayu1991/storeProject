using DevComponents.DotNetBar;
using log4net;
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
using common.toolstrackingsystem;
namespace toolstrackingsystem
{
    public partial class FrmDBOption : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(frmEditUserinfo));
        SqlConnection conn = ConnectionHelper.GetConnectionByKey("MPConnection1");
        public FrmDBOption()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var fileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")+".bak";
            //还原的数据库MyDataBase
            string backupstr = "backup database [cangku_manage_db] to disk='" + @"C:\Temp\"+ fileName + "';"; // 数据库备份语句
            conn.Open();
            SqlCommand comm = new SqlCommand(backupstr, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                comm.ExecuteNonQuery();
                MessageBox.Show("备份成功!");

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmDBOption", ex.Message, ex.StackTrace, ex.Source);
                MessageBox.Show("备份失败!");

            }
            finally {
                conn.Close();
            }
        }
       
      
    }
}
