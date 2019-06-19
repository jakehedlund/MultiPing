namespace MultiPingStatus
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnSetFile = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlPingControls = new System.Windows.Forms.FlowLayoutPanel();
            this.chkTop = new System.Windows.Forms.CheckBox();
            this.spcTest = new MultiPingStatus.SinglePingControl();
            this.pnlPingControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(3, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(81, 6);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 3;
            this.btnReload.Text = "Reload File";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnSetFile
            // 
            this.btnSetFile.Location = new System.Drawing.Point(159, 6);
            this.btnSetFile.Name = "btnSetFile";
            this.btnSetFile.Size = new System.Drawing.Size(75, 23);
            this.btnSetFile.TabIndex = 4;
            this.btnSetFile.Text = "Open File";
            this.toolTip1.SetToolTip(this.btnSetFile, "Open a list of IPs (format name,ip one per line)");
            this.btnSetFile.UseVisualStyleBackColor = true;
            this.btnSetFile.Click += new System.EventHandler(this.btnSetFile_Click);
            // 
            // pnlPingControls
            // 
            this.pnlPingControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPingControls.AutoScroll = true;
            this.pnlPingControls.Controls.Add(this.spcTest);
            this.pnlPingControls.Location = new System.Drawing.Point(4, 37);
            this.pnlPingControls.Name = "pnlPingControls";
            this.pnlPingControls.Size = new System.Drawing.Size(324, 223);
            this.pnlPingControls.TabIndex = 5;
            // 
            // chkTop
            // 
            this.chkTop.AutoSize = true;
            this.chkTop.Location = new System.Drawing.Point(238, 10);
            this.chkTop.Name = "chkTop";
            this.chkTop.Size = new System.Drawing.Size(92, 17);
            this.chkTop.TabIndex = 6;
            this.chkTop.Text = "Always on top";
            this.chkTop.UseVisualStyleBackColor = true;
            this.chkTop.CheckedChanged += new System.EventHandler(this.chkTop_CheckedChanged);
            // 
            // spcTest
            // 
            this.spcTest.Interval = 1000;
            this.spcTest.Ip = "127.  0.  0.  1";
            this.spcTest.Location = new System.Drawing.Point(3, 3);
            this.spcTest.Name = "spcTest";
            this.spcTest.PingTargetName = "spcTest";
            this.spcTest.Size = new System.Drawing.Size(302, 54);
            this.spcTest.TabIndex = 2;
            this.spcTest.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spcTest_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 262);
            this.Controls.Add(this.chkTop);
            this.Controls.Add(this.pnlPingControls);
            this.Controls.Add(this.btnSetFile);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Ping Status";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlPingControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private SinglePingControl spcTest;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnSetFile;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.FlowLayoutPanel pnlPingControls;
        private System.Windows.Forms.CheckBox chkTop;
    }
}

