using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace week3
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Uang { get; set; }
        public string ActiveAxeName { get; set; }
        public int ownedOak { get; set; }
        public int ownedMahogany { get; set; }
        public int ownedMystic { get; set; }

        public int GameDay { get; private set; }
        public int GameHour { get; private set; }
        public int GameMenit { get; private set; }

        // Kapak aktif dinamis dari database
        public string ActiveAxe
        {
            get
            {
                var dt = DatabaseHelper.ExecuteQuery(
                    "SELECT nama_axe FROM axe_inventory WHERE user_id = @user AND aktif = 1",
                    new Dictionary<string, object> { { "@user", Id } }
                );

                if (dt.Rows.Count > 0)
                    return dt.Rows[0]["nama_axe"].ToString();

                return "Wooden Axe";
            }
        }

        public User()
        {
            Id = 1; // default id player
            Username = "Player";
            LoadFromDatabase();
            LoadInventoryKayu();
        }

        public void LoadFromDatabase()
        {
            string query = "SELECT nama, uang, game_day, game_hour, game_menit FROM users WHERE id = @id";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new Dictionary<string, object> { { "@id", this.Id } });

            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                Username = row["nama"].ToString();
                Uang = Convert.ToInt32(row["uang"]);
                GameDay = Convert.ToInt32(row["game_day"]);
                GameHour = Convert.ToInt32(row["game_hour"]);
                GameMenit = Convert.ToInt32(row["game_menit"]);
            }
            else
            {
                // User default jika belum ada
                GameDay = 1;
                GameHour = 6;
                GameMenit = 0;
                Uang = 0;

                string insert = @"INSERT INTO users (id, nama, uang, game_day, game_hour, game_menit)
                                  VALUES (@id, @nama, @uang, @day, @hour, @menit)";
                DatabaseHelper.ExecuteNonQuery(insert, new Dictionary<string, object>
                {
                    {"@id", Id},
                    {"@nama", Username},
                    {"@uang", Uang},
                    {"@day", GameDay},
                    {"@hour", GameHour},
                    {"@menit", GameMenit}
                });
            }
        }

        public void LoadInventoryKayu()
        {
            string query = "SELECT nama_kayu, jumlah FROM log_inventory WHERE user_id = @user";
            var dt = DatabaseHelper.ExecuteQuery(query, new Dictionary<string, object> { { "@user", Id } });

            ownedOak = 0;
            ownedMahogany = 0;
            ownedMystic = 0;

            foreach (DataRow row in dt.Rows)
            {
                string namaKayu = row["nama_kayu"].ToString();
                int jumlah = Convert.ToInt32(row["jumlah"]);

                switch (namaKayu)
                {
                    case "Oak":
                        ownedOak = jumlah;
                        break;
                    case "Mahogany":
                        ownedMahogany = jumlah;
                        break;
                    case "Mystic":
                        ownedMystic = jumlah;
                        break;
                }
            }
        }

        // Tambah kayu ke inventory
        public void TambahLog(string namaKayu, int jumlah)
        {
            string cek = "SELECT jumlah FROM log_inventory WHERE user_id = @user AND nama_kayu = @nama";
            var dt = DatabaseHelper.ExecuteQuery(cek, new Dictionary<string, object>
            {
                {"@user", Id},
                {"@nama", namaKayu}
            });

            if (dt.Rows.Count > 0)
            {
                int jumlahBaru = Convert.ToInt32(dt.Rows[0]["jumlah"]) + jumlah;
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE log_inventory SET jumlah = @jumlah WHERE user_id = @user AND nama_kayu = @nama",
                    new Dictionary<string, object>
                    {
                        {"@jumlah", jumlahBaru},
                        {"@user", Id},
                        {"@nama", namaKayu}
                    });
            }
            else
            {
                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO log_inventory (user_id, nama_kayu, jumlah) VALUES (@user, @nama, @jumlah)",
                    new Dictionary<string, object>
                    {
                        {"@user", Id},
                        {"@nama", namaKayu},
                        {"@jumlah", jumlah}
                    });
            }

            // Update property lokal juga
            switch (namaKayu)
            {
                case "Oak": ownedOak = GetJumlahLog("Oak"); break;
                case "Mahogany": ownedMahogany = GetJumlahLog("Mahogany"); break;
                case "Mystic": ownedMystic = GetJumlahLog("Mystic"); break;
            }
        }

        public int GetJumlahLog(string namaKayu)
        {
            string query = "SELECT jumlah FROM log_inventory WHERE user_id = @user AND nama_kayu = @nama";
            var dt = DatabaseHelper.ExecuteQuery(query, new Dictionary<string, object>
            {
                {"@user", Id},
                {"@nama", namaKayu}
            });

            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["jumlah"]);

            return 0;
        }

        // Simpan progress game (uang, waktu)
        public void SaveProgress()
        {
            //MessageBox.Show("masukk sabe progresss;;");
            string query = @"UPDATE users
                             SET uang = @uang,
                                 game_day = @day,
                                 game_hour = @hour,
                                 game_menit = @menit
                             WHERE id = @id";

            DatabaseHelper.ExecuteNonQuery(query, new Dictionary<string, object>
            {
                {"@uang", Uang},
                {"@day", GameDay},
                {"@hour", GameHour},
                {"@menit", GameMenit},
                {"@id", Id}
            });
        }

        // Update uang saja
        public void UpdateUang()
        {
            string query = "UPDATE users SET uang = @uang WHERE id = @id";
            DatabaseHelper.ExecuteNonQuery(query, new Dictionary<string, object>
            {
                {"@uang", Uang},
                {"@id", Id}
            });
        }

        // Set kapak aktif
        public void EquipAxe(string nama)
        {
            DatabaseHelper.ExecuteNonQuery(
                "UPDATE axe_inventory SET aktif = 0 WHERE user_id = @user",
                new Dictionary<string, object> { { "@user", Id } }
            );

            DatabaseHelper.ExecuteNonQuery(
                "UPDATE axe_inventory SET aktif = 1 WHERE user_id = @user AND nama_axe = @nama",
                new Dictionary<string, object>
                {
                    {"@user", Id},
                    {"@nama", nama}
                });
        }

        // Update waktu game
        public void SetGameTime(int day, int hour, int menit)
        {
            GameDay = day;
            GameHour = hour;
            GameMenit = menit;
            SaveProgress();
        }
    }
}
