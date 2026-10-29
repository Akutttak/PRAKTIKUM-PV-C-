using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace week3
{
    public partial class tebangPohon : Form
    {
        private Timer progressTimer = new Timer();
        private bool progressNaik = true;
        private int hit = 0;
        private int miss = 0;
        private kayuh kayuRightNow;
        private const int TARGET_MIN = 60;
        private const int TARGET_MAX = 85;
        private int targetHit = 3;
        private string kapakYangDipakai;

        public kayuh hasilLog { get; private set; }

        public tebangPohon(kayuh kayuYangDitebang, string jenisKapak)
        {
            InitializeComponent();
            this.kayuRightNow = kayuYangDitebang;
            this.kapakYangDipakai = jenisKapak;
            this.Text = $"Tebang Pohon: {kayuRightNow.nama}";
        }

        private void tebangPohon_Load(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            progressTimer.Interval = 30;
            progressTimer.Tick += progressTimer_Tick;
            progressTimer.Start();

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            targetHit = AxePower.GetTargetHit(kayuRightNow.nama, kapakYangDipakai);
            MessageBox.Show($"{kayuRightNow.nama}, {kapakYangDipakai}, {targetHit}");
            updateTulisan();
        }

        private int TentukanTargetHit(string namaKayu, string jenisKapak)
        {
            if (string.IsNullOrEmpty(namaKayu) || string.IsNullOrEmpty(jenisKapak))
                return 3; // default aman

            namaKayu = namaKayu.ToLower();
            jenisKapak = jenisKapak.ToLower();

            if (namaKayu == "oak")
            {
                if (jenisKapak == "stone axe") return 3;
                if (jenisKapak == "iron axe") return 2;
                if (jenisKapak == "diamond axe") return 1;
            }
            else if (namaKayu == "mahogany")
            {
                if (jenisKapak == "stone axe") return 5;
                if (jenisKapak == "iron axe") return 3;
                if (jenisKapak == "diamond axe") return 2;
            }
            else if (namaKayu == "mystic")
            {
                if (jenisKapak == "stone axe") return 8;
                if (jenisKapak == "iron axe") return 5;
                if (jenisKapak == "diamond axe") return 3;
            }

            return 3; // default
        }


        private void progressTimer_Tick(object sender, EventArgs e)
        {
            if (progressNaik)
            {
                progressBar1.Value += 1;
                if (progressBar1.Value >= progressBar1.Maximum)
                    progressNaik = false;
            }
            else
            {
                progressBar1.Value -= 1;
                if (progressBar1.Value <= progressBar1.Minimum)
                    progressNaik = true;
            }
        }

        private void tebangPohon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                cekTebang();
            }
        }
        private void tebangPohon_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                cekTebang();
            }
        }

        private void cekTebang()
        {
            int value = progressBar1.Value;

            if (value >= 60 && value <= 85)
            {
                hit++;
                if (hit >= targetHit)
                {
                    progressTimer.Stop();

                    hasilLog = new kayuh(
                        kayuRightNow.nama,
                        kayuRightNow.harga,
                        kayuRightNow.warnah,
                        kayuRightNow.jumlahLog
                    );

                    MessageBox.Show($"Berhasil menebang {kayuRightNow.nama}!\nMendapat {kayuRightNow.jumlahLog} log.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }
            }
            else
            {
                miss++;
                if (miss >= targetHit)
                {
                    progressTimer.Stop();
                    MessageBox.Show("Tebang gagal!");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }
            }

            updateTulisan();
        }

        private void button1_Click(object sender, EventArgs e) 
        { 
            hit++; 
        }

        private void updateTulisan()
        {
            label2.Text = $"target hit : {targetHit}";
            labelHit.Text = $"Hit: {targetHit}/3";
            labelMiss.Text = $"Miss: {miss}/3";
        }
    }
}
