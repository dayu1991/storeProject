namespace toolstrackingsystem
{
    partial class FrmWorkerManager
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
            this.Remark_textBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.PersonName_Detail_textBox = new System.Windows.Forms.TextBox();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.PersonCode_Detail_textBox = new System.Windows.Forms.TextBox();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.Delete_button = new DevComponents.DotNetBar.ButtonX();
            this.Edit_button = new DevComponents.DotNetBar.ButtonX();
            this.Add_button = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.PersonList_dataGridViewX = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Search_buttonX = new DevComponents.DotNetBar.ButtonX();
            this.PersonName_textBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.PersonCode_textBox = new System.Windows.Forms.TextBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.Can_TakeOut_checkBox = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.Print_button = new DevComponents.DotNetBar.ButtonX();
            this.Pull_Out_button = new DevComponents.DotNetBar.ButtonX();
            this.Put_In_button = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.Is_Receive_checkBox = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pagerControl1 = new toolstrackingsystem.PageControl.PagerControl();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PersonList_dataGridViewX)).BeginInit();
            this.groupPanel3.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Remark_textBox
            // 
            // 
            // 
            // 
            this.Remark_textBox.Border.Class = "TextBoxBorder";
            this.Remark_textBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Remark_textBox.Location = new System.Drawing.Point(553, 15);
            this.Remark_textBox.Name = "Remark_textBox";
            this.Remark_textBox.PreventEnterBeep = true;
            this.Remark_textBox.Size = new System.Drawing.Size(306, 21);
            this.Remark_textBox.TabIndex = 13;
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(505, 16);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(55, 23);
            this.labelX7.TabIndex = 12;
            this.labelX7.Text = "备注:";
            // 
            // PersonName_Detail_textBox
            // 
            this.PersonName_Detail_textBox.Location = new System.Drawing.Point(274, 16);
            this.PersonName_Detail_textBox.Name = "PersonName_Detail_textBox";
            this.PersonName_Detail_textBox.Size = new System.Drawing.Size(120, 21);
            this.PersonName_Detail_textBox.TabIndex = 6;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(208, 16);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 5;
            this.labelX4.Text = "人员名称:";
            // 
            // PersonCode_Detail_textBox
            // 
            this.PersonCode_Detail_textBox.Location = new System.Drawing.Point(96, 16);
            this.PersonCode_Detail_textBox.Name = "PersonCode_Detail_textBox";
            this.PersonCode_Detail_textBox.Size = new System.Drawing.Size(114, 21);
            this.PersonCode_Detail_textBox.TabIndex = 4;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(34, 16);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(66, 23);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "人员编码:";
            // 
            // Delete_button
            // 
            this.Delete_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Delete_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Delete_button.Location = new System.Drawing.Point(295, 52);
            this.Delete_button.Name = "Delete_button";
            this.Delete_button.Size = new System.Drawing.Size(75, 23);
            this.Delete_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Delete_button.TabIndex = 2;
            this.Delete_button.Text = "删除";
            this.Delete_button.Click += new System.EventHandler(this.Delete_button_Click);
            // 
            // Edit_button
            // 
            this.Edit_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Edit_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Edit_button.Location = new System.Drawing.Point(183, 52);
            this.Edit_button.Name = "Edit_button";
            this.Edit_button.Size = new System.Drawing.Size(75, 23);
            this.Edit_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Edit_button.TabIndex = 1;
            this.Edit_button.Text = "修改";
            this.Edit_button.Click += new System.EventHandler(this.Edit_button_Click);
            // 
            // Add_button
            // 
            this.Add_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Add_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Add_button.Location = new System.Drawing.Point(60, 52);
            this.Add_button.Name = "Add_button";
            this.Add_button.Size = new System.Drawing.Size(75, 23);
            this.Add_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Add_button.TabIndex = 0;
            this.Add_button.Text = "添加";
            this.Add_button.Click += new System.EventHandler(this.Add_button_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.pagerControl1);
            this.groupPanel2.Controls.Add(this.PersonList_dataGridViewX);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(11, 83);
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
            this.groupPanel2.TabIndex = 4;
            // 
            // PersonList_dataGridViewX
            // 
            this.PersonList_dataGridViewX.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PersonList_dataGridViewX.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.PersonList_dataGridViewX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PersonList_dataGridViewX.DefaultCellStyle = dataGridViewCellStyle2;
            this.PersonList_dataGridViewX.EnableHeadersVisualStyles = false;
            this.PersonList_dataGridViewX.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.PersonList_dataGridViewX.Location = new System.Drawing.Point(0, 0);
            this.PersonList_dataGridViewX.MultiSelect = false;
            this.PersonList_dataGridViewX.Name = "PersonList_dataGridViewX";
            this.PersonList_dataGridViewX.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PersonList_dataGridViewX.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.PersonList_dataGridViewX.RowTemplate.Height = 23;
            this.PersonList_dataGridViewX.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.PersonList_dataGridViewX.Size = new System.Drawing.Size(890, 282);
            this.PersonList_dataGridViewX.TabIndex = 0;
            this.PersonList_dataGridViewX.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PersonList_dataGridViewX_CellClick);
            this.PersonList_dataGridViewX.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.PersonList_dataGridViewX_RowStateChanged);
            // 
            // Search_buttonX
            // 
            this.Search_buttonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Search_buttonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Search_buttonX.Location = new System.Drawing.Point(606, 21);
            this.Search_buttonX.Name = "Search_buttonX";
            this.Search_buttonX.Size = new System.Drawing.Size(75, 23);
            this.Search_buttonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Search_buttonX.TabIndex = 4;
            this.Search_buttonX.Text = "查找";
            this.Search_buttonX.Click += new System.EventHandler(this.Search_buttonX_Click);
            // 
            // PersonName_textBox
            // 
            // 
            // 
            // 
            this.PersonName_textBox.Border.Class = "TextBoxBorder";
            this.PersonName_textBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PersonName_textBox.Location = new System.Drawing.Point(338, 21);
            this.PersonName_textBox.Name = "PersonName_textBox";
            this.PersonName_textBox.PreventEnterBeep = true;
            this.PersonName_textBox.Size = new System.Drawing.Size(137, 21);
            this.PersonName_textBox.TabIndex = 3;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(272, 21);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "人员名称:";
            // 
            // PersonCode_textBox
            // 
            this.PersonCode_textBox.Location = new System.Drawing.Point(112, 21);
            this.PersonCode_textBox.Name = "PersonCode_textBox";
            this.PersonCode_textBox.Size = new System.Drawing.Size(137, 21);
            this.PersonCode_textBox.TabIndex = 1;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(38, 21);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(72, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "人员编码:";
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.Can_TakeOut_checkBox);
            this.groupPanel3.Controls.Add(this.Print_button);
            this.groupPanel3.Controls.Add(this.Pull_Out_button);
            this.groupPanel3.Controls.Add(this.Put_In_button);
            this.groupPanel3.Controls.Add(this.Remark_textBox);
            this.groupPanel3.Controls.Add(this.labelX7);
            this.groupPanel3.Controls.Add(this.PersonName_Detail_textBox);
            this.groupPanel3.Controls.Add(this.labelX4);
            this.groupPanel3.Controls.Add(this.PersonCode_Detail_textBox);
            this.groupPanel3.Controls.Add(this.labelX3);
            this.groupPanel3.Controls.Add(this.Delete_button);
            this.groupPanel3.Controls.Add(this.Edit_button);
            this.groupPanel3.Controls.Add(this.Add_button);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Location = new System.Drawing.Point(11, 421);
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
            this.groupPanel3.TabIndex = 5;
            // 
            // Can_TakeOut_checkBox
            // 
            this.Can_TakeOut_checkBox.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.Can_TakeOut_checkBox.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Can_TakeOut_checkBox.Checked = true;
            this.Can_TakeOut_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Can_TakeOut_checkBox.CheckValue = "Y";
            this.Can_TakeOut_checkBox.Location = new System.Drawing.Point(412, 15);
            this.Can_TakeOut_checkBox.Name = "Can_TakeOut_checkBox";
            this.Can_TakeOut_checkBox.Size = new System.Drawing.Size(87, 23);
            this.Can_TakeOut_checkBox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Can_TakeOut_checkBox.TabIndex = 18;
            this.Can_TakeOut_checkBox.Text = "领用权限";
            // 
            // Print_button
            // 
            this.Print_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Print_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Print_button.Location = new System.Drawing.Point(633, 52);
            this.Print_button.Name = "Print_button";
            this.Print_button.Size = new System.Drawing.Size(75, 23);
            this.Print_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Print_button.TabIndex = 17;
            this.Print_button.Text = "打印";
            this.Print_button.Click += new System.EventHandler(this.Print_button_Click);
            // 
            // Pull_Out_button
            // 
            this.Pull_Out_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Pull_Out_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Pull_Out_button.Location = new System.Drawing.Point(525, 52);
            this.Pull_Out_button.Name = "Pull_Out_button";
            this.Pull_Out_button.Size = new System.Drawing.Size(75, 23);
            this.Pull_Out_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Pull_Out_button.TabIndex = 16;
            this.Pull_Out_button.Text = "导入Excel";
            this.Pull_Out_button.Click += new System.EventHandler(this.Pull_Out_button_Click);
            // 
            // Put_In_button
            // 
            this.Put_In_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Put_In_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Put_In_button.Location = new System.Drawing.Point(413, 52);
            this.Put_In_button.Name = "Put_In_button";
            this.Put_In_button.Size = new System.Drawing.Size(75, 23);
            this.Put_In_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Put_In_button.TabIndex = 15;
            this.Put_In_button.Text = "导出Excel";
            this.Put_In_button.Click += new System.EventHandler(this.Put_In_button_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.Is_Receive_checkBox);
            this.groupPanel1.Controls.Add(this.Search_buttonX);
            this.groupPanel1.Controls.Add(this.PersonName_textBox);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.PersonCode_textBox);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(11, 7);
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
            this.groupPanel1.TabIndex = 3;
            // 
            // Is_Receive_checkBox
            // 
            this.Is_Receive_checkBox.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.Is_Receive_checkBox.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Is_Receive_checkBox.Checked = true;
            this.Is_Receive_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Is_Receive_checkBox.CheckValue = "Y";
            this.Is_Receive_checkBox.Location = new System.Drawing.Point(500, 21);
            this.Is_Receive_checkBox.Name = "Is_Receive_checkBox";
            this.Is_Receive_checkBox.Size = new System.Drawing.Size(100, 23);
            this.Is_Receive_checkBox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Is_Receive_checkBox.TabIndex = 5;
            this.Is_Receive_checkBox.Text = "领用权限";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // pagerControl1
            // 
            this.pagerControl1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pagerControl1.JumpText = "Go";
            this.pagerControl1.Location = new System.Drawing.Point(0, 284);
            this.pagerControl1.Name = "pagerControl1";
            this.pagerControl1.PageIndex = 1;
            this.pagerControl1.PageSize = 100;
            this.pagerControl1.RecordCount = 0;
            this.pagerControl1.Size = new System.Drawing.Size(887, 44);
            this.pagerControl1.TabIndex = 1;
            // 
            // FrmWorkerManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 569);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.groupPanel1);
            this.Name = "FrmWorkerManager";
            this.Text = "Frmworkermanager";
            this.Load += new System.EventHandler(this.FrmWorkerManager_Load);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PersonList_dataGridViewX)).EndInit();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX Remark_textBox;
        private DevComponents.DotNetBar.LabelX labelX7;
        private System.Windows.Forms.TextBox PersonName_Detail_textBox;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.TextBox PersonCode_Detail_textBox;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX Delete_button;
        private DevComponents.DotNetBar.ButtonX Edit_button;
        private DevComponents.DotNetBar.ButtonX Add_button;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX PersonList_dataGridViewX;
        private DevComponents.DotNetBar.ButtonX Search_buttonX;
        private DevComponents.DotNetBar.Controls.TextBoxX PersonName_textBox;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.TextBox PersonCode_textBox;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX Print_button;
        private DevComponents.DotNetBar.ButtonX Pull_Out_button;
        private DevComponents.DotNetBar.ButtonX Put_In_button;
        private PageControl.PagerControl pagerControl1;
        private DevComponents.DotNetBar.Controls.CheckBoxX Is_Receive_checkBox;
        private DevComponents.DotNetBar.Controls.CheckBoxX Can_TakeOut_checkBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}