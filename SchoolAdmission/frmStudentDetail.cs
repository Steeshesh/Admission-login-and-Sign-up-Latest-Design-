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

namespace SchoolAdmission
{
    public partial class frmStudentDetail : Form
    {
        private int userId;
        private string birthCertPath;
        private string torPath;
        private string goodMoralPath;

        public frmStudentDetail(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadUserData();
        }

        private void LoadUserData()
        {
            try
            {
                // Load personal information
                string personalQuery = @"
                SELECT * FROM user 
                WHERE UserID = @userId";

                DataTable personalData = DatabaseConnection.ExecuteQuery(personalQuery,
                    new Dictionary<string, object> { { "@userId", userId } });

                if (personalData.Rows.Count > 0)
                {
                    DataRow user = personalData.Rows[0];
                    lblName.Text = $"{user["FirstName"]} {user["MiddleName"]} {user["LastName"]}";
                    lblGender.Text = user["Gender"]?.ToString() ?? "N/A";
                    lblDOB.Text = Convert.ToDateTime(user["DateOfBirth"]).ToString("MMMM dd, yyyy");
                    lblNationality.Text = user["Nationality"]?.ToString() ?? "N/A";
                }

                // Load academic information
                string academicQuery = @"
                SELECT * FROM academic 
                WHERE UserID = @userId";

                DataTable academicData = DatabaseConnection.ExecuteQuery(academicQuery,
                    new Dictionary<string, object> { { "@userId", userId } });

                if (academicData.Rows.Count > 0)
                {
                    DataRow academic = academicData.Rows[0];
                    lblSchool.Text = academic["HighSchoolName"]?.ToString() ?? "N/A";
                    lblSchoolAddress.Text = academic["HighSchoolAddress"]?.ToString() ?? "N/A";
                    lblStrand.Text = academic["Strand"]?.ToString() ?? "N/A";
                    lblGWA.Text = academic["GeneralWeightedAverage"]?.ToString() ?? "N/A";
                }

                // Load document paths
                string docQuery = @"
                SELECT * FROM docreqs 
                WHERE UserID = @userId";

                DataTable docData = DatabaseConnection.ExecuteQuery(docQuery,
                    new Dictionary<string, object> { { "@userId", userId } });

                if (docData.Rows.Count > 0)
                {
                    DataRow docs = docData.Rows[0];

                    // Store paths for button clicks
                    birthCertPath = docs["BirthCertificate"]?.ToString();
                    torPath = docs["TranscriptOfRecords"]?.ToString();
                    goodMoralPath = docs["GoodMorals"]?.ToString();

                    // Load formal picture directly
                    string formalPicPath = docs["FormalPicture"]?.ToString();
                    if (!string.IsNullOrEmpty(formalPicPath) && File.Exists(formalPicPath))
                    {
                        picFormalPicture.Image = Image.FromFile(formalPicPath);
                        picFormalPicture.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}");
            }
        }

        // Button click handlers for documents
      

        private void ShowDocument(string path, string title)
        {
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                MessageBox.Show($"{title} not found or not submitted.", "Document Unavailable",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (Form imageForm = new Form())
                {
                    imageForm.Text = title;
                    imageForm.Size = new Size(800, 600);
                    imageForm.StartPosition = FormStartPosition.CenterScreen;

                    PictureBox pb = new PictureBox();
                    pb.Dock = DockStyle.Fill;
                    pb.Image = Image.FromFile(path);
                    pb.SizeMode = PictureBoxSizeMode.Zoom;

                    imageForm.Controls.Add(pb);
                    imageForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying {title}: {ex.Message}");
            }
        }

        // Approve/Reject buttons




        private void UpdateStatus(string newStatus)
        {
            try
            {
                string comment = null;

                // If rejecting, show comment dialog
                if (newStatus == "Rejected")
                {
                    using (var commentDialog = new frmCommentDialog())
                    {
                        if (commentDialog.ShowDialog() != DialogResult.OK)
                        {
                            return; // User cancelled
                        }
                        comment = commentDialog.Comment;
                    }
                }

                // First, check if status exists for this user
                string checkQuery = @"
            SELECT StatusID 
            FROM status 
            WHERE UserID = @userId";

                var parameters = new Dictionary<string, object>
        {
            { "@userId", userId },
            { "@status", newStatus },
            { "@comment", comment }
        };

                DataTable existingStatus = DatabaseConnection.ExecuteQuery(checkQuery,
                    new Dictionary<string, object> { { "@userId", userId } });

                string updateQuery;

                if (existingStatus.Rows.Count > 0)
                {
                    // Update existing record
                    updateQuery = @"
                UPDATE status 
                SET ReqStatus = @status, 
                    Comment = CASE 
                        WHEN @status = 'Rejected' THEN @comment 
                        ELSE NULL 
                    END,
                    ExamStatus = CASE 
                        WHEN @status = 'Approved' THEN ExamStatus 
                        ELSE NULL 
                    END
                WHERE UserID = @userId";
                }
                else
                {
                    // Insert new record only if no record exists
                    updateQuery = @"
                INSERT INTO status (UserID, ReqStatus, Comment) 
                VALUES (@userId, @status, @comment)";
                }

                bool success = DatabaseConnection.ExecuteNonQuery(updateQuery, parameters);

                if (success)
                {
                    string message = newStatus == "Rejected"
                        ? $"Application has been rejected.\nReason: {comment}"
                        : $"Application has been {newStatus.ToLower()}.";

                    MessageBox.Show(message, "Status Updated",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating status: {ex.Message}");
            }
        }

        // Clean up resources when form closes
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (picFormalPicture.Image != null)
            {
                picFormalPicture.Image.Dispose();
            }
        }

        private void frmStudentDetail_Load(object sender, EventArgs e)
        {

        }

        private void btnBirth_Click_1(object sender, EventArgs e)
        {
                ShowDocument(birthCertPath, "Birth Certificate");      
        }

        private void btnTOR_Click_1(object sender, EventArgs e)
        {
            ShowDocument(torPath, "Transcript of Records");
        }

        private void btnGoodMoral_Click_1(object sender, EventArgs e)
        {
            ShowDocument(goodMoralPath, "Good Moral Certificate");
        }

        private void btnApprove_Click_1(object sender, EventArgs e)
        {
            UpdateStatus("Approved");
        }

        private void btnReject_Click_1(object sender, EventArgs e)
        {
            UpdateStatus("Rejected");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
            }
        }
    }
}
