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
using System.IO;
using ViewEntity.toolstrackingsystem;
using Newtonsoft.Json;
using System.Collections;
namespace toolstrackingsystem
{
    public partial class FrmDBOption : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(frmEditUserinfo));
        SqlConnection conn = ConnectionHelper.GetConnectionByKey("DongSuo");
        private static List<DbManageEntity> dbManageEntitys;
        private static string currentPath = AppDomain.CurrentDomain.BaseDirectory;
        private static string jsonFile = currentPath + "App_Data\\ManageDb.json";
        private static string toolDbName = "cangku_manage_db";



        private int slectedIndex = 0;
        private string selectName ="";
        public FrmDBOption()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var fileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")+".bak";
            var path = currentPath+ "DataBase\\";
            if (!Directory.Exists(path))//如果不存在就创建file文件夹
            {
                 Directory.CreateDirectory(path);
            }
            var fileAllName = path + fileName;
            //还原的数据库MyDataBase
            string backupstr = "backup database [cangku_manage_db] to disk='" + fileAllName + "';"; // 数据库备份语句
            conn.Open();
            SqlCommand comm = new SqlCommand(backupstr, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                comm.ExecuteNonQuery();
                var dbManageEntity = new DbManageEntity();
                dbManageEntity.AddTime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                dbManageEntity.FileName = fileName;
                dbManageEntity.FilePath = path;
                dbManageEntitys.Add(dbManageEntity);
                var json = JsonConvert.SerializeObject(dbManageEntitys);
                IOHelp.WriteFile(jsonFile, json,false);
                LoadDate();
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

        private void FrmDBOption_Load(object sender, EventArgs e)
        {
            LoadDate();
        }
        private void LoadDate()
        {
            dbManageEntitys = new List<DbManageEntity>();
            try
            {
                if (File.Exists(jsonFile))
                {
                    string json = IOHelp.ReadFile(jsonFile);
                    dbManageEntitys = JsonConvert.DeserializeObject<List<DbManageEntity>>(json) ?? new List<DbManageEntity>();
                    this.dataGridViewX1.AutoGenerateColumns = false;
                    this.dataGridViewX1.DataSource = dbManageEntitys;
                    this.dataGridViewX1.Rows[0].Selected = true;
                    slectedIndex = 0;
                    selectName = dataGridViewX1.Rows[0].Cells[2].Value.ToString()+dataGridViewX1.Rows[0].Cells[0].Value.ToString();
                }
                else {
                    dbManageEntitys = new List<DbManageEntity>();
                    this.dataGridViewX1.AutoGenerateColumns = false;
                    this.dataGridViewX1.DataSource = dbManageEntitys;
                    this.dataGridViewX1.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmDBOptionLoad", ex.Message, ex.StackTrace, ex.Source);
            }          
        }

        private void dataGridViewX1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);  
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                slectedIndex = e.RowIndex;
                selectName =this.dataGridViewX1.Rows[slectedIndex].Cells[2].Value.ToString()+this.dataGridViewX1.Rows[slectedIndex].Cells[0].Value.ToString();
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectName))
            {
                MessageBox.Show("请选择一条记录！");
                return;
            }


            bool isKilled = exepro(toolDbName);
            if (isKilled)
            {
                string BACKUP = String.Format("RESTORE DATABASE {0} FROM DISK = '{1}'" + "WITH REPLACE", toolDbName, selectName);
                SqlCommand cmd = new SqlCommand(BACKUP, conn);
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("还原成功！");
                }
                catch (SqlException ex)
                {
                    logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmDBOptionLoad", ex.Message, ex.StackTrace, ex.Source);
                    MessageBox.Show("还原失败");                  

                }
                finally
                {
                    conn.Close();
                }
            }
            else {
                MessageBox.Show("杀死线程失败！");
                return;
            }
        }
        /**/
        /// <summary>
        /// 杀死当前库的所有进程
        /// </summary>
        /// <returns></returns>
        private  bool exepro(string dbName)
        {


            string cmdTxt = "use master;";
            cmdTxt += " declare  @sql nvarchar(500) declare @spid int set @sql='declare getspid  cursor for ";
            cmdTxt += " select spid from sysprocesses where dbid=db_id('''+@dbname+''')' exec (@sql) ";
            cmdTxt += " open getspid fetch next from getspid into @spid  while @@fetch_status <>-1 begin ";
            cmdTxt += " exec('kill '+@spid) fetch next from getspid into @spid end close getspid deallocate getspid ";

            SqlCommand cmd = new SqlCommand(cmdTxt, conn);

            cmd.Parameters.Add(new SqlParameter("@dbname", dbName));
            cmd.CommandType = CommandType.Text;

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                ArrayList list = new ArrayList();
                while (dr.Read())
                {
                    list.Add(dr.GetInt16(0));

                }
                dr.Close();
                for (int i = 0; i < list.Count; i++)
                {
                    cmd = new SqlCommand(string.Format("KILL {0}", list), conn);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmDBOptionLoad", ex.Message, ex.StackTrace, ex.Source);

                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnEmpty_Click(object sender, EventArgs e)
        {
           
            try
            {
                DirectoryInfo dir = new DirectoryInfo(currentPath + "DataBase\\");
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
                File.Delete(jsonFile);      //删除指定文件
                LoadDate();

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmDBOption-delete", ex.Message, ex.StackTrace, ex.Source);

            }

        }
       
      
    }
}
