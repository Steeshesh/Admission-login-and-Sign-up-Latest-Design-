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
    public partial class AdmissionExam : Form

    {
        private int timeLeft;

        public AdmissionExam()
        {
            InitializeComponent();

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

        private void Logout_Click(object sender, EventArgs e)
        {

        }

        private void LogoutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
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

            // Empty GroupBox Validation //
            var radioPairs = new (RadioButton rbtn1, RadioButton rbtn2)[]
            {
                 (rbtnCorrect1, rbtn2),
                 (rbtnCorrect2, radioButton4),
                 (rbtnCorrect3, radioButton6),
                 (rbtnCorrect4, radioButton8),
                 (rbtnCorrect5, radioButton9),
                 (rbtnCorrect6, radioButton12),
                 (rbtnCorrect7, radioButton13),
                 (rbtnCorrect8, radioButton15),
                 (rbtnCorrect9, radioButton17),
                 (rbtnCorrect10, radioButton25),
                 (rbtnCorrect11, radioButton26),
                 (rbtnCorrect12, radioButton27),
                 (rbtnCorrect13, radioButton22),
                 (rbtnCorrect14, radioButton29),
                 (rbtnCorrect15, radioButton24)
            };

            bool allAnswered = true;
            List<int> unansweredQuestions = new List<int>(); // List to track unanswered questions

            // Check for unanswered questions in each group box
            for (int i = 0; i < radioPairs.Length; i++)
            {
                var pair = radioPairs[i];
                if (!pair.rbtn1.Checked && !pair.rbtn2.Checked)
                {
                    unansweredQuestions.Add(i + 1); // Track the unanswered question index
                    allAnswered = false; // Mark as unanswered
                }
            }

            // If there are unanswered questions, show validation messages
            if (!allAnswered)
            {
                // Display an error message for each unanswered question group
                foreach (var questionIndex in unansweredQuestions)
                {
                    MessageBox.Show($"Question No. {questionIndex} is empty. Please select either True or False.",
                                    "Submission Failed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
                return; // Stop further checks until user answers the skipped or no answer question/s
            }

            // After checking for unanswered questions, show score-based messages
            if (Counter >= 8)
            {
                // Show congratulations message if the user passed
                MessageBox.Show("Congratulations! You passed the exam!", "Well Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Please check your status for your requirements approval.", "Waiting for approval", MessageBoxButtons.OK, MessageBoxIcon.Information);

                new Status().Show();
                this.Hide();
            }
            else if (Counter <= 7)
            {
                // Show the apology message if the user didn't pass
                MessageBox.Show("We're sorry, you didn't pass the exam. Better luck next time!", "Try Again, next examination", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}