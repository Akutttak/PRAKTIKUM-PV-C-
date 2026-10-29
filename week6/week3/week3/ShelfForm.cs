using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace week3
{
    public partial class ShelfForm : Form
    {
        private User player;
        private int shelfId;
        private int warungId;
        private string connectionString = "Server=localhost;Database=pv_t6_224117124;UserID=root;Password=;";
        private Dictionary<string, int> basePrices = new Dictionary<string, int>
        {
            { "Oak", 50 },
            { "Mahogany", 120 },
            { "Mystic", 250 }
        };

        public ShelfForm(User player, int shelfId)
        {
            InitializeComponent();
            this.player = player;
            this.shelfId = shelfId;

            this.Load += ShelfForm_Load;
            comboJenis.SelectedIndexChanged += ComboJenis_SelectedIndexChanged;
            numericJumlah.ValueChanged += (s, e) => UpdateOKButton();
            btnOK.Click += BtnOK_Click;
            btnCancel.Click += (s, e) => this.Close();
        }

        private void ShelfForm_Load(object sender, EventArgs e)
        {
            comboJenis.Items.AddRange(new string[] { "Oak", "Mahogany", "Mystic" });
            comboJenis.SelectedIndex = 0;
            LoadWarungId();
        }

        private void LoadWarungId()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id FROM warung_user WHERE user_id = @user_id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user_id", player.Id);

                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        warungId = Convert.ToInt32(result);
                    else
                        MessageBox.Show("Warung tidak ditemukan untuk player ini.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat ID warung: " + ex.Message);
            }
        }

        private void ComboJenis_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedWood = comboJenis.SelectedItem.ToString();
            int playerStock = 0;

            // 🔹 Ambil stok dari tabel log_inventory
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT jumlah FROM log_inventory WHERE user_id = @user AND nama_kayu = @kayu";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", player.Id);
                    cmd.Parameters.AddWithValue("@kayu", selectedWood);

                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        playerStock = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat stok dari database: " + ex.Message);
            }

            //MessageBox.Show("playercountL " + playerStock);
            label4.Text = $"INVENTORY E ADA: {playerStock}";

            // 🔹 Atur maksimum jumlah yang bisa diisi
            numericJumlah.Maximum = playerStock;

            // 🔹 Hitung harga maksimum dari basePrices
            int maxPrice = basePrices[selectedWood] * 2;

            // 🔹 Atur batas maksimum harga numeric dan label harga maksimum (Label5)
            numericHarga.Maximum = maxPrice;
            label5.Text = $"Harga maksimum: {maxPrice}";

            UpdateOKButton();
        }



        private void UpdateOKButton()
        {
            btnOK.Enabled = numericJumlah.Value > 0;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            string woodType = comboJenis.SelectedItem.ToString();
            int quantity = (int)numericJumlah.Value;
            int price = (int)numericHarga.Value;

            // 1. Kurangi stok dari player
            switch (woodType)
            {
                case "Oak": player.ownedOak -= quantity; break;
                case "Mahogany": player.ownedMahogany -= quantity; break;
                case "Mystic": player.ownedMystic -= quantity; break;
            }

            // 2. Simpan ke tabel warung_inventory
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO warung_inventory (warung_id, shelf_id, wood_name, price, stock)
                        VALUES (@wid, @shelf, @wood, @price, @stock)
                        ON DUPLICATE KEY UPDATE 
                            wood_name = @wood,
                            price = @price,
                            stock = stock + @stock";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@wid", warungId);
                    cmd.Parameters.AddWithValue("@shelf", shelfId);
                    cmd.Parameters.AddWithValue("@wood", woodType);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@stock", quantity);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"{quantity} {woodType} log(s) ditempatkan di rak!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memperbarui rak: " + ex.Message);
                // rollback stok player jika gagal
                switch (woodType)
                {
                    case "Oak": player.ownedOak += quantity; break;
                    case "Mahogany": player.ownedMahogany += quantity; break;
                    case "Mystic": player.ownedMystic += quantity; break;
                }
            }
        }
    }
}
