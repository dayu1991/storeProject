namespace toolstrackingsystem
{
    partial class PrintCurrentCountInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintCurrentCountInfo));
            this.t_CurrentCountInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cangku_manage_dbDataSet = new toolstrackingsystem.cangku_manage_dbDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.t_CurrentCountInfoTableAdapter = new toolstrackingsystem.cangku_manage_dbDataSetTableAdapters.t_CurrentCountInfoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.t_CurrentCountInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cangku_manage_dbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // t_CurrentCountInfoBindingSource
            // 
            this.t_CurrentCountInfoBindingSource.DataMember = "t_CurrentCountInfo";
            this.t_CurrentCountInfoBindingSource.DataSource = this.cangku_manage_dbDataSet;
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
            reportDataSource1.Value = this.t_CurrentCountInfoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "toolstrackingsystem.流水账.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(723, 351);
            this.reportViewer1.TabIndex = 0;
            // 
            // t_CurrentCountInfoTableAdapter
            // 
            this.t_CurrentCountInfoTableAdapter.ClearBeforeFill = true;
            // 
            // PrintCurrentCountInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 351);
            this.Controls.Add(this.reportViewer1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrintCurrentCountInfo";
            this.Text = "打印预览";
            this.Load += new System.EventHandler(this.PrintCurrentCountInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t_CurrentCountInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cangku_manage_dbDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource t_CurrentCountInfoBindingSource;
        private cangku_manage_dbDataSet cangku_manage_dbDataSet;
        private cangku_manage_dbDataSetTableAdapters.t_CurrentCountInfoTableAdapter t_CurrentCountInfoTableAdapter;
    }
}