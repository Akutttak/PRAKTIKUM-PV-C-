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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace w5
{
    public partial class login : Form
    {
        public string koneksi = "Server=localhost;Database=pv_t5_224117124;UserID=root;Password=;";
        MySqlConnection conn;
        public login()
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //button register
            this.Hide();
            register formRegis = new register();
            formRegis.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //button login
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Masukkan Username dan Password!");
                return;
            }

            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                string kueri = "SELECT userId, nama, username, role, balance FROM user WHERE username=@username AND password=@password";
                MySqlCommand cmd = new MySqlCommand(kueri, conn);

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                MessageBox.Show($"username ; {username} | password: {password}");


                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    MessageBox.Show("yuhuuu reader e masukkk");
                    string roleUser = reader.GetString("role");
                    string usernameLoggedIn = textBox1.Text;
                    string userId = reader["userId"].ToString();
                    reader.Close();

                    MessageBox.Show("berhaisl loginn");

                    if (roleUser.ToLower() == "admin")
                    {
                        this.Hide();
                        Form1 formAdmin = new Form1(usernameLoggedIn);
                        formAdmin.ShowDialog();
                    }
                    else
                    {
                        this.Hide();
                        formUser formUsahh = new formUser(userId, usernameLoggedIn);
                        formUsahh.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("usn or pass wrong");
                }
                reader.Close();
                conn.Close();
            } catch (Exception ex)
            {
                MessageBox.Show("Error saat login: " + ex.Message);
            }
        }
    }
}
