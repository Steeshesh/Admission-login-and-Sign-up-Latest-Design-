using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Admission_login_and_Sign_up__Latest_Design_
{
    public partial class DefaultPage : Form
    {
        public DefaultPage()
        {
            InitializeComponent();
            this.DoubleBuffered = true;  // Enable double buffering to reduce flicker
        }

        private void Statusbtn_Click(object sender, EventArgs e)
        {
            Application.DoEvents();  // Ensure UI events are processed before switching forms
            new Status().Show();
            this.Hide();
        }

        private void DefaultPage_Load(object sender, EventArgs e)
        {
            // Set background colors for other controls (if needed)
        }

        

        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Draw a gradient on gradientPanel1
            using (LinearGradientBrush brush = new LinearGradientBrush(
                gradientPanel1.ClientRectangle,
                Color.FromArgb(100, 0, 0, 0),
                Color.Transparent,
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, gradientPanel1.ClientRectangle);
            }
        }

        private void gradientPanel2_Paint(object sender, PaintEventArgs e)
        {
            // Draw a gradient on gradientPanel2
            using (LinearGradientBrush brush = new LinearGradientBrush(
                gradientPanel2.ClientRectangle,
                Color.FromArgb(100, 0, 0, 0),
                Color.Transparent,
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, gradientPanel2.ClientRectangle);
            }
        }

        private void LogoutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.InvokeRequired)  // Ensure UI update happens on the UI thread
            {
                this.Invoke(new Action(Application.Exit));
            }
            else
            {
                Application.Exit();
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Applybtn_Click(object sender, EventArgs e)
        {
            Application.DoEvents();  // Ensure UI events are processed before switching forms
            new ApplicationForm().Show();
            this.Hide();
        }

        private void Qualifications_Click(object sender, EventArgs e)
        {
            // Add functionality as needed
        }

        private void DocReq_Click(object sender, EventArgs e)
        {
            // Add functionality as needed
        }

        private void Instructionbtn_Click(object sender, EventArgs e)
        {
            // Add functionality as needed
        }
    }
}
