using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week1
{
    public partial class DoHomework : Form
    {
        int jawaban;
        Random rand = new Random();

        int num1;
        int num2;
        string[] operators = { "+", "-", "*", "/" };
        public static string op;
        public DoHomework()
        {
            InitializeComponent();

            num1 = rand.Next(1, 99);
            num2 = rand.Next(1, 99);

            op = operators[rand.Next(operators.Length)];

            labelPertanyaan.Text = $"{num1} {op} {num2}";


            if (op.Equals("+"))
            {
                jawaban = num1 + num2;
            }
            else if (op.Equals("-"))
            {
                jawaban = num1 - num2;
            }
            else if (op.Equals("*"))
            {
                jawaban = num1 * num2;
            }
            else
            {
                jawaban = num1 / num2;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (jawaban.ToString() == textBoxJawabanUser.Text)
            {
                MessageBox.Show("Selamat jawaban anda benar, anda mendapatkan uang sebesar Rp 10.000");
                UserStorage.currentUser.money += 10000;
                this.Hide();
                FormVendingMachine vendingMachine = new FormVendingMachine();
                vendingMachine.ShowDialog();
            }
            else
            {
                MessageBox.Show("jawaban salah kasian ga dapat uang");
                MessageBox.Show("ini jawabannya bwang: " + num1 + op + num2 + " = " + jawaban);
            }
        }
    }
}
