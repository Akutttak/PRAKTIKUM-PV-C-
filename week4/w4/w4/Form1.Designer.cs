namespace w4
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.order = new w4.Order();
            this.labelTitlePizza = new System.Windows.Forms.Label();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.labelTitleHistoryTransaksi = new System.Windows.Forms.Label();
            this.labelListAntrian = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.groupBoxParaButton = new System.Windows.Forms.GroupBox();
            this.checkBoxMushroom = new System.Windows.Forms.CheckBox();
            this.checkBoxTuna = new System.Windows.Forms.CheckBox();
            this.checkBoxPeperoni = new System.Windows.Forms.CheckBox();
            this.checkBoxBeef = new System.Windows.Forms.CheckBox();
            this.checkBoxCheese = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelNamaPizza = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pijah = new w4.Pijah();
            this.pizzaIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.releaseDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hargaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toppingsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aksi = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.order)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxParaButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pijah)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pizzaIdDataGridViewTextBoxColumn,
            this.namaDataGridViewTextBoxColumn,
            this.tipeDataGridViewTextBoxColumn,
            this.releaseDateDataGridViewTextBoxColumn,
            this.hargaDataGridViewTextBoxColumn,
            this.toppingsDataGridViewTextBoxColumn,
            this.Stok,
            this.Aksi});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 52);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1412, 177);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 261);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(952, 164);
            this.dataGridView2.TabIndex = 1;
            // 
            // bindingSource2
            // 
            this.bindingSource2.AllowNew = true;
            this.bindingSource2.DataMember = "Order";
            this.bindingSource2.DataSource = this.order;
            // 
            // order
            // 
            this.order.DataSetName = "Order";
            this.order.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelTitlePizza
            // 
            this.labelTitlePizza.AutoSize = true;
            this.labelTitlePizza.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitlePizza.Location = new System.Drawing.Point(569, 9);
            this.labelTitlePizza.Name = "labelTitlePizza";
            this.labelTitlePizza.Size = new System.Drawing.Size(176, 25);
            this.labelTitlePizza.TabIndex = 2;
            this.labelTitlePizza.Text = "Pizza Dashboard";
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Location = new System.Drawing.Point(1301, 14);
            this.buttonLogOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(92, 33);
            this.buttonLogOut.TabIndex = 3;
            this.buttonLogOut.Text = "Log Out";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(1001, 261);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(423, 164);
            this.listBox1.TabIndex = 4;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // labelTitleHistoryTransaksi
            // 
            this.labelTitleHistoryTransaksi.AutoSize = true;
            this.labelTitleHistoryTransaksi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleHistoryTransaksi.Location = new System.Drawing.Point(13, 235);
            this.labelTitleHistoryTransaksi.Name = "labelTitleHistoryTransaksi";
            this.labelTitleHistoryTransaksi.Size = new System.Drawing.Size(158, 20);
            this.labelTitleHistoryTransaksi.TabIndex = 5;
            this.labelTitleHistoryTransaksi.Text = "History Transaksi";
            // 
            // labelListAntrian
            // 
            this.labelListAntrian.AutoSize = true;
            this.labelListAntrian.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListAntrian.Location = new System.Drawing.Point(1003, 238);
            this.labelListAntrian.Name = "labelListAntrian";
            this.labelListAntrian.Size = new System.Drawing.Size(175, 20);
            this.labelListAntrian.TabIndex = 6;
            this.labelListAntrian.Text = "List Order (Antrian)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonClear);
            this.groupBox1.Controls.Add(this.buttonDelete);
            this.groupBox1.Controls.Add(this.buttonUpdate);
            this.groupBox1.Controls.Add(this.buttonAdd);
            this.groupBox1.Controls.Add(this.groupBoxParaButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.labelNamaPizza);
            this.groupBox1.Location = new System.Drawing.Point(12, 444);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1244, 187);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(1023, 117);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(101, 37);
            this.buttonClear.TabIndex = 14;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(911, 117);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(101, 37);
            this.buttonDelete.TabIndex = 13;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(800, 117);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(101, 37);
            this.buttonUpdate.TabIndex = 12;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(691, 117);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(101, 37);
            this.buttonAdd.TabIndex = 11;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // groupBoxParaButton
            // 
            this.groupBoxParaButton.Controls.Add(this.checkBoxMushroom);
            this.groupBoxParaButton.Controls.Add(this.checkBoxTuna);
            this.groupBoxParaButton.Controls.Add(this.checkBoxPeperoni);
            this.groupBoxParaButton.Controls.Add(this.checkBoxBeef);
            this.groupBoxParaButton.Controls.Add(this.checkBoxCheese);
            this.groupBoxParaButton.Location = new System.Drawing.Point(691, 14);
            this.groupBoxParaButton.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxParaButton.Name = "groupBoxParaButton";
            this.groupBoxParaButton.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxParaButton.Size = new System.Drawing.Size(388, 97);
            this.groupBoxParaButton.TabIndex = 10;
            this.groupBoxParaButton.TabStop = false;
            this.groupBoxParaButton.Text = "Toppings";
            // 
            // checkBoxMushroom
            // 
            this.checkBoxMushroom.AutoSize = true;
            this.checkBoxMushroom.Location = new System.Drawing.Point(265, 28);
            this.checkBoxMushroom.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxMushroom.Name = "checkBoxMushroom";
            this.checkBoxMushroom.Size = new System.Drawing.Size(92, 20);
            this.checkBoxMushroom.TabIndex = 4;
            this.checkBoxMushroom.Text = "Mushroom";
            this.checkBoxMushroom.UseVisualStyleBackColor = true;
            // 
            // checkBoxTuna
            // 
            this.checkBoxTuna.AutoSize = true;
            this.checkBoxTuna.Location = new System.Drawing.Point(145, 60);
            this.checkBoxTuna.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxTuna.Name = "checkBoxTuna";
            this.checkBoxTuna.Size = new System.Drawing.Size(60, 20);
            this.checkBoxTuna.TabIndex = 3;
            this.checkBoxTuna.Text = "Tuna";
            this.checkBoxTuna.UseVisualStyleBackColor = true;
            // 
            // checkBoxPeperoni
            // 
            this.checkBoxPeperoni.AutoSize = true;
            this.checkBoxPeperoni.Location = new System.Drawing.Point(145, 28);
            this.checkBoxPeperoni.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxPeperoni.Name = "checkBoxPeperoni";
            this.checkBoxPeperoni.Size = new System.Drawing.Size(84, 20);
            this.checkBoxPeperoni.TabIndex = 2;
            this.checkBoxPeperoni.Text = "Peperoni";
            this.checkBoxPeperoni.UseVisualStyleBackColor = true;
            // 
            // checkBoxBeef
            // 
            this.checkBoxBeef.AutoSize = true;
            this.checkBoxBeef.Location = new System.Drawing.Point(20, 60);
            this.checkBoxBeef.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxBeef.Name = "checkBoxBeef";
            this.checkBoxBeef.Size = new System.Drawing.Size(57, 20);
            this.checkBoxBeef.TabIndex = 1;
            this.checkBoxBeef.Text = "Beef";
            this.checkBoxBeef.UseVisualStyleBackColor = true;
            // 
            // checkBoxCheese
            // 
            this.checkBoxCheese.AutoSize = true;
            this.checkBoxCheese.Location = new System.Drawing.Point(20, 28);
            this.checkBoxCheese.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxCheese.Name = "checkBoxCheese";
            this.checkBoxCheese.Size = new System.Drawing.Size(74, 20);
            this.checkBoxCheese.TabIndex = 0;
            this.checkBoxCheese.Text = "cheese";
            this.checkBoxCheese.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(283, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Stok";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(351, 113);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(100, 22);
            this.numericUpDown2.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(381, 68);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Release Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Harga";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(85, 111);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(160, 22);
            this.numericUpDown1.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(85, 71);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 24);
            this.comboBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipe";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 28);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(561, 22);
            this.textBox1.TabIndex = 1;
            // 
            // labelNamaPizza
            // 
            this.labelNamaPizza.AutoSize = true;
            this.labelNamaPizza.Location = new System.Drawing.Point(13, 32);
            this.labelNamaPizza.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNamaPizza.Name = "labelNamaPizza";
            this.labelNamaPizza.Size = new System.Drawing.Size(44, 16);
            this.labelNamaPizza.TabIndex = 0;
            this.labelNamaPizza.Text = "Nama";
            // 
            // bindingSource1
            // 
            this.bindingSource1.AllowNew = true;
            this.bindingSource1.DataMember = "Pizza";
            this.bindingSource1.DataSource = this.pijah;
            // 
            // pijah
            // 
            this.pijah.DataSetName = "Pijah";
            this.pijah.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pizzaIdDataGridViewTextBoxColumn
            // 
            this.pizzaIdDataGridViewTextBoxColumn.DataPropertyName = "PizzaId";
            this.pizzaIdDataGridViewTextBoxColumn.HeaderText = "PizzaId";
            this.pizzaIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pizzaIdDataGridViewTextBoxColumn.Name = "pizzaIdDataGridViewTextBoxColumn";
            this.pizzaIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // namaDataGridViewTextBoxColumn
            // 
            this.namaDataGridViewTextBoxColumn.DataPropertyName = "Nama";
            this.namaDataGridViewTextBoxColumn.HeaderText = "Nama";
            this.namaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.namaDataGridViewTextBoxColumn.Name = "namaDataGridViewTextBoxColumn";
            this.namaDataGridViewTextBoxColumn.Width = 125;
            // 
            // tipeDataGridViewTextBoxColumn
            // 
            this.tipeDataGridViewTextBoxColumn.DataPropertyName = "Tipe";
            this.tipeDataGridViewTextBoxColumn.HeaderText = "Tipe";
            this.tipeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tipeDataGridViewTextBoxColumn.Name = "tipeDataGridViewTextBoxColumn";
            this.tipeDataGridViewTextBoxColumn.Width = 125;
            // 
            // releaseDateDataGridViewTextBoxColumn
            // 
            this.releaseDateDataGridViewTextBoxColumn.DataPropertyName = "ReleaseDate";
            this.releaseDateDataGridViewTextBoxColumn.HeaderText = "ReleaseDate";
            this.releaseDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.releaseDateDataGridViewTextBoxColumn.Name = "releaseDateDataGridViewTextBoxColumn";
            this.releaseDateDataGridViewTextBoxColumn.Width = 125;
            // 
            // hargaDataGridViewTextBoxColumn
            // 
            this.hargaDataGridViewTextBoxColumn.DataPropertyName = "Harga";
            this.hargaDataGridViewTextBoxColumn.HeaderText = "Harga";
            this.hargaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hargaDataGridViewTextBoxColumn.Name = "hargaDataGridViewTextBoxColumn";
            this.hargaDataGridViewTextBoxColumn.Width = 125;
            // 
            // toppingsDataGridViewTextBoxColumn
            // 
            this.toppingsDataGridViewTextBoxColumn.DataPropertyName = "Toppings";
            this.toppingsDataGridViewTextBoxColumn.HeaderText = "Toppings";
            this.toppingsDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.toppingsDataGridViewTextBoxColumn.Name = "toppingsDataGridViewTextBoxColumn";
            this.toppingsDataGridViewTextBoxColumn.Width = 125;
            // 
            // Stok
            // 
            this.Stok.DataPropertyName = "Stok";
            this.Stok.HeaderText = "Stok";
            this.Stok.MinimumWidth = 6;
            this.Stok.Name = "Stok";
            this.Stok.Width = 125;
            // 
            // Aksi
            // 
            this.Aksi.HeaderText = "Aksi";
            this.Aksi.MinimumWidth = 6;
            this.Aksi.Name = "Aksi";
            this.Aksi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Aksi.Text = "TambahAksi";
            this.Aksi.UseColumnTextForButtonValue = true;
            this.Aksi.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1436, 646);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelListAntrian);
            this.Controls.Add(this.labelTitleHistoryTransaksi);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.labelTitlePizza);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.order)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxParaButton.ResumeLayout(false);
            this.groupBoxParaButton.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pijah)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private Pijah pijah;
        private System.Windows.Forms.BindingSource bindingSource2;
        private Order order;
        private System.Windows.Forms.Label labelTitlePizza;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label labelTitleHistoryTransaksi;
        private System.Windows.Forms.Label labelListAntrian;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelNamaPizza;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.GroupBox groupBoxParaButton;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.CheckBox checkBoxMushroom;
        private System.Windows.Forms.CheckBox checkBoxTuna;
        private System.Windows.Forms.CheckBox checkBoxPeperoni;
        private System.Windows.Forms.CheckBox checkBoxBeef;
        private System.Windows.Forms.CheckBox checkBoxCheese;
        private System.Windows.Forms.DataGridViewTextBoxColumn pizzaIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn releaseDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hargaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toppingsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stok;
        private System.Windows.Forms.DataGridViewButtonColumn Aksi;
    }
}

