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
    public partial class Status : Form
    {
        private Database database;

        public Status()
        {
            InitializeComponent();
            database = new Database();
        }

        private void Status_Load(object sender, EventArgs e)
        {
            string firstName = GetUserFirstName(UserSession.UserID);
            string appStat = GetUserApplicationStatus(UserSession.UserID);

            if (firstName == "")
            {
                fullName.Text = "Welcome!";
            }
            else
            {
                fullName.Text = "Welcome, " + firstName;
            }

            if (appStat == "")
            {
                applicationStatus.Text = "No submission";
            }
            else 
            {
                applicationStatus.Text = appStat;
            }
        }

        private void Instructionbtn_Click(object sender, EventArgs e)
        {
            new DefaultPage().Show();
            this.Hide();
        }

        private void LogoutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void informations_Paint(object sender, PaintEventArgs e)
        {
            informations.BackColor = Color.FromArgb(150, Color.Black);
        }

        private void Applybtn_Click(object sender, EventArgs e)
        {
            new ApplicationForm().Show();
            this.Hide();
        }

        private void applicationStatus_Click(object sender, EventArgs e)
        {

        }

        private void fullName_Click(object sender, EventArgs e)
        {
            // Get the FirstName using UserID from the UserSession

            // Assuming there's a label (e.g., lblFullName) to display the name
        }

        private string GetUserFirstName(int userId)
        {
            // Query the database to get the first name of the logged-in user
            string query = "SELECT FirstName FROM user WHERE UserID = @userID";
            object result = database.ExecuteScalar(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@userID", userId);
            });

            return result?.ToString(); // Return the FirstName if found
        }

        private string GetUserApplicationStatus(int userId) 
        {
            string query_stat = "SELECT AppStatus FROM user WHERE UserID = @userID";
            object result = database.ExecuteScalar(query_stat, cmd =>
            {
                cmd.Parameters.AddWithValue("@userID", userId);
            });

            return result?.ToString();
        }

        private void informations_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void TakeExamButton_Click(object sender, EventArgs e)
        {
            new AdmissionExam().Show();
            this.Hide();
        }

        private void applicationStatus_Click_1(object sender, EventArgs e)
        {

        }
    }
}
