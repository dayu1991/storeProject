﻿namespace toolstrackingsystem
{
    partial class FrmCreditQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.Print_button = new DevComponents.DotNetBar.ButtonX();
            this.export_button = new DevComponents.DotNetBar.ButtonX();
            this.Search_buttonX = new DevComponents.DotNetBar.ButtonX();
            this.PersonCode_textBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TollList_dataGridViewX = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.pagerControl1 = new toolstrackingsystem.PageControl.PagerControl();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TollList_dataGridViewX)).BeginInit();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.White;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.Print_button);
            this.groupPanel1.Controls.Add(this.export_button);
            this.groupPanel1.Controls.Add(this.Search_buttonX);
            this.groupPanel1.Controls.Add(this.PersonCode_textBox);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(7, 9);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(896, 70);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 10;
            // 
            // Print_button
            // 
            this.Print_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Print_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Print_button.Location = new System.Drawing.Point(587, 24);
            this.Print_button.Name = "Print_button";
            this.Print_button.Size = new System.Drawing.Size(75, 23);
            this.Print_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Print_button.TabIndex = 18;
            this.Print_button.Text = "打印";
            this.Print_button.Click += new System.EventHandler(this.Print_button_Click);
            // 
            // export_button
            // 
            this.export_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.export_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.export_button.Location = new System.Drawing.Point(493, 24);
            this.export_button.Name = "export_button";
            this.export_button.Size = new System.Drawing.Size(75, 23);
            this.export_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.export_button.TabIndex = 16;
            this.export_button.Text = "导出Excel";
            this.export_button.Click += new System.EventHandler(this.export_button_Click);
            // 
            // Search_buttonX
            // 
            this.Search_buttonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Search_buttonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Search_buttonX.Location = new System.Drawing.Point(396, 24);
            this.Search_buttonX.Name = "Search_buttonX";
            this.Search_buttonX.Size = new System.Drawing.Size(75, 23);
            this.Search_buttonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Search_buttonX.TabIndex = 4;
            this.Search_buttonX.Text = "查找";
            this.Search_buttonX.Click += new System.EventHandler(this.Search_buttonX_Click);
            // 
            // PersonCode_textBox
            // 
            this.PersonCode_textBox.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.PersonCode_textBox.Border.Class = "TextBoxBorder";
            this.PersonCode_textBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PersonCode_textBox.DisabledBackColor = System.Drawing.Color.White;
            this.PersonCode_textBox.ForeColor = System.Drawing.Color.Black;
            this.PersonCode_textBox.Location = new System.Drawing.Point(263, 24);
            this.PersonCode_textBox.Name = "PersonCode_textBox";
            this.PersonCode_textBox.PreventEnterBeep = true;
            this.PersonCode_textBox.Size = new System.Drawing.Size(105, 21);
            this.PersonCode_textBox.TabIndex = 3;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(197, 24);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "人员编码:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // TollList_dataGridViewX
            // 
            this.TollList_dataGridViewX.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TollList_dataGridViewX.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.TollList_dataGridViewX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TollList_dataGridViewX.DefaultCellStyle = dataGridViewCellStyle14;
            this.TollList_dataGridViewX.EnableHeadersVisualStyles = false;
            this.TollList_dataGridViewX.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.TollList_dataGridViewX.Location = new System.Drawing.Point(0, 0);
            this.TollList_dataGridViewX.MultiSelect = false;
            this.TollList_dataGridViewX.Name = "TollList_dataGridViewX";
            this.TollList_dataGridViewX.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TollList_dataGridViewX.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.TollList_dataGridViewX.RowTemplate.Height = 23;
            this.TollList_dataGridViewX.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.TollList_dataGridViewX.Size = new System.Drawing.Size(890, 380);
            this.TollList_dataGridViewX.TabIndex = 0;
            this.TollList_dataGridViewX.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.TollList_dataGridViewX_RowStateChanged);
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.White;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.pagerControl1);
            this.groupPanel2.Controls.Add(this.TollList_dataGridViewX);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(7, 85);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(896, 433);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 11;
            // 
            // pagerControl1
            // 
            this.pagerControl1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pagerControl1.JumpText = "Go";
            this.pagerControl1.Location = new System.Drawing.Point(-1, 382);
            this.pagerControl1.Name = "pagerControl1";
            this.pagerControl1.PageIndex = 1;
            this.pagerControl1.PageSize = 100;
            this.pagerControl1.RecordCount = 0;
            this.pagerControl1.Size = new System.Drawing.Size(891, 44);
            this.pagerControl1.TabIndex = 1;
            this.pagerControl1.OnPageChanged += new System.EventHandler(this.pagerControl1_OnPageChanged);
            // 
            // FrmCreditQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 555);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.groupPanel2);
            this.Name = "FrmCreditQuery";
            this.Text = "信用查询";
            this.Load += new System.EventHandler(this.FrmCreditQuery_Load);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TollList_dataGridViewX)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX Print_button;
        private DevComponents.DotNetBar.ButtonX export_button;
        private DevComponents.DotNetBar.ButtonX Search_buttonX;
        private DevComponents.DotNetBar.Controls.TextBoxX PersonCode_textBox;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DevComponents.DotNetBar.Controls.DataGridViewX TollList_dataGridViewX;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private PageControl.PagerControl pagerControl1;

    }
}