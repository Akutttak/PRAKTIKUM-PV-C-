using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3
{
    public class kayuh
    {
        public string nama { get; set; }
        public int harga { get; set; }
        public Color warnah { get; set; }
        public int jumlahLog { get; set; }

        public kayuh(string nama, int harga, Color warnah, int jumlahLog=1)
        {
            this.nama = nama;
            this.harga = harga;
            this.warnah = warnah;
            this.jumlahLog = jumlahLog;
        }
    }
}
