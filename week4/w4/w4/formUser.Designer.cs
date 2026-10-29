namespace w4
{
    partial class formUser
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
            this.labelTitleHistoryTransaksi = new System.Windows.Forms.Label();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.labelTitlePizza = new System.Windows.Forms.Label();
            this.dataGridViewKeranjang = new System.Windows.Forms.DataGridView();
            this.pizzaIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hargaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fKPizzaKeranjangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pijah = new w4.Pijah();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pizzaIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.releaseDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hargaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toppingsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonOrder = new System.Windows.Forms.Button();
            this.buttonRemoveItem = new System.Windows.Forms.Button();
            this.buttonClearCart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKeranjang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKPizzaKeranjangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pijah)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitleHistoryTransaksi
            // 
            this.labelTitleHistoryTransaksi.AutoSize = true;
            this.labelTitleHistoryTransaksi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleHistoryTransaksi.Location = new System.Drawing.Point(87, 240);
            this.labelTitleHistoryTransaksi.Name = "labelTitleHistoryTransaksi";
            this.labelTitleHistoryTransaksi.Size = new System.Drawing.Size(228, 20);
            this.labelTitleHistoryTransaksi.TabIndex = 13;
            this.labelTitleHistoryTransaksi.Text = "KERANJANG CHECKOUT";
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Location = new System.Drawing.Point(1259, 18);
            this.buttonLogOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(92, 33);
            this.buttonLogOut.TabIndex = 11;
            this.buttonLogOut.Text = "Log Out";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // labelTitlePizza
            // 
            this.labelTitlePizza.AutoSize = true;
            this.labelTitlePizza.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitlePizza.Location = new System.Drawing.Point(643, 14);
            this.labelTitlePizza.Name = "labelTitlePizza";
            this.labelTitlePizza.Size = new System.Drawing.Size(168, 25);
            this.labelTitlePizza.TabIndex = 10;
            this.labelTitlePizza.Text = "ORDER PITJAH";
            // 
            // dataGridViewKeranjang
            // 
            this.dataGridViewKeranjang.AutoGenerateColumns = false;
            this.dataGridViewKeranjang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKeranjang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pizzaIdDataGridViewTextBoxColumn1,
            this.namaDataGridViewTextBoxColumn1,
            this.hargaDataGridViewTextBoxColumn1,
            this.qtyDataGridViewTextBoxColumn,
            this.subTotalDataGridViewTextBoxColumn,
            this.usernameDataGridViewTextBoxColumn});
            this.dataGridViewKeranjang.DataSource = this.fKPizzaKeranjangBindingSource;
            this.dataGridViewKeranjang.Location = new System.Drawing.Point(85, 266);
            this.dataGridViewKeranjang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewKeranjang.Name = "dataGridViewKeranjang";
            this.dataGridViewKeranjang.RowHeadersWidth = 51;
            this.dataGridViewKeranjang.RowTemplate.Height = 24;
            this.dataGridViewKeranjang.Size = new System.Drawing.Size(1265, 164);
            this.dataGridViewKeranjang.TabIndex = 9;
            this.dataGridViewKeranjang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewKeranjang_CellClick);
            // 
            // pizzaIdDataGridViewTextBoxColumn1
            // 
            this.pizzaIdDataGridViewTextBoxColumn1.DataPropertyName = "PizzaId";
            this.pizzaIdDataGridViewTextBoxColumn1.HeaderText = "PizzaId";
            this.pizzaIdDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.pizzaIdDataGridViewTextBoxColumn1.Name = "pizzaIdDataGridViewTextBoxColumn1";
            this.pizzaIdDataGridViewTextBoxColumn1.Width = 125;
            // 
            // namaDataGridViewTextBoxColumn1
            // 
            this.namaDataGridViewTextBoxColumn1.DataPropertyName = "Nama";
            this.namaDataGridViewTextBoxColumn1.HeaderText = "Nama";
            this.namaDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.namaDataGridViewTextBoxColumn1.Name = "namaDataGridViewTextBoxColumn1";
            this.namaDataGridViewTextBoxColumn1.Width = 125;
            // 
            // hargaDataGridViewTextBoxColumn1
            // 
            this.hargaDataGridViewTextBoxColumn1.DataPropertyName = "Harga";
            this.hargaDataGridViewTextBoxColumn1.HeaderText = "Harga";
            this.hargaDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.hargaDataGridViewTextBoxColumn1.Name = "hargaDataGridViewTextBoxColumn1";
            this.hargaDataGridViewTextBoxColumn1.Width = 125;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.qtyDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.Width = 125;
            // 
            // subTotalDataGridViewTextBoxColumn
            // 
            this.subTotalDataGridViewTextBoxColumn.DataPropertyName = "SubTotal";
            this.subTotalDataGridViewTextBoxColumn.HeaderText = "SubTotal";
            this.subTotalDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.subTotalDataGridViewTextBoxColumn.Name = "subTotalDataGridViewTextBoxColumn";
            this.subTotalDataGridViewTextBoxColumn.Width = 125;
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            this.usernameDataGridViewTextBoxColumn.DataPropertyName = "username";
            this.usernameDataGridViewTextBoxColumn.HeaderText = "username";
            this.usernameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            this.usernameDataGridViewTextBoxColumn.Width = 125;
            // 
            // fKPizzaKeranjangBindingSource
            // 
            this.fKPizzaKeranjangBindingSource.DataMember = "FK_Pizza_Keranjang";
            this.fKPizzaKeranjangBindingSource.DataSource = this.bindingSource1;
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
            this.toppingsDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(85, 57);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1265, 177);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
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
            // buttonOrder
            // 
            this.buttonOrder.Location = new System.Drawing.Point(85, 445);
            this.buttonOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonOrder.Name = "buttonOrder";
            this.buttonOrder.Size = new System.Drawing.Size(125, 33);
            this.buttonOrder.TabIndex = 14;
            this.buttonOrder.Text = "Order";
            this.buttonOrder.UseVisualStyleBackColor = true;
            this.buttonOrder.Click += new System.EventHandler(this.buttonOrder_Click);
            // 
            // buttonRemoveItem
            // 
            this.buttonRemoveItem.Location = new System.Drawing.Point(235, 445);
            this.buttonRemoveItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRemoveItem.Name = "buttonRemoveItem";
            this.buttonRemoveItem.Size = new System.Drawing.Size(125, 33);
            this.buttonRemoveItem.TabIndex = 15;
            this.buttonRemoveItem.Text = "Remove Item";
            this.buttonRemoveItem.UseVisualStyleBackColor = true;
            this.buttonRemoveItem.Click += new System.EventHandler(this.buttonRemoveItem_Click);
            // 
            // buttonClearCart
            // 
            this.buttonClearCart.Location = new System.Drawing.Point(386, 445);
            this.buttonClearCart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClearCart.Name = "buttonClearCart";
            this.buttonClearCart.Size = new System.Drawing.Size(125, 33);
            this.buttonClearCart.TabIndex = 16;
            this.buttonClearCart.Text = "Clear Cart";
            this.buttonClearCart.UseVisualStyleBackColor = true;
            this.buttonClearCart.Click += new System.EventHandler(this.buttonClearCart_Click);
            // 
            // formUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1435, 651);
            this.Controls.Add(this.buttonClearCart);
            this.Controls.Add(this.buttonRemoveItem);
            this.Controls.Add(this.buttonOrder);
            this.Controls.Add(this.labelTitleHistoryTransaksi);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.labelTitlePizza);
            this.Controls.Add(this.dataGridViewKeranjang);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formUser";
            this.Text = "formUser";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKeranjang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKPizzaKeranjangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pijah)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTitleHistoryTransaksi;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.Label labelTitlePizza;
        private System.Windows.Forms.DataGridView dataGridViewKeranjang;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private Pijah pijah;
        private System.Windows.Forms.DataGridViewTextBoxColumn pizzaIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn releaseDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hargaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toppingsDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button buttonOrder;
        private System.Windows.Forms.Button buttonRemoveItem;
        private System.Windows.Forms.Button buttonClearCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn pizzaIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn namaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn hargaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource fKPizzaKeranjangBindingSource;
    }
}