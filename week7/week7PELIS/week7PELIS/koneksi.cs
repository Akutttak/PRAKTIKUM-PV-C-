using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week7PELIS
{
    public static class koneksi
    {
        public static MySqlConnection getConn()
        {
            string str = "server=localhost;" +
                "user id=root;" +
                "password=;" +
                "database=db_goputplusbanget";
            return new MySqlConnection(str);
        }
    }
}
