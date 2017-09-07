namespace toolstrackingsystem
{
    partial class FrmEditUser
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.UserCode_textBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.UserName_textBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Description_textBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Password_textBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Save_Edit_button = new DevComponents.DotNetBar.ButtonX();
            this.Cancel_button = new DevComponents.DotNetBar.ButtonX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.role_comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(26, 34);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "用户编码:";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(26, 74);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "用 户 名:";
            this.labelX2.Click += new System.EventHandler(this.labelX2_Click);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(26, 152);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "用户说明:";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(26, 200);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 3;
            this.labelX4.Text = "密    码:";
            // 
            // UserCode_textBox
            // 
            // 
            // 
            // 
            this.UserCode_textBox.Border.Class = "TextBoxBorder";
            this.UserCode_textBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UserCode_textBox.Enabled = false;
            this.UserCode_textBox.Location = new System.Drawing.Point(107, 34);
            this.UserCode_textBox.Name = "UserCode_textBox";
            this.UserCode_textBox.PreventEnterBeep = true;
            this.UserCode_textBox.Size = new System.Drawing.Size(145, 21);
            this.UserCode_textBox.TabIndex = 4;
            // 
            // UserName_textBox
            // 
            // 
            // 
            // 
            this.UserName_textBox.Border.Class = "TextBoxBorder";
            this.UserName_textBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UserName_textBox.Location = new System.Drawing.Point(107, 78);
            this.UserName_textBox.Name = "UserName_textBox";
            this.UserName_textBox.PreventEnterBeep = true;
            this.UserName_textBox.Size = new System.Drawing.Size(145, 21);
            this.UserName_textBox.TabIndex = 5;
            // 
            // Description_textBox
            // 
            // 
            // 
            // 
            this.Description_textBox.Border.Class = "TextBoxBorder";
            this.Description_textBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Description_textBox.Location = new System.Drawing.Point(107, 152);
            this.Description_textBox.Name = "Description_textBox";
            this.Description_textBox.PreventEnterBeep = true;
            this.Description_textBox.Size = new System.Drawing.Size(145, 21);
            this.Description_textBox.TabIndex = 6;
            // 
            // Password_textBox
            // 
            // 
            // 
            // 
            this.Password_textBox.Border.Class = "TextBoxBorder";
            this.Password_textBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Password_textBox.Location = new System.Drawing.Point(107, 202);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.PasswordChar = '*';
            this.Password_textBox.PreventEnterBeep = true;
            this.Password_textBox.Size = new System.Drawing.Size(145, 21);
            this.Password_textBox.TabIndex = 7;
            // 
            // Save_Edit_button
            // 
            this.Save_Edit_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Save_Edit_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Save_Edit_button.Location = new System.Drawing.Point(53, 256);
            this.Save_Edit_button.Name = "Save_Edit_button";
            this.Save_Edit_button.Size = new System.Drawing.Size(75, 23);
            this.Save_Edit_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Save_Edit_button.TabIndex = 8;
            this.Save_Edit_button.Text = "保存";
            this.Save_Edit_button.Click += new System.EventHandler(this.Save_Edit_button_Click);
            // 
            // Cancel_button
            // 
            this.Cancel_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Cancel_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Cancel_button.Location = new System.Drawing.Point(151, 256);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Cancel_button.TabIndex = 9;
            this.Cancel_button.Text = "取消";
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(26, 112);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 10;
            this.labelX5.Text = "用户角色:";
            // 
            // role_comboBox
            // 
            this.role_comboBox.FormattingEnabled = true;
            this.role_comboBox.Location = new System.Drawing.Point(107, 115);
            this.role_comboBox.Name = "role_comboBox";
            this.role_comboBox.Size = new System.Drawing.Size(145, 20);
            this.role_comboBox.TabIndex = 11;
            // 
            // FrmEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 316);
            this.Controls.Add(this.role_comboBox);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.Save_Edit_button);
            this.Controls.Add(this.Password_textBox);
            this.Controls.Add(this.Description_textBox);
            this.Controls.Add(this.UserName_textBox);
            this.Controls.Add(this.UserCode_textBox);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改";
            this.Load += new System.EventHandler(this.FrmEditUser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX UserCode_textBox;
        private DevComponents.DotNetBar.Controls.TextBoxX UserName_textBox;
        private DevComponents.DotNetBar.Controls.TextBoxX Description_textBox;
        private DevComponents.DotNetBar.Controls.TextBoxX Password_textBox;
        private DevComponents.DotNetBar.ButtonX Save_Edit_button;
        private DevComponents.DotNetBar.ButtonX Cancel_button;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.ComboBox role_comboBox;
    }
}