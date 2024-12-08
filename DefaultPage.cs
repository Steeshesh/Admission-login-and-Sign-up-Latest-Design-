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

        private void LogoutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LogOutUser();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LogOutUser();
        }

        private void LogOutUser()
        {
            // Clear the current user's session data
            UserSession.Clear();

            // Redirect to the Login form
            Login loginForm = new Login();
            loginForm.Show();

            // Close the current form
            this.Close();
        }

        private void Applybtn_Click(object sender, EventArgs e)
        {
            Application.DoEvents();  // Ensure UI events are processed before switching forms
            new ApplicationForm().Show();
            this.Hide();
        }

        private void Instructionbtn_Click(object sender, EventArgs e)
        {
            // Add functionality as needed
        }
    }
}
