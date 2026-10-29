using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3
{
    public class LogItem
    {
        public string NamaKayu { get; set; }
        public int Jumlah { get; set; }

        public LogItem(string nama, int jumlah)
        {
            NamaKayu = nama;
            Jumlah = jumlah;
        }
    }
}
