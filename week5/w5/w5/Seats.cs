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
    public partial class Seats : Form
    {
        public string koneksi = "Server=localhost; Database=pv_t5_224117124; UserID=root; Password=;";
        MySqlConnection conn;
        private string studioName;
        private string movieYgMain;
        private decimal studioPrice;
        public Seats(string namaStudio, string movieYgPlaying, decimal hargaStudio)
        {
            InitializeComponent();

            conn = new MySqlConnection(koneksi);

            studioName = namaStudio;
            movieYgMain = movieYgPlaying;
            studioPrice = hargaStudio;

            label2.Text = namaStudio;
            label5.Text = hargaStudio.ToString();
            label7.Text = movieYgPlaying;

            loadSeatDrDatabase();
        }

        public void loadSeatDrDatabase()
        {
            try
            {
                conn.Open();

                string query = "SELECT seat1, seat2, seat3, seat4, seat5 FROM studio WHERE studioName = @name";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", studioName);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        bool isBooked = Convert.ToBoolean(reader["seat" + i]);
                        Button btn = this.Controls.Find("button" + i, true).FirstOrDefault() as Button;

                        if (btn != null)
                        {
                            btn.BackColor = isBooked ? Color.Red : System.Drawing.SystemColors.Control;
                            btn.Enabled = !isBooked;
                        }
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //close
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // fisinshhh movehh
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string querySelect = "SELECT seat1, seat2, seat3, seat4, seat5 FROM studio WHERE studioName = @name";
                MySqlCommand cmdSelect = new MySqlCommand(querySelect, conn);
                cmdSelect.Parameters.AddWithValue("@name", studioName);

                MySqlDataReader reader = cmdSelect.ExecuteReader();
                int seatsUsed = 0;

                if (reader.Read())
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        if (Convert.ToBoolean(reader["seat" + i]))
                        {
                            seatsUsed++;
                        }
                    }
                }

                reader.Close();

                decimal totalPendapatan = seatsUsed * studioPrice;

                string queryReset = "UPDATE studio SET seat1 = 0, seat2 = 0, seat3 = 0, seat4 = 0, seat5 = 0 WHERE studioName = @name";
                MySqlCommand cmdReset = new MySqlCommand(queryReset, conn);
                cmdReset.Parameters.AddWithValue("@name", studioName);
                cmdReset.ExecuteNonQuery();


                MessageBox.Show(
                    $"Movie selesai.\nKursi terpakai : {seatsUsed}\nTotal pendapatan: Rp {totalPendapatan:N0}",
                    "Finish Movie",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                loadSeatDrDatabase();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat menyelesaikan movie: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
