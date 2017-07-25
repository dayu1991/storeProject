namespace toolstrackingsystem
{
    partial class FrmOutTool
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
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnOutContinue = new DevComponents.DotNetBar.ButtonX();
            this.tbEditCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.btnOut = new DevComponents.DotNetBar.ButtonX();
            this.tbEditoutdescribes = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.tbEditPersonName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.tbEditPersonCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.cbEditOutTime = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.tbTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbChildTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPackNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPackName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbToolCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbToolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbCheckTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btnOutContinue);
            this.groupPanel2.Controls.Add(this.tbEditCode);
            this.groupPanel2.Controls.Add(this.labelX11);
            this.groupPanel2.Controls.Add(this.btnOut);
            this.groupPanel2.Controls.Add(this.tbEditoutdescribes);
            this.groupPanel2.Controls.Add(this.labelX10);
            this.groupPanel2.Controls.Add(this.tbEditPersonName);
            this.groupPanel2.Controls.Add(this.labelX9);
            this.groupPanel2.Controls.Add(this.tbEditPersonCode);
            this.groupPanel2.Controls.Add(this.labelX8);
            this.groupPanel2.Controls.Add(this.cbEditOutTime);
            this.groupPanel2.Controls.Add(this.labelX6);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(6, 417);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1056, 199);
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
            this.groupPanel2.TabIndex = 3;
            this.groupPanel2.Text = "工具领用信息";
            // 
            // btnOutContinue
            // 
            this.btnOutContinue.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOutContinue.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOutContinue.Location = new System.Drawing.Point(739, 72);
            this.btnOutContinue.Name = "btnOutContinue";
            this.btnOutContinue.Size = new System.Drawing.Size(84, 44);
            this.btnOutContinue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOutContinue.TabIndex = 32;
            this.btnOutContinue.Text = "继续领用";
            this.btnOutContinue.Click += new System.EventHandler(this.btnOutContinue_Click);
            // 
            // tbEditCode
            // 
            // 
            // 
            // 
            this.tbEditCode.Border.Class = "TextBoxBorder";
            this.tbEditCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbEditCode.Location = new System.Drawing.Point(73, 22);
            this.tbEditCode.Name = "tbEditCode";
            this.tbEditCode.PreventEnterBeep = true;
            this.tbEditCode.Size = new System.Drawing.Size(204, 21);
            this.tbEditCode.TabIndex = 28;
            // 
            // labelX11
            // 
            this.labelX11.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(13, 22);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(123, 23);
            this.labelX11.TabIndex = 27;
            this.labelX11.Text = "工具编码：";
            // 
            // btnOut
            // 
            this.btnOut.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOut.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOut.Location = new System.Drawing.Point(739, 22);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(84, 44);
            this.btnOut.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOut.TabIndex = 21;
            this.btnOut.Text = "确认领用";
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // tbEditoutdescribes
            // 
            // 
            // 
            // 
            this.tbEditoutdescribes.Border.Class = "TextBoxBorder";
            this.tbEditoutdescribes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbEditoutdescribes.Location = new System.Drawing.Point(73, 94);
            this.tbEditoutdescribes.Name = "tbEditoutdescribes";
            this.tbEditoutdescribes.PreventEnterBeep = true;
            this.tbEditoutdescribes.Size = new System.Drawing.Size(627, 21);
            this.tbEditoutdescribes.TabIndex = 19;
            // 
            // labelX10
            // 
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(13, 92);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(101, 23);
            this.labelX10.TabIndex = 18;
            this.labelX10.Text = "领用说明：";
            // 
            // tbEditPersonName
            // 
            // 
            // 
            // 
            this.tbEditPersonName.Border.Class = "TextBoxBorder";
            this.tbEditPersonName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbEditPersonName.Location = new System.Drawing.Point(413, 60);
            this.tbEditPersonName.Name = "tbEditPersonName";
            this.tbEditPersonName.PreventEnterBeep = true;
            this.tbEditPersonName.Size = new System.Drawing.Size(287, 21);
            this.tbEditPersonName.TabIndex = 14;
            // 
            // labelX9
            // 
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(350, 56);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(83, 23);
            this.labelX9.TabIndex = 13;
            this.labelX9.Text = "人员名称：";
            // 
            // tbEditPersonCode
            // 
            // 
            // 
            // 
            this.tbEditPersonCode.Border.Class = "TextBoxBorder";
            this.tbEditPersonCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbEditPersonCode.Location = new System.Drawing.Point(413, 22);
            this.tbEditPersonCode.Name = "tbEditPersonCode";
            this.tbEditPersonCode.PreventEnterBeep = true;
            this.tbEditPersonCode.Size = new System.Drawing.Size(287, 21);
            this.tbEditPersonCode.TabIndex = 12;
            // 
            // labelX8
            // 
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(350, 22);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(83, 23);
            this.labelX8.TabIndex = 11;
            this.labelX8.Text = "人员编码：";
            // 
            // cbEditOutTime
            // 
            this.cbEditOutTime.DisplayMember = "Text";
            this.cbEditOutTime.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEditOutTime.FormattingEnabled = true;
            this.cbEditOutTime.ItemHeight = 15;
            this.cbEditOutTime.Location = new System.Drawing.Point(73, 55);
            this.cbEditOutTime.Name = "cbEditOutTime";
            this.cbEditOutTime.Size = new System.Drawing.Size(204, 21);
            this.cbEditOutTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbEditOutTime.TabIndex = 7;
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(8, 56);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(85, 23);
            this.labelX6.TabIndex = 6;
            this.labelX6.Text = "使用时间：";
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tbTypeName,
            this.tbChildTypeName,
            this.tbPackNo,
            this.tbPackName,
            this.tbToolCode,
            this.tbToolName,
            this.tbModel,
            this.tbPosition,
            this.tbRemarks,
            this.tbCheckTime});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(6, 3);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(1056, 408);
            this.dataGridViewX1.TabIndex = 4;
            // 
            // tbTypeName
            // 
            this.tbTypeName.DataPropertyName = "TypeName";
            this.tbTypeName.HeaderText = "工具配属";
            this.tbTypeName.Name = "tbTypeName";
            this.tbTypeName.ReadOnly = true;
            // 
            // tbChildTypeName
            // 
            this.tbChildTypeName.DataPropertyName = "ChildTypeName";
            this.tbChildTypeName.HeaderText = "工具类别";
            this.tbChildTypeName.Name = "tbChildTypeName";
            this.tbChildTypeName.ReadOnly = true;
            // 
            // tbPackNo
            // 
            this.tbPackNo.DataPropertyName = "PackCode";
            this.tbPackNo.HeaderText = "包编号";
            this.tbPackNo.Name = "tbPackNo";
            this.tbPackNo.ReadOnly = true;
            // 
            // tbPackName
            // 
            this.tbPackName.DataPropertyName = "PackName";
            this.tbPackName.HeaderText = "包名称";
            this.tbPackName.Name = "tbPackName";
            this.tbPackName.ReadOnly = true;
            // 
            // tbToolCode
            // 
            this.tbToolCode.DataPropertyName = "ToolCode";
            this.tbToolCode.HeaderText = "编号";
            this.tbToolCode.Name = "tbToolCode";
            this.tbToolCode.ReadOnly = true;
            // 
            // tbToolName
            // 
            this.tbToolName.DataPropertyName = "ToolName";
            this.tbToolName.HeaderText = "名称";
            this.tbToolName.Name = "tbToolName";
            this.tbToolName.ReadOnly = true;
            // 
            // tbModel
            // 
            this.tbModel.DataPropertyName = "Models";
            this.tbModel.HeaderText = "型号";
            this.tbModel.Name = "tbModel";
            this.tbModel.ReadOnly = true;
            // 
            // tbPosition
            // 
            this.tbPosition.DataPropertyName = "Location";
            this.tbPosition.HeaderText = "位置";
            this.tbPosition.Name = "tbPosition";
            this.tbPosition.ReadOnly = true;
            // 
            // tbRemarks
            // 
            this.tbRemarks.DataPropertyName = "Remarks";
            this.tbRemarks.HeaderText = "备注";
            this.tbRemarks.Name = "tbRemarks";
            this.tbRemarks.ReadOnly = true;
            // 
            // tbCheckTime
            // 
            this.tbCheckTime.DataPropertyName = "OptionPerson";
            this.tbCheckTime.HeaderText = "操作人员";
            this.tbCheckTime.Name = "tbCheckTime";
            this.tbCheckTime.ReadOnly = true;
            // 
            // FrmOutTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 630);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.groupPanel2);
            this.Name = "FrmOutTool";
            this.Text = "FrmOutTool";
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbEditCode;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.ButtonX btnOut;
        private DevComponents.DotNetBar.Controls.TextBoxX tbEditoutdescribes;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.Controls.TextBoxX tbEditPersonName;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.TextBoxX tbEditPersonCode;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbEditOutTime;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.ButtonX btnOutContinue;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbChildTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbPackNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbPackName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbToolCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbToolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbCheckTime;
    }
}