namespace toolstrackingsystem
{
    partial class FrmPrintToolInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrintToolInfo));
            this.t_ToolInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cangku_manage_dbDataSet = new toolstrackingsystem.cangku_manage_dbDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.t_ToolInfoTableAdapter = new toolstrackingsystem.cangku_manage_dbDataSetTableAdapters.t_ToolInfoTableAdapter();
            this.ToolInfoExtendBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.t_ToolInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cangku_manage_dbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolInfoExtendBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // t_ToolInfoBindingSource
            // 
            this.t_ToolInfoBindingSource.DataMember = "t_ToolInfo";
            this.t_ToolInfoBindingSource.DataSource = this.cangku_manage_dbDataSet;
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
            reportDataSource1.Value = this.ToolInfoExtendBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "toolstrackingsystem.基础数据.工具管理.Report11.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(849, 495);
            this.reportViewer1.TabIndex = 0;
            // 
            // t_ToolInfoTableAdapter
            // 
            this.t_ToolInfoTableAdapter.ClearBeforeFill = true;
            // 
            // ToolInfoExtendBindingSource
            // 
            this.ToolInfoExtendBindingSource.DataMember = "ToolInfoExtend";
            this.ToolInfoExtendBindingSource.DataSource = this.cangku_manage_dbDataSet;
            // 
            // FrmPrintToolInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 495);
            this.Controls.Add(this.reportViewer1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrintToolInfo";
            this.Text = "打印预览";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrintToolInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t_ToolInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cangku_manage_dbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolInfoExtendBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource t_ToolInfoBindingSource;
        private cangku_manage_dbDataSet cangku_manage_dbDataSet;
        private cangku_manage_dbDataSetTableAdapters.t_ToolInfoTableAdapter t_ToolInfoTableAdapter;
        private System.Windows.Forms.BindingSource ToolInfoExtendBindingSource;

    }
}