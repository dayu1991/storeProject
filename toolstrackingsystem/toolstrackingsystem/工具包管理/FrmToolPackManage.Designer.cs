namespace toolstrackingsystem
{
    partial class FrmToolPackManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ToolInfoList_dataGridViewX = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.Add_button = new DevComponents.DotNetBar.ButtonX();
            this.Edit_button = new DevComponents.DotNetBar.ButtonX();
            this.Delete_button = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.ToolInfoCode_Detail_textBox = new System.Windows.Forms.TextBox();
            this.Print_button = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.Pack_Code_textBox = new System.Windows.Forms.TextBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.Pack_Name_textBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Search_buttonX = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.type_comboBox = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.ToolInfoList_dataGridViewX)).BeginInit();
            this.groupPanel2.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolInfoList_dataGridViewX
            // 
            this.ToolInfoList_dataGridViewX.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ToolInfoList_dataGridViewX.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ToolInfoList_dataGridViewX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ToolInfoList_dataGridViewX.DefaultCellStyle = dataGridViewCellStyle5;
            this.ToolInfoList_dataGridViewX.EnableHeadersVisualStyles = false;
            this.ToolInfoList_dataGridViewX.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.ToolInfoList_dataGridViewX.Location = new System.Drawing.Point(0, 0);
            this.ToolInfoList_dataGridViewX.MultiSelect = false;
            this.ToolInfoList_dataGridViewX.Name = "ToolInfoList_dataGridViewX";
            this.ToolInfoList_dataGridViewX.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ToolInfoList_dataGridViewX.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.ToolInfoList_dataGridViewX.RowTemplate.Height = 23;
            this.ToolInfoList_dataGridViewX.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ToolInfoList_dataGridViewX.Size = new System.Drawing.Size(890, 323);
            this.ToolInfoList_dataGridViewX.TabIndex = 0;
            this.ToolInfoList_dataGridViewX.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ToolInfoList_dataGridViewX_CellClick);
            this.ToolInfoList_dataGridViewX.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.ToolInfoList_dataGridViewX_CellStateChanged);
            this.ToolInfoList_dataGridViewX.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.ToolInfoList_dataGridViewX_RowStateChanged);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.ToolInfoList_dataGridViewX);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(9, 87);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(896, 332);
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
            this.groupPanel2.TabIndex = 7;
            // 
            // Add_button
            // 
            this.Add_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Add_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Add_button.Location = new System.Drawing.Point(362, 30);
            this.Add_button.Name = "Add_button";
            this.Add_button.Size = new System.Drawing.Size(75, 23);
            this.Add_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Add_button.TabIndex = 0;
            this.Add_button.Text = "添加";
            this.Add_button.Click += new System.EventHandler(this.Add_button_Click);
            // 
            // Edit_button
            // 
            this.Edit_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Edit_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Edit_button.Location = new System.Drawing.Point(580, 30);
            this.Edit_button.Name = "Edit_button";
            this.Edit_button.Size = new System.Drawing.Size(75, 23);
            this.Edit_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Edit_button.TabIndex = 1;
            this.Edit_button.Text = "完成组包";
            this.Edit_button.Click += new System.EventHandler(this.Edit_button_Click);
            // 
            // Delete_button
            // 
            this.Delete_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Delete_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Delete_button.Location = new System.Drawing.Point(470, 30);
            this.Delete_button.Name = "Delete_button";
            this.Delete_button.Size = new System.Drawing.Size(75, 23);
            this.Delete_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Delete_button.TabIndex = 2;
            this.Delete_button.Text = "删除";
            this.Delete_button.CheckedChanged += new System.EventHandler(this.Delete_button_CheckedChanged);
            this.Delete_button.Click += new System.EventHandler(this.Delete_button_Click);
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(49, 30);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(66, 23);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "工具编码:";
            // 
            // ToolInfoCode_Detail_textBox
            // 
            this.ToolInfoCode_Detail_textBox.Location = new System.Drawing.Point(121, 30);
            this.ToolInfoCode_Detail_textBox.Name = "ToolInfoCode_Detail_textBox";
            this.ToolInfoCode_Detail_textBox.Size = new System.Drawing.Size(204, 21);
            this.ToolInfoCode_Detail_textBox.TabIndex = 4;
            // 
            // Print_button
            // 
            this.Print_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Print_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Print_button.Location = new System.Drawing.Point(688, 30);
            this.Print_button.Name = "Print_button";
            this.Print_button.Size = new System.Drawing.Size(75, 23);
            this.Print_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Print_button.TabIndex = 17;
            this.Print_button.Text = "清空";
            this.Print_button.Click += new System.EventHandler(this.Print_button_Click);
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.Print_button);
            this.groupPanel3.Controls.Add(this.ToolInfoCode_Detail_textBox);
            this.groupPanel3.Controls.Add(this.labelX3);
            this.groupPanel3.Controls.Add(this.Delete_button);
            this.groupPanel3.Controls.Add(this.Edit_button);
            this.groupPanel3.Controls.Add(this.Add_button);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Location = new System.Drawing.Point(9, 425);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(896, 94);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 8;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(234, 21);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(51, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "包编码:";
            // 
            // Pack_Code_textBox
            // 
            this.Pack_Code_textBox.Location = new System.Drawing.Point(291, 21);
            this.Pack_Code_textBox.Name = "Pack_Code_textBox";
            this.Pack_Code_textBox.Size = new System.Drawing.Size(137, 21);
            this.Pack_Code_textBox.TabIndex = 1;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(462, 21);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(49, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "包名称:";
            // 
            // Pack_Name_textBox
            // 
            // 
            // 
            // 
            this.Pack_Name_textBox.Border.Class = "TextBoxBorder";
            this.Pack_Name_textBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Pack_Name_textBox.Location = new System.Drawing.Point(517, 21);
            this.Pack_Name_textBox.Name = "Pack_Name_textBox";
            this.Pack_Name_textBox.PreventEnterBeep = true;
            this.Pack_Name_textBox.Size = new System.Drawing.Size(137, 21);
            this.Pack_Name_textBox.TabIndex = 3;
            // 
            // Search_buttonX
            // 
            this.Search_buttonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Search_buttonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Search_buttonX.Location = new System.Drawing.Point(688, 21);
            this.Search_buttonX.Name = "Search_buttonX";
            this.Search_buttonX.Size = new System.Drawing.Size(75, 23);
            this.Search_buttonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Search_buttonX.TabIndex = 4;
            this.Search_buttonX.Text = "查找";
            this.Search_buttonX.Click += new System.EventHandler(this.Search_buttonX_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.type_comboBox);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.Search_buttonX);
            this.groupPanel1.Controls.Add(this.Pack_Name_textBox);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.Pack_Code_textBox);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(9, 11);
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
            this.groupPanel1.TabIndex = 6;
            // 
            // type_comboBox
            // 
            this.type_comboBox.DisplayMember = "Text";
            this.type_comboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.type_comboBox.FormattingEnabled = true;
            this.type_comboBox.ItemHeight = 15;
            this.type_comboBox.Location = new System.Drawing.Point(96, 21);
            this.type_comboBox.Name = "type_comboBox";
            this.type_comboBox.Size = new System.Drawing.Size(121, 21);
            this.type_comboBox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.type_comboBox.TabIndex = 6;
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(49, 21);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(51, 23);
            this.labelX5.TabIndex = 5;
            this.labelX5.Text = "包类别:";
            // 
            // FrmToolPackManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 531);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.groupPanel2);
            this.Name = "FrmToolPackManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工具包管理";
            this.Load += new System.EventHandler(this.FrmToolPackManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ToolInfoList_dataGridViewX)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX ToolInfoList_dataGridViewX;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX Add_button;
        private DevComponents.DotNetBar.ButtonX Edit_button;
        private DevComponents.DotNetBar.ButtonX Delete_button;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.TextBox ToolInfoCode_Detail_textBox;
        private DevComponents.DotNetBar.ButtonX Print_button;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.TextBox Pack_Code_textBox;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX Pack_Name_textBox;
        private DevComponents.DotNetBar.ButtonX Search_buttonX;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx type_comboBox;
    }
}