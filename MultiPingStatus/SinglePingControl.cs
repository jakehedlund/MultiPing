using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;
using System.Threading;

namespace MultiPingStatus
{
    public partial class SinglePingControl : UserControl
    {
        public int Interval { get {
                if (pingTimer != null)
                    return pingTimer.Interval;
                else
                    return 0;
            } set {
                if (pingTimer != null)
                    pingTimer.Interval = value;
            }
        }

        public string Ip { get; set; }
        public string PingTargetName { get; set; }

        BackgroundWorker bgw = new BackgroundWorker();
        System.Windows.Forms.Timer pingTimer;

        Color badColor = Color.Red;
        Color goodColor = Color.Green;

        bool pingInProgress = false;
        bool enabled = true;

        public uint OctetOne { get; set; }

        public SinglePingControl()
        {
            InitializeComponent();
            pingTimer = new System.Windows.Forms.Timer();

            bgw = new BackgroundWorker();
            bgw.WorkerSupportsCancellation = true;
            bgw.DoWork += Bgw_DoWork;
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += Bgw_ProgressChanged;
        }

        public SinglePingControl(string ip) : this()
        {
            this.Ip = ip;
        }

        public SinglePingControl(string name, string ip) : this()
        {
            this.Ip = ip;

            this.PingTargetName = name;
        }

        private void Bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
                lblAlive.BackColor = badColor;
            else
            {
                lblAlive.BackColor = goodColor;
                lblTime.Text = e.ProgressPercentage + "ms";
            }
        }

        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            IPAddress addr; 

            while(true)
            {
                if (bgw.CancellationPending)
                {
                    lblAlive.BackColor = badColor;
                    return;
                }

                if (string.IsNullOrWhiteSpace(this.Ip) || pingInProgress || !enabled)
                {
                    Thread.Sleep(1000);
                    continue;
                }
                //string ipStr = txtIp.Text.Replace(" ", "");
                string ipStr = this.Ip.Replace(" ", "");

                if (string.IsNullOrWhiteSpace(ipStr))
                    continue;
                
                // Check for invalid IP address. 
                if (!IPAddress.TryParse(ipStr, out addr))
                {
                    Thread.Sleep(1000);
                    continue;
                }
                
                try
                {
                    if(System.Diagnostics.Debugger.IsAttached)
                        Console.WriteLine("Pinging: " + ipStr);

                    using (var p = new Ping())
                    {
                        pingInProgress = true;
                        var resp = p.Send(addr, 1000);

                        if (resp.Status == IPStatus.Success)
                        {
                            bgw.ReportProgress((int)resp.RoundtripTime);
                            
                        }
                        else
                        {
                            bgw.ReportProgress(-1);
                        }
                        pingInProgress = false;
                    }

                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error pinging! " + ex.Message);
                }
                finally
                {
                    pingInProgress = false;
                }
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            //txtIp.ForeColor = badColor;
        }

        private void SinglePingControl_Load(object sender, EventArgs e)
        {
            pingTimer.Interval = 1000;

            if (!string.IsNullOrWhiteSpace(PingTargetName))
                gbxTitle.Text = PingTargetName;
            else
                gbxTitle.Text = "test" + Ip;

            try
            {
                if (string.IsNullOrWhiteSpace(this.Ip))
                    this.Ip = "127.0.0.1";
                txtIp.Text = PadIp(this.Ip);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error setting IP: " + ex.Message);
            }
            
        }

        public void Start()
        {
            //pingTimer.Start();
            if(!bgw.IsBusy)
                bgw.RunWorkerAsync();
        }

        public void Stop()
        {
            bgw.CancelAsync();
            lblAlive.BackColor = badColor;
        }

        private void txtIp_TextChanged(object sender, EventArgs e)
        {
            Ip = txtIp.Text;
        }

        private void txtIp_KeyDown(object sender, KeyEventArgs e)
        {
            int pos = txtIp.SelectionStart;
            int max = (txtIp.MaskedTextProvider.Length - txtIp.MaskedTextProvider.EditPositionCount);

            if (e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal)
            {
                int nextField = 0;

                for (int i = 0; i < txtIp.MaskedTextProvider.Length; i++)
                {
                    if (!txtIp.MaskedTextProvider.IsEditPosition(i) && (pos + max) >= i)
                        nextField = i;
                }
                nextField += 1;

                // We're done, enable the TabStop property again  
                if (pos == nextField)
                    txtIp_Leave(this, e);

                txtIp.SelectionStart = nextField;
            }

            
        }

        private void txtIp_Leave(object sender, EventArgs e)
        {
            // Resets the cursor when we leave the textbox  
            txtIp.SelectionStart = 0;
            // Enable the TabStop property so we can cycle through the form controls again  
            //foreach (Control c in this.Parent.Controls)
            //    c.TabStop = true;
        }

        private void txtIp_KeyPress(object sender, KeyPressEventArgs e)
        {
            //txtIp_KeyDown(sender, e);
            Console.WriteLine("Pressed: " + e.KeyChar);
            int pos = txtIp.SelectionStart;
            string orig = txtIp.Text;

            if (pos < txtIp.Mask.Length && pos < orig.Length && txtIp.Text[pos] == ' ')
            {
                MaskedTextResultHint hint = MaskedTextResultHint.DigitExpected;
                if (txtIp.MaskedTextProvider.VerifyChar(e.KeyChar, pos, out hint))
                {
                    if (txtIp.MaskedTextProvider.Replace(e.KeyChar, pos))
                    {
                        Console.WriteLine(txtIp.MaskedTextProvider.ToDisplayString());
                        txtIp.MaskedTextProvider.InsertAt(e.KeyChar, pos);
                    }
                    else
                        Console.WriteLine("Error replacing.");
                }
                else
                    Console.WriteLine("Hint: " + hint.ToString()); 
            }

        }

        private void txtIp_Enter(object sender, EventArgs e)
        {
            // Resets the cursor when we enter the textbox  
            txtIp.SelectionStart = 0;
            // Disable the TabStop property to prevent the form and its controls to catch the Tab key  
            //foreach (Control c in this.Parent.Controls)
            //    c.TabStop = false;
        }

        public static string PadIp(string ip)
        {
            string[] split = ip.Split('.');
            string newIp = "";

            newIp = string.Join(".", split.Select(s => s.PadLeft(3, ' '))) ;

            return newIp;
        }

        private void chkEn_CheckedChanged(object sender, EventArgs e)
        {
            this.enabled = chkEn.Checked;

            if (!enabled)
                lblAlive.BackColor = badColor;
        }

        private void txtIp_Validated(object sender, EventArgs e)
        {
            //txtIp.ForeColor = SystemColors.WindowText;
        }
    }
}
