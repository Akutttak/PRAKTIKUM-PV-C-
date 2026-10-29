using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week7PELIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataSet1 ds;
        public void loadData()
        {
            ds = new DataSet1();
            using (MySqlConnection conn = koneksi.getConn())
            {
                conn.Open();
                MySqlDataAdapter da
                    = new MySqlDataAdapter("SELECT RestaurantID, NAME, Address, Phone, Email, OpeningHours\r\nFROM restaurants;", conn);
                da.Fill(ds, "restaurants");
                dataGridView1.DataSource = ds.Tables["restaurants"];

                //if (ds.Tables["restaurants"].Rows.Count == 0)
                //{
                //    //crystalReportViewer1.ReportSource = null;
                //    MessageBox.Show("Tidak ada data untuk ditampilkan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
            //LoadRestaurants();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string selectedRestaurantID = dataGridView1.Rows[e.RowIndex].Cells["RestaurantID"].Value.ToString();
                this.Hide();
                //MessageBox.Show("haloh");
                Form2 form2 = new Form2(selectedRestaurantID);
                form2.ShowDialog();
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
