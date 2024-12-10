using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admission_login_and_Sign_up__Latest_Design_
{
    public partial class Status : Form
    {
        private readonly Database database;
        private bool isClosing = false;

        public Status()
        {
            // Enable double buffering
            this.SetStyle(ControlStyles.DoubleBuffer |
                         ControlStyles.UserPaint |
                         ControlStyles.AllPaintingInWmPaint,
                         true);
            this.UpdateStyles();

            InitializeComponent();
            database = new Database();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private async void Status_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadUserDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadUserDataAsync()
        {
            await Task.Run(() =>
            {
                var firstName = GetUserFirstName(UserSession.UserID);
                var reqStat = GetUserRequirementsStatus(UserSession.UserID);
                var user_studentID = GetUserID(UserSession.UserID);
                var programName = GetChosenProgram(UserSession.UserID);
                var examStatus = GetExamStatus(UserSession.UserID);
                var comment = GetComment(UserSession.UserID);

                // Update UI on the main thread
                this.Invoke((MethodInvoker)delegate
                {
                    UpdateUI(firstName, reqStat, user_studentID, programName, examStatus, comment);
                });
            });
        }
        private void LoadImageToPictureBox(string imagePath)
        {
            try
            {
                // Dispose of the current image if it exists
                if (studentPic.Image != null)
                {
                    var currentImage = studentPic.Image;
                    studentPic.Image = null;
                    currentImage.Dispose();
                }

                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        studentPic.Image = Image.FromStream(stream);
                        studentPic.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    // Load a default image if no image is found
                    studentPic.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateUI(string firstName, string reqStat, string user_studentID,
                    string programName, string examStatus, string comment)
        {
            fullName.Text = string.IsNullOrEmpty(firstName) ? "Welcome!" : "Welcome, " + firstName;
            requirementStatus.Text = string.IsNullOrEmpty(reqStat) ? "No Record" : reqStat;
            studentID.Text = string.IsNullOrEmpty(user_studentID) ? "" : user_studentID;
            ChosenProgram.Text = string.IsNullOrEmpty(programName) ? "No Record" : programName;
            examinationStatus.Text = string.IsNullOrEmpty(examStatus) ? "" : examStatus;
            documentationStat.Text = string.IsNullOrEmpty(comment) ? "" : comment;

            TakeExamButton.Visible = reqStat == "Approved" && string.IsNullOrEmpty(examStatus);

            // Load the formal picture
            string imagePath = GetUserFormalPicture(UserSession.UserID);
            LoadImageToPictureBox(imagePath);
        }

        private string GetUserFirstName(int userId)
        {
            string query = "SELECT FirstName FROM user WHERE UserID = @userID";
            return ExecuteScalarQuery(query, userId);
        }

        private string GetUserRequirementsStatus(int userId)
        {
            string query = "SELECT ReqStatus FROM status WHERE UserID = @userID";
            return ExecuteScalarQuery(query, userId);
        }

        private string GetUserID(int userId)
        {
            string query = "SELECT UserID FROM user WHERE UserID = @userID";
            return ExecuteScalarQuery(query, userId);
        }

        private string GetChosenProgram(int userId)
        {
            string query = "SELECT ProgramName FROM program WHERE UserID = @userID";
            return ExecuteScalarQuery(query, userId);
        }

        private string GetExamStatus(int userId)
        {
            string query = "SELECT ExamStatus FROM status WHERE UserID = @userID";
            return ExecuteScalarQuery(query, userId);
        }

        private string GetComment(int userId)
        {
            string query = "SELECT Comment FROM status WHERE UserID = @userID";
            return ExecuteScalarQuery(query, userId);
        }

        private string ExecuteScalarQuery(string query, int userId)
        {
            try
            {
                object result = database.ExecuteScalar(query, cmd =>
                {
                    cmd.Parameters.AddWithValue("@userID", userId);
                });
                return result?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void Instructionbtn_Click(object sender, EventArgs e)
        {
            var defaultPage = new DefaultPage();
            defaultPage.Show();
            CloseForm();
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
            UserSession.Clear();
            var loginForm = new Login();
            loginForm.Show();
            CloseForm();
        }

        private void Applybtn_Click(object sender, EventArgs e)
        {
            var applicationForm = new ApplicationForm();
            applicationForm.Show();
            CloseForm();
        }

        private void TakeExamButton_Click(object sender, EventArgs e)
        {
            var examForm = new AdmissionExam();
            examForm.Show();
            CloseForm();
        }

        private void CloseForm()
        {
            isClosing = true;
            this.Hide();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!isClosing && e.CloseReason == CloseReason.UserClosing)
            {
                // Handle application exit
                Application.Exit();
            }
            base.OnFormClosing(e);
        }

        private void informations_Paint(object sender, PaintEventArgs e)
        {
            if (informations != null)
            {
                informations.BackColor = Color.FromArgb(150, Color.Black);
            }
        }
        private string GetUserFormalPicture(int userId)
        {
            string query = "SELECT FormalPicture FROM docreqs WHERE UserID = @userID";
            return ExecuteScalarQuery(query, userId);
        }

        // Empty event handlers can be removed if not needed
        private void applicationStatus_Click(object sender, EventArgs e) { }
        private void fullName_Click(object sender, EventArgs e) { }
        private void applicationStatus_Click_1(object sender, EventArgs e) { }
        private void studentID_Click(object sender, EventArgs e) { }
        private void examinationStatus_Click(object sender, EventArgs e) { }
        private void documentationStat_Click(object sender, EventArgs e) { }
        private void documentationStatusLB_Click(object sender, EventArgs e) { }
        private void informations_Paint_1(object sender, PaintEventArgs e) { }

        private void studentPic_Click(object sender, EventArgs e)
        {

        }
    }
}