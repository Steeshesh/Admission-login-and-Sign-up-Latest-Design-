using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System;

namespace Admission_login_and_Sign_up__Latest_Design_
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            SetupChart();
            LoadCounts();
        }

        private void SetupChart()
        {
            // Configure chart appearance
            statusChart.BackColor = Color.FromArgb(46, 51, 73);
            statusChart.ChartAreas[0].BackColor = Color.FromArgb(37, 42, 64);

            // Configure legend
            statusChart.Legends[0].BackColor = Color.FromArgb(37, 42, 64);
            statusChart.Legends[0].ForeColor = Color.White;

            // Configure chart area
            statusChart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            statusChart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;

            // Configure series
            statusChart.Series[0].ChartType = SeriesChartType.Pie;
            statusChart.Series[0].LabelForeColor = Color.White;
        }

        private void LoadCounts()
        {
            try
            {
                string query = @"
                    SELECT 
                        SUM(CASE WHEN s.ReqStatus = 'Pending' OR s.ReqStatus IS NULL THEN 1 ELSE 0 END) as PendingCount,
                        SUM(CASE WHEN s.ReqStatus = 'Approved' THEN 1 ELSE 0 END) as ApprovedCount
                    FROM user u
                    LEFT JOIN status s ON u.UserID = s.UserID
                    WHERE u.FirstName IS NOT NULL";

                DataTable dt = DatabaseConnection.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    int pendingCount = Convert.ToInt32(dt.Rows[0]["PendingCount"]);
                    int approvedCount = Convert.ToInt32(dt.Rows[0]["ApprovedCount"]);

                    // Update labels
                    lblPending.Text = $"{pendingCount} Students";
                    lblApproved.Text = $"{approvedCount} Students";

                    // Update chart
                    statusChart.Series[0].Points.Clear();

                    // Add pending data
                    var pendingPoint = statusChart.Series[0].Points.Add(pendingCount);
                    pendingPoint.Color = Color.FromArgb(0, 126, 249); // Blue color to match your label
                    pendingPoint.LegendText = "Pending";
                    pendingPoint.Label = $"Pending\n({pendingCount})";

                    // Add approved data
                    var approvedPoint = statusChart.Series[0].Points.Add(approvedCount);
                    approvedPoint.Color = Color.FromArgb(50, 226, 178); // Green color to match your label
                    approvedPoint.LegendText = "Approved";
                    approvedPoint.Label = $"Approved\n({approvedCount})";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading counts: {ex.Message}");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadCounts();
        }
    }
}