using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3
{
    public class Tool
    {
        public string Nama { get; set; }
        public int HargaBeli { get; set; }
        public string AxeType { get; set; }

        public Tool(string nama, int harga, string type)
        {
            Nama = nama;
            HargaBeli = harga;
            AxeType = type;
        }
    }
}
