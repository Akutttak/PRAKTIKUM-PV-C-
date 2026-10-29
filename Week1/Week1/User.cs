using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    public class User
    {

        public string username { get; set; }
        public string nama { get; set; }
        public string password { get; set; }
        public string referralCode { get; set; }
        public int money { get; set; }

        public User(string username, string nama, string password, string referralCode, int money)
        {
            this.username = username;
            this.nama = nama;
            this.password = password;
            this.referralCode = referralCode;
            this.money = money;
        }


    }
}
