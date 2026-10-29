using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace week3
{
    public partial class shop : Form
    {
        private User currentUser;
        public int price_oak = 50;
        public int price_mahogany = 120;
        public int price_mystic = 250;

        public shop(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void shop_Load(object sender, EventArgs e)
        {
            UpdateShopDisplay();
        }

        // 🔹 Ambil jumlah log dari database
        private int GetJumlahLog(string namaKayu)
        {
            string query = "SELECT jumlah FROM log_inventory WHERE user_id = @user_id AND nama_kayu = @nama";
            object result = DatabaseHelper.ExecuteScalar(query, new Dictionary<string, object>
            {
                {"@user_id", currentUser.Id},
                {"@nama", namaKayu}
            });

            return result != null ? Convert.ToInt32(result) : 0;
        }

        // 🔹 Ambil kapak aktif dari database
        private string GetActiveAxeName()
        {
            string query = "SELECT nama_axe FROM axe_inventory WHERE user_id = @user_id AND aktif = 1 LIMIT 1";
            object result = DatabaseHelper.ExecuteScalar(query, new Dictionary<string, object>
            {
                {"@user_id", currentUser.Id}
            });

            return result?.ToString() ?? "Belum ada kapak aktif";
        }

        // 🔹 Ambil daftar kapak yang dimiliki user
        private string GetOwnedAxes()
        {
            string query = "SELECT nama_axe FROM axe_inventory WHERE user_id = @user_id";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new Dictionary<string, object>
            {
                {"@user_id", currentUser.Id}
            });

            if (dt.Rows.Count == 0) return "Belum punya kapak";

            List<string> axes = new List<string>();
            foreach (DataRow row in dt.Rows)
                axes.Add(row["nama_axe"].ToString());

            return string.Join(", ", axes);
        }

        // 🔹 Update tampilan UI
        private void UpdateShopDisplay()
        {
            labelUang.Text = $"Uang: {currentUser.Uang}";
            labelOak.Text = $"Oak: {GetJumlahLog("oak")} (Rp {price_oak}/log)";
            labelMahogany.Text = $"Mahogany: {GetJumlahLog("mahogany")} (Rp {price_mahogany}/log)";
            labelMystic.Text = $"Mystic: {GetJumlahLog("mystic")} (Rp {price_mystic}/log)";

            labelOwn.Text = $"Owned: {GetOwnedAxes()}";
            labelEquipped.Text = $"Equipped: {GetActiveAxeName()}";
        }

        // 🔹 Menjual log
        private void SellLog(string namaKayu, int hargaPerLog)
        {
            int jumlah = GetJumlahLog(namaKayu);
            if (jumlah <= 0)
            {
                MessageBox.Show($"Kamu tidak punya {namaKayu} log!", "Info");
                return;
            }

            int jumlahJual = 1;
            int totalHarga = jumlahJual * hargaPerLog;
            currentUser.Uang += totalHarga;

            DatabaseHelper.ExecuteNonQuery(
                "UPDATE log_inventory SET jumlah = jumlah - @jumlah WHERE user_id = @user_id AND nama_kayu = @nama",
                new Dictionary<string, object>
                {
                    {"@jumlah", jumlahJual},
                    {"@user_id", currentUser.Id},
                    {"@nama", namaKayu}
                });

            MessageBox.Show($"Berhasil menjual {jumlahJual} {namaKayu} log seharga Rp {totalHarga}!", "Berhasil");

            UpdateShopDisplay();
        }

        // 🔹 Menjual semua log
        private void buttonSellAll_Click(object sender, EventArgs e)
        {
            string[] kayuList = { "oak", "mahogany", "mystic" };
            int[] hargaList = { price_oak, price_mahogany, price_mystic };

            int totalLogsSold = 0;
            int totalUang = 0;

            for (int i = 0; i < kayuList.Length; i++)
            {
                int jumlah = GetJumlahLog(kayuList[i]);
                if (jumlah > 0)
                {
                    int uangDidapat = jumlah * hargaList[i];
                    totalLogsSold += jumlah;
                    totalUang += uangDidapat;

                    DatabaseHelper.ExecuteNonQuery(
                        "UPDATE log_inventory SET jumlah = 0 WHERE user_id = @user_id AND nama_kayu = @nama",
                        new Dictionary<string, object>
                        {
                            {"@user_id", currentUser.Id},
                            {"@nama", kayuList[i]}
                        });
                }
            }

            if (totalLogsSold > 0)
            {
                currentUser.Uang += totalUang;
                MessageBox.Show($"Berhasil menjual {totalLogsSold} log! Kamu mendapatkan Rp {totalUang}!", "Berhasil");
            }
            else
            {
                MessageBox.Show("Kamu tidak punya log untuk dijual.", "Info");
            }

            UpdateShopDisplay();
        }

        // 🔹 Membeli kapak
        private void BuyAxe(string nama, int harga, string type)
        {
            if (currentUser.Uang < harga)
            {
                MessageBox.Show("Uangmu tidak cukup!", "Gagal");
                return;
            }

            string queryCek = "SELECT COUNT(*) FROM axe_inventory WHERE user_id = @user_id AND nama_axe = @nama";
            int sudahPunya = Convert.ToInt32(DatabaseHelper.ExecuteScalar(queryCek, new Dictionary<string, object>
            {
                {"@user_id", currentUser.Id},
                {"@nama", nama}
            }));

            if (sudahPunya > 0)
            {
                MessageBox.Show($"Kamu sudah punya {nama}!", "Info");
                return;
            }

            DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO axe_inventory (user_id, nama_axe, harga, tipe, aktif) VALUES (@user_id, @nama, @harga, @tipe, 0)",
                new Dictionary<string, object>
                {
                    {"@user_id", currentUser.Id},
                    {"@nama", nama},
                    {"@harga", harga},
                    {"@tipe", type}
                });

            currentUser.Uang -= harga;

            MessageBox.Show($"Kamu membeli {nama} seharga Rp {harga}!", "Berhasil");
            UpdateShopDisplay();
        }

        // Tombol event
        private void buttonBuyIron_Click(object sender, EventArgs e)
        {
            BuyAxe("Iron Axe", 1500, "Iron");
        }

        private void buttonBuyDiamond_Click(object sender, EventArgs e)
        {
            BuyAxe("Diamond Axe", 3000, "Diamond");
        }

        private void buttonSellOak_Click_1(object sender, EventArgs e)
        {
            SellLog("oak", price_oak);
        }

        private void buttonSellMahgony_Click(object sender, EventArgs e)
        {
            SellLog("mahogany", price_mahogany);
        }

        private void buttonSellMystic_Click_1(object sender, EventArgs e)
        {
            SellLog("mystic", price_mystic);
        }

    }
}
