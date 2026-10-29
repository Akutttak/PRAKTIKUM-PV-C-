using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3
{
    public static class AxePower
    {
        public static readonly Dictionary<string, Dictionary<string, int>> KekuatanTebang =
            new Dictionary<string, Dictionary<string, int>>
        {
            {"oak", new Dictionary<string, int>
                {
                    {"Stone Axe", 3},
                    {"Iron Axe", 2},
                    {"Diamond Axe", 1}
                }
            },
            {"mahogany", new Dictionary<string, int>
                {
                    {"Stone Axe", 5},
                    {"Iron Axe", 3},
                    {"Diamond Axe", 2}
                }
            },
            {"mystic", new Dictionary<string, int>
                {
                    {"Stone Axe", 8},
                    {"Iron Axe", 5},
                    {"Diamond Axe", 3}
                }
            }
        };

        // Method untuk mendapatkan Target Hit yang diperlukan
        public static int GetTargetHit(string namaKayu, string tipeKapak)
        {
            string keyKayu = namaKayu.ToLower();

            if (KekuatanTebang.ContainsKey(keyKayu) && KekuatanTebang[keyKayu].ContainsKey(tipeKapak))
            {
                return KekuatanTebang[keyKayu][tipeKapak];
            }

            // Default aman jika kombinasi tidak ditemukan
            return 10;
        }
    }
}
