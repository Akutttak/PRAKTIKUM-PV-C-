using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week3
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        private Timer gameTimer = new Timer();
        private Rectangle shopArea;
        private Rectangle homeArea;
        private Rectangle warungArea;
        private Rectangle playerArea;
        private bool moveUp, moveDown, moveLeft, moveRight;
        public int posisiPlayerX = 400;
        public int posisiPlayerY = 280;
        public int playerWidth = 70;
        public int playerHeight = 70;
        public int playerSpeed = 5;
        private Image imgShop, imgHome, imgPlayer, imgWarung;
        private int hour = 6;
        private int menit = 0;
        private int day = 1;
        private const int MAX_HOUR = 24;
        private const int TIME_INCREMENT = 10; 
        private const int REAL_SECOND_INTERVAL = 1000; 
        private Timer timerWaktuGame = new Timer();
        private bool isPassedOut = false;


        private bool interactPohon = false;
        private List<Panel> placedWoodPanels = new List<Panel>();
        private User currentPlayer;

        private string connectionString = "Server=localhost;Database=pv_t6_224117124;UserID=root;Password=;";


        //private List<Tool> availableTools = new List<Tool>
        //{
        //    new Tool("Stone Axe", 0, 1),
        //    new Tool("Iron Axe", 1500, 3),
        //    new Tool("Diamond Axe", 6000, 6)
        //};


        private List<kayuh> listKayu = new List<kayuh>
        {
            new kayuh("oak", 50, Color.Green),
            new kayuh("mahogany", 120, Color.Brown),
            new kayuh("mystic", 250, Color.Purple),
        };
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            panelDinamik.Paint += new PaintEventHandler(panelDinamik_Paint);


        }

        public List<kayuh> RandomKayuh()
        {
            List<kayuh> listRandomKayu = new List<kayuh>();

            int kayuYangDiGenerate = rnd.Next(8, 13);

            List<string> randomKayu = new List<string>();

            for (int i = 0; i < 60; i++)
            {
                randomKayu.Add("oak");
            }

            for (int i = 0; i < 30; i++)
            {
                randomKayu.Add("mahogany");
            }

            for (int i = 0; i < 10; i++)
            {
                randomKayu.Add("mystic");
            }

            for (int i = 0; i < kayuYangDiGenerate; i++)
            {
                int indeksRandom = rnd.Next(0, randomKayu.Count);
                string namaKayu = randomKayu[indeksRandom];

                kayuh kayuygkepilih = null;

                foreach (var wood in listKayu)
                {
                    if (wood.nama == namaKayu)
                    {
                        kayuygkepilih = wood;
                        break;
                    }
                }

                if (kayuygkepilih != null)
                {
                    int minLog = 2;
                    int maxLog = 4;

                    if (kayuygkepilih.nama == "oak")
                    {
                        minLog = 2; maxLog = 4;
                    }
                    else if (kayuygkepilih.nama == "mahogany")
                    {
                        minLog = 4; maxLog = 7;
                    }
                    else if (kayuygkepilih.nama == "mystic")
                    {
                        minLog = 6; maxLog = 10;
                    }

                    kayuh kayuSesiBaru = new kayuh(
                        kayuygkepilih.nama,
                        kayuygkepilih.harga,
                        kayuygkepilih.warnah,
                        rnd.Next(minLog, maxLog + 1)
                    );

                    listRandomKayu.Add(kayuSesiBaru);
                }
                else
                {
                    MessageBox.Show($"errorr {namaKayu} tidak ditemukan");
                }
            }
            return listRandomKayu;
        }
        private bool CheckCollision(Panel panelA, Panel panelB)
        {
            Rectangle rectA = new Rectangle(panelA.Location, panelA.Size);
            Rectangle rectB = new Rectangle(panelB.Location, panelB.Size);
            return rectA.IntersectsWith(rectB);
        }

        public void displayKayuKayu(List<kayuh> listRandomKayu)
        {
            const int WADAH_WIDTH = 993; 
            const int WADAH_HEIGHT = 475;

            int actualWadahWidth = panelDinamik.ClientSize.Width;
            int actualWadahHeight = panelDinamik.ClientSize.Height;

            const int PANEL_WIDTH = 40;
            const int PANEL_HEIGHT = 60;
            const int MARGIN = 5;

            List<Panel> placedPanels = new List<Panel>();

            panelDinamik.Controls.Clear();

            int maxX = actualWadahWidth - PANEL_WIDTH - MARGIN;
            int maxY = actualWadahHeight - PANEL_HEIGHT - MARGIN;
            int minX = MARGIN;
            int minY = MARGIN;

            const int MAX_ATTEMPTS = 500;

            foreach (var kayu in listRandomKayu)
            {
                Panel panelKayu = new Panel();
                panelKayu.Width = PANEL_WIDTH;
                panelKayu.Height = PANEL_HEIGHT;
                panelKayu.BackColor = kayu.warnah;
                panelKayu.BorderStyle = BorderStyle.FixedSingle;

                bool placed = false;
                int attempts = 0;

                while (!placed && attempts < MAX_ATTEMPTS)
                {
                    if (minX > maxX || minY > maxY)
                    {
                        break;
                    }

                    int randomX = rnd.Next(minX, maxX + 1);
                    int randomY = rnd.Next(minY, maxY + 1);
                    panelKayu.Location = new Point(randomX, randomY);

                    bool isColliding = false;

                    foreach (var existingPanel in placedPanels)
                    {
                        if (CheckCollision(panelKayu, existingPanel))
                        {
                            isColliding = true;
                            break;
                        }
                    }

                    Rectangle currentKayuRect = new Rectangle(panelKayu.Location, panelKayu.Size);

                    if (currentKayuRect.IntersectsWith(shopArea) ||
                        currentKayuRect.IntersectsWith(homeArea) ||
                        currentKayuRect.IntersectsWith(warungArea) ||
                        currentKayuRect.IntersectsWith(playerArea))
                    {
                        isColliding = true;
                    }

                    if (!isColliding)
                    {
                        Label lblNama = new Label();
                        lblNama.Text = kayu.nama;
                        lblNama.AutoSize = true;
                        lblNama.Location = new Point(5, 5);

                        Button btnPilih = new Button();
                        btnPilih.Text = $"Pilih (${kayu.harga})";
                        btnPilih.Tag = kayu;
                        btnPilih.Width = PANEL_WIDTH - 10;
                        btnPilih.Location = new Point(5, 65);

                        btnPilih.Click += (sender, e) => HandlePilihanKayu(kayu);

                        panelKayu.Controls.Add(lblNama);
                        panelKayu.Controls.Add(btnPilih);

                        panelDinamik.Controls.Add(panelKayu);
                        placedWoodPanels.Add(panelKayu);
                        placedPanels.Add(panelKayu);
                        placed = true;
                    }
                    attempts++;
                }
            }
        }

        private void HandlePilihanKayu(kayuh listRandomKayu)
        {
            MessageBox.Show($"Anda memilih {listRandomKayu.nama} seharga ${listRandomKayu.harga}. Lanjutkan proses game!");
        }
        private void MuatSesiKayuBaru()
        {
            List<kayuh> kayuUntukSesi = RandomKayuh();

            displayKayuKayu(kayuUntukSesi);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            currentPlayer = new User();

            day = currentPlayer.GameDay;
            hour = currentPlayer.GameHour;
            menit = currentPlayer.GameMenit;

            UpdateGameTimeLabel();

            imgShop = Image.FromFile("shopp.jpg");
            imgHome = Image.FromFile("homm.jpg");
            imgWarung = Image.FromFile("warung.jpg");
            imgPlayer = Image.FromFile("playah.png");

            int shopWidth = 90;
            int shopHeight = 90;
            int posisiShopX = 20;
            int posisiShopY = 280;

            int homeWidth = 90;
            int homeHeight = 90;
            int posisiHomeX = 630;
            int posisiHomeY = 280;

            int warungWidth = 90;
            int warungHeight = 90;
            int posisiwarungX = 20;
            int posisiwarungY = 175;

            shopArea = new Rectangle(posisiShopX, posisiShopY, shopWidth, shopHeight);
            homeArea = new Rectangle(posisiHomeX, posisiHomeY, homeWidth, homeHeight);
            warungArea = new Rectangle(posisiwarungX, posisiwarungY, warungWidth, warungHeight);
            playerArea = new Rectangle(posisiPlayerX, posisiPlayerY, playerWidth, playerHeight);

            // mulai dari jam 6 pagi
            hour = 6;
            menit = 0;

            MuatSesiKayuBaru();
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;

            // Timer untuk gerakan player
            gameTimer.Interval = 25;
            gameTimer.Tick += new EventHandler(gameTimer_Tick);
            gameTimer.Start();

            // Timer khusus untuk waktu game
            timerWaktuGame.Interval = 1000; // 1 detik real = 10 menit di game
            timerWaktuGame.Tick += TimerWaktuGame_Tick;
            timerWaktuGame.Start();

            UpdateGameTimeLabel();
        }

        private void TimerWaktuGame_Tick(object sender, EventArgs e)
        {
            TambahWaktuGame(10); // tambah 10 menit tiap tick
        }



        private void panelDinamik_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(imgShop, shopArea);
            e.Graphics.DrawImage(imgHome, homeArea);
            e.Graphics.DrawImage(imgWarung, warungArea);
            e.Graphics.DrawImage(imgPlayer, posisiPlayerX, posisiPlayerY, 70, 70);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up) moveUp = true;
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down) moveDown = true;
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left) moveLeft = true;
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right) moveRight = true;

            if (e.KeyCode == Keys.F)
            {
                if (playerArea.IntersectsWith(homeArea))
                {
                    var result = MessageBox.Show("Tidur untuk lanjut ke hari berikutnya?", "Rumah", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        day++;
                        hour = 6;
                        menit = 0;
                        currentPlayer.SetGameTime(day, hour, menit);
                        ProsesPenjualanWarung();
                    }

                }
                else if (playerArea.IntersectsWith(shopArea))
                {
                    shop formShop = new shop(currentPlayer);
                    formShop.ShowDialog();
                }
                else if (playerArea.IntersectsWith(warungArea))
                {
                    // Cek apakah user sudah punya warung
                    string query = "SELECT sudah_beli FROM warung_user WHERE user_id = @user";
                    var dt = DatabaseHelper.ExecuteQuery(query, new Dictionary<string, object> { { "@user", currentPlayer.Id } });

                    bool sudahBeli = false;
                    if (dt.Rows.Count > 0)
                        sudahBeli = Convert.ToInt32(dt.Rows[0]["sudah_beli"]) == 1;

                    if (!sudahBeli)
                    {
                        var result = MessageBox.Show("Beli warung seharga 1.000G?", "Beli Warung", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            if (currentPlayer.Uang >= 1000)
                            {
                                currentPlayer.Uang -= 1000;

                                // Jika belum ada record warung user → insert
                                if (dt.Rows.Count == 0)
                                {
                                    string insertQuery = "INSERT INTO warung_user (user_id, sudah_beli) VALUES (@user, 1)";
                                    DatabaseHelper.ExecuteNonQuery(insertQuery, new Dictionary<string, object> { { "@user", currentPlayer.Id } });
                                }
                                else
                                {
                                    string updateQuery = "UPDATE warung_user SET sudah_beli = 1 WHERE user_id = @user";
                                    DatabaseHelper.ExecuteNonQuery(updateQuery, new Dictionary<string, object> { { "@user", currentPlayer.Id } });
                                }

                                currentPlayer.UpdateUang();
                                MessageBox.Show("Selamat! Kamu telah membeli warung.");
                            }
                            else
                            {
                                MessageBox.Show("Uang kamu tidak cukup untuk membeli warung!");
                            }
                        }
                    }
                    else
                    {
                        // Sudah punya warung → buka form warung
                        StoreForm warungForm = new StoreForm(currentPlayer);
                        warungForm.ShowDialog();

                    }
                }

                else
                {
                    bool dekatPohon = false;
                    foreach (var panelKayu in placedWoodPanels)
                    {
                        Rectangle rectKayu = new Rectangle(panelKayu.Location, panelKayu.Size);

                        if (playerArea.IntersectsWith(rectKayu))
                        {
                            dekatPohon = true;
                            kayuh kayuDekat = null;

                            foreach (Control ctrl in panelKayu.Controls)
                            {
                                if (ctrl is Button btn && btn.Tag is kayuh)
                                {
                                    kayuDekat = (kayuh)btn.Tag;
                                    break;
                                }
                            }

                            if (kayuDekat != null)
                            {
                                InteractDenganPohon(kayuDekat);
                            }

                            break;
                        }
                    }

                    interactPohon = dekatPohon;
                }

            }

            if (e.KeyCode == Keys.I)
            {
                inventory inv = new inventory(currentPlayer);
                inv.ShowDialog();
            }
            if (e.KeyCode == Keys.H)
            {
                formHistory history = new formHistory(currentPlayer, connectionString);
                history.ShowDialog();
            }
        }



        private void panelDinamik_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            currentPlayer.UpdateUang();
            currentPlayer.LoadInventoryKayu();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up) moveUp = false;
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down) moveDown = false;
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left) moveLeft = false;
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right) moveRight = false;

        }

        private void InteractDenganPohon(kayuh pohon)
        {
            string namaKapakAktif = currentPlayer.ActiveAxe;
            tebangPohon form = new tebangPohon(pohon, namaKapakAktif);
            if (form.ShowDialog() == DialogResult.OK)
            {
                kayuh hasil = form.hasilLog;
                currentPlayer.TambahLog(hasil.nama, hasil.jumlahLog);

                MessageBox.Show($"Log {hasil.nama} telah ditambahkan ke inventory!");

                Panel panelYangDitebang = null;

                foreach (var panel in placedWoodPanels)
                {
                    foreach (Control ctrl in panel.Controls)
                    {
                        if (ctrl is Button btn && btn.Tag is kayuh k && k == pohon)
                        {
                            panelYangDitebang = panel;
                            break;
                        }
                    }
                    if (panelYangDitebang != null)
                        break;
                }

                if (panelYangDitebang != null)
                {
                    panelDinamik.Controls.Remove(panelYangDitebang);
                    placedWoodPanels.Remove(panelYangDitebang);
                }
            }
        }



        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (moveLeft) posisiPlayerX -= playerSpeed;
            if (moveRight) posisiPlayerX += playerSpeed;
            if (moveUp) posisiPlayerY -= playerSpeed;
            if (moveDown) posisiPlayerY += playerSpeed;

            playerArea.X = posisiPlayerX;
            playerArea.Y = posisiPlayerY;

            int maxWidth = panelDinamik.ClientSize.Width - playerArea.Width;
            int maxHeight = panelDinamik.ClientSize.Height - playerArea.Height;

            if (posisiPlayerX < 0) posisiPlayerX = 0;
            if (posisiPlayerX > maxWidth) posisiPlayerX = maxWidth;
            if (posisiPlayerY < 0) posisiPlayerY = 0;
            if (posisiPlayerY > maxHeight) posisiPlayerY = maxHeight;

            UpdateGameTimeLabel();

            panelDinamik.Invalidate();
        }

        private void TambahWaktuGame(int menitTambahan)
        {
            if (isPassedOut) return;

            menit += menitTambahan;

            if (menit >= 60)
            {
                menit -= 60;
                hour++;
            }

            // Jika jam lebih dari 24 → lanjut ke hari berikut
            if (hour >= 24)
            {
                isPassedOut = true;

                int kehilangan = (int)(currentPlayer.Uang * 0.1);
                currentPlayer.Uang -= kehilangan;

                MessageBox.Show($"Kamu pingsan karena kelelahan!\nPencuri mengambil {kehilangan} gold darimu.");

                day++;
                hour = 6;
                menit = 0;
                isPassedOut = false;
            }

            UpdateGameTimeLabel();
        }
        private void UpdateGameTimeLabel()
        {
            labelTime.Text = $"Time: {hour:D2}:{menit:D2}";
            labelDay.Text = $"Day: {day}";
        }
        private void ProsesPenjualanWarung()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        string queryShelves = @"
                    SELECT wi.id AS inventory_id, wi.wood_name, wi.stock, wi.price
                    FROM warung_inventory wi
                    JOIN warung_user wu ON wi.warung_id = wu.id
                    WHERE wu.user_id = @user";

                        MySqlCommand cmdShelves = new MySqlCommand(queryShelves, conn, transaction);
                        cmdShelves.Parameters.AddWithValue("@user", currentPlayer.Id);

                        var aggregatedSales = new Dictionary<string, (int totalSold, int totalPrice)>();
                        var toUpdate = new List<(int inventoryId, string woodName, int sold, int remaining, int price)>();

                        using (var reader = cmdShelves.ExecuteReader())
                        {
                            Random rnd = new Random();

                            while (reader.Read())
                            {
                                int inventoryId = reader.GetInt32("inventory_id");
                                string woodName = reader.GetString("wood_name");
                                int stock = reader.GetInt32("stock");
                                int price = reader.GetInt32("price");

                                // Ambil stok pemain untuk kayu ini
                                int ownedStock = currentPlayer.GetJumlahLog(woodName);
                                int maxJual = Math.Min(stock, ownedStock);

                                int sold = rnd.Next(0, maxJual + 1); // random penjualan antara 0 sampai stok pemain
                                int remaining = stock - sold;
                                int income = sold * price;

                                if (sold > 0)
                                {
                                    if (!aggregatedSales.ContainsKey(woodName))
                                        aggregatedSales[woodName] = (0, 0);

                                    var current = aggregatedSales[woodName];
                                    aggregatedSales[woodName] = (current.totalSold + sold, current.totalPrice + income);

                                    // Kurangi inventory pemain
                                    currentPlayer.TambahLog(woodName, -sold);
                                }

                                toUpdate.Add((inventoryId, woodName, sold, remaining, price));

                                // Update uang pemain lokal
                                currentPlayer.Uang += income;
                            }
                        }

                        // Update stok warung & simpan penjualan
                        foreach (var item in toUpdate)
                        {
                            string updateStock = "UPDATE warung_inventory SET stock = @remaining WHERE id = @id";
                            MySqlCommand cmdUpdate = new MySqlCommand(updateStock, conn, transaction);
                            cmdUpdate.Parameters.AddWithValue("@remaining", item.remaining);
                            cmdUpdate.Parameters.AddWithValue("@id", item.inventoryId);
                            cmdUpdate.ExecuteNonQuery();

                            if (item.sold > 0)
                            {
                                string insertSale = @"
                            INSERT INTO sales 
                            (user_id, wood_name, quantity, price_per_item, total_price, sale_date, day)
                            VALUES (@user, @wood, @qty, @price, @total, NOW(), @day)";
                                MySqlCommand cmdSale = new MySqlCommand(insertSale, conn, transaction);
                                cmdSale.Parameters.AddWithValue("@user", currentPlayer.Id);
                                cmdSale.Parameters.AddWithValue("@wood", item.woodName);
                                cmdSale.Parameters.AddWithValue("@qty", item.sold);
                                cmdSale.Parameters.AddWithValue("@price", item.price);
                                cmdSale.Parameters.AddWithValue("@total", item.sold * item.price);
                                cmdSale.Parameters.AddWithValue("@day", day);
                                cmdSale.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();

                        // Ringkasan penjualan
                        if (aggregatedSales.Count > 0)
                        {
                            var salesSummaryLines = new List<string>();
                            foreach (var entry in aggregatedSales)
                            {
                                salesSummaryLines.Add($"{entry.Value.totalSold} {entry.Key} terjual, total Rp {entry.Value.totalPrice}");
                            }
                            MessageBox.Show("Ringkasan Penjualan Hari Ini:\n" + string.Join("\n", salesSummaryLines));
                        }
                        else
                        {
                            MessageBox.Show("Tidak ada penjualan hari ini.");
                        }

                        // Update uang pemain ke database
                        currentPlayer.UpdateUang();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memproses penjualan: " + ex.Message);
            }
        }




    }

}
