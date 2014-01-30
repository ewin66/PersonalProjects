using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Diagnostics;

namespace ForumHelper
{
    public partial class ToastForm : Form
    {
        public ToastForm()
        {
            InitializeComponent();
            TopMost = true;
            ShowInTaskbar = false;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Tick += timer_Tick;

        }

        private System.Windows.Forms.Timer timer;
        private int startPosX;
        private int startPosY;

        private void ToastForm_Load(object sender, EventArgs e)
        {
            
        }
        protected override void OnLoad(EventArgs e)
        {
            startPosX = Screen.PrimaryScreen.WorkingArea.Width - Width;
            startPosY = Screen.PrimaryScreen.WorkingArea.Height - Height;
            SetDesktopLocation(startPosX, startPosY);
            pageLinkLabel.Text = URLEventArgs.Url;
          //  base.OnLoad(e);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            startPosY -= 50;
            if (startPosY < Screen.PrimaryScreen.WorkingArea.Height - Height) timer.Stop();
            else
            {
                SetDesktopLocation(startPosX, startPosY); 
                timer.Stop();
            }
        }

        private void ToastForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pageLinkLabelClick(object sender, EventArgs e)
        {
            Process.Start(this.pageLinkLabel.Text);
            this.Close();
        }
    }
}
