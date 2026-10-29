using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace w4
{
    public partial class tambahAksi : Form
    {
        public int NewStockValue { get; private set; } = 0;
        public tambahAksi()
        {
            InitializeComponent();
        }

        private void tambahAksi_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewStockValue = (int)this.numericUpDown1.Value;
            this.DialogResult = DialogResult.OK; // Set dialog result untuk konfirmasi ke Form1
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
