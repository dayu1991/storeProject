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

namespace toolstrackingsystem
{
    public partial class FrmNotBackTool : Office2007RibbonForm
    {
        public FrmNotBackTool()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void TollList_dataGridViewX_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}
