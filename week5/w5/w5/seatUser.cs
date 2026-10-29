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
    public partial class seatUser : Form
    {
        public string koneksi = "Server=localhost; Database=pv_t5_224117124; UserID=root; Password=;";
        MySqlConnection conn;
        private string studioName;
        private string movieYgMain;
        private decimal studioPrice;
        private string userId;
        List<int> selectedSeats = new List<int>();
        public seatUser(string namaStudio, string movieYgPlaying, decimal hargaStudio, string idUser)
        {
            InitializeComponent();

            conn = new MySqlConnection(koneksi);

            studioName = namaStudio;
            movieYgMain = movieYgPlaying;
            studioPrice = hargaStudio;
            userId = idUser;

            label2.Text = namaStudio;
            label5.Text = hargaStudio.ToString();
            label7.Text = movieYgPlaying;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("masuk btn 1 clicke");
            if (button1.BackColor == Color.MidnightBlue)
            {
                //MessageBox.Show("masukk backcolor control");
                button1.BackColor = Color.Yellow;
                selectedSeats.Add(1);
            }
            else if (button1.BackColor == Color.Yellow)
            {
                //MessageBox.Show("masuk back color yeloo");
                button1.BackColor = System.Drawing.SystemColors.Control;
                selectedSeats.Remove(1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("masuk btn 1 clicke");
            if (button2.BackColor == Color.MidnightBlue)
            {
                //MessageBox.Show("masukk backcolor control");
                button2.BackColor = Color.Yellow;
                selectedSeats.Add(1);
            }
            else if (button2.BackColor == Color.Yellow)
            {
                //MessageBox.Show("masuk back color yeloo");
                button2.BackColor = System.Drawing.SystemColors.Control;
                selectedSeats.Remove(1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.MidnightBlue)
            {
                //MessageBox.Show("masukk backcolor control");
                button3.BackColor = Color.Yellow;
                selectedSeats.Add(1);
            }
            else if (button3.BackColor == Color.Yellow)
            {
                //MessageBox.Show("masuk back color yeloo");
                button2.BackColor = System.Drawing.SystemColors.Control;
                selectedSeats.Remove(1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.MidnightBlue)
            {
                //MessageBox.Show("masukk backcolor control");
                button4.BackColor = Color.Yellow;
                selectedSeats.Add(1);
            }
            else if (button4.BackColor == Color.Yellow)
            {
                //MessageBox.Show("masuk back color yeloo");
                button4.BackColor = System.Drawing.SystemColors.Control;
                selectedSeats.Remove(1);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.MidnightBlue)
            {
                //MessageBox.Show("masukk backcolor control");
                button5.BackColor = Color.Yellow;
                selectedSeats.Add(1);
            }
            else if (button5.BackColor == Color.Yellow)
            {
                //MessageBox.Show("masuk back color yeloo");
                button5.BackColor = System.Drawing.SystemColors.Control;
                selectedSeats.Remove(1);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (selectedSeats.Count == 0)
            {
                MessageBox.Show("Pilih kursi terlebih dahulu!");
                return;
            }

            decimal totalHarga = studioPrice * selectedSeats.Count;
            decimal saldoUser = 0;

            try
            {
                conn.Open();

                int realUserId = -1;
                string qGetId = "SELECT userId FROM `user` WHERE username = @username";
                MySqlCommand cmdGetId = new MySqlCommand(qGetId, conn);
                cmdGetId.Parameters.AddWithValue("@username", userId);

                using (MySqlDataReader reader = cmdGetId.ExecuteReader())
                {
                    if (reader.Read())
                        realUserId = reader.GetInt32("userId");
                }

                if (realUserId == -1)
                {
                    MessageBox.Show("User tidak ditemukan!");
                    return;
                }

                string qSaldo = "SELECT balance FROM `user` WHERE userId = @id";
                MySqlCommand cmdSaldo = new MySqlCommand(qSaldo, conn);
                cmdSaldo.Parameters.AddWithValue("@id", realUserId);
                saldoUser = Convert.ToDecimal(cmdSaldo.ExecuteScalar() ?? 0);

                MessageBox.Show($"Saldo user: {saldoUser}");

                if (saldoUser < totalHarga)
                {
                    MessageBox.Show($"Saldo tidak cukup! Total: Rp {totalHarga}");
                    return;
                }

                int totalUpdated = 0;
                foreach (int seat in selectedSeats)
                {
                    string colName = "seat" + seat;
                    string qUpdate = $"UPDATE studio SET {colName} = 1 WHERE studioName = @studio AND {colName} = 0";
                    MessageBox.Show(qUpdate);
                    MySqlCommand cmdUpdate = new MySqlCommand(qUpdate, conn);
                    cmdUpdate.Parameters.AddWithValue("@studio", studioName);
                    int result = cmdUpdate.ExecuteNonQuery();

                    if (result > 0)
                    {
                        totalUpdated++;
                    }
                    else
                    {
                        MessageBox.Show($"Seat {seat} gagal di-book (mungkin sudah terisi).");
                    }
                }

                if (totalUpdated > 0)
                {
                    decimal hargaBayar = studioPrice * totalUpdated;

                    string qKurangSaldo = "UPDATE `user` SET balance = balance - @harga WHERE userId = @id";
                    MySqlCommand cmdKurangSaldo = new MySqlCommand(qKurangSaldo, conn);
                    cmdKurangSaldo.Parameters.AddWithValue("@harga", hargaBayar);
                    cmdKurangSaldo.Parameters.AddWithValue("@id", realUserId);
                    cmdKurangSaldo.ExecuteNonQuery();

                    MessageBox.Show($"Booking berhasil! Dibayar: Rp {hargaBayar}");
                }
                else
                {
                    MessageBox.Show("Tidak ada kursi yang berhasil di-book. Saldo tidak dikurangi.");
                    return;
                }

                foreach (int seat in selectedSeats)
                {
                    switch (seat)
                    {
                        case 1: button1.BackColor = Color.Green; break;
                        case 2: button2.BackColor = Color.Green; break;
                        case 3: button3.BackColor = Color.Green; break;
                        case 4: button4.BackColor = Color.Green; break;
                        case 5: button5.BackColor = Color.Green; break;
                    }
                }

                selectedSeats.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat booking: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
