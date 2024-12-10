using System.Windows.Forms;
using System;
using Admission_login_and_Sign_up__Latest_Design_;

namespace Admission_login_and_Sign_up__Latest_Design_
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }     

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            // Create the coursePage
            frmAbout AboutPage = new frmAbout();

            // Hide the current form
            this.Hide();

            // Show the new form
            AboutPage.Show();

            // Close the application when the new form is closed
            AboutPage.FormClosed += (s, args) => this.Close();
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            // Create the coursePage
            frmAbout AboutPage = new frmAbout();

            // Hide the current form
            this.Hide();

            // Show the new form
            AboutPage.Show();

            // Close the application when the new form is closed
            AboutPage.FormClosed += (s, args) => this.Close();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            // Create the coursePage
            frmCourses AboutPage = new frmCourses();

            // Hide the current form
            this.Hide();

            // Show the new form
            AboutPage.Show();

            // Close the application when the new form is closed
            AboutPage.FormClosed += (s, args) => this.Close();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            // Create the coursePage
            Login AboutPage = new Login();

            // Hide the current form
            this.Hide();

            // Show the new form
            AboutPage.Show();

            // Close the application when the new form is closed
            AboutPage.FormClosed += (s, args) => this.Close();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            // Create the coursePage
            Signup AboutPage = new Signup();

            // Hide the current form
            this.Hide();

            // Show the new form
            AboutPage.Show();

            // Close the application when the new form is closed
            AboutPage.FormClosed += (s, args) => this.Close();
        }
    }
}
