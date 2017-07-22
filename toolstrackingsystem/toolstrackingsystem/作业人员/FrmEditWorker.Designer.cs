namespace toolstrackingsystem
{
    partial class FrmEditWorker
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
            this.Cancel_button = new DevComponents.DotNetBar.ButtonX();
            this.Save_Edit_button = new DevComponents.DotNetBar.ButtonX();
            this.Remark_textBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.PersonName_textBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.PersonCode_textBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.IsReceive_radiobutton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // Cancel_button
            // 
            this.Cancel_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Cancel_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Cancel_button.Location = new System.Drawing.Point(156, 212);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Cancel_button.TabIndex = 21;
            this.Cancel_button.Text = "取消";
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // Save_Edit_button
            // 
            this.Save_Edit_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Save_Edit_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Save_Edit_button.Location = new System.Drawing.Point(58, 212);
            this.Save_Edit_button.Name = "Save_Edit_button";
            this.Save_Edit_button.Size = new System.Drawing.Size(75, 23);
            this.Save_Edit_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Save_Edit_button.TabIndex = 20;
            this.Save_Edit_button.Text = "保存";
            this.Save_Edit_button.Click += new System.EventHandler(this.Save_Edit_button_Click);
            // 
            // Remark_textBox
            // 
            // 
            // 
            // 
            this.Remark_textBox.Border.Class = "TextBoxBorder";
            this.Remark_textBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Remark_textBox.Location = new System.Drawing.Point(112, 124);
            this.Remark_textBox.Name = "Remark_textBox";
            this.Remark_textBox.PreventEnterBeep = true;
            this.Remark_textBox.Size = new System.Drawing.Size(145, 21);
            this.Remark_textBox.TabIndex = 18;
            // 
            // PersonName_textBox
            // 
            // 
            // 
            // 
            this.PersonName_textBox.Border.Class = "TextBoxBorder";
            this.PersonName_textBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PersonName_textBox.Location = new System.Drawing.Point(112, 80);
            this.PersonName_textBox.Name = "PersonName_textBox";
            this.PersonName_textBox.PreventEnterBeep = true;
            this.PersonName_textBox.Size = new System.Drawing.Size(145, 21);
            this.PersonName_textBox.TabIndex = 17;
            // 
            // PersonCode_textBox
            // 
            // 
            // 
            // 
            this.PersonCode_textBox.Border.Class = "TextBoxBorder";
            this.PersonCode_textBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PersonCode_textBox.Enabled = false;
            this.PersonCode_textBox.Location = new System.Drawing.Point(112, 36);
            this.PersonCode_textBox.Name = "PersonCode_textBox";
            this.PersonCode_textBox.PreventEnterBeep = true;
            this.PersonCode_textBox.ReadOnly = true;
            this.PersonCode_textBox.Size = new System.Drawing.Size(145, 21);
            this.PersonCode_textBox.TabIndex = 16;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(31, 124);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 14;
            this.labelX3.Text = "备    注:";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(31, 76);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 13;
            this.labelX2.Text = "人员名称:";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(31, 36);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 12;
            this.labelX1.Text = "人员编码:";
            // 
            // IsReceive_radiobutton
            // 
            this.IsReceive_radiobutton.AutoSize = true;
            this.IsReceive_radiobutton.Location = new System.Drawing.Point(112, 164);
            this.IsReceive_radiobutton.Name = "IsReceive_radiobutton";
            this.IsReceive_radiobutton.Size = new System.Drawing.Size(71, 16);
            this.IsReceive_radiobutton.TabIndex = 23;
            this.IsReceive_radiobutton.TabStop = true;
            this.IsReceive_radiobutton.Text = "领用权限";
            this.IsReceive_radiobutton.UseVisualStyleBackColor = true;
            // 
            // FrmEditWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 256);
            this.Controls.Add(this.IsReceive_radiobutton);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.Save_Edit_button);
            this.Controls.Add(this.Remark_textBox);
            this.Controls.Add(this.PersonName_textBox);
            this.Controls.Add(this.PersonCode_textBox);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditWorker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改作业员";
            this.Load += new System.EventHandler(this.FrmEditWorker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX Cancel_button;
        private DevComponents.DotNetBar.ButtonX Save_Edit_button;
        private DevComponents.DotNetBar.Controls.TextBoxX Remark_textBox;
        private DevComponents.DotNetBar.Controls.TextBoxX PersonName_textBox;
        private DevComponents.DotNetBar.Controls.TextBoxX PersonCode_textBox;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.RadioButton IsReceive_radiobutton;
    }
}