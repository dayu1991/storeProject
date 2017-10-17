namespace toolstrackingsystem
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.textBox_UserName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.textBox_PassWord = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.LoginButton = new DevComponents.DotNetBar.ButtonX();
            this.ResetButton = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.scan_checkBox = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // textBox_UserName
            // 
            // 
            // 
            // 
            this.textBox_UserName.Border.Class = "TextBoxBorder";
            this.textBox_UserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_UserName.Location = new System.Drawing.Point(217, 90);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.PreventEnterBeep = true;
            this.textBox_UserName.Size = new System.Drawing.Size(100, 21);
            this.textBox_UserName.TabIndex = 0;
            this.textBox_UserName.TextChanged += new System.EventHandler(this.textBox_UserName_TextChanged_1);
            this.textBox_UserName.Leave += new System.EventHandler(this.textBox_UserName_Leave);
            this.textBox_UserName.MouseLeave += new System.EventHandler(this.textBox_UserName_MouseLeave);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(160, 90);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(51, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "用户名:";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(160, 126);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "密  码:";
            // 
            // textBox_PassWord
            // 
            // 
            // 
            // 
            this.textBox_PassWord.Border.Class = "TextBoxBorder";
            this.textBox_PassWord.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_PassWord.Location = new System.Drawing.Point(217, 126);
            this.textBox_PassWord.Name = "textBox_PassWord";
            this.textBox_PassWord.PasswordChar = '*';
            this.textBox_PassWord.PreventEnterBeep = true;
            this.textBox_PassWord.Size = new System.Drawing.Size(100, 21);
            this.textBox_PassWord.TabIndex = 4;
            // 
            // LoginButton
            // 
            this.LoginButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.LoginButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.LoginButton.Location = new System.Drawing.Point(159, 191);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(68, 23);
            this.LoginButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LoginButton.TabIndex = 5;
            this.LoginButton.Text = "登录";
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ResetButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ResetButton.Location = new System.Drawing.Point(245, 191);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(68, 23);
            this.ResetButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ResetButton.TabIndex = 6;
            this.ResetButton.Text = "重置";
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(73, 25);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(348, 38);
            this.labelX3.TabIndex = 7;
            this.labelX3.Text = "北京动车段工具管理追溯系统";
            // 
            // scan_checkBox
            // 
            // 
            // 
            // 
            this.scan_checkBox.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.scan_checkBox.Location = new System.Drawing.Point(217, 155);
            this.scan_checkBox.Name = "scan_checkBox";
            this.scan_checkBox.Size = new System.Drawing.Size(100, 23);
            this.scan_checkBox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.scan_checkBox.TabIndex = 8;
            this.scan_checkBox.Text = "扫码登录";
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 262);
            this.Controls.Add(this.scan_checkBox);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.textBox_PassWord);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.textBox_UserName);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBox_UserName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBox_PassWord;
        private DevComponents.DotNetBar.ButtonX LoginButton;
        private DevComponents.DotNetBar.ButtonX ResetButton;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.CheckBoxX scan_checkBox;
    }
}