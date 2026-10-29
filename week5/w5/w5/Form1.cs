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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace w5
{
    public partial class Form1 : Form
    {
        public string koneksi = "Server=localhost; Database=pv_t5_224117124; UserID=root; Password=;";
        MySqlConnection conn;
        public int selected = -1;
        private string currentUser;
        private string currentName;


        public Form1(string username)
        {
            InitializeComponent();
            connectDatabase();

            currentUser = username;
            currentName = getNameFromUsername(username);

            label1.Text = $"WELKAMMM, {currentName}!";
            generateStudioId();

            //label8.Text = generateStudioId();

            ////idk kenapa generateStudioId e gamau ke update

            //string idStudioGes = generateStudioId();

            //try
            //{
            //    if (conn.State == ConnectionState.Closed)
            //    {
            //        conn.Open();
            //    }

            //    // kalau tujuannya INSERT studio baru
            //    string query = "INSERT INTO studio (studioId, studioName, basePrice) VALUES (@studioId, @studioName, @basePrice)";
            //    MySqlCommand cmd = new MySqlCommand(query, conn);
            //    cmd.Parameters.AddWithValue("@studioId", idStudioGes);
            //    cmd.Parameters.AddWithValue("@studioName", "Studio Baru"); // atau ambil dari textbox
            //    cmd.Parameters.AddWithValue("@basePrice", 50000); // ganti sesuai inputan

            //    cmd.ExecuteNonQuery(); // <- ini penting
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error waktu input generateStudioId ke DB: " + ex.Message);
            //}
            //finally
            //{
            //    if (conn.State == ConnectionState.Open)
            //        conn.Close();
            //}


            refreshDGV();
            loadComboBox();
            currentUser = username;

            label6.Text = "lek mau tambah movie id e : " + generateMovieId();

            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.Name = "Seat";
            btnColumn.HeaderText = "Seats";
            btnColumn.Text = "See Seats";
            btnColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnColumn);

            button4.Enabled = false;
            button5.Enabled = false;
        }

        public void connectDatabase()
        {
            conn = new MySqlConnection(koneksi);

            try
            {
                conn.Open(); 
                conn.Close(); 
                MessageBox.Show("database connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void refreshDGV()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string query = "SELECT m.movieId, m.title, m.genre, m.duration, s.studioId, s.studioName, s.basePrice\r\nFROM movie m\r\nJOIN studio s ON s.studioId=m.studioId;";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void clear()
        {
            textBox1.Text = "";
            numericUpDown1.Value = 0;
            comboBox1.Text = "";

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;

            comboBox1.SelectedIndex = -1;
        }
        public void loadComboBox()
        {
            conn.Open();

            string query = "SELECT studioId, studioName FROM studio";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "studioName";
            comboBox1.ValueMember = "studioId"; 

            comboBox1.SelectedIndex = -1;

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            conn.Close();
        }

        public string generateMovieId()
        {
            string nextId = "MOV004";

            if (conn == null) conn = new MySqlConnection(koneksi);

            try
            {
                conn.Open();

                string query = "SELECT MAX(movieId) FROM movie";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    string maxId = result.ToString();

                    string numPart = maxId.Substring(3);
                    int currentNum = int.Parse(numPart);

                    int nextNum = currentNum + 1;

                    nextId = "MOV" + nextNum.ToString("D3");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating Movie ID: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return nextId;
        }

        public string generateStudioId()
        {
            string nextCode = "STD001";
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT MAX(studioId) FROM studio";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    string maxCode = result.ToString().Trim();

                    // Pastikan format valid: minimal 6 karakter dan diawali “STD”
                    if (!string.IsNullOrEmpty(maxCode) && maxCode.StartsWith("STD") && maxCode.Length >= 6)
                    {
                        int currentNum = int.Parse(maxCode.Substring(3)); // ambil angka setelah “STD”
                        nextCode = "STD" + (currentNum + 1).ToString("D3");
                    }
                    else
                    {
                        nextCode = "STD001"; // fallback kalau datanya aneh
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating Studio Code: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return nextCode;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //button add movie

            string movieId = generateMovieId();
            string title = textBox1.Text;
            decimal duration = numericUpDown1.Value;
            //string studio = comboBox1.SelectedIndex.ToString();
            string genre = getSelectedCheckBox();
            string studioId = (comboBox1.SelectedValue != null) ? comboBox1.SelectedValue.ToString() : studioId = "";
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (title == "" || duration <= 0 || studioId == "" || genre == "")
                {
                    MessageBox.Show("masukkan inputan yang valid!");
                    return;
                }

                if (duration < 60)
                {
                    MessageBox.Show("durasi e < 60 kenot");
                    return;
                }

                if (title.Length < 10)
                {
                    MessageBox.Show("title lenght e < 10 kenot");
                    return;
                }

                string query = "INSERT INTO movie (movieId, title, genre, duration, studioId) VALUES (@movieId, @title, @genre, @duration, @studioId)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@movieId", movieId);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@genre", genre);
                cmd.Parameters.AddWithValue("@duration", duration);
                cmd.Parameters.AddWithValue("@studioId", studioId);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Data isa ke insert wehh");
                    refreshDGV();
                    clear();
                }
                else
                {
                    MessageBox.Show("Failed to insert data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //button update movie
            string movieId = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string title = textBox1.Text;
            decimal duration = numericUpDown1.Value;
            string genre = getSelectedCheckBox();
            string studioId = (comboBox1.SelectedValue != null) ? comboBox1.SelectedValue.ToString() : studioId = "";
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (title == "" || duration <= 0 || studioId == "" || genre == "")
                {
                    MessageBox.Show("masukkan inputan yang valid!");
                    return;
                }

                if (duration < 60)
                {
                    MessageBox.Show("durasi e < 60 kenot");
                    return;
                }

                if (title.Length < 10)
                {
                    MessageBox.Show("title lenght e < 10 kenot");
                    return;
                }

                string query = "UPDATE movie SET title = @title,genre = @genre,duration = @duration,studioId = @studioId WHERE movieId = @movieId;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@movieId", movieId);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@genre", genre);
                cmd.Parameters.AddWithValue("@duration", duration);
                cmd.Parameters.AddWithValue("@studioId", studioId);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Data isa ke update wehhoo");
                    refreshDGV();
                    clear();
                }
                else
                {
                    MessageBox.Show("Failed to update data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error waktu updatee: " + ex.Message);
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //button del movie
            if (button5.Enabled == true)
            {
                MessageBox.Show("cihuyy bisa delete");
            }
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("pilih dulu lah data yg mau di del");
            }
            string aidiMovieh = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            DialogResult dialogResult = MessageBox.Show(
                "Apakah anda yakin ingin menghapus data ini?",
                "Delete Alert",
                MessageBoxButtons.YesNo
            );
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    conn.Open();

                    string query = "DELETE FROM movie WHERE movieId = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", aidiMovieh);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Data berhasil dihapus");
                        label6.Text = "lek mau tambah movie id e : " + generateMovieId();
                        button5.Enabled = false;

                        // reset selectedId
                        refreshDGV();
                    }
                    else
                    {
                        MessageBox.Show("yahh kenot hapus data");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error saat del: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //button clear
            clear();
            button3.Enabled = true;
            button4.Enabled = false; // entah iki del ta up pokok e disable ws
            button5.Enabled = false; // entah iki del ta up
        }

        public string getSelectedCheckBox()
        {
            List<string> selectedGenre = new List<string>();

            if (checkBox1.Checked)
            {
                selectedGenre.Add("Action");
            }
            else if (checkBox2.Checked) {
                selectedGenre.Add("Comedy");
            }
            else if (checkBox3.Checked)
            {
                selectedGenre.Add("Drama");
            }
            else if (checkBox4.Checked) {
                selectedGenre.Add("Sci-fi");
            }
            else if (checkBox5.Checked)
            {
                selectedGenre.Add("Animation");
            }
            else if (checkBox6.Checked)
            {
                selectedGenre.Add("Horror");
            }
            return string.Join(",", selectedGenre);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            button3.Enabled = false; // Disable ADD
            button4.Enabled = true;  // Enable Update
            button5.Enabled = true;  // Enable Delete

            clear();

            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                string movieId = row.Cells[0].Value.ToString();

                label7.Text = "current movId: " + dataGridView1.CurrentRow.Cells[1].Value.ToString();

                textBox1.Text = row.Cells[2].Value.ToString();

                MessageBox.Show($"Cell[3] value: {row.Cells[3].Value}");


                numericUpDown1.Value = Convert.ToDecimal(row.Cells[4].Value);

                //MessageBox.Show($"inih numeric: {numericUpDown1.Value} + 1 = {numericUpDown1.Value + 1}");

                comboBox1.SelectedValue = row.Cells[5].Value.ToString();

                string genres = row.Cells[3].Value.ToString();

                if (genres.Contains("Action")) checkBox1.Checked = true;
                if (genres.Contains("Comedy")) checkBox2.Checked = true;
                if (genres.Contains("Drama")) checkBox3.Checked = true;
                if (genres.Contains("Horror")) checkBox6.Checked = true;
                if (genres.Contains("Animation")) checkBox5.Checked = true;
                if (genres.Contains("Sci-Fi")) checkBox4.Checked = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading movie data: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public string getNameFromUsername(string username)
        {
            string name = "";

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string query = "SELECT nama FROM user WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    name = result.ToString();
                }
                else
                {
                    name = username; // fallback kalau tidak ada nama
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error mengambil nama: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return name;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            login formLogin = new login();
            formLogin.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string namaStudio = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            decimal hargaStudio = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[7].Value);
            string movieYgPlaying = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            MessageBox.Show(namaStudio  + "+" +  hargaStudio);
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Seats" && e.RowIndex >= 0)
            {
                Seats formSeatAdmin = new Seats(namaStudio, movieYgPlaying, hargaStudio);
                formSeatAdmin.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            addStudio formAddStudio = new addStudio();
            formAddStudio.ShowDialog();
        }
    }
}
