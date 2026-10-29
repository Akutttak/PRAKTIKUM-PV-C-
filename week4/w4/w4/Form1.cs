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

namespace w4
{
    public partial class Form1 : Form
    {
        public int counter = 1;
        private DataSet ds;
        public DataTable dt;
        public int selected = -1;
        public DataTable dtOrderHeader;
        public DataTable dtOrderDetail;
        public DataTable dtPendingOrders;
        public Form1(DataSet pizzaDs)
        {
            InitializeComponent();

            this.ds = pizzaDs;
            this.dt = ds.Tables["Pizza"];

            dataGridView1.DataSource = dt;

            comboBox1.Items.Add("pan");
            comboBox1.Items.Add("thin");
            comboBox1.Items.Add("stuffed");

            buttonUpdate.Enabled = false;
            buttonDelete.Enabled = false;
            listBox1.Items.Add("alohhaaa");

            if (ds.Tables.Contains("OrderHeader"))
            {
                this.dtOrderHeader = ds.Tables["OrderHeader"];
                dataGridView2.DataSource = dtOrderHeader;

                this.dtPendingOrders = dtOrderHeader.Clone();
            }
            else
            {
                this.dtPendingOrders = new DataTable("PendingOrders");
                this.dtPendingOrders.Columns.Add("OrderID", typeof(string));
                this.dtPendingOrders.Columns.Add("Username", typeof(string));
                this.dtPendingOrders.Columns.Add("Tanggal", typeof(DateTime));
                this.dtPendingOrders.Columns.Add("Total", typeof(int));
                this.dtPendingOrders.Columns.Add("Items", typeof(string));
            }

            if (ds.Tables.Contains("OrderDetail"))
            {
                this.dtOrderDetail = ds.Tables["OrderDetail"];
            }

            UpdatePendingListBox();

            if (ds.Tables.Contains("OrderDetail"))
            {
                this.dtOrderDetail = ds.Tables["OrderDetail"];
            }
            UpdatePendingListBox();
            //this.dtPendingOrders = dtOrderHeader.Clone();
            //if (ds.Tables.Contains("PendingOrders"))
            //{
            //    this.dtPendingOrders = ds.Tables["PendingOrders"];
            //}

        }

        public void addDataToPitsahTable(string nama, string tipeh, DateTime tanggal, int harga, List<string> toppings, int stok)
        {
            this.dt = ds.Tables["Pizza"];
            //check validation duluh
            if (string.IsNullOrEmpty(nama) || nama.Length < 10)
            {
                MessageBox.Show("iki nama e kosong ato length nama e < 10 ");
                return;
            }

            if (harga <= 10000)
            {
                MessageBox.Show("harga e kenot kurang dari 10k bang");
                return;
            }

            if (stok < 1)
            {
                MessageBox.Show("stok e mek oleh minim 1");
                return;
            }
            if (toppings == null || toppings.Count == 0)
            {
                MessageBox.Show("At least select 1 topping pijah lahh");
                return;
            }

            string kode = "PZ";
            string counterString = counter.ToString("000");
            string finalId = $"{kode}{counterString}";

            counter++;

            DataRow dr = dt.NewRow();
            dr["PizzaId"] = finalId;
            dr["Nama"] = nama;
            dr["Tipe"] = tipeh;
            dr["ReleaseDate"] = tanggal;
            dr["Harga"] = harga;
            dr["Toppings"] = string.Join(", ", toppings);
            dr["Stok"] = stok;
            dt.Rows.Add(dr);

            dataGridView1.DataSource = dt;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string nama = textBox1.Text;
            int harga = (int)numericUpDown1.Value;
            int stok = (int)numericUpDown2.Value;
            DateTime tanggal = dateTimePicker1.Value;

            //combobox
            string selectedItem = null;
            if (comboBox1.SelectedItem != null)
            {
                selectedItem = comboBox1.SelectedItem.ToString();
            }

            if (string.IsNullOrEmpty(selectedItem))
            {
                MessageBox.Show("Please select a pizza type from the dropdown.", "Validation Error");
                return;
            }

            List<string> toppings = new List<string>();
            if (checkBoxCheese.Checked) toppings.Add("cheese");
            if (checkBoxBeef.Checked) toppings.Add("beef");
            if (checkBoxPeperoni.Checked) toppings.Add("peperoni");
            if (checkBoxTuna.Checked) toppings.Add("tuna");
            if (checkBoxMushroom.Checked) toppings.Add("mushroom");

            addDataToPitsahTable(nama, selectedItem, tanggal, harga, toppings, stok);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selected = e.RowIndex;
                textBox1.Text = dataGridView1.Rows[selected].Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[selected].Cells[2].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[selected].Cells[3].Value.ToString();
                numericUpDown1.Text = dataGridView1.Rows[selected].Cells[4].Value.ToString();
                numericUpDown2.Text = dataGridView1.Rows[selected].Cells[6].Value.ToString();
                string toppingsText = dataGridView1.Rows[selected].Cells[5].Value.ToString().ToLower();

                checkBoxCheese.Checked = toppingsText.Contains("cheese");
                checkBoxBeef.Checked = toppingsText.Contains("beef");
                checkBoxPeperoni.Checked = toppingsText.Contains("peperoni");
                checkBoxTuna.Checked = toppingsText.Contains("tuna");
                checkBoxMushroom.Checked = toppingsText.Contains("mushroom");

            }

