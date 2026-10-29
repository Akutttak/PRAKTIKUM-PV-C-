using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace week3
{
    public partial class inventory : Form
    {
        private User currentUser;
        private Dictionary<string, int> kayuInventory = new Dictionary<string, int>();

        public inventory(User user)
        {
            InitializeComponent();
            currentUser = user ?? new User();
            LoadInventory();
            UpdateKayuLabels();
            UpdateUserInfo();

            // Tambahkan event handler radio button
            radioButtonStoneAxe.CheckedChanged += Radio_CheckedChanged;
            radioButtonIron.CheckedChanged += Radio_CheckedChanged;
            radioButtonDiamond.CheckedChanged += Radio_CheckedChanged;

            radioButtonDiamond.Tag = "Diamond Axe";
            radioButtonIron.Tag = "Iron Axe";
            radioButtonStoneAxe.Tag = "Stone Axe";
        }

        // =====================================
        // 🔹 Load inventory dari database
        // =====================================
        private void LoadInventory()
        {
            string query = "SELECT nama_axe, aktif FROM axe_inventory WHERE user_id = @user";
            var dt = DatabaseHelper.ExecuteQuery(query, new Dictionary<string, object> { { "@user", currentUser.Id } });

            bool hasWooden = true; // Wooden selalu tersedia
            bool hasStone = false;
            bool hasIron = false;
            bool hasDiamond = false;
            string axeAktif = "Wooden Axe";

            foreach (DataRow row in dt.Rows)
            {
                string namaAxe = row["nama_axe"].ToString();
                int aktif = Convert.ToInt32(row["aktif"]);

                if (namaAxe == "Iron Axe")
                    hasIron = true;
                else if (namaAxe == "Diamond Axe")
                    hasDiamond = true;

                if (aktif == 1)
                    axeAktif = namaAxe;
            }

            // Enable sesuai kepemilikan
            radioButtonStoneAxe.Enabled = hasStone;
            radioButtonIron.Enabled = hasIron;
            radioButtonDiamond.Enabled = hasDiamond;

            // Pilih radio sesuai yang aktif
            if (axeAktif == "Stone Axe") radioButtonStoneAxe.Checked = true;
            else if (axeAktif == "Iron Axe") radioButtonIron.Checked = true;
            else if (axeAktif == "Diamond Axe") radioButtonDiamond.Checked = true;

            MessageBox.Show($"Loaded: Iron={hasIron}, Diamond={hasDiamond}, Aktif={axeAktif}");
        }


        // =====================================
        // 🔹 Tambah kayu dan update database
        // =====================================
        public void TambahKayu(string namaKayu, int jumlah)
        {
            if (kayuInventory.ContainsKey(namaKayu))
                kayuInventory[namaKayu] += jumlah;
            else
                kayuInventory[namaKayu] = jumlah;

            string cekQuery = "SELECT COUNT(*) FROM log_inventory WHERE user_id = @user AND nama_kayu = @nama";
            var dt = DatabaseHelper.ExecuteQuery(cekQuery, new Dictionary<string, object>
            {
                {"@user", currentUser.Id},
                {"@nama", namaKayu}
            });

            bool ada = Convert.ToInt32(dt.Rows[0][0]) > 0;

            if (ada)
            {
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE log_inventory SET jumlah = @jumlah WHERE user_id = @user AND nama_kayu = @nama",
                    new Dictionary<string, object>
                    {
                        {"@jumlah", kayuInventory[namaKayu]},
                        {"@user", currentUser.Id},
                        {"@nama", namaKayu}
                    });
            }
            else
            {
                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO log_inventory (user_id, nama_kayu, jumlah) VALUES (@user, @nama, @jumlah)",
                    new Dictionary<string, object>
                    {
                        {"@user", currentUser.Id},
                        {"@nama", namaKayu},
                        {"@jumlah", kayuInventory[namaKayu]}
                    });
            }

            UpdateKayuLabels();
        }

        // =====================================
        // 🔹 Update label kayu
        // =====================================
        private void UpdateKayuLabels()
        {
            labelOak.Text = "Oak: " + GetJumlah("Oak");
            labelMahogany.Text = "Mahogany: " + GetJumlah("Mahogany");
            labelMystic.Text = "Mystic: " + GetJumlah("Mystic");
        }

        private int GetJumlah(string namaKayu)
        {
            return kayuInventory.ContainsKey(namaKayu) ? kayuInventory[namaKayu] : 0;
        }

        // =====================================
        // 🔹 Update info user
        // =====================================
        private void UpdateUserInfo()
        {
            currentUser.LoadFromDatabase();
            labelUang.Text = $"Saldo: {currentUser.Uang}G";
            label1.Text = $"User: {currentUser.Username}\nUang: {currentUser.Uang}\nKapak Aktif: {currentUser.ActiveAxeName}";
            //labelActiveAxe.Text = $"Kapak Aktif: {currentUser.ActiveAxe}";
        }

        // =====================================
        // 🔹 Event radio button (auto equip)
        // =====================================
        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender is RadioButton rb) || !rb.Checked)
                return;

            string selectedAxe = rb.Tag?.ToString();

            if (!string.IsNullOrEmpty(selectedAxe))
            {
                currentUser.EquipAxe(selectedAxe);
                MessageBox.Show($"Kapak {selectedAxe} berhasil diaktifkan!",
                                "Equip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateUserInfo();
            }
        }

        private void inventory_Load(object sender, EventArgs e)
        {
            UpdateKayuLabels();
            UpdateUserInfo();

            // Atur radio button yang aktif sesuai data di database
            string axeAktif = currentUser.ActiveAxe;
            if (axeAktif == "Stone Axe") radioButtonStoneAxe.Checked = true;
            else if (axeAktif == "Iron Axe") radioButtonIron.Checked = true;
            else if (axeAktif == "Diamond Axe") radioButtonDiamond.Checked = true;
        }
    }
}
