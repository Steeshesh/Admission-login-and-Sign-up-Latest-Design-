using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SchoolAdmission
{
    public partial class frmAnalytics : Form
    {
        public frmAnalytics()
        {
            InitializeComponent();
        }

        private void frmAnalytics_Load(object sender, EventArgs e)
        {
            LoadAnalytics();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAnalytics();
        }

        private void LoadAnalytics()
        {
            // Clear existing data
            chartGender.Series["Gender"].Points.Clear();
            chartAge.Series["Age"].Points.Clear();

            // Gender Distribution
            string genderQuery = @"
                SELECT Gender, COUNT(*) as Count 
                FROM user 
                WHERE Gender IS NOT NULL
                GROUP BY Gender";
            DataTable genderData = DatabaseConnection.ExecuteQuery(genderQuery);

            int totalStudents = 0;
            foreach (DataRow row in genderData.Rows)
            {
                totalStudents += Convert.ToInt32(row["Count"]);
            }

            foreach (DataRow row in genderData.Rows)
            {
                string gender = row["Gender"].ToString();
                int count = Convert.ToInt32(row["Count"]);
                double percentage = (count * 100.0) / totalStudents;
                DataPoint point = new DataPoint();
                point.SetValueXY(gender, count);
                point.Label = $"{gender}\n{percentage:F1}%";
                chartGender.Series["Gender"].Points.Add(point);
            }

            labelGenderDistribution.Text = $"Gender Distribution";

            // Age Distribution
            // Since DateOfBirth is stored as varchar in your database, we need to convert it
            string ageQuery = @"
                SELECT 
                    CASE 
                        WHEN TIMESTAMPDIFF(YEAR, STR_TO_DATE(DateOfBirth, '%Y-%m-%d'), CURDATE()) < 20 THEN 'Under 20'
                        WHEN TIMESTAMPDIFF(YEAR, STR_TO_DATE(DateOfBirth, '%Y-%m-%d'), CURDATE()) BETWEEN 20 AND 25 THEN '20-25'
                        ELSE 'Over 25'
                    END as AgeGroup,
                    COUNT(*) as Count
                FROM user
                WHERE DateOfBirth IS NOT NULL
                GROUP BY AgeGroup
                ORDER BY AgeGroup";
            DataTable ageData = DatabaseConnection.ExecuteQuery(ageQuery);

            foreach (DataRow row in ageData.Rows)
            {
                string ageGroup = row["AgeGroup"].ToString();
                int count = Convert.ToInt32(row["Count"]);
                double percentage = (count * 100.0) / totalStudents;
                DataPoint point = new DataPoint();
                point.SetValueXY(ageGroup, count);
                point.Label = $"{percentage:F1}%";
                chartAge.Series["Age"].Points.Add(point);
            }

            // Average Age
            string avgAgeQuery = @"
                SELECT AVG(TIMESTAMPDIFF(YEAR, STR_TO_DATE(DateOfBirth, '%Y-%m-%d'), CURDATE())) as AverageAge 
                FROM user
                WHERE DateOfBirth IS NOT NULL";
            DataTable avgAgeData = DatabaseConnection.ExecuteQuery(avgAgeQuery);

            // Handle case where there might be no data
            double averageAge = 0;
            if (avgAgeData.Rows.Count > 0 && avgAgeData.Rows[0]["AverageAge"] != DBNull.Value)
            {
                averageAge = Convert.ToDouble(avgAgeData.Rows[0]["AverageAge"]);
            }
            labelAverageAge.Text = $"Average Age: {averageAge:F1} years";

            // Additional Analytics

            // Program Distribution
            string programQuery = @"
                SELECT 
                    COALESCE(ProgramName, 'Undecided') as Program,
                    COUNT(*) as Count
                FROM program
                GROUP BY ProgramName";
            DataTable programData = DatabaseConnection.ExecuteQuery(programQuery);

            // You might want to add a new chart for program distribution
            // chartProgram.Series["Program"].Points.Clear();
            // foreach (DataRow row in programData.Rows)
            // {
            //     string program = row["Program"].ToString();
            //     int count = Convert.ToInt32(row["Count"]);
            //     chartProgram.Series["Program"].Points.AddXY(program, count);
            // }

            // Academic Performance
            string academicQuery = @"
                SELECT 
                    AVG(GeneralWeightedAverage) as AvgGWA,
                    MIN(GeneralWeightedAverage) as MinGWA,
                    MAX(GeneralWeightedAverage) as MaxGWA
                FROM academic
                WHERE GeneralWeightedAverage IS NOT NULL";
            DataTable academicData = DatabaseConnection.ExecuteQuery(academicQuery);

            if (academicData.Rows.Count > 0)
            {
                double avgGWA = Convert.ToDouble(academicData.Rows[0]["AvgGWA"]);
                // You might want to add labels for these statistics
                // labelAverageGWA.Text = $"Average GWA: {avgGWA:F2}";
            }

            // Application Status Distribution
            string statusQuery = @"
                SELECT 
                    COALESCE(ReqStatus, 'Pending') as Status,
                    COUNT(*) as Count
                FROM status
                GROUP BY ReqStatus";
            DataTable statusData = DatabaseConnection.ExecuteQuery(statusQuery);

            // You might want to add a chart for status distribution
            // chartStatus.Series["Status"].Points.Clear();
            // foreach (DataRow row in statusData.Rows)
            // {
            //     string status = row["Status"].ToString();
            //     int count = Convert.ToInt32(row["Count"]);
            //     chartStatus.Series["Status"].Points.AddXY(status, count);
            // }

            // Total Students (from user table)
            string totalQuery = "SELECT COUNT(*) as Total FROM user WHERE FirstName IS NOT NULL";
            DataTable totalData = DatabaseConnection.ExecuteQuery(totalQuery);
            int total = Convert.ToInt32(totalData.Rows[0]["Total"]);
            labelTotalStudents.Text = $"Total Students: {total}";

            // Update Age Distribution Label
            labelAgeDistribution.Text = "Age Distribution";
        }

        private void chartGender_Click(object sender, EventArgs e)
        {
            // Add any click handling if needed
        }

        private void chartAge_Click(object sender, EventArgs e)
        {
            // Add any click handling if needed
        }
    }
}