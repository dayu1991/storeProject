﻿namespace toolstrackingsystem
{
    partial class FrmPrint
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
            this.t_PersonInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //this.cangku_manage_dbDataSet = new toolstrackingsystem.cangku_manage_dbDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            //this.t_PersonInfoTableAdapter = new //toolstrackingsystem.cangku_manage_dbDataSetTableAdapters.t_PersonInfoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.t_PersonInfoBindingSource)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.cangku_manage_dbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // t_PersonInfoBindingSource
            // 
            //this.t_PersonInfoBindingSource.DataMember = "t_PersonInfo";
            //this.t_PersonInfoBindingSource.DataSource = this.cangku_manage_dbDataSet;
            // 
            // cangku_manage_dbDataSet
            // 
            //this.cangku_manage_dbDataSet.DataSetName = "cangku_manage_dbDataSet";
            //this.cangku_manage_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.t_PersonInfoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "toolstrackingsystem.作业人员.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(723, 351);
            this.reportViewer1.TabIndex = 0;
            // 
            // t_PersonInfoTableAdapter
            // 
            //this.t_PersonInfoTableAdapter.ClearBeforeFill = true;
            // 
            // FrmPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 351);
            this.Controls.Add(this.reportViewer1);
            this.DoubleBuffered = true;
            this.Name = "FrmPrint";
            this.Text = "打印预览";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t_PersonInfoBindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.cangku_manage_dbDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource t_PersonInfoBindingSource;
    }
}