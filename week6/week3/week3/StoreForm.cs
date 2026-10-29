using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace week3
{
    public partial class StoreForm : Form
    {
        private User player;
        private int storeLevel;
        private string connectionString = "Server=localhost;Database=pv_t6_224117124;UserID=root;Password=;";
        private Dictionary<int, int> upgradeCosts = new Dictionary<int, int>
        {
            { 2, 750 },
            { 3, 2000 }
        };

        public StoreForm(User player)
        {
            InitializeComponent();
            this.player = player;

            // Event handler tombol
            this.Load += StoreForm_Load;
            btnSet1.Click += (s, e) => OpenShelfForm(1);
            btnSet2.Click += (s, e) => OpenShelfForm(2);
            btnSet3.Click += (s, e) => OpenShelfForm(3);
            btnUpgrade.Click += BtnUpgrade_Click;
            btnClose.Click += (s, e) => this.Close();
        }

        private void StoreForm_Load(object sender, EventArgs e)
        {
            LoadStoreLevel();
            UpdateUI();
        }

        // ==============================================================
        //  🔹 LOAD LEVEL WARUNG DARI TABEL warung_user
        // ==============================================================
        private void LoadStoreLevel()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT level_warung FROM warung_user WHERE user_id = @user";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", player.Id);

                    var result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                        storeLevel = Convert.ToInt32(result);
                    else
                    {
                        // kalau user belum punya data warung, buat baru
                        storeLevel = 1;
                        string insert = "INSERT INTO warung_user (user_id, nama_warung, sudah_beli, level_warung) VALUES (@user, 'Warung Kayu', 1, 1)";
                        MySqlCommand insertCmd = new MySqlCommand(insert, conn);
                        insertCmd.Parameters.AddWithValue("@user", player.Id);
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading warung: " + ex.Message);
                storeLevel = 1;
            }
        }

        // ==============================================================
        //  🔹 UPDATE TAMPILAN UI
        // ==============================================================
        private void UpdateUI()
        {
            lblSaldo.Text = $"Rp {player.Uang}";
            lblLevel.Text = $"Level {storeLevel}";

            gbShelf1.Enabled = true;
            gbShelf2.Enabled = storeLevel >= 2;
            gbShelf3.Enabled = storeLevel >= 3;

            if (storeLevel < 3)
            {
                btnUpgrade.Enabled = true;
                btnUpgrade.Text = $"Upgrade ke Level {storeLevel + 1} (Rp {upgradeCosts[storeLevel + 1]})";
            }
            else
            {
                btnUpgrade.Enabled = false;
                btnUpgrade.Text = "Maksimal Level";
            }

            LoadShelfData(gbShelf1, 1);
            LoadShelfData(gbShelf2, 2);
            LoadShelfData(gbShelf3, 3);
        }

        // ==============================================================
        //  🔹 LOAD ISI RAK (contoh dari tabel log_inventory milik user)
        // ==============================================================
        private void LoadShelfData(GroupBox gb, int shelfId)
        {
            // Hapus semua label lama agar tidak menumpuk
            var oldLabels = gb.Controls.OfType<Label>().Where(l => l.Name == "lblShelfData").ToList();
            foreach (var l in oldLabels)
            {
                gb.Controls.Remove(l);
                l.Dispose();
            }

            // Buat label baru
            Label lblShelfData = new Label
            {
                Name = "lblShelfData",
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.Black,
                Location = new Point(15, 30)
            };

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT wood_name, price, stock 
                FROM warung_inventory wi
                JOIN warung_user wu ON wi.warung_id = wu.id
                WHERE wu.user_id = @user AND shelf_id = @shelf AND stock > 0"; // hanya ambil yang stock > 0

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", player.Id);
                    cmd.Parameters.AddWithValue("@shelf", shelfId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        var shelfText = new System.Text.StringBuilder();
                        bool adaBarang = false;

                        while (reader.Read())
                        {
                            adaBarang = true;
                            string wood = reader.GetString("wood_name");
                            int price = reader.GetInt32("price");
                            int stock = reader.GetInt32("stock");

                            shelfText.AppendLine($"Barang: {wood}, Harga: {price}, Stok: {stock}");
                        }

                        lblShelfData.Text = adaBarang ? shelfText.ToString() : "Rak Kosong";
                    }
                }
            }
            catch (Exception ex)
            {
                lblShelfData.Text = "Gagal memuat data rak.";
                MessageBox.Show($"Error rak {shelfId}: {ex.Message}");
            }

            gb.Controls.Add(lblShelfData);
            lblShelfData.BringToFront();
        }




        // ==============================================================
        //  🔹 TOMBOL UPGRADE WARUNG
        // ==============================================================
        private void BtnUpgrade_Click(object sender, EventArgs e)
        {
            int nextLevel = storeLevel + 1;
            if (nextLevel > 3) return;

            int cost = upgradeCosts[nextLevel];

            if (player.Uang >= cost)
            {
                player.Uang -= cost;
                player.SaveProgress(); // simpan uang user ke DB
                storeLevel = nextLevel;

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "UPDATE warung_user SET level_warung = @level WHERE user_id = @user";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@level", storeLevel);
                        cmd.Parameters.AddWithValue("@user", player.Id);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Warung berhasil di-upgrade ke Level {storeLevel}!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menyimpan upgrade: " + ex.Message);
                }

                UpdateUI();
            }
            else
            {
                MessageBox.Show("Uang tidak cukup untuk upgrade!");
            }
        }

        private void OpenShelfForm(int shelfId)
        {
            using (ShelfForm shelfForm = new ShelfForm(player, shelfId))
            {
                shelfForm.ShowDialog();
                UpdateUI();
            }
        }

    }
}
