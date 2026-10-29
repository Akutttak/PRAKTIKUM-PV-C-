using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    public static class UserStorage
    {
        public static List<User> users = new List<User>();
        public static User currentUser { get; set; }
        public static Random rnd = new Random();

        public static void AddUser(string username, string nama, string password, string referralCode)
        {
            int startingMoney = 0;
            if (!string.IsNullOrEmpty(referralCode) && referralCode.Trim().ToLower() == "referral money")
            {
                startingMoney += 100000;
            }
            if (string.IsNullOrEmpty(referralCode))
            {
                referralCode = GenerateReferralCode();
                startingMoney += 50000;
            }

            users.Add(new User(username, nama, password, referralCode, startingMoney));
        }

        private static string GenerateReferralCode()
        {
            return rnd.Next(10000, 99999).ToString();
        }
    }
}
