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

        // Add this event handler
        private void labelGenderDistribution_Click(object sender, EventArgs e)
        {
            // This can be empty if you don't need any action when the label is clicked
        }

        private void LoadAnalytics()
        {
            // Clear existing data
            chartGender.Series["Gender"].Points.Clear();
            chartAge.Series["Age"].Points.Clear();

            // Gender Distribution
            string genderQuery = @"
                SELECT Gender, COUNT(*) as Count 
                FROM students 
                GROUP BY Gender";
            DataTable genderData = DatabaseConnection.ExecuteQuery(genderQuery);

            int totalStudents = 0;
            foreach (DataRow row in genderData.Rows)
            {
                totalStudents += Convert.ToInt32(row["Count"]);
            }

            foreach (DataRow row in genderData.Rows)
            {
                string gender = char.ToUpper(row["Gender"].ToString()[0]) + row["Gender"].ToString().Substring(1);
                int count = Convert.ToInt32(row["Count"]);
                double percentage = (count * 100.0) / totalStudents;
                DataPoint point = new DataPoint();
                point.SetValueXY(gender, count);
                point.Label = $"{gender}\n{percentage:F1}%";
                chartGender.Series["Gender"].Points.Add(point);
            }

            labelGenderDistribution.Text = $"Gender Distribution";

            // Age Distribution
            string ageQuery = @"
                SELECT 
                    CASE 
                        WHEN TIMESTAMPDIFF(YEAR, DateOfBirth, CURDATE()) < 20 THEN 'Under 20'
                        WHEN TIMESTAMPDIFF(YEAR, DateOfBirth, CURDATE()) BETWEEN 20 AND 25 THEN '20-25'
                        ELSE 'Over 25'
                    END as AgeGroup,
                    COUNT(*) as Count
                FROM students
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
                SELECT AVG(TIMESTAMPDIFF(YEAR, DateOfBirth, CURDATE())) as AverageAge 
                FROM students";
            DataTable avgAgeData = DatabaseConnection.ExecuteQuery(avgAgeQuery);
            double averageAge = Convert.ToDouble(avgAgeData.Rows[0]["AverageAge"]);
            labelAverageAge.Text = $"Average Age: {averageAge:F1} years";

            // Total Students
            labelTotalStudents.Text = $"Total Students: {totalStudents}";

            // Update Age Distribution Label
            labelAgeDistribution.Text = "Age Distribution";
        }

        private void chartGender_Click(object sender, EventArgs e)
        {

        }

        private void chartAge_Click(object sender, EventArgs e)
        {

        }
    }
}