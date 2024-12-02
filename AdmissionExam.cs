using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Admission_login_and_Sign_up__Latest_Design_
{
    public partial class AdmissionExam : Form
    {
        private bool isTimerExpired = false;  // Flag to track if the timer expired
        private int timeLeft;

        public AdmissionExam()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Enable double buffering for the form

            // Initialize the timer event
            ExamTimer.Tick += ExamTimer_Tick;
        }

        // Navigation and Page Control
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
        protected override void OnPaint(PaintEventArgs e)
        {
            this.DoubleBuffered = true;
            base.OnPaint(e);
        }

        private void Applybtn_Click(object sender, EventArgs e)
        {
            new ApplicationForm().Show(); // Temporary
            this.Hide();
        }

        // Exam Timer Logic
        private void ExamTimer_Tick(object sender, EventArgs e)
        {
            lbltimebox.Text = timeLeft.ToString();

            // Countdown logic
            timeLeft--;
            if (timeLeft < 0)
            {
                ExamTimer.Stop();
                isTimerExpired = true;

                MessageBox.Show("Time's up! Submitting your exam now.", "Time Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SubmitExam_Click(sender, e); // Auto-submit the exam
            }
        }

        // Submit Exam and Auto Scoring
        private void SubmitExam_Click(object sender, EventArgs e)
        {
            ExamTimer.Stop(); // Stop the timer

            int score = 0; // Counter for correct answers

            // Correct answers
            RadioButton[] radioButtons = {
                rbtnCorrect1, rbtnCorrect2, rbtnCorrect3, rbtnCorrect4, rbtnCorrect5,
                rbtnCorrect6, rbtnCorrect7, rbtnCorrect8, rbtnCorrect9, rbtnCorrect10,
                rbtnCorrect11, rbtnCorrect12, rbtnCorrect13, rbtnCorrect14, rbtnCorrect15
            };

            // Check for correct answers
            foreach (var rbtn in radioButtons)
            {
                if (rbtn.Checked) score++;
            }

            // Unanswered questions validation
            if (!isTimerExpired)
            {
                var radioPairs = new (RadioButton, RadioButton)[] {
                    (rbtnCorrect1, rbtn2), (rbtnCorrect2, radioButton4), (rbtnCorrect3, radioButton6),
                    (rbtnCorrect4, radioButton8), (rbtnCorrect5, radioButton9), (rbtnCorrect6, radioButton12),
                    (rbtnCorrect7, radioButton13), (rbtnCorrect8, radioButton15), (rbtnCorrect9, radioButton17),
                    (rbtnCorrect10, radioButton25), (rbtnCorrect11, radioButton26), (rbtnCorrect12, radioButton27),
                    (rbtnCorrect13, radioButton22), (rbtnCorrect14, radioButton29), (rbtnCorrect15, radioButton24)
                };

                List<int> unansweredQuestions = new List<int>();
                for (int i = 0; i < radioPairs.Length; i++)
                {
                    if (!radioPairs[i].Item1.Checked && !radioPairs[i].Item2.Checked)
                        unansweredQuestions.Add(i + 1);
                }

                if (unansweredQuestions.Count > 0)
                {
                    foreach (int q in unansweredQuestions)
                    {
                        MessageBox.Show($"Question No. {q} is empty. Please select either True or False.",
                                        "Submission Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    ExamTimer.Start(); // Resume the timer
                    return;
                }
            }

            // Display the result
            if (score >= 8)
            {
                MessageBox.Show("Congratulations! You passed the exam!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Please check your status for requirements approval.", "Approval Pending", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("We're sorry, you didn't pass the exam. Better luck next time!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            new Status().Show();
            this.Hide();
        }

        // Timer Start Trigger
        private void StartTimerOnSelection(RadioButton radioButton)
        {
            if (radioButton.Checked && !ExamTimer.Enabled)
            {
                timeLeft = 30; // Initialize timer duration
                lbltimebox.Text = timeLeft.ToString();
                ExamTimer.Start();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) => StartTimerOnSelection(rbtnCorrect1);
        private void rbtn2_CheckedChanged(object sender, EventArgs e) => StartTimerOnSelection(rbtn2);
        private void rbtnCorrect2_CheckedChanged(object sender, EventArgs e) => StartTimerOnSelection(rbtnCorrect2);
        private void radioButton4_CheckedChanged_1(object sender, EventArgs e) => StartTimerOnSelection(radioButton4);

        // Empty Event Handlers (Retained for Future Use)
        private void Logout_Click(object sender, EventArgs e) { }
        private void LogoutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { }
        private void Nextbtn_Paint(object sender, PaintEventArgs e) { ExamForm.BackColor = Color.FromArgb(150, Color.Black); }
        private void AdmissionExam_Load(object sender, EventArgs e) { }
        private void lbltimebox_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }

        // Empty Label Click Handlers
        private void label2_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void label11_Click(object sender, EventArgs e) { }
        private void label15_Click(object sender, EventArgs e) { }
        private void label17_Click(object sender, EventArgs e) { }
        private void label18_Click(object sender, EventArgs e) { }

        // Other RadioButton Handlers
        private void radioButton8_CheckedChanged(object sender, EventArgs e) { }
        private void radioButton10_CheckedChanged(object sender, EventArgs e) { }
        private void radioButton13_CheckedChanged(object sender, EventArgs e) { }
        private void radioButton23_CheckedChanged(object sender, EventArgs e) { }
    }
}
