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
            string reqStat = GetUserRequirementsStatus(UserSession.UserID);
            string user_studentID = GetUserID(UserSession.UserID);
            string programName = GetChosenProgram(UserSession.UserID);
            string examStatus = GetExamStatus(UserSession.UserID);
            string comment = GetComment(UserSession.UserID);

            if (string.IsNullOrEmpty(firstName))
            {
                fullName.Text = "Welcome!";
            }
            else
            {
                fullName.Text = "Welcome, " + firstName;
            }

            if (string.IsNullOrEmpty(reqStat))
            {
                requirementStatus.Text = "No Record";
            }
            else
            {
                requirementStatus.Text = reqStat;
            }

            if (string.IsNullOrEmpty(user_studentID))
            {
                studentID.Text = "";
            }
            else
            {
                studentID.Text = user_studentID;
            }

            if (string.IsNullOrEmpty(programName))
            {
                ChosenProgram.Text = "No Record";
            }
            else
            {
                ChosenProgram.Text = programName;
            }

            if (string.IsNullOrEmpty(examStatus))
            {
                examinationStatus.Text = "";
            }
            else
            {
                examinationStatus.Text = examStatus;
            }

            if (string.IsNullOrEmpty(comment))
            {
                documentationStat.Text = "";
            }
            else
            {
                documentationStat.Text = comment;
            }
            // Set the visibility of the Take Exam button
            TakeExamButton.Visible = reqStat == "Approved" && string.IsNullOrEmpty(examStatus);
        }

        private void Instructionbtn_Click(object sender, EventArgs e)
        {
            new DefaultPage().Show();
            this.Hide();
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

        private string GetUserRequirementsStatus(int userId)
        {
            string query_stat = "SELECT ReqStatus FROM status WHERE UserID = @userID";
            object result = database.ExecuteScalar(query_stat, cmd =>
            {
                cmd.Parameters.AddWithValue("@userID", userId);
            });

            return result?.ToString();
        }

        private string GetUserID(int userId)
        {
            string query_id = "SELECT UserID FROM user WHERE UserID = @userID";
            object result = database.ExecuteScalar(query_id, cmd =>
            {
                cmd.Parameters.AddWithValue("@userID", userId);
            });

            return result?.ToString();
        }

        private string GetChosenProgram(int userId)
        {
            string query_program = "SELECT ProgramName FROM program WHERE UserID = @userID";
            object result = database.ExecuteScalar(query_program, cmd =>
            {
                cmd.Parameters.AddWithValue("@userID", userId);
            });

            return result?.ToString();
        }

        private string GetExamStatus(int userId)
        {
            string query_examStat = "SELECT ExamStatus FROM status WHERE UserID = @userID";
            object result = database.ExecuteScalar(query_examStat, cmd =>
            {
                cmd.Parameters.AddWithValue("@userID", userId);
            });

            return result?.ToString();
        }

        private string GetComment(int userId)
        {
            string query_comment = "SELECT Comment FROM status WHERE UserID = @userID";
            object result = database.ExecuteScalar(query_comment, cmd =>
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

        private void studentID_Click(object sender, EventArgs e)
        {

        }

        private void examinationStatus_Click(object sender, EventArgs e)
        {

        }

        private void documentationStat_Click(object sender, EventArgs e)
        {

        }

        private void documentationStatusLB_Click(object sender, EventArgs e)
        {

        }
    }
}
