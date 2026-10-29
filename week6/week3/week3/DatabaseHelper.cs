using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week3
{
    public static class DatabaseHelper
    {
        private static string connectionString = "Server=localhost;Database=pv_t6_224117124;Uid=root;Pwd=;";
        public static void ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MessageBox.Show("aloha koneksinya masuk i think");
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var p in parameters)
                            cmd.Parameters.AddWithValue(p.Key, p.Value);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MessageBox.Show("aloha koneksinya masuk i think");
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var p in parameters)
                            cmd.Parameters.AddWithValue(p.Key, p.Value);
                    }

                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public static object ExecuteScalar(string query, Dictionary<string, object> parameters = null)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MessageBox.Show("aloha koneksinya masuk i think");
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }

                    return cmd.ExecuteScalar();
                }
            }
        }

        public static bool TestConnection()
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Koneksi gagal: " + ex.Message);
                return false;
            }
        }
    }
}
