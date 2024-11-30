using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Admission_login_and_Sign_up__Latest_Design_
{
    public class Database
    {
        private string connectionString = "server=localhost;uid=root;database=dummy_db_account;password=;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public bool ExecuteQuery(string query, Action<MySqlCommand> parameterize = null)
        {
            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        parameterize?.Invoke(cmd);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Database Error: " + ex.Message);
                    return false;
                }
            }
        }

        public object ExecuteScalar(string query, Action<MySqlCommand> parameterize = null)
        {
            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        parameterize?.Invoke(cmd);
                        return cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Database Error: " + ex.Message);
                    return null;
                }
            }
        }
    }
}