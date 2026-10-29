using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace w4
{
    public partial class loginRegis : Form
    {
        public DataSet ds;
        public DataTable dt;
        public DataSet dataPijah;
        public DataTable tablePijah;
        public int counter = 1;
        public Form1 formAdmin;
        public loginRegis()
        {
            InitializeComponent();


            ds = new User();
            dt = ds.Tables["User"];

            dataPijah = new Pijah();
            formAdmin = new Form1(dataPijah);
            

            //custome date buat dummy
            DateTime customeTanggalBuatPeperoni = new DateTime(2024, 1, 10);
            DateTime customeTanggalBuatTunaMayoh = new DateTime(2024, 5, 18);
            DateTime customeTanggalBuatBeef = new DateTime(2023, 2, 11);
            //inih dummy data e ke table pitsah
            addDataToPitsahTable("peperoniPeperonii", "pan", customeTanggalBuatPeperoni, 60000, new List<string> { "cheese", "peperoni" }, 8);
            addDataToPitsahTable("tunah mayoou", "thin", customeTanggalBuatTunaMayoh, 55000, new List<string> { "cheese", "tuna" }, 6);
            addDataToPitsahTable("beeff deluxe", "stuffed", customeTanggalBuatBeef, 70000, new List<string> { "cheese", "beef", "mushroom" }, 5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string role = "";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan Password tidak boleh kosong.", "Validasi");
                return;
            }

            if (((username == "admin") || (username == "Admin")) && ((password == "admin") || (password == "Admin")))
            {

                role = "admin";
                DataRow[] existingAdmin = dt.Select($"username = 'admin'");
                if (existingAdmin.Length == 0)
                {
                    DataRow adminRow = dt.NewRow();
                    adminRow["username"] = "admin";
                    adminRow["password"] = "admin";
                    adminRow["role"] = role;
                    dt.Rows.Add(adminRow);
                }
                this.Hide();
                formAdmin.ShowDialog();
                this.Show();
                return;
            }
            var matchingUsers = dt.AsEnumerable()
                          .Where(row => row.Field<string>("username").Equals(username, StringComparison.OrdinalIgnoreCase) &&
                                        row.Field<string>("password") == password)
                          .ToList();

            if (matchingUsers.Count > 0)
            {
                // LOGIN BERHASIL (User ditemukan dan password cocok)
                role = "user";
                formUser formUsah = new formUser(dataPijah, username, formAdmin);

                this.Hide();
                formUsah.ShowDialog();
                this.Show();
                // TIDAK PERLU dt.Rows.Add(dr); karena user sudah ada.

            }

            else if (!((username == "admin") || (username == "Admin")) && !((password == "admin") || (password == "Admin")))
            {
                DialogResult result = MessageBox.Show($"User '{username}' tidak ditemukan. Apakah Anda ingin mendaftar dengan password ini?",
                                                 "Daftar Baru?",
                                                 MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    role = "user";
                    DataRow newUserRow = dt.NewRow();
                    newUserRow["username"] = username;
                    newUserRow["password"] = password;
                    newUserRow["role"] = role;
                    dt.Rows.Add(newUserRow);

                    MessageBox.Show($"Registrasi berhasil! Selamat datang, {username}.", "Berhasil");
                    formUser formUsah = new formUser(dataPijah, username, formAdmin);
                    this.Hide();
                    formUsah.ShowDialog();
                    this.Show();
                    role = "user";
                }
            }

            //DataRow dr = dt.NewRow();
            //dr["username"] = username;
            //dr["password"] = password;
            //dr["role"] = role;
            //dt.Rows.Add(dr);

            dataGridViewUser.DataSource = dt;

        }

        public void addDataToPitsahTable(string nama, string tipeh, DateTime tanggal, int harga, List<string> toppings, int stok)
        {
            tablePijah = dataPijah.Tables["Pizza"];
            //check validation duluh
            if (string.IsNullOrEmpty(nama) || nama.Length < 10)
            {
                MessageBox.Show("iki nama e kosong ato length nama e < 10 ");
                return;
            }

            if (harga <= 10000)
            {
                MessageBox.Show("harga e kenot kurang dari 10k bang");
                return;
            }

            if (stok < 1)
            {
                MessageBox.Show("stok e mek oleh minim 1");
                return;
            }
            if (toppings == null || toppings.Count == 0)
            {
                MessageBox.Show("At least select 1 topping pijah lahh");
                return;
            }

            string kode = "PZ";
            string counterString = counter.ToString("000");
            string finalId = $"{kode}{counterString}";

            counter++;

            DataRow dr = tablePijah.NewRow();
            dr["PizzaId"] = finalId;
            dr["Nama"] = nama;
            dr["Tipe"] = tipeh;
            dr["ReleaseDate"] = tanggal;
            dr["Harga"] = harga;
            dr["Toppings"] = string.Join(", ", toppings);
            dr["Stok"] = stok;
            tablePijah.Rows.Add(dr);

            //dataGridView1.DataSource = dt;
        }
    }
}
