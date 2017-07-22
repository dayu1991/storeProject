﻿namespace toolstrackingsystem.PageControl
{
    partial class PagerControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPageCount = new System.Windows.Forms.Label();
            this.lblSept = new System.Windows.Forms.Label();
            this.lblMsg4 = new System.Windows.Forms.Label();
            this.lblMsg3 = new System.Windows.Forms.Label();
            this.lblMsg1 = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblMsg2 = new System.Windows.Forms.Label();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtPageSize = new System.Windows.Forms.TextBox();
            this.txtPageNum = new System.Windows.Forms.TextBox();
            this.lnkLast = new System.Windows.Forms.LinkLabel();
            this.lnkNext = new System.Windows.Forms.LinkLabel();
            this.lnkPrev = new System.Windows.Forms.LinkLabel();
            this.lnkFirst = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblPageCount
            // 
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.ForeColor = System.Drawing.Color.Red;
            this.lblPageCount.Location = new System.Drawing.Point(68, 19);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(11, 12);
            this.lblPageCount.TabIndex = 72;
            this.lblPageCount.Text = "1";
            // 
            // lblSept
            // 
            this.lblSept.AutoSize = true;
            this.lblSept.Location = new System.Drawing.Point(51, 19);
            this.lblSept.Name = "lblSept";
            this.lblSept.Size = new System.Drawing.Size(11, 12);
            this.lblSept.TabIndex = 71;
            this.lblSept.Text = "/";
            // 
            // lblMsg4
            // 
            this.lblMsg4.AutoSize = true;
            this.lblMsg4.Location = new System.Drawing.Point(285, 19);
            this.lblMsg4.Name = "lblMsg4";
            this.lblMsg4.Size = new System.Drawing.Size(17, 12);
            this.lblMsg4.TabIndex = 70;
            this.lblMsg4.Text = "条";
            // 
            // lblMsg3
            // 
            this.lblMsg3.AutoSize = true;
            this.lblMsg3.Location = new System.Drawing.Point(216, 19);
            this.lblMsg3.Name = "lblMsg3";
            this.lblMsg3.Size = new System.Drawing.Size(29, 12);
            this.lblMsg3.TabIndex = 69;
            this.lblMsg3.Text = "每页";
            // 
            // lblMsg1
            // 
            this.lblMsg1.AutoSize = true;
            this.lblMsg1.Location = new System.Drawing.Point(91, 19);
            this.lblMsg1.Name = "lblMsg1";
            this.lblMsg1.Size = new System.Drawing.Size(17, 12);
            this.lblMsg1.TabIndex = 68;
            this.lblMsg1.Text = "共";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.ForeColor = System.Drawing.Color.Red;
            this.lblTotalCount.Location = new System.Drawing.Point(133, 19);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(11, 12);
            this.lblTotalCount.TabIndex = 67;
            this.lblTotalCount.Text = "0";
            // 
            // lblMsg2
            // 
            this.lblMsg2.AutoSize = true;
            this.lblMsg2.Location = new System.Drawing.Point(169, 19);
            this.lblMsg2.Name = "lblMsg2";
            this.lblMsg2.Size = new System.Drawing.Size(41, 12);
            this.lblMsg2.TabIndex = 66;
            this.lblMsg2.Text = "条记录";
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = true;
            this.lblCurrentPage.ForeColor = System.Drawing.Color.Red;
            this.lblCurrentPage.Location = new System.Drawing.Point(34, 19);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(11, 12);
            this.lblCurrentPage.TabIndex = 65;
            this.lblCurrentPage.Text = "1";
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGo.ForeColor = System.Drawing.Color.Black;
            this.btnGo.Location = new System.Drawing.Point(518, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(45, 23);
            this.btnGo.TabIndex = 64;
            this.btnGo.Text = "跳转";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtPageSize
            // 
            this.txtPageSize.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPageSize.Location = new System.Drawing.Point(247, 14);
            this.txtPageSize.Name = "txtPageSize";
            this.txtPageSize.Size = new System.Drawing.Size(32, 21);
            this.txtPageSize.TabIndex = 62;
            this.txtPageSize.Text = "100";
            this.txtPageSize.TextChanged += new System.EventHandler(this.txtPageSize_TextChanged);
            // 
            // txtPageNum
            // 
            this.txtPageNum.Location = new System.Drawing.Point(480, 14);
            this.txtPageNum.Name = "txtPageNum";
            this.txtPageNum.Size = new System.Drawing.Size(29, 21);
            this.txtPageNum.TabIndex = 63;
            this.txtPageNum.TextChanged += new System.EventHandler(this.txtPageNum_TextChanged);
            // 
            // lnkLast
            // 
            this.lnkLast.AutoSize = true;
            this.lnkLast.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnkLast.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkLast.LinkColor = System.Drawing.Color.Black;
            this.lnkLast.Location = new System.Drawing.Point(436, 19);
            this.lnkLast.Name = "lnkLast";
            this.lnkLast.Size = new System.Drawing.Size(29, 12);
            this.lnkLast.TabIndex = 61;
            this.lnkLast.TabStop = true;
            this.lnkLast.Text = "尾页";
            this.lnkLast.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLast_LinkClicked);
            // 
            // lnkNext
            // 
            this.lnkNext.AutoSize = true;
            this.lnkNext.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnkNext.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkNext.LinkColor = System.Drawing.Color.Black;
            this.lnkNext.Location = new System.Drawing.Point(389, 19);
            this.lnkNext.Name = "lnkNext";
            this.lnkNext.Size = new System.Drawing.Size(41, 12);
            this.lnkNext.TabIndex = 60;
            this.lnkNext.TabStop = true;
            this.lnkNext.Text = "下一页";
            this.lnkNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNext_LinkClicked);
            // 
            // lnkPrev
            // 
            this.lnkPrev.AutoSize = true;
            this.lnkPrev.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnkPrev.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkPrev.LinkColor = System.Drawing.Color.Black;
            this.lnkPrev.Location = new System.Drawing.Point(342, 19);
            this.lnkPrev.Name = "lnkPrev";
            this.lnkPrev.Size = new System.Drawing.Size(41, 12);
            this.lnkPrev.TabIndex = 59;
            this.lnkPrev.TabStop = true;
            this.lnkPrev.Text = "上一页";
            this.lnkPrev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPrev_LinkClicked);
            // 
            // lnkFirst
            // 
            this.lnkFirst.AutoSize = true;
            this.lnkFirst.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnkFirst.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkFirst.LinkColor = System.Drawing.Color.Black;
            this.lnkFirst.Location = new System.Drawing.Point(307, 19);
            this.lnkFirst.Name = "lnkFirst";
            this.lnkFirst.Size = new System.Drawing.Size(29, 12);
            this.lnkFirst.TabIndex = 58;
            this.lnkFirst.TabStop = true;
            this.lnkFirst.Text = "首页";
            this.lnkFirst.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFirst_LinkClicked);
            // 
            // PagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.lblPageCount);
            this.Controls.Add(this.lblSept);
            this.Controls.Add(this.lblMsg4);
            this.Controls.Add(this.lblMsg3);
            this.Controls.Add(this.lblMsg1);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.lblMsg2);
            this.Controls.Add(this.lblCurrentPage);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtPageSize);
            this.Controls.Add(this.txtPageNum);
            this.Controls.Add(this.lnkLast);
            this.Controls.Add(this.lnkNext);
            this.Controls.Add(this.lnkPrev);
            this.Controls.Add(this.lnkFirst);
            this.Name = "PagerControl";
            this.Size = new System.Drawing.Size(582, 44);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.Label lblSept;
        private System.Windows.Forms.Label lblMsg4;
        private System.Windows.Forms.Label lblMsg3;
        private System.Windows.Forms.Label lblMsg1;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblMsg2;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtPageSize;
        private System.Windows.Forms.TextBox txtPageNum;
        private System.Windows.Forms.LinkLabel lnkLast;
        private System.Windows.Forms.LinkLabel lnkNext;
        private System.Windows.Forms.LinkLabel lnkPrev;
        private System.Windows.Forms.LinkLabel lnkFirst;
    }
}
