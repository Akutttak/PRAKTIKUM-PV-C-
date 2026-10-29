using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace week3
{
    public partial class formHistory : Form
    {
        private string connectionString;
        private User player;

        // Constructor menerima player dan connection string
        public formHistory(User player, string connectionString)
        {
            InitializeComponent();
            this.player = player;
            this.connectionString = connectionString;

            this.Load += FormHistory_Load; // panggil ShowSalesHistory saat form load

            // Ambil total revenue dari tabel sales
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT IFNULL(SUM(total_price), 0) FROM sales WHERE user_id = @user";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", player.Id);

                    object result = cmd.ExecuteScalar();
                    decimal totalRevenue = 0;

                    if (result != null && result != DBNull.Value)
                        totalRevenue = Convert.ToDecimal(result);

                    label1.Text = "TOTAL REVENUE: Rp " + totalRevenue.ToString("N0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil total revenue: " + ex.Message);
                label1.Text = "TOTAL REVENUE: Rp 0";
            }
        }


        private void FormHistory_Load(object sender, EventArgs e)
        {
            ShowSalesHistory();
        }

        private void ShowSalesHistory()
        {
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        string query = @"
                            SELECT day, wood_name AS 'Item', quantity AS 'Qty', price_per_item AS 'Unit Price', 
                                   total_price AS 'Revenue'
                            FROM sales
                            WHERE user_id = @user
                            ORDER BY sale_date DESC";

                        MySqlCommand cmd = new MySqlCommand(query, conn, transaction);
                        cmd.Parameters.AddWithValue("@user", player.Id);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        transaction.Commit();
                    }
                }

                // Tampilkan di DataGridView
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat history penjualan: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
