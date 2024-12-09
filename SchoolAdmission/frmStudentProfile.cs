using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
            // Basic DataGridView styling
            dataGridViewStudents.BackgroundColor = Color.FromArgb(46, 51, 73);
            dataGridViewStudents.BorderStyle = BorderStyle.None;
            dataGridViewStudents.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewStudents.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewStudents.EnableHeadersVisualStyles = false;
            dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Column Header Styling
            dataGridViewStudents.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(24, 30, 54);
            dataGridViewStudents.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(224, 224, 224);
            dataGridViewStudents.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewStudents.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            dataGridViewStudents.ColumnHeadersHeight = 40;

            // Cell Styling
            dataGridViewStudents.DefaultCellStyle.BackColor = Color.FromArgb(35, 40, 62);
            dataGridViewStudents.DefaultCellStyle.ForeColor = Color.FromArgb(224, 224, 224);
            dataGridViewStudents.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dataGridViewStudents.DefaultCellStyle.Padding = new Padding(5);
            dataGridViewStudents.RowTemplate.Height = 35;

            // Selection Styling
            dataGridViewStudents.DefaultCellStyle.SelectionBackColor = Color.FromArgb(64, 134, 246);
            dataGridViewStudents.DefaultCellStyle.SelectionForeColor = Color.White;

            // Grid Colors
            dataGridViewStudents.GridColor = Color.FromArgb(24, 30, 54);

            // Add columns to the DataGridView
            dataGridViewStudents.Columns.Add("UserID", "User ID");
            dataGridViewStudents.Columns.Add("Name", "Name");
            dataGridViewStudents.Columns.Add("Status", "Status");
            dataGridViewStudents.Columns.Add("Comment", "Rejection Reason");

            // Add a button column for viewing details
            DataGridViewButtonColumn btnViewInfo = new DataGridViewButtonColumn();
            btnViewInfo.HeaderText = "Details";
            btnViewInfo.Text = "View";
            btnViewInfo.Name = "btnViewInfo";
            btnViewInfo.UseColumnTextForButtonValue = true;
            btnViewInfo.FlatStyle = FlatStyle.Flat;
            btnViewInfo.DefaultCellStyle.BackColor = Color.FromArgb(64, 134, 246);
            btnViewInfo.DefaultCellStyle.ForeColor = Color.White;
            btnViewInfo.DefaultCellStyle.SelectionBackColor = Color.FromArgb(72, 149, 255);
            btnViewInfo.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewStudents.Columns.Add(btnViewInfo);

            // Set column widths
            dataGridViewStudents.Columns["UserID"].Width = 80;
            dataGridViewStudents.Columns["Name"].Width = 200;
            dataGridViewStudents.Columns["Status"].Width = 100;
            dataGridViewStudents.Columns["Comment"].Width = 250;
            dataGridViewStudents.Columns["btnViewInfo"].Width = 80;

            // Custom status cell coloring
            dataGridViewStudents.CellFormatting += (sender, e) =>
            {
                if (e.ColumnIndex == dataGridViewStudents.Columns["Status"].Index && e.Value != null)
                {
                    switch (e.Value.ToString().ToLower())
                    {
                        case "approved":
                            e.CellStyle.ForeColor = Color.FromArgb(75, 181, 67);
                            break;
                        case "rejected":
                            e.CellStyle.ForeColor = Color.FromArgb(230, 88, 88);
                            break;
                        case "pending":
                            e.CellStyle.ForeColor = Color.FromArgb(255, 198, 51);
                            break;
                    }
                }
            };

            // Remove focus rectangle
            dataGridViewStudents.RowHeadersVisible = false;
            dataGridViewStudents.CellClick += DataGridViewStudents_CellClick;

            // Additional customization
            foreach (DataGridViewColumn column in dataGridViewStudents.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                if (column.Name != "btnViewInfo")
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }

            // Alternating row colors
            dataGridViewStudents.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(40, 45, 67);
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
            SELECT 
                u.UserID, 
                CONCAT(COALESCE(u.FirstName, ''), ' ', COALESCE(u.LastName, '')) as Name,
                s.ReqStatus as Status,
                s.Comment
            FROM user u
            LEFT JOIN status s ON u.UserID = s.UserID
            WHERE u.FirstName IS NOT NULL
            ORDER BY u.UserID";

                DataTable dt = DatabaseConnection.ExecuteQuery(query);
                dataGridViewStudents.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    dataGridViewStudents.Rows.Add(
                        row["UserID"],
                        row["Name"],
                        row["Status"] ?? "Pending",
                        row["Status"]?.ToString() == "Rejected" ? row["Comment"] : ""
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
            if (e.ColumnIndex == dataGridViewStudents.Columns["btnViewInfo"].Index && e.RowIndex >= 0)
            {
                int userId = Convert.ToInt32(dataGridViewStudents.Rows[e.RowIndex].Cells["UserID"].Value);

                // Open the detailed view form
                using (var detailForm = new frmStudentDetail(userId))
                {
                    if (detailForm.ShowDialog() == DialogResult.OK)
                    {
                        // Refresh the data after the detail form is closed
                        LoadStudentData();
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStudentData();
        }
    }
}