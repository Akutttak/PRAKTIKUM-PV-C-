using System;
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
    public partial class GuntingBatuKertas : Form
    {
        Random rand = new Random();
        string[] choices = { "Rock", "Paper", "Scissors" };

        public GuntingBatuKertas()
        {
            InitializeComponent();
        }

        private void buttonGunting_Click(object sender, EventArgs e)
        {
            Play("Scissors");
        }

        private void buttonBatu_Click(object sender, EventArgs e)
        {
            Play("Rock");
        }

        private void buttonKertas_Click(object sender, EventArgs e)
        {
            Play("Paper");
        }

        private void Play(string userChoice)
        {
            string computerChoice = choices[rand.Next(choices.Length)];

            string result = $"You: {userChoice}\nComputer: {computerChoice}\n\n";

            if (userChoice == computerChoice)
            {
                result += "It's a Draw!";
            }
            else if ((userChoice == "Rock" && computerChoice == "Scissors") ||
                     (userChoice == "Paper" && computerChoice == "Rock") ||
                     (userChoice == "Scissors" && computerChoice == "Paper"))
            {
                result += "You Win!";
            }
            else
            {
                result += "You Lose!";
            }

            labelMenangApaKalah.Text = result;

            //FormVendingMachine vendingMachine = new FormVendingMachine();
            //vendingMachine.ShowDialog();
            //this.Hide();
        }
    }
}
