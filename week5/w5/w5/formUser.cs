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
    public partial class formUser : Form
    {
        public string koneksi = "Server=localhost; Database=pv_t5_224117124; UserID=root; Password=;";
        MySqlConnection conn;
        public int selected = -1;
        private string currentUser;
        private string currentUserId;
        private string currentName;


        public formUser(string userId, string username)
        {
            InitializeComponent();
            connectDatabase();
            currentUser = username;
            currentName = getNameFromUsername(username); // 🔹 ambil nama dari DB

            label1.Text = $"WELKAMMM, {currentName}!";
            currentUser = username;
            currentUserId = userId;

            string saldo = getBalanceFromUserId(currentUserId);
            label2.Text = $"Balance : Rp {saldo}";
            refreshDGV();

            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.Name = "Seat";
            btnColumn.HeaderText = "Seats";
            btnColumn.Text = "See Seats";
            btnColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnColumn);

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
        public void refreshDGV()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string query = "SELECT m.movieId, m.title, m.genre, m.duration, s.studioId, s.studioName, s.basePrice\r\nFROM movie m\r\nJOIN studio s ON s.studioId=m.studioId;";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void formUser_Load(object sender, EventArgs e)
        {
            
        }

        public string getNameFromUsername(string username)
        {
            string name = "";

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string query = "SELECT nama FROM user WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    name = result.ToString();
                }
                else
                {
                    name = username; // fallback kalau tidak ada nama
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error mengambil nama: " + ex.Message + "\n\n" + ex.StackTrace);
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return name;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            login formLogin = new login();
            formLogin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TOP UP JIEN
            topup formTopup = new topup(currentUserId, currentUser);
            formTopup.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string namaStudio = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            decimal hargaStudio = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[7].Value);
            string movieYgPlaying = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Seats" && e.RowIndex >= 0)
            {
                seatUser formSeatUsah = new seatUser(namaStudio, movieYgPlaying, hargaStudio, currentUser);
                formSeatUsah.ShowDialog();
            }
            string newBalance = getBalanceFromUserId(currentUserId);
            label2.Text = $"Balance : Rp {newBalance}";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string keyword = textBox1.Text.Trim();

                string query = @"SELECT m.movieId, m.title, m.genre, m.duration, 
                                s.studioId, s.studioName, s.basePrice
                         FROM movie m
                         JOIN studio s ON s.studioId = m.studioId
                         WHERE m.title LIKE @keyword;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat mencari: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public string getBalanceFromUserId(string userId)
        {
            string balance = "0";

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string query = "SELECT balance FROM user WHERE userId = @userId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    balance = result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error mengambil saldo: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return balance;
        }


    }
}
