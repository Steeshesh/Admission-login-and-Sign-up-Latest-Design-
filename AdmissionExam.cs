using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace Admission_login_and_Sign_up__Latest_Design_
{
    public partial class AdmissionExam : Form
    {
        private bool isTimerExpired = false;  // Flag to track if the timer expired
        private int timeLeft;
        private Database database;
        public AdmissionExam()
        {
            InitializeComponent();
            database = new Database();
            ExamTimer.Tick += ExamTimer_Tick;
        }

        private void Statusbtn_Click(object sender, EventArgs e)
        {
            new Status().Show();
            this.Hide();
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

        private void Applybtn_Click(object sender, EventArgs e)
        {
            new ApplicationForm().Show(); // temporary
            this.Hide();
        }

        private void Nextbtn_Paint(object sender, PaintEventArgs e)
        {
            ExamForm.BackColor = Color.FromArgb(150, Color.Black);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SubmitExam_Click(object sender, EventArgs e)
        {
            // Stop the timer when the submit button is clicked
            ExamTimer.Stop();

            // Auto scoring //
            int Counter = 0;

            RadioButton[] radioButtons = { rbtnCorrect1, rbtnCorrect2, rbtnCorrect3, rbtnCorrect4, rbtnCorrect5, rbtnCorrect6,
                   rbtnCorrect7, rbtnCorrect8, rbtnCorrect9, rbtnCorrect10, rbtnCorrect11,
                   rbtnCorrect12, rbtnCorrect13, rbtnCorrect14, rbtnCorrect15 };

            foreach (var rbtn in radioButtons)
            {
                if (rbtn.Checked)
                {
                    Counter++;
                }
            }

            // After checking for unanswered questions, determine the result
            string examResult;
            if (Counter >= 8)
            {
                examResult = "Passed";
                MessageBox.Show("Congratulations! You passed the exam!", "Well Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                examResult = "Failed";
                MessageBox.Show("We're sorry, you didn't pass the exam. Better luck next time!", "Try Again, next examination", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Update the ExamStatus in the database
            UpdateExamStatus(UserSession.UserID, examResult);

            // Redirect to the Status page
            new Status().Show();
            this.Hide();
        }

        /// <summary>
        /// Updates the ExamStatus in the database for the given UserID.
        /// </summary>
        /// <param name="userId">The ID of the user taking the exam.</param>
        /// <param name="examResult">The result of the exam ("Passed" or "Failed").</param>
        private void UpdateExamStatus(int userId, string examResult)
        {
            string query = "UPDATE status SET ExamStatus = @examResult WHERE UserID = @userId";

            try
            {
                Database database = new Database();
                database.ExecuteScalar(query, cmd =>
                {
                    cmd.Parameters.AddWithValue("@examResult", examResult);
                    cmd.Parameters.AddWithValue("@userId", userId);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the exam status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if ((rbtnCorrect1.Checked) && !ExamTimer.Enabled)
            {
                // Set the initial time for the countdown (e.g., 20 seconds)
                timeLeft = 30;

                // Display the initial time on the label
                lbltimebox.Text = timeLeft.ToString();

                // Start the timer
                ExamTimer.Start();
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton23_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ExamTimer_Tick(object sender, EventArgs e)
        {
            lbltimebox.Text = timeLeft.ToString();

            // Decrease the timeLeft by 1 second each tick
            timeLeft--;

            // When timeLeft reaches 0 or below, stop the timer and display a message
            if (timeLeft < 0)
            {
                ExamTimer.Stop();
                isTimerExpired = true;  // Mark timer as expired


                // Show a message to inform the user that the time is up
                MessageBox.Show("Time's up! Submitting your exam now.", "Time Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Automatically trigger the SubmitExam_Click method to submit the exam
                SubmitExam_Click(sender, e);
            }

        }

        private void lbltimebox_Click(object sender, EventArgs e)
        {

        }

        private void rbtn2_CheckedChanged(object sender, EventArgs e)
        {
            if ((rbtn2.Checked) && !ExamTimer.Enabled)
            {
                // Set the initial time for the countdown (e.g., 20 seconds)
                timeLeft = 30;

                // Display the initial time on the label
                lbltimebox.Text = timeLeft.ToString();

                // Start the timer
                ExamTimer.Start();
            }
        }

        private void rbtnCorrect2_CheckedChanged(object sender, EventArgs e)
        {
            if ((rbtnCorrect2.Checked) && !ExamTimer.Enabled)
            {
                // Set the initial time for the countdown (e.g., 20 seconds)
                timeLeft = 30;

                // Display the initial time on the label
                lbltimebox.Text = timeLeft.ToString();

                // Start the timer
                ExamTimer.Start();
            }
        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            if ((radioButton4.Checked) && !ExamTimer.Enabled)
            {
                // Set the initial time for the countdown (e.g., 20 seconds)
                timeLeft = 30;

                // Display the initial time on the label
                lbltimebox.Text = timeLeft.ToString();

                // Start the timer
                ExamTimer.Start();
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdmissionExam_Load(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }
    }
}
