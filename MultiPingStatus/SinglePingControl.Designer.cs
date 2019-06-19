namespace MultiPingStatus
{
    partial class SinglePingControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.gbxTitle = new System.Windows.Forms.GroupBox();
            this.txtIp = new System.Windows.Forms.MaskedTextBox();
            this.lblAlive = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.chkEn = new System.Windows.Forms.CheckBox();
            this.pnlMain.SuspendLayout();
            this.gbxTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.gbxTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(298, 51);
            this.pnlMain.TabIndex = 0;
            // 
            // gbxTitle
            // 
            this.gbxTitle.Controls.Add(this.txtIp);
            this.gbxTitle.Controls.Add(this.lblAlive);
            this.gbxTitle.Controls.Add(this.lblTime);
            this.gbxTitle.Controls.Add(this.chkEn);
            this.gbxTitle.Location = new System.Drawing.Point(3, 1);
            this.gbxTitle.Name = "gbxTitle";
            this.gbxTitle.Size = new System.Drawing.Size(289, 49);
            this.gbxTitle.TabIndex = 6;
            this.gbxTitle.TabStop = false;
            this.gbxTitle.Text = "ROV";
            // 
            // txtIp
            // 
            this.txtIp.AllowPromptAsInput = false;
            this.txtIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtIp.Location = new System.Drawing.Point(113, 14);
            this.txtIp.Mask = "999.999.999.999";
            this.txtIp.Name = "txtIp";
            this.txtIp.ResetOnPrompt = false;
            this.txtIp.ResetOnSpace = false;
            this.txtIp.Size = new System.Drawing.Size(140, 26);
            this.txtIp.TabIndex = 1;
            this.txtIp.Text = "127  0  0  1";
            this.txtIp.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            this.txtIp.TextChanged += new System.EventHandler(this.txtIp_TextChanged);
            this.txtIp.Enter += new System.EventHandler(this.txtIp_Enter);
            this.txtIp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIp_KeyDown);
            this.txtIp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIp_KeyPress);
            this.txtIp.Leave += new System.EventHandler(this.txtIp_Leave);
            this.txtIp.Validated += new System.EventHandler(this.txtIp_Validated);
            // 
            // lblAlive
            // 
            this.lblAlive.BackColor = System.Drawing.Color.Red;
            this.lblAlive.Location = new System.Drawing.Point(10, 18);
            this.lblAlive.Name = "lblAlive";
            this.lblAlive.Size = new System.Drawing.Size(20, 20);
            this.lblAlive.TabIndex = 999;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTime.Location = new System.Drawing.Point(53, 18);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(39, 20);
            this.lblTime.TabIndex = 999;
            this.lblTime.Text = "0ms";
            // 
            // chkEn
            // 
            this.chkEn.AutoSize = true;
            this.chkEn.Checked = true;
            this.chkEn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEn.Location = new System.Drawing.Point(265, 21);
            this.chkEn.Name = "chkEn";
            this.chkEn.Size = new System.Drawing.Size(15, 14);
            this.chkEn.TabIndex = 5;
            this.chkEn.TabStop = false;
            this.chkEn.UseVisualStyleBackColor = true;
            this.chkEn.CheckedChanged += new System.EventHandler(this.chkEn_CheckedChanged);
            // 
            // SinglePingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "SinglePingControl";
            this.Size = new System.Drawing.Size(298, 51);
            this.Load += new System.EventHandler(this.SinglePingControl_Load);
            this.pnlMain.ResumeLayout(false);
            this.gbxTitle.ResumeLayout(false);
            this.gbxTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.MaskedTextBox txtIp;
        private System.Windows.Forms.Label lblAlive;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.GroupBox gbxTitle;
        private System.Windows.Forms.CheckBox chkEn;
    }
}
