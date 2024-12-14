using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Admission_login_and_Sign_up__Latest_Design_
{
    public partial class frmAnalytics : Form
    {
        // Data structures to store analytics
        // Dictionary to store gender distribution data
        // Key: Gender (string), Value: Count (int)
        private readonly Dictionary<string, int> genderDistribution;
        // SortedDictionary to store age distribution data (automatically sorts by age group)
        // Key: Age Group (string), Value: Count (int)
        private readonly SortedDictionary<string, int> ageDistribution;

        // Queue to manage analytics processing requests in FIFO order
        private readonly Queue<AnalyticsRequest> analyticsQueue;

        // Stack to store historical snapshots of analytics data (LIFO)
        private readonly Stack<AnalyticsSnapshot> analyticsHistory;

        // Cache dictionary to store query results and improve performance
        // Key: Query identifier (string), Value: Query result (DataTable)
        private readonly Dictionary<string, DataTable> queryCache;
        public frmAnalytics()
        {
            InitializeComponent();
            // Initialize all data structures
            genderDistribution = new Dictionary<string, int>();
            ageDistribution = new SortedDictionary<string, int>();
            analyticsQueue = new Queue<AnalyticsRequest>();
            analyticsHistory = new Stack<AnalyticsSnapshot>();
            queryCache = new Dictionary<string, DataTable>();
        }

        // Custom classes for better organization
        private class AnalyticsRequest
        {
            public string QueryType { get; set; }
            public DateTime RequestTime { get; set; }
        }
        // Custom class to store snapshots of analytics data
        private class AnalyticsSnapshot
        {
            public Dictionary<string, int> GenderData { get; set; }
            public SortedDictionary<string, int> AgeData { get; set; }
            public DateTime SnapshotTime { get; set; }
        }

        private class AnalyticsMetrics
        {
            public double Average { get; set; }
            public int Count { get; set; }
            public double Percentage { get; set; }
        }

        private void frmAnalytics_Load(object sender, EventArgs e)
        {
            InitializeAnalytics();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SaveCurrentSnapshot();
            InitializeAnalytics();
        }

        private void SaveCurrentSnapshot()
        {
            analyticsHistory.Push(new AnalyticsSnapshot
            {
                GenderData = new Dictionary<string, int>(genderDistribution),
                AgeData = new SortedDictionary<string, int>(ageDistribution),
                SnapshotTime = DateTime.Now
            });
        }

        private void InitializeAnalytics()
        {
            ClearCharts();
            QueueAnalyticsRequests();
            ProcessAnalyticsQueue();
        }

        private void ClearCharts()
        {
            chartGender.Series["Gender"].Points.Clear();
            chartAge.Series["Age"].Points.Clear();
            genderDistribution.Clear();
            ageDistribution.Clear();
        }

        private void QueueAnalyticsRequests()
        {
            analyticsQueue.Enqueue(new AnalyticsRequest { QueryType = "Gender", RequestTime = DateTime.Now });
            analyticsQueue.Enqueue(new AnalyticsRequest { QueryType = "Age", RequestTime = DateTime.Now });
            analyticsQueue.Enqueue(new AnalyticsRequest { QueryType = "Program", RequestTime = DateTime.Now });
        }

        private void ProcessAnalyticsQueue()
        {
            while (analyticsQueue.Count > 0)
            {
                var request = analyticsQueue.Dequeue();
                ProcessAnalyticsRequest(request);
            }
            UpdateTotalStudents();

        }

        private void ProcessAnalyticsRequest(AnalyticsRequest request)
        {
            switch (request.QueryType)
            {
                case "Gender":
                    ProcessGenderAnalytics();
                    break;
                case "Age":
                    ProcessAgeAnalytics();
                    break;
                case "Program":
                    ProcessProgramAnalytics();
                    break;
            }
        }

        private void ProcessGenderAnalytics()
        {
            string query = @"
                SELECT Gender, COUNT(*) as Count 
                FROM user 
                WHERE Gender IS NOT NULL
                GROUP BY Gender";

            DataTable data = GetCachedData(query, "Gender");
            var metrics = CalculateMetrics(data);
            UpdateGenderChart(data, metrics);
        }
        private void UpdateTotalStudents()
        {
            try
            {
                // This query will count all users in the user table
                string totalQuery = @"
            SELECT COUNT(*) as Total 
            FROM user";

                DataTable totalData = DatabaseConnection.ExecuteQuery(totalQuery);

                if (totalData != null && totalData.Rows.Count > 0 && totalData.Rows[0]["Total"] != DBNull.Value)
                {
                    int totalStudents = Convert.ToInt32(totalData.Rows[0]["Total"]);
                    labelTotalStudents.Text = $"Total Student Applicants: {totalStudents:N0}";
                }
                else
                {
                    labelTotalStudents.Text = "Total Student Applicants: 0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating total students: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                labelTotalStudents.Text = "Total Student Applicants: Error";
            }
        }

        private void ProcessAgeAnalytics()
        {
            string query = @"
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

            DataTable data = GetCachedData(query, "Age");
            var metrics = CalculateMetrics(data);
            UpdateAgeChart(data, metrics);
            UpdateAverageAge();
        }

        private DataTable GetCachedData(string query, string cacheKey)
        {
            if (!queryCache.ContainsKey(cacheKey))
            {
                queryCache[cacheKey] = DatabaseConnection.ExecuteQuery(query);
            }
            return queryCache[cacheKey];
        }

        private AnalyticsMetrics CalculateMetrics(DataTable data)
        {
            int total = data.AsEnumerable().Sum(row => Convert.ToInt32(row["Count"]));
            double average = data.AsEnumerable().Average(row => Convert.ToInt32(row["Count"]));
            return new AnalyticsMetrics
            {
                Average = average,
                Count = total,
                Percentage = 100.0
            };
        }

        private void UpdateGenderChart(DataTable data, AnalyticsMetrics metrics)
        {
            foreach (DataRow row in data.Rows)
            {
                string gender = row["Gender"].ToString();
                int count = Convert.ToInt32(row["Count"]);
                double percentage = (count * 100.0) / metrics.Count;

                genderDistribution[gender] = count;
                AddChartPoint(chartGender, "Gender", gender, count, percentage);
            }
            labelGenderDistribution.Text = "Gender Distribution";
        }

        private void UpdateAgeChart(DataTable data, AnalyticsMetrics metrics)
        {
            foreach (DataRow row in data.Rows)
            {
                string ageGroup = row["AgeGroup"].ToString();
                int count = Convert.ToInt32(row["Count"]);
                double percentage = (count * 100.0) / metrics.Count;

                ageDistribution[ageGroup] = count;
                AddChartPoint(chartAge, "Age", ageGroup, count, percentage);
            }
            labelAgeDistribution.Text = "Age Distribution";
        }

        private void AddChartPoint(Chart chart, string series, string category, int value, double percentage)
        {
            DataPoint point = new DataPoint();
            point.SetValueXY(category, value);
            point.Label = $"{percentage:F1}%";
            chart.Series[series].Points.Add(point);
        }

        private void ProcessProgramAnalytics()
        {
            // Implementation for program analytics
            // Similar structure to gender and age analytics
        }

        private void UpdateAverageAge()
        {
            string query = @"
                SELECT AVG(TIMESTAMPDIFF(YEAR, STR_TO_DATE(DateOfBirth, '%Y-%m-%d'), CURDATE())) as AverageAge 
                FROM user
                WHERE DateOfBirth IS NOT NULL";

            DataTable data = GetCachedData(query, "AverageAge");
            double averageAge = data.Rows[0]["AverageAge"] != DBNull.Value ?
                Convert.ToDouble(data.Rows[0]["AverageAge"]) : 0;

            labelAverageAge.Text = $"Average Age: {averageAge:F1} years";
        }

        // Event handlers
        private void chartGender_Click(object sender, EventArgs e)
        {
            // Implementation if needed
        }

        private void chartAge_Click(object sender, EventArgs e)
        {
            // Implementation if needed
        }
    }
}