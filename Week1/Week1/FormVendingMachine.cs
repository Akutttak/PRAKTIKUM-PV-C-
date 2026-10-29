using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Week1
{
    public partial class FormVendingMachine : Form
    {
        private int insertedMoney = 0;
        private int targetPressCount = 0;
        private int currentPressCount = 0;

        Random rendem = new Random();

        public FormVendingMachine()
        {
            InitializeComponent();
            UpdateMoneyDisplay();
            groupBoxVendingMachine.Enabled = false;
            buttonInsertMoney5000.Click += InsertMoneyButton_Click;
            buttonInsertMoney10000.Click += InsertMoneyButton_Click;
            buttonInsertMoney20000.Click += InsertMoneyButton_Click;

            buttonHarga5000.Click += buttonHargaDiteken;
            buttonHarga6500.Click += buttonHargaDiteken;
            buttonHarga5500.Click += buttonHargaDiteken;
            buttonHarga10000.Click += buttonHargaDiteken;
            buttonHarga13000.Click += buttonHargaDiteken;
            buttonHarga4000.Click += buttonHargaDiteken;
            buttonHarga9000.Click += buttonHargaDiteken;
            buttonHarga11000.Click += buttonHargaDiteken;
            buttonHarga3000.Click += buttonHargaDiteken;
        }

        private void InsertMoneyButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn == buttonInsertMoney5000)
                InsertMoney(5000);
            else if (btn == buttonInsertMoney10000)
                InsertMoney(10000);
            else if (btn == buttonInsertMoney20000)
                InsertMoney(20000);
        }

        private void InsertMoney(int amount)
        {
            if (UserStorage.currentUser != null && UserStorage.currentUser.money >= amount)
            {
                UserStorage.currentUser.money -= amount;
                insertedMoney += amount;
                UpdateMoneyDisplay();
                groupBoxVendingMachine.Enabled = true;
                MessageBox.Show($"Inserted Rp {amount:N0}. Total inserted: Rp {insertedMoney:N0}", "Money Inserted");
            }
            else
            {
                MessageBox.Show("Uang di dompet ga cukup", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateMoneyDisplay()
        {
            if (UserStorage.currentUser != null)
            {
                labelYourMoney.Text = $"Your Money: Rp {UserStorage.currentUser.money:N0}";
                labelUangUser.Text = $"Rp {insertedMoney:N0}"; // Show inserted money here
                labelReferralCode.Text = $"Referral Code : {UserStorage.currentUser.referralCode}";
            }
        }

        private void buttonDoHomework_Click(object sender, EventArgs e)
        {
            DoHomework formDoHomework = new DoHomework();
            formDoHomework.FormClosed += (s, args) => UpdateMoneyDisplay();
            formDoHomework.Show();
            this.Hide();
        }


        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();
        }

        private void buttonHargaDiteken(object sender, EventArgs e)
        {
            int price = 0;
            string namaItem="";
            Button btn = sender as Button;

            if (btn == buttonHarga5000) { price = 5000; namaItem = "Burger"; }
            else if (btn == buttonHarga6500) { price = 6500; namaItem = "Pizza"; }
            else if (btn == buttonHarga10000) { price = 10000; namaItem = "Spaghetti"; }
            else if (btn == buttonHarga4000) { price = 4000; namaItem = "Croissant"; }
            else if (btn == buttonHarga5500) { price = 5500; namaItem = "Sandwich"; }
            else if (btn == buttonHarga13000) { price = 13000; namaItem = "Cake"; }
            else if (btn == buttonHarga9000) { price = 9000; namaItem = "Cheese"; }
            else if (btn == buttonHarga11000) { price = 11000; namaItem = "Onigiri"; }
            else if (btn == buttonHarga3000) { price = 3000; namaItem = "Strawberry"; }

            if (price > 0 && UserStorage.currentUser != null)
            {
                if (insertedMoney >= price)
                {
                    insertedMoney -= price;

                    listBoxVendingMachine.Items.Add(namaItem);

                    MessageBox.Show($"You bought {namaItem} for Rp {price:N0}. Remaining inserted money: Rp {insertedMoney:N0}");

                    if (insertedMoney <= 0)
                    {
                        groupBoxVendingMachine.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Uang yang dimasukkan tidak cukup!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                UpdateMoneyDisplay();
            }
        }

        private void buttonPressButton_Click(object sender, EventArgs e)
        {
            if (targetPressCount == 0)
            {
                targetPressCount = rendem.Next(5, 20);
                currentPressCount = 0;
            }
            buttonPressButton.Text = "TEKAN ( " + currentPressCount + " / " + targetPressCount + " )";
            currentPressCount++;

            if (currentPressCount >= targetPressCount)
            {
                UserStorage.currentUser.money += 10000;
                MessageBox.Show("Congrats! dapet duid 10.000 🎉");
                UpdateMoneyDisplay();
                targetPressCount = 0;
                currentPressCount = 0;
            }
        }

        private void buttonDoStuff_Click(object sender, EventArgs e)
        {
            GuntingBatuKertas guntingBatuKertas = new GuntingBatuKertas();
            guntingBatuKertas.ShowDialog();
        }
    }
}
