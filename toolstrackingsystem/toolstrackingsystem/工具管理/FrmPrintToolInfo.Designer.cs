﻿namespace toolstrackingsystem
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cangku_manage_dbDataSet = new toolstrackingsystem.cangku_manage_dbDataSet();
            this.t_ToolInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.t_ToolInfoTableAdapter = new toolstrackingsystem.cangku_manage_dbDataSetTableAdapters.t_ToolInfoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cangku_manage_dbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_ToolInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.t_ToolInfoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "toolstrackingsystem.工具管理.ToolInfo.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-6, -2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(861, 503);
            this.reportViewer1.TabIndex = 0;
            // 
            // cangku_manage_dbDataSet
            // 
            this.cangku_manage_dbDataSet.DataSetName = "cangku_manage_dbDataSet";
            this.cangku_manage_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // t_ToolInfoBindingSource
            // 
            this.t_ToolInfoBindingSource.DataMember = "t_ToolInfo";
            this.t_ToolInfoBindingSource.DataSource = this.cangku_manage_dbDataSet;
            // 
            // t_ToolInfoTableAdapter
            // 
            this.t_ToolInfoTableAdapter.ClearBeforeFill = true;
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
            this.Load += new System.EventHandler(this.FrmPrintToolInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cangku_manage_dbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_ToolInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource t_ToolInfoBindingSource;
        private cangku_manage_dbDataSet cangku_manage_dbDataSet;
        private cangku_manage_dbDataSetTableAdapters.t_ToolInfoTableAdapter t_ToolInfoTableAdapter;

    }
}