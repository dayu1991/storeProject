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

namespace toolstrackingsystem
{
    public partial class FrmAddRemarkForScrapedTool : Office2007Form
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FrmAddRemarkForScrapedTool));
        public IToolRepairRecordService _toolRepairRecordService;
        private t_ToolRepairRecord toolRepairRecord;
        public FrmAddRemarkForScrapedTool()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrmAddRemarkForScrapedTool_Load(object sender, EventArgs e)
        {
            _toolRepairRecordService = Program.container.Resolve<ToolRepairRecordService>();
            toolRepairRecord = (t_ToolRepairRecord)this.Tag;
            if (toolRepairRecord != null)
            {
                tool_Code_Label.Text = toolRepairRecord.ToolCode;
                Scrap_Memo_richTextBoxEx1.Text = toolRepairRecord.ScrapMemo;
            }
            else {
                MessageBox.Show("工具信息不存在，请重新选择工具");
                this.Dispose();
            }

        }

        private void Save_buttonX_Click(object sender, EventArgs e)
        {
            if (Scrap_Memo_richTextBoxEx1.Text == "")
            {
                MessageBox.Show("备注信息不能为空");
                return;
            }
            toolRepairRecord.ScrapMemo = Scrap_Memo_richTextBoxEx1.Text;
            if (_toolRepairRecordService.UpdateToolRepairInfo(toolRepairRecord))
            {
                MessageBox.Show("备注更新成功");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Dispose();
            }
        }

        private void Cancel_buttonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Dispose();
        }

    }
}
