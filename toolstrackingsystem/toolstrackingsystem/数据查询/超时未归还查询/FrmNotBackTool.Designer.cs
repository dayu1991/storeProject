namespace toolstrackingsystem
{
    partial class FrmNotBackTool
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.Print_button = new DevComponents.DotNetBar.ButtonX();
            this.export_button = new DevComponents.DotNetBar.ButtonX();
            this.Search_buttonX = new DevComponents.DotNetBar.ButtonX();
            this.ToolCode_textBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.PersonCode_textBox = new System.Windows.Forms.TextBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
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
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.Print_button);
            this.groupPanel1.Controls.Add(this.export_button);
            this.groupPanel1.Controls.Add(this.Search_buttonX);
            this.groupPanel1.Controls.Add(this.ToolCode_textBox);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.PersonCode_textBox);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(10, 9);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1454, 70);
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
            this.groupPanel1.TabIndex = 8;
            // 
            // Print_button
            // 
            this.Print_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Print_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Print_button.Location = new System.Drawing.Point(700, 21);
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
            this.export_button.Location = new System.Drawing.Point(606, 21);
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
            this.Search_buttonX.Location = new System.Drawing.Point(509, 21);
            this.Search_buttonX.Name = "Search_buttonX";
            this.Search_buttonX.Size = new System.Drawing.Size(75, 23);
            this.Search_buttonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Search_buttonX.TabIndex = 4;
            this.Search_buttonX.Text = "查找";
            this.Search_buttonX.Click += new System.EventHandler(this.Search_buttonX_Click);
            // 
            // ToolCode_textBox
            // 
            // 
            // 
            // 
            this.ToolCode_textBox.Border.Class = "TextBoxBorder";
            this.ToolCode_textBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ToolCode_textBox.Location = new System.Drawing.Point(376, 21);
            this.ToolCode_textBox.Name = "ToolCode_textBox";
            this.ToolCode_textBox.PreventEnterBeep = true;
            this.ToolCode_textBox.Size = new System.Drawing.Size(105, 21);
            this.ToolCode_textBox.TabIndex = 3;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(310, 21);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "工具编码:";
            // 
            // PersonCode_textBox
            // 
            this.PersonCode_textBox.Location = new System.Drawing.Point(167, 21);
            this.PersonCode_textBox.Name = "PersonCode_textBox";
            this.PersonCode_textBox.Size = new System.Drawing.Size(119, 21);
            this.PersonCode_textBox.TabIndex = 1;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(93, 21);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(72, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "人员编码:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // TollList_dataGridViewX
            // 
            this.TollList_dataGridViewX.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TollList_dataGridViewX.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.TollList_dataGridViewX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TollList_dataGridViewX.DefaultCellStyle = dataGridViewCellStyle2;
            this.TollList_dataGridViewX.EnableHeadersVisualStyles = false;
            this.TollList_dataGridViewX.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.TollList_dataGridViewX.Location = new System.Drawing.Point(-4, -1);
            this.TollList_dataGridViewX.MultiSelect = false;
            this.TollList_dataGridViewX.Name = "TollList_dataGridViewX";
            this.TollList_dataGridViewX.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TollList_dataGridViewX.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.TollList_dataGridViewX.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.TollList_dataGridViewX.RowTemplate.Height = 23;
            this.TollList_dataGridViewX.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.TollList_dataGridViewX.Size = new System.Drawing.Size(1455, 591);
            this.TollList_dataGridViewX.TabIndex = 0;
            this.TollList_dataGridViewX.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.TollList_dataGridViewX_RowStateChanged);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.pagerControl1);
            this.groupPanel2.Controls.Add(this.TollList_dataGridViewX);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(10, 85);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1454, 643);
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
            this.groupPanel2.TabIndex = 9;
            // 
            // pagerControl1
            // 
            this.pagerControl1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pagerControl1.JumpText = "Go";
            this.pagerControl1.Location = new System.Drawing.Point(-3, 591);
            this.pagerControl1.Name = "pagerControl1";
            this.pagerControl1.PageIndex = 1;
            this.pagerControl1.PageSize = 100;
            this.pagerControl1.RecordCount = 0;
            this.pagerControl1.Size = new System.Drawing.Size(1454, 44);
            this.pagerControl1.TabIndex = 1;
            this.pagerControl1.OnPageChanged += new System.EventHandler(this.pagerControl1_OnPageChanged);
            // 
            // FrmNotBackTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1469, 733);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.groupPanel2);
            this.Name = "FrmNotBackTool";
            this.Text = "超时查询";
            this.Load += new System.EventHandler(this.FrmNotBackTool_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
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
        private DevComponents.DotNetBar.Controls.TextBoxX ToolCode_textBox;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.TextBox PersonCode_textBox;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DevComponents.DotNetBar.Controls.DataGridViewX TollList_dataGridViewX;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private PageControl.PagerControl pagerControl1;
    }
}