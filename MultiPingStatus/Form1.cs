﻿using MultiPingStatus.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiPingStatus
{
    public partial class Form1 : Form
    {
        List<SinglePingControl> pingList = new List<SinglePingControl>();

        bool pinging = false;

        string FileName { get; set; }

        int _interval = 1000;

        public Form1()
        {
            InitializeComponent();

            //pingList.Add(new SinglePingControl("ROV", "192.168.0.30"));
            //pingList.Add(new SinglePingControl("PBX", "192.168.0.20"));
            //pingList.Add(new SinglePingControl("Cam1", "192.168.0.250"));
            //pingList.Add(new SinglePingControl("Cam2", "192.168.0.251"));
            //pingList.Add(new SinglePingControl("Cam3", "192.168.0.252"));

            pnlPingControls.Controls.Clear();
            pnlPingControls.Controls.AddRange(pingList.ToArray());

            //pnlPingControls.Refresh();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!pinging)
            {
                StartPinging();
            }
            else
            {
                StopPinging();
            }
        }

        private void StartPinging()
        {
            foreach (var p in pingList)
                p.Start();

            btnStart.Text = "Stop";
            pinging = true;
        }

        private void StopPinging()
        {
            foreach (var p in pingList)
                p.Stop();
            btnStart.Text = "Start";
            pinging = false;
        }

        private void spcTest_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ReadFile(string fname)
        {
            if (!File.Exists(fname))
                return;

            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = new FileStream(fname, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error opening file: " + ex.Message);
                throw ex;
            }

            string line = "";

            List<SinglePingControl> templist = new List<SinglePingControl>();

            if (sr == null)
                return; 

            while ((line = sr.ReadLine()) != null)
            {
                line = line.Trim();
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (line[0] == '#')
                    continue;

                if (line[0] == '/' && line[1] == '/')
                    continue;

                try
                {
                    string[] tokens = new string[2];
                    string name, ip;

                    if (line.Contains(','))
                        tokens = line.Split(',');
                    else if (line.Contains(':'))
                        tokens = line.Split(':');

                    if (tokens.Count() == 2)
                    {
                        name = tokens[0].Trim();
                        ip = tokens[1].Trim();

                        templist.Add(new SinglePingControl(name, ip));
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error parsing line: " + ex.Message);
                    throw ex;
                }
            }

            ReloadControls(templist);
            sr.Close();
            fs.Close();

        }

        private void ReloadControls(List<SinglePingControl> list)
        {

            if (list.Count > 0)
            {
                StopPinging();
                
                pnlPingControls.Controls.Clear();
                pnlPingControls.Controls.AddRange(list.ToArray());

                pingList = list;
            }
        }

        private void chkTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = chkTop.Checked;
        }

        private void btnSetFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            var res = fd.ShowDialog();

            if (res == DialogResult.OK)
            {
                string fname = fd.FileName;

                FileName = fname;
                try
                {
                    ReadFile(fname);
                    this.Name = "Ping status: " + fd.SafeFileName;
                }catch(Exception ex)
                {
                    MessageBox.Show("Error parsing file: " + ex.Message, "Error");
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {

                ReadFile(FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error parsing file: " + ex.Message, "Error");
            }

            // Adjust window size to fit. 
            int singleHeight = pnlPingControls.Controls[0].Height; 
            var sc = Screen.FromControl(this);
            this.Height = Math.Min(sc.WorkingArea.Height, (3+singleHeight) * (this.pnlPingControls.Controls.Count) + 120);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopPinging();
            Thread.Sleep(200);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                var path = Path.Combine(Directory.GetCurrentDirectory(), "ip_list.txt");
                if (File.Exists(path))
                {
                    this.FileName = path;
                    btnReload_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error opening file: " + ex.Message); 
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            foreach( var c in pingList)
            {
                c.Interval = (int)nudInterval.Value;
            }
            this._interval = (int)nudInterval.Value;
        }
    }
}
