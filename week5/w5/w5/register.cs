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
    public partial class register : Form
    {
        public string koneksi = "Server=localhost; Database=pv_t5_224117124; UserID=root; Password=;";
        MySqlConnection conn;
        public register()
        {
            InitializeComponent();
            connectDatabase();
            
        }
        public void connectDatabase()
        {
            conn = new MySqlConnection(koneksi);

            try
            {
                conn.Open();
                conn.Close();
                MessageBox.Show("database connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (name == "" || password == "" || username == "")
            {
                MessageBox.Show("masukkan inputan yang valid!");
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("passs length < 6 kenot");
                return;
            }
            try
            {
                if(conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                string checkQuery = "SELECT COUNT(username) FROM user WHERE username = @username";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@username", username);

                int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (userCount > 0)
                {
                    MessageBox.Show("Username sudah terdaftar (Unique)! Silakan gunakan username lain.");
                    return;
                }

                string query = "INSERT INTO user (nama, username, password, role, balance) VALUES (@nama, @username, @password, @role, @balance)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama", name);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@role", "user");
                cmd.Parameters.AddWithValue("@balance", 0.00);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Data inserted successfully");
                    //refreshDGV();
                    clear();
                }
                else
                {
                    MessageBox.Show("Failed to insert data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            login formLogin = new login();
            formLogin.ShowDialog();
        }
    }
}
