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
using service.toolstrackingsystem;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using log4net;
using dbentity.toolstrackingsystem;
using System.Runtime.Caching;
using ViewEntity.toolstrackingsystem;
using System.IO;
using System.Threading;
using System.Net.Sockets;

namespace toolstrackingsystem
{
    public partial class FrmScrapToolManage : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(frmEditUserinfo));
        private Sys_User_Info userInfo = MemoryCache.Default.Get("userinfo") as Sys_User_Info;
        private List<ScrapToolInfoEntity> infoList = new List<ScrapToolInfoEntity>();
        private IScrapToolInfoService _scrapToolInfoService;
        private IToolInfoService _toolInfoService;
        private int selectIndex=0;
        private Thread threadClient;
        private Socket socketClient = Program.SocketClient;
        //代理用来设置text的值 （实现另一个线程操作主线程的对象）
        private delegate void SetTextCallback(string text);
        public FrmScrapToolManage()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void FrmScrapToolManage_Load(object sender, EventArgs e)
        {
            _scrapToolInfoService  =Program.container.Resolve<IScrapToolInfoService>() as ScrapToolInfoService;
            _toolInfoService = Program.container.Resolve<IToolInfoService>() as ToolInfoService;

            threadClient = new Thread(RecMsg);

            //将窗体线程设置为与后台同步
            threadClient.IsBackground = true;

            //启动线程
            threadClient.Start();
        }
        private void ToolInfo_dataGridView_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {

        }
        private void ToolInfo_dataGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1); 
        }

        private void ToolInfo_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectIndex = e.RowIndex;
        }
        /// <summary>
        /// 工具文本框离开焦点时触发查找符合条件的工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tool_Code_textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                    string toolCode = Tool_Code_textBox.Text;
                if (string.IsNullOrEmpty(toolCode))
                {
                    return;
                }
                ToolInfo_dataGridView.DataSource = _scrapToolInfoService.GetToolInfoForScrapList(toolCode);
                for (int i = 0; i < ToolInfo_dataGridView.Columns.Count; i++)
                {
                    ToolInfo_dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
                ToolInfo_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                ToolInfo_dataGridView.Columns[0].HeaderText = "包编码";
                ToolInfo_dataGridView.Columns[1].HeaderText = "包名称";
                ToolInfo_dataGridView.Columns[2].HeaderText = "配属";
                ToolInfo_dataGridView.Columns[3].HeaderText = "类别";
                ToolInfo_dataGridView.Columns[4].HeaderText = "工具编码";
                ToolInfo_dataGridView.Columns[5].HeaderText = "名称";
                ToolInfo_dataGridView.Columns[6].HeaderText = "型号";
                ToolInfo_dataGridView.Columns[7].HeaderText = "位置";
                ToolInfo_dataGridView.Columns[8].HeaderText = "备注";
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmScrapToolManage--Tool_Code_textBox_TextChanged", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        private void ScrapTool_dataGridViewX2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        /// <summary>
        /// 报废工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Scrap_buttonX_Click(object sender, EventArgs e)
        {
            try
            {
                if (ToolInfo_dataGridView.Rows.Count <= 0)
                {
                    MessageBox.Show("请先选择需要作废的工具");
                    return;
                }
                string toolCode = ToolInfo_dataGridView.Rows[selectIndex].Cells[4].Value.ToString();
                if (string.IsNullOrEmpty(toolCode))
                {
                    MessageBox.Show("请选择需要作废的工具");
                    return;
                }
                t_ScrapToolInfo scrapToolInfo = new t_ScrapToolInfo();
                scrapToolInfo = _scrapToolInfoService.ScrapTool(toolCode, userInfo.UserCode);
                if (scrapToolInfo == null)
                {
                    MessageBox.Show("作废失败，请重试");
                    return;
                }
                ScrapToolInfoEntity toolInfo = new ScrapToolInfoEntity();
                toolInfo.ToolCode = scrapToolInfo.ToolCode;
                toolInfo.ToolName = scrapToolInfo.ToolName;
                toolInfo.ScrapTime = scrapToolInfo.ScrapTime;
                toolInfo.Remarks = scrapToolInfo.Remarks;
                toolInfo.OptionPerson = scrapToolInfo.OptionPerson;
                infoList.Add(toolInfo);
                ScrapTool_dataGridViewX2.DataSource = infoList;
                for (int i = 0; i < ScrapTool_dataGridViewX2.Columns.Count; i++)
                {
                    ScrapTool_dataGridViewX2.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
                ScrapTool_dataGridViewX2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                ScrapTool_dataGridViewX2.Columns[0].HeaderText = "工具编码";
                ScrapTool_dataGridViewX2.Columns[1].HeaderText = "名称";
                ScrapTool_dataGridViewX2.Columns[2].HeaderText = "报废时间";
                ScrapTool_dataGridViewX2.Columns[3].HeaderText = "备注";
                ScrapTool_dataGridViewX2.Columns[4].HeaderText = "操作人员";
                //刷新页面
                Tool_Code_textBox_TextChanged(sender,e);
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmScrapToolManage--Scrap_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        /// <summary>
        /// 查询报废工具信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Scraptool_button_Click(object sender, EventArgs e)
        {
            try
            {
                string toolCode = Scrap_ToolInfoCode_Detail_textBox.Text;
                infoList = _scrapToolInfoService.GetScrapToolInfoList(toolCode);
                ScrapTool_dataGridViewX2.DataSource = infoList;
                for (int i = 0; i < ScrapTool_dataGridViewX2.Columns.Count; i++)
                {
                    ScrapTool_dataGridViewX2.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
                ScrapTool_dataGridViewX2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                ScrapTool_dataGridViewX2.Columns[0].HeaderText = "工具编码";
                ScrapTool_dataGridViewX2.Columns[1].HeaderText = "名称";
                ScrapTool_dataGridViewX2.Columns[2].HeaderText = "报废时间";
                ScrapTool_dataGridViewX2.Columns[3].HeaderText = "备注";
                ScrapTool_dataGridViewX2.Columns[4].HeaderText = "操作人员";

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmScrapToolManage--Scrap_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Filter = "Excel(*.xls)|*.xls|Excel(*.xlsx)|*.xlsx";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    NPOI.SS.UserModel.IWorkbook book = null;
                    if (fileDialog.FilterIndex == 1)
                    {
                        book = new NPOI.HSSF.UserModel.HSSFWorkbook();
                    }
                    else
                    {
                        book = new NPOI.XSSF.UserModel.XSSFWorkbook();
                    }
                    NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("报废工具列表");
                    // 添加表头
                    NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
                    for (int i = 0; i < ScrapTool_dataGridViewX2.Columns.Count; i++)
                    {
                        var item = ScrapTool_dataGridViewX2.Columns[i];
                        NPOI.SS.UserModel.ICell cell = row.CreateCell(i);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.HeaderText);
                    }
                    
                    // 添加数据
                    for (int i = 0; i < infoList.Count; i++)
                    {
                        var item = infoList[i];
                        row = sheet.CreateRow(i + 1);
                        NPOI.SS.UserModel.ICell cell = row.CreateCell(0);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.ToolCode);
                        cell = row.CreateCell(1);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.ToolName);
                        cell = row.CreateCell(2);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.ScrapTime);
                        cell = row.CreateCell(3);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.Remarks);
                        cell = row.CreateCell(4);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(item.OptionPerson);
                    }
                    // 写入 
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    book.Write(ms);
                    book = null;
                    using (FileStream fs = new FileStream(fileDialog.FileName, FileMode.Create, FileAccess.Write))
                    {
                        byte[] data = ms.ToArray();
                        fs.Write(data, 0, data.Length);
                        fs.Flush();
                    }
                    ms.Close();
                    ms.Dispose();
                    MessageBox.Show("导出成功");
                    return;
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "toolstrackingsystem--FrmWorkerManager--Put_In_button_Click", ex.Message, ex.StackTrace, ex.Source);
            }

        }
        /// <summary>
        /// 打印查询到的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            FrmPrintScrapTools printFrm = new FrmPrintScrapTools();
            printFrm.Tag = Scrap_ToolInfoCode_Detail_textBox.Text;
            printFrm.ShowDialog();
        }
        #region 接收服务端发来信息的方法
        private void RecMsg()
        {
            while (true) //持续监听服务端发来的消息
            {
                if (socketClient != null && socketClient.Connected && socketClient.Available > 0)
                {
                    //定义一个1024*200的内存缓冲区 用于临时性存储接收到的信息
                    byte[] arrRecMsg = new byte[1024 * 200];

                    //将客户端套接字接收到的数据存入内存缓冲区, 并获取其长度
                    int length = socketClient.Receive(arrRecMsg);

                    string strData = Encoding.Default.GetString(arrRecMsg, 0, length);
                    var totalText = strData;
                    if (!string.IsNullOrWhiteSpace(totalText))
                    {
                        SetText(totalText);

                    }
                }
                Thread.Sleep(200);
            }
        }
        private void SetText(string text)
        {
            //获取当前有焦点的控件，然后给当前控件赋值
            Control ctl = this.ActiveControl;
            if (ctl is TextBox) //只给textbox赋值
            {
                // InvokeRequired需要比较调用线程ID和创建线程ID
                // 如果它们不相同则返回true
                if (ctl.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    ctl.Text = text;
                }
            }
        }

        #endregion
    }
}