            buttonDelete.Enabled = true;
            buttonUpdate.Enabled = true;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Text = "";
            numericUpDown1.Text = "";
            numericUpDown2.Text = "";
            checkBoxCheese.Checked = false;
            checkBoxBeef.Checked = false;
            checkBoxPeperoni.Checked = false;
            checkBoxTuna.Checked = false;
            checkBoxMushroom.Checked = false;

            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (selected != -1)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this row?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dt.Rows.RemoveAt(selected);

                    textBox1.Text = "";
                    comboBox1.Text = "";
                    dateTimePicker1.Text = "";
                    numericUpDown1.Text = "";
                    numericUpDown2.Text = "";
                    checkBoxCheese.Checked = false;
                    checkBoxBeef.Checked = false;
                    checkBoxPeperoni.Checked = false;
                    checkBoxTuna.Checked = false;
                    checkBoxMushroom.Checked = false;

                    selected = -1;
                }

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
                else if (type== "thin")
                {
                    dataGridView1.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.Aqua;
                }
                else if (type == "stuffed")
                {
                    dataGridView1.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.MediumPurple;
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("aaaaaaaa");
            if(e.RowIndex >= 0)
            {
                DataRow rowToUpdate = dt.Rows[e.RowIndex];
                string pizzaId = rowToUpdate["PizzaId"].ToString();
                int currentStock = Convert.ToInt32(rowToUpdate["Stok"]);

                tambahAksi formTambahAksi = new tambahAksi();

                if (formTambahAksi.ShowDialog() == DialogResult.OK)
                { 
                    int newStockAddition = formTambahAksi.NewStockValue;

                    if (newStockAddition <= 0)
                    {
                        MessageBox.Show("minim 1 weehh nambahe");
                        return;
                    }

                    rowToUpdate["Stok"] = currentStock + newStockAddition;

                    MessageBox.Show($"Stok Pizza ID {pizzaId} berhasil di-update.\nStok Lama: {currentStock}, Ditambah: {newStockAddition}, Stok Baru: {rowToUpdate["Stok"]}", "Update Berhasil");

                    dataGridView1.Refresh();
                }

                formTambahAksi.Dispose();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // Cek apakah ada baris yang dipilih
            if (selected == -1)
            {
                MessageBox.Show("Pilih baris Pizza yang ingin di-update terlebih dahulu.", "Peringatan");
                return;
            }

            //ambil all nilai 
            string nama = textBox1.Text;
            string selectedItem = comboBox1.SelectedItem?.ToString();
            DateTime tanggal = dateTimePicker1.Value;
            int harga = (int)numericUpDown1.Value;
            int stok = (int)numericUpDown2.Value;

            // para toppings toppings di cekbok
            List<string> toppings = new List<string>();
            if (checkBoxCheese.Checked) toppings.Add("cheese");
            if (checkBoxBeef.Checked) toppings.Add("beef");
            if (checkBoxPeperoni.Checked) toppings.Add("peperoni");
            if (checkBoxTuna.Checked) toppings.Add("tuna");
            if (checkBoxMushroom.Checked) toppings.Add("mushroom");

            string toppingsText = string.Join(", ", toppings);


            // RE-VALIDASI DATA (SAMA SEPERTI ADD)
            if (string.IsNullOrEmpty(nama) || nama.Length < 10)
            {
                MessageBox.Show("Nama tidak boleh kosong atau panjangnya kurang dari 10 karakter.", "Validasi Error");
                return;
            }
            if (string.IsNullOrEmpty(selectedItem))
            {
                MessageBox.Show("Tipe pizza harus dipilih.", "Validasi Error");
                return;
            }
            if (harga <= 10000)
            {
                MessageBox.Show("Harga minimal adalah 10,000.", "Validasi Error");
                return;
            }
            if (stok < 1)
            {
                MessageBox.Show("Stok minimal adalah 1.", "Validasi Error");
                return;
            }
            if (toppings.Count == 0)
            {
                MessageBox.Show("Pilih minimal 1 topping.", "Validasi Error");
                return;
            }

            // Update Baris DataTable
            try
            {
                DataRow rowToUpdate = dt.Rows[selected];

                rowToUpdate["Nama"] = nama;
                rowToUpdate["Tipe"] = selectedItem;
                rowToUpdate["ReleaseDate"] = tanggal; 
                rowToUpdate["Harga"] = harga;         
                rowToUpdate["Toppings"] = toppingsText;
                rowToUpdate["Stok"] = stok;           


                MessageBox.Show($"Data Pizza '{nama}' berhasil di-update!", "Update Berhasil");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat menyimpan data: {ex.Message}", "Error Database");
                return;
            }


            // Clear Form dan Reset Status
            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;

            checkBoxCheese.Checked = false;
            checkBoxBeef.Checked = false;
            checkBoxPeperoni.Checked = false;
            checkBoxTuna.Checked = false;
            checkBoxMushroom.Checked = false;

            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;

            // Reset selected row index
            selected = -1;
        }
        // Tambahkan method ini di Form1.cs
        // Di Form1.cs, method AddPendingOrder

        public void AddPendingOrder(string orderId, string username, DateTime tanggal, int total, string itemSummary)
        {
            MessageBox.Show("masuk add pending order");
            // 1. Tambahkan ke dtPendingOrders (DataTable sementara)
            DataRow pendingRow = dtPendingOrders.NewRow();
            pendingRow["OrderID"] = orderId;
            pendingRow["Username"] = username;
            pendingRow["Tanggal"] = tanggal;
            pendingRow["Total"] = total;

            pendingRow["Items"] = itemSummary; 
            dtPendingOrders.Rows.Add(pendingRow);

            // 2. Refresh ListBox
            UpdatePendingListBox();
        }

        private void UpdatePendingListBox()
        {
            listBox1.Items.Clear();
            MessageBox.Show($"masuk update pending listbox. Data rows count: {dtPendingOrders.Rows.Count}");
            //listBox1.Items.Add("ALOHHAAA TEST SUCCESS");
            //listBox1.Items.Add("Test Order 1");
            foreach (DataRow row in dtPendingOrders.Rows)
            {
                try
                {
                    string orderId = row["OrderID"].ToString();
                    string username = row["Username"].ToString(); 
                    int total = Convert.ToInt32(row["Total"]);    

                    string display = $"[{orderId}] {username} - Total: {total:N0}";
                    listBox1.Items.Add(display);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saat menampilkan data: {ex.Message}. Cek nama/tipe kolom!");
                    return;
                }
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;

            int selectedIndex = listBox1.SelectedIndex;

            DataRow rowToMove = dtPendingOrders.Rows[selectedIndex];

            string orderId = rowToMove["OrderID"].ToString();
            string username = rowToMove["Username"].ToString();
            DateTime tanggal = Convert.ToDateTime(rowToMove["Tanggal"]);
            int total = Convert.ToInt32(rowToMove["Total"]);

            string itemSummary = rowToMove["Items"].ToString();

            DataRow historyRow = dtOrderHeader.NewRow();
            historyRow["OrderID"] = orderId;
            historyRow["Username"] = username;
            historyRow["Tanggal"] = tanggal;
            historyRow["Total"] = total;
            historyRow["Items"] = itemSummary;
            dtOrderHeader.Rows.Add(historyRow);

            rowToMove.Delete();
            dtPendingOrders.AcceptChanges(); // Konfirmasi penghapusan

            UpdatePendingListBox();

            MessageBox.Show($"Order {orderId} Selesai dan dipindahkan ke History.\nTotal {total}", "Order Completed");
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
