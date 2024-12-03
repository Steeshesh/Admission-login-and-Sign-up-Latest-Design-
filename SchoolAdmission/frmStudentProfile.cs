using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SchoolAdmission
{
    public partial class frmStudentProfile : Form
    {
        public frmStudentProfile()
        {
            InitializeComponent();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            // Add columns to the DataGridView
            dataGridViewStudents.Columns.Add("StudentID", "Student ID");
            dataGridViewStudents.Columns.Add("Name", "Name");
            dataGridViewStudents.Columns.Add("Status", "Status");

            // Add a button column for approval
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "Action";
            btnColumn.Text = "Approve";
            btnColumn.Name = "btnApprove";
            btnColumn.UseColumnTextForButtonValue = true;
            dataGridViewStudents.Columns.Add(btnColumn);

            // Handle cell click event
            dataGridViewStudents.CellClick += DataGridViewStudents_CellClick;
        }

        private void frmStudentProfile_Load(object sender, EventArgs e)
        {
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            try
            {
                string query = @"
                    SELECT s.StudentID, 
                           CONCAT(s.FirstName, ' ', s.LastName) as Name,
                           a.Status
                    FROM students s
                    LEFT JOIN applications a ON s.StudentID = a.StudentID
                    ORDER BY s.StudentID";

                DataTable dt = DatabaseConnection.ExecuteQuery(query);
                dataGridViewStudents.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    dataGridViewStudents.Rows.Add(
                        row["StudentID"],
                        row["Name"],
                        row["Status"] ?? "Pending"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading student data: " + ex.Message);
            }
        }

        private void DataGridViewStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the button column
            if (e.ColumnIndex == dataGridViewStudents.Columns["btnApprove"].Index && e.RowIndex >= 0)
            {
                int studentId = Convert.ToInt32(dataGridViewStudents.Rows[e.RowIndex].Cells["StudentID"].Value);
                string currentStatus = dataGridViewStudents.Rows[e.RowIndex].Cells["Status"].Value.ToString();

                if (currentStatus.ToLower() != "approved")
                {
                    try
                    {
                        string updateQuery = @"
                            UPDATE applications 
                            SET Status = 'Approved' 
                            WHERE StudentID = @StudentID";

                        DatabaseConnection.ExecuteNonQuery(updateQuery,
                            new Dictionary<string, object> { { "@StudentID", studentId } });

                        // Refresh the data
                        LoadStudentData();
                        MessageBox.Show("Application approved successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating application status: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Application is already approved.");
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStudentData();
        }
    }
}