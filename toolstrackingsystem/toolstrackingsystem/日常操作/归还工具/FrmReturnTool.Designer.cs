﻿namespace toolstrackingsystem
{
    partial class FrmReturnTool
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.tbTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbChildTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPackNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPackName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbToolCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbToolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbOutStoreTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbOutDescribe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPersonCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPersonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbCheckTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnAddTool = new DevComponents.DotNetBar.ButtonX();
            this.btnReturnContinue = new DevComponents.DotNetBar.ButtonX();
            this.btnReturn = new DevComponents.DotNetBar.ButtonX();
            this.tbEditoutdescribes = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.tbEditCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
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
            this.tbOutStoreTime,
            this.tbOutDescribe,
            this.tbPersonCode,
            this.tbPersonName,
            this.tbCheckTime});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(6, 4);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(1472, 580);
            this.dataGridViewX1.TabIndex = 5;
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
            this.tbToolName.Width = 150;
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
            // tbOutStoreTime
            // 
            this.tbOutStoreTime.DataPropertyName = "OutStoreTime";
            this.tbOutStoreTime.HeaderText = "领用时间";
            this.tbOutStoreTime.Name = "tbOutStoreTime";
            this.tbOutStoreTime.ReadOnly = true;
            this.tbOutStoreTime.Width = 150;
            // 
            // tbOutDescribe
            // 
            this.tbOutDescribe.DataPropertyName = "OutDescribes";
            this.tbOutDescribe.HeaderText = "领用说明";
            this.tbOutDescribe.Name = "tbOutDescribe";
            this.tbOutDescribe.ReadOnly = true;
            // 
            // tbPersonCode
            // 
            this.tbPersonCode.DataPropertyName = "PersonCode";
            this.tbPersonCode.HeaderText = "人员编码";
            this.tbPersonCode.Name = "tbPersonCode";
            this.tbPersonCode.ReadOnly = true;
            // 
            // tbPersonName
            // 
            this.tbPersonName.DataPropertyName = "PersonName";
            this.tbPersonName.HeaderText = "人员姓名";
            this.tbPersonName.Name = "tbPersonName";
            this.tbPersonName.ReadOnly = true;
            // 
            // tbCheckTime
            // 
            this.tbCheckTime.DataPropertyName = "OptionPersonName";
            this.tbCheckTime.HeaderText = "操作人员";
            this.tbCheckTime.Name = "tbCheckTime";
            this.tbCheckTime.ReadOnly = true;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btnAddTool);
            this.groupPanel2.Controls.Add(this.btnReturnContinue);
            this.groupPanel2.Controls.Add(this.btnReturn);
            this.groupPanel2.Controls.Add(this.tbEditoutdescribes);
            this.groupPanel2.Controls.Add(this.labelX10);
            this.groupPanel2.Controls.Add(this.tbEditCode);
            this.groupPanel2.Controls.Add(this.labelX11);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(6, 590);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1472, 78);
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
            this.groupPanel2.TabIndex = 6;
            // 
            // btnAddTool
            // 
            this.btnAddTool.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddTool.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddTool.Location = new System.Drawing.Point(398, 26);
            this.btnAddTool.Name = "btnAddTool";
            this.btnAddTool.Size = new System.Drawing.Size(40, 23);
            this.btnAddTool.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddTool.TabIndex = 33;
            this.btnAddTool.Text = "增加";
            this.btnAddTool.Click += new System.EventHandler(this.btnAddTool_Click);
            // 
            // btnReturnContinue
            // 
            this.btnReturnContinue.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReturnContinue.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReturnContinue.Location = new System.Drawing.Point(1026, 24);
            this.btnReturnContinue.Name = "btnReturnContinue";
            this.btnReturnContinue.Size = new System.Drawing.Size(101, 25);
            this.btnReturnContinue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReturnContinue.TabIndex = 32;
            this.btnReturnContinue.Text = "继续归还";
            this.btnReturnContinue.Click += new System.EventHandler(this.btnReturnContinue_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReturn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReturn.Location = new System.Drawing.Point(891, 24);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(98, 25);
            this.btnReturn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReturn.TabIndex = 21;
            this.btnReturn.Text = "确认归还";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // tbEditoutdescribes
            // 
            // 
            // 
            // 
            this.tbEditoutdescribes.Border.Class = "TextBoxBorder";
            this.tbEditoutdescribes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbEditoutdescribes.Location = new System.Drawing.Point(562, 26);
            this.tbEditoutdescribes.Name = "tbEditoutdescribes";
            this.tbEditoutdescribes.PreventEnterBeep = true;
            this.tbEditoutdescribes.Size = new System.Drawing.Size(250, 21);
            this.tbEditoutdescribes.TabIndex = 19;
            // 
            // labelX10
            // 
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(472, 26);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(101, 23);
            this.labelX10.TabIndex = 18;
            this.labelX10.Text = "归还说明：";
            // 
            // tbEditCode
            // 
            // 
            // 
            // 
            this.tbEditCode.Border.Class = "TextBoxBorder";
            this.tbEditCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbEditCode.Location = new System.Drawing.Point(188, 26);
            this.tbEditCode.Name = "tbEditCode";
            this.tbEditCode.PreventEnterBeep = true;
            this.tbEditCode.Size = new System.Drawing.Size(204, 21);
            this.tbEditCode.TabIndex = 1;
            this.tbEditCode.TextChanged += new System.EventHandler(this.tbEditCode_TextChanged);
            // 
            // labelX11
            // 
            this.labelX11.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(98, 24);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(123, 23);
            this.labelX11.TabIndex = 27;
            this.labelX11.Text = "工具/包编码：";
            // 
            // FrmReturnTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1486, 700);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.dataGridViewX1);
            this.Name = "FrmReturnTool";
            this.Text = "FrmReturnTool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmReturnTool_FormClosed);
            this.Load += new System.EventHandler(this.FrmReturnTool_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmReturnTool_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnAddTool;
        private DevComponents.DotNetBar.ButtonX btnReturnContinue;
        private DevComponents.DotNetBar.Controls.TextBoxX tbEditCode;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.ButtonX btnReturn;
        private DevComponents.DotNetBar.Controls.TextBoxX tbEditoutdescribes;
        private DevComponents.DotNetBar.LabelX labelX10;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbChildTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbPackNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbPackName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbToolCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbToolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbOutStoreTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbOutDescribe;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbPersonCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbPersonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbCheckTime;



    }
}