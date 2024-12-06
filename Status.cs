﻿using System;
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

            if (firstName == "")
            {
                fullName.Text = "Welcome!";
            }
            else
            {
                fullName.Text = "Welcome, " + firstName;
            }

            if (reqStat == "")
            {
                requirementStatus.Text = "No submission";
            }
            else 
            {
                requirementStatus.Text = reqStat;
            }

            if (user_studentID == "")
            {
                studentID.Text = "";
            }
            else 
            {
                studentID.Text = user_studentID;
            }

            if (programName == "")
            {
                ChosenProgram.Text = "No Submission";
            }
            else
            {
                ChosenProgram.Text = programName;
            }

            // Set the visibility of the Take Exam button
            TakeExamButton.Visible = reqStat == "Approved";
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

        private string GetUserRequirementsStatus(int userId) 
        {
            string query_stat = "SELECT ReqStatus FROM user WHERE UserID = @userID";
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
    }
}
