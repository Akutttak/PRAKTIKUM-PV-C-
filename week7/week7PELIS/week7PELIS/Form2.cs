using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week7PELIS
{
    public partial class Form2 : Form
    {
        private string idResto;
        public Form2(string id)
        {
            InitializeComponent();
            idResto = id;
        }

        public void loadData()
        {
            DataSet ds = new DataSet();

            DataTable dtRestaurants = new DataTable("restaurants");
            string sqlRestaurants = "SELECT * FROM Restaurants WHERE RestaurantID = @id";

            using (MySqlConnection conn = koneksi.getConn())
            using (MySqlCommand cmdResto = new MySqlCommand(sqlRestaurants, conn))
            using (MySqlDataAdapter adapterResto = new MySqlDataAdapter(cmdResto))
            {
                cmdResto.Parameters.AddWithValue("@id", idResto);
                conn.Open();
                adapterResto.Fill(dtRestaurants);
            }

            ds.Tables.Add(dtRestaurants);

            DataTable dtNota = new DataTable("notah");
            string sqlNota = @"
                SELECT 
                    dtransorder.HTransID,
                    orders.OrderID,
                    orders.RestaurantID,
                    restaurants.Name AS RestaurantName,
                    restaurants.Address,
                    restaurants.Phone,
                    restaurants.Email,
                    restaurants.OpeningHours,
                    orders.CustomerName,
                    orders.CustomerAddress,
                    orders.CustomerPhone,
                    orders.OrderDate,
                    menuitems.Name AS NamaMenu,
                    menuitems.Price AS Harga,
                    dtransorder.Quantity,
                    dtransorder.Subtotal,
                    orders.OrderStatus
                FROM dtransorder
                JOIN htransorder ON htransorder.HTransID = dtransorder.HTransID
                JOIN orders ON htransorder.OrderID = orders.OrderID
                JOIN menuitems ON dtransorder.MenuID = menuitems.MenuID
                JOIN restaurants ON orders.RestaurantID = restaurants.RestaurantID
                WHERE restaurants.RestaurantID = @id
                ORDER BY dtransorder.HTransID, dtransorder.DTransID;
            ";

            using (MySqlConnection conn = koneksi.getConn())
            using (MySqlCommand cmdNota = new MySqlCommand(sqlNota, conn))
            using (MySqlDataAdapter adapterNota = new MySqlDataAdapter(cmdNota))
            {
                cmdNota.Parameters.AddWithValue("@id", idResto);
                conn.Open();
                adapterNota.Fill(dtNota);
            }

            ds.Tables.Add(dtNota);

            CrystalReport1 cr = new CrystalReport1();
            cr.SetDataSource(ds);

            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.RefreshReport();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 formm = new Form1();
            formm.ShowDialog();
        }
    }
}
