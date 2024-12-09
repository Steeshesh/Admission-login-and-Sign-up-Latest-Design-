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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            LoadCounts();
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

                    lblPending.Text = pendingCount.ToString();
                    lblApproved.Text = approvedCount.ToString();
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
