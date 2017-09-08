namespace toolstrackingsystem
{

    partial class FrmPrintPersonCreditRecord
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrintPersonCreditRecord));
            this.t_PersonCreditRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cangku_manage_dbDataSet = new toolstrackingsystem.cangku_manage_dbDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.t_PersonCreditRecordTableAdapter = new toolstrackingsystem.cangku_manage_dbDataSetTableAdapters.t_PersonCreditRecordTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.t_PersonCreditRecordBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cangku_manage_dbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // t_PersonCreditRecordBindingSource
            // 
            this.t_PersonCreditRecordBindingSource.DataMember = "t_PersonCreditRecord";
            this.t_PersonCreditRecordBindingSource.DataSource = this.cangku_manage_dbDataSet;
            // 
            // cangku_manage_dbDataSet
            // 
            this.cangku_manage_dbDataSet.DataSetName = "cangku_manage_dbDataSet";
            this.cangku_manage_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.t_PersonCreditRecordBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "toolstrackingsystem.数据查询.信用查询.Report6.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(723, 351);
            this.reportViewer1.TabIndex = 0;
            // 
            // t_PersonCreditRecordTableAdapter
            // 
            this.t_PersonCreditRecordTableAdapter.ClearBeforeFill = true;
            // 
            // FrmPrintPersonCreditRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 351);
            this.Controls.Add(this.reportViewer1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrintPersonCreditRecord";
            this.Text = "打印预览";
            this.Load += new System.EventHandler(this.FrmPrintPersonCreditRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t_PersonCreditRecordBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cangku_manage_dbDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource t_PersonCreditRecordBindingSource;
        private cangku_manage_dbDataSet cangku_manage_dbDataSet;
        private cangku_manage_dbDataSetTableAdapters.t_PersonCreditRecordTableAdapter t_PersonCreditRecordTableAdapter;
    }
}