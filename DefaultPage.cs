using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admission_login_and_Sign_up__Latest_Design_
{
    public partial class DefaultPage : Form
    {
        public DefaultPage()
        {
            InitializeComponent();
        }

        private void Statusbtn_Click(object sender, EventArgs e)
        {
            new Status().Show();
            this.Hide();
        }

        private void DefaultPage_Load(object sender, EventArgs e)
        {

        }

        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            gradientPanel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            informations.BackColor = Color.FromArgb(150, Color.Black);
        }

        private void LogoutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void gradientPanel2_Paint(object sender, PaintEventArgs e)
        {
            gradientPanel2.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Applybtn_Click(object sender, EventArgs e)
        {
            new ApplicationForm().Show();
            this.Hide();
        }

        private void Qualifications_Click(object sender, EventArgs e)
        {

        }

        private void DocReq_Click(object sender, EventArgs e)
        {

        }
    }
}
