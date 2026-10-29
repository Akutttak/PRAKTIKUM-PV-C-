using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace w5
{
    public partial class topup : Form
    {
        public string koneksi = "Server=localhost; Database=pv_t5_224117124; UserID=root; Password=;";
        MySqlConnection conn;
        private string currentUserId;
        private string currentUsername;
        public topup(string userId, string username)
        {
            InitializeComponent();
            conn = new MySqlConnection(koneksi);
            currentUserId = userId;
            currentUsername = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal uang = numericUpDown1.Value;

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (uang <= 50000)
                {
                    MessageBox.Show("topup minim 50k lah bwang");
                    return;
                }
                if (uang == 0)
                {
                    MessageBox.Show("input yg valid dong");
                    return;
                }

                string query = "UPDATE user SET balance = balance + @balance WHERE userId = @userId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", currentUserId);
                cmd.Parameters.AddWithValue("@balance", uang);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("top up berhasil yorobunh");
                }
                else
                {
                    MessageBox.Show("Failed to topup");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            formUser formUserBaru = new formUser(currentUserId, currentUsername);
            formUserBaru.Show();
        }
    }
}
