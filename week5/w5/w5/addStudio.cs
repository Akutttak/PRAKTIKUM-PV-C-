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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace w5
{
    public partial class addStudio : Form
    {
        public string koneksi = "Server=localhost; Database=pv_t5_224117124; UserID=root; Password=;";
        MySqlConnection conn;
        public addStudio()
        {
            InitializeComponent();
            conn = new MySqlConnection(koneksi);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studioName = textBox1.Text.Trim();
            decimal price = numericUpDown1.Value;

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                if (string.IsNullOrEmpty(studioName) || price <= 0)
                {
                    MessageBox.Show("Masukkan inputan yang valid!");
                    return;
                }

                if (price < 20000)
                {
                    MessageBox.Show("Minimal harga studio adalah 20.000!");
                    return;
                }

                // 🔹 Cek apakah nama studio sudah ada
                string checkQuery = "SELECT COUNT(*) FROM studio WHERE studioName = @studioName";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@studioName", studioName);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("Nama studio sudah ada! Gunakan nama lain.");
                    return;
                }

                // 🔹 Jika belum ada, baru INSERT
                string query = "INSERT INTO studio (studioName, basePrice) VALUES (@studioName, @basePrice)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@studioName", studioName);
                cmd.Parameters.AddWithValue("@basePrice", price);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Studio baru berhasil ditambahkan!");
                }
                else
                {
                    MessageBox.Show("Gagal menambahkan studio.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
