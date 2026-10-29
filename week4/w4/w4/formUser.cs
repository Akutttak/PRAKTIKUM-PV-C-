using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace w4
{
    public partial class formUser : Form
    {
        public int selected = -1;
        public DataTable pizzaTable;
        //public DataTable kerangjangTable;
        public DataSet sharedDs;
        public string currentUsername;
        public DataTable dtOrderHeader;
        public DataTable dtOrderDetail;
        public int orderCounter = 1;
        public DataTable dtKeranjang;

        public Form1 adminForm;

        public formUser(DataSet sharingDataSet, string username, Form1 adminReference)
        {
            InitializeComponent();

            this.sharedDs = sharingDataSet;
            this.currentUsername = username;
            this.adminForm = adminReference;

            if (sharedDs.Tables.Contains("Pizza"))
            {
                pizzaTable = sharingDataSet.Tables["Pizza"];
                dataGridView1.DataSource = pizzaTable;

                if (sharedDs.Tables.Contains("Keranjang"))
                {
                    dtKeranjang = sharedDs.Tables["Keranjang"];
                    dataGridViewKeranjang.DataSource = dtKeranjang;
                }
            }
            else
            {
                MessageBox.Show("Error: The 'Pizza' DataTable was not found in the shared DataSet.", "Data Table Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (sharedDs.Tables.Contains("OrderHeader"))
            {
                this.dtOrderHeader = sharedDs.Tables["OrderHeader"];
            }
            if (sharedDs.Tables.Contains("OrderDetail"))
            {
                this.dtOrderDetail = sharedDs.Tables["OrderDetail"];
            }
            if (sharedDs.Tables.Contains("Keranjang"))
            {
                this.dtKeranjang = sharedDs.Tables["Keranjang"];
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells[2].Value != null)
            {
                string type = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                if (type == "pan")
                {
                    dataGridView1.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.Yellow;
                }
                else if (type == "thin")
                {
                    dataGridView1.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.Aqua;
                }
                else if (type == "stuffed")
                {
                    dataGridView1.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.MediumPurple;
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selected = e.RowIndex;

                string pizzaId = dataGridView1.Rows[selected].Cells[0].Value.ToString();
                string nama = dataGridView1.Rows[selected].Cells[1].Value.ToString();
                int harga = Convert.ToInt32(dataGridView1.Rows[selected].Cells[4].Value);

                //MessageBox.Show($"{nama} {tipe} {harga} {toppingsText}");

                addDataToKeranjangTable(pizzaId, nama, harga, this.currentUsername);
            }
        }
        public void addDataToKeranjangTable(string id, string nama, int harga, string username)
        {
            if (dtKeranjang == null) return;

            string filterExpression = $"PizzaId = '{id}'";
            DataRow[] foundRows = dtKeranjang.Select(filterExpression);

            DataRow existingRow = null;
            if (foundRows.Length > 0)
            {
                existingRow = foundRows[0];
            }

            string toppingsText = pizzaTable.Rows[selected]["Toppings"].ToString();


            if (existingRow != null)
            {
                int currentQty = Convert.ToInt32(existingRow["Qty"]);
                currentQty++;

                existingRow["Qty"] = currentQty;
                existingRow["Subtotal"] = currentQty * harga;
            }
            else
            {
                DataRow newRow = dtKeranjang.NewRow();
                newRow["PizzaId"] = id;
                newRow["Nama"] = nama;
                newRow["Harga"] = harga;
                newRow["Qty"] = 1;
                newRow["Subtotal"] = harga;
                newRow["username"] = username;

                dtKeranjang.Rows.Add(newRow);
            }
        }

        private void buttonRemoveItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("masuk btn remove item");
            if (selected != -1)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this row?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dtKeranjang.Rows.RemoveAt(selected);

                    selected = -1;
                }
            }
        }

        private void buttonClearCart_Click(object sender, EventArgs e)
        {
            dtKeranjang.Rows.Clear();
        }

        private void dataGridViewKeranjang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selected = e.RowIndex;

                string pizzaId = dataGridView1.Rows[selected].Cells[0].Value.ToString();
                string nama = dataGridView1.Rows[selected].Cells[1].Value.ToString();
                int harga = Convert.ToInt32(dataGridView1.Rows[selected].Cells[4].Value);
            }
        }

        private void buttonOrder_Click(object sender, EventArgs e)
        {
            // Cek inisialisasi tabel Order sebelum digunakan
            if (dtKeranjang == null || dtOrderHeader == null || dtOrderDetail == null) return;

            // Filter Keranjang HANYA untuk User yang sedang Login 
            DataRow[] userCartRows = dtKeranjang.Select($"Username = '{this.currentUsername}'");

            if (userCartRows.Length == 0)
            {
                MessageBox.Show("Keranjang Anda kosong. Silakan tambahkan minimal satu item untuk Order.",
                                "Keranjang Kosong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int totalOrder = 0;
            string orderId = GenerateNewOrderId();

            
            foreach (DataRow cartRow in userCartRows)
            {
                totalOrder += Convert.ToInt32(cartRow["Subtotal"]);
                string pizzaId = cartRow["PizzaId"].ToString();
                int qtyOrdered = Convert.ToInt32(cartRow["Qty"]);

                DataRow[] pizzaToUpdate = pizzaTable.Select($"PizzaId = '{pizzaId}'");
                if (pizzaToUpdate.Length > 0 && Convert.ToInt32(pizzaToUpdate[0]["Stok"]) < qtyOrdered)
                {
                    MessageBox.Show($"Stok {cartRow["Nama"]} tidak cukup ({pizzaToUpdate[0]["Stok"]}). Order dibatalkan.",
                                    "Stok Kurang", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string itemSummary = "";
            int uniqueItemCount = 0;

            foreach (DataRow cartRow in dtKeranjang.Rows)
            {
                string namaPizza = cartRow["Nama"].ToString();
                int qty = Convert.ToInt32(cartRow["Qty"]);

                // Format: [Nama Pizza x Qty]
                if (!string.IsNullOrEmpty(itemSummary))
                {
                    itemSummary += "; "; // Pemisah
                }
                itemSummary += $"{namaPizza} x {qty}";
                uniqueItemCount++;
            }

            // Tambahkan ringkasan total item (opsional, tapi bagus)
            if (uniqueItemCount > 0)
            {
                // Contoh: "3 item: Pizza A x 1; Pizza B x 2"
                itemSummary = $"{uniqueItemCount} item: {itemSummary}";
            }

            if (adminForm != null)
            {
                adminForm.AddPendingOrder(orderId, this.currentUsername, DateTime.Now, totalOrder, itemSummary);
            }

            foreach (DataRow cartRow in userCartRows)
            {
                string pizzaId = cartRow["PizzaId"].ToString();
                int qtyOrdered = Convert.ToInt32(cartRow["Qty"]);
                int itemHarga = Convert.ToInt32(cartRow["Harga"]);

                DataRow detailRow = dtOrderDetail.NewRow();
                detailRow["OrderID"] = orderId;
                detailRow["PizzaId"] = pizzaId;
                detailRow["Nama"] = cartRow["Nama"].ToString();
                detailRow["HargaJual"] = itemHarga;
                detailRow["Qty"] = qtyOrdered;
                dtOrderDetail.Rows.Add(detailRow); 

                // b. Update Stok di PizzaTable
                DataRow[] pizzaToUpdate = pizzaTable.Select($"PizzaId = '{pizzaId}'");
                if (pizzaToUpdate.Length > 0)
                {
                    DataRow pizzaRow = pizzaToUpdate[0];
                    pizzaRow["Stok"] = Convert.ToInt32(pizzaRow["Stok"]) - qtyOrdered;
                }
            }

            for (int i = userCartRows.Length - 1; i >= 0; i--)
            {
                userCartRows[i].Delete();
            }
            dtKeranjang.AcceptChanges();

            MessageBox.Show($"Order Berhasil! ID Order: {orderId}. Total: {totalOrder:N0}",
                                    "Order Selesai", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Method ini sekarang akan berfungsi karena this.orderCounter sudah dideklarasikan
        private string GenerateNewOrderId()
        {
            string prefix = "ORD";
            string datePart = DateTime.Now.ToString("yyyyddMM");
            string counterString = this.orderCounter.ToString("00000"); // Menggunakan this.orderCounter
            string finalId = $"{prefix}{datePart}{counterString}";
            this.orderCounter++;
            return finalId;
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                this.Close();
            }
        }
    }
}
