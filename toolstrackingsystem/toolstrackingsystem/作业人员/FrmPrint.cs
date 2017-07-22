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
            this.t_PersonInfoTableAdapter.Fill(this.cangku_manage_dbDataSet.t_PersonInfo);

            this.reportViewer1.RefreshReport();
        }
    }
}
