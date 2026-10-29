namespace week3
{
    partial class shop
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
            this.labelUang = new System.Windows.Forms.Label();
            this.groupBoxSellWood = new System.Windows.Forms.GroupBox();
            this.buttonSellMystic = new System.Windows.Forms.Button();
            this.buttonSellMahgony = new System.Windows.Forms.Button();
            this.buttonSellOak = new System.Windows.Forms.Button();
            this.labelMystic = new System.Windows.Forms.Label();
            this.labelMahogany = new System.Windows.Forms.Label();
            this.labelOak = new System.Windows.Forms.Label();
            this.groupBoxBuyAxes = new System.Windows.Forms.GroupBox();
            this.buttonBuyDiamond = new System.Windows.Forms.Button();
            this.buttonBuyIron = new System.Windows.Forms.Button();
            this.labelDiamondAxe = new System.Windows.Forms.Label();
            this.labelIronAxe = new System.Windows.Forms.Label();
            this.labelEquipped = new System.Windows.Forms.Label();
            this.labelOwn = new System.Windows.Forms.Label();
            this.buttonSellAll = new System.Windows.Forms.Button();
            this.groupBoxSellWood.SuspendLayout();
            this.groupBoxBuyAxes.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUang
            // 
            this.labelUang.AutoSize = true;
            this.labelUang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUang.Location = new System.Drawing.Point(29, 30);
            this.labelUang.Name = "labelUang";
            this.labelUang.Size = new System.Drawing.Size(64, 20);
            this.labelUang.TabIndex = 0;
            this.labelUang.Text = "Uang: ";
            // 
            // groupBoxSellWood
            // 
            this.groupBoxSellWood.Controls.Add(this.buttonSellMystic);
            this.groupBoxSellWood.Controls.Add(this.buttonSellMahgony);
            this.groupBoxSellWood.Controls.Add(this.buttonSellOak);
            this.groupBoxSellWood.Controls.Add(this.labelMystic);
            this.groupBoxSellWood.Controls.Add(this.labelMahogany);
            this.groupBoxSellWood.Controls.Add(this.labelOak);
            this.groupBoxSellWood.Location = new System.Drawing.Point(33, 65);
            this.groupBoxSellWood.Name = "groupBoxSellWood";
            this.groupBoxSellWood.Size = new System.Drawing.Size(391, 286);
            this.groupBoxSellWood.TabIndex = 1;
            this.groupBoxSellWood.TabStop = false;
            this.groupBoxSellWood.Text = "sell wood";
            // 
            // buttonSellMystic
            // 
            this.buttonSellMystic.Location = new System.Drawing.Point(241, 160);
            this.buttonSellMystic.Name = "buttonSellMystic";
            this.buttonSellMystic.Size = new System.Drawing.Size(129, 36);
            this.buttonSellMystic.TabIndex = 5;
            this.buttonSellMystic.Text = "Sell Mystic 250/log";
            this.buttonSellMystic.UseVisualStyleBackColor = true;
            this.buttonSellMystic.Click += new System.EventHandler(this.buttonSellMystic_Click_1);
            // 
            // buttonSellMahgony
            // 
            this.buttonSellMahgony.Location = new System.Drawing.Point(241, 87);
            this.buttonSellMahgony.Name = "buttonSellMahgony";
            this.buttonSellMahgony.Size = new System.Drawing.Size(129, 58);
            this.buttonSellMahgony.TabIndex = 4;
            this.buttonSellMahgony.Text = "Sell Mahogany 120/log";
            this.buttonSellMahgony.UseVisualStyleBackColor = true;
            this.buttonSellMahgony.Click += new System.EventHandler(this.buttonSellMahgony_Click);
            // 
            // buttonSellOak
            // 
            this.buttonSellOak.Location = new System.Drawing.Point(241, 37);
            this.buttonSellOak.Name = "buttonSellOak";
            this.buttonSellOak.Size = new System.Drawing.Size(129, 29);
            this.buttonSellOak.TabIndex = 3;
            this.buttonSellOak.Text = "Sell Oak (50/log)";
            this.buttonSellOak.UseVisualStyleBackColor = true;
            this.buttonSellOak.Click += new System.EventHandler(this.buttonSellOak_Click_1);
            // 
            // labelMystic
            // 
            this.labelMystic.AutoSize = true;
            this.labelMystic.Location = new System.Drawing.Point(11, 163);
            this.labelMystic.Name = "labelMystic";
            this.labelMystic.Size = new System.Drawing.Size(54, 16);
            this.labelMystic.TabIndex = 2;
            this.labelMystic.Text = "Mystic : ";
            // 
            // labelMahogany
            // 
            this.labelMahogany.AutoSize = true;
            this.labelMahogany.Location = new System.Drawing.Point(11, 98);
            this.labelMahogany.Name = "labelMahogany";
            this.labelMahogany.Size = new System.Drawing.Size(80, 16);
            this.labelMahogany.TabIndex = 1;
            this.labelMahogany.Text = "Mahogany : ";
            // 
            // labelOak
            // 
            this.labelOak.AutoSize = true;
            this.labelOak.Location = new System.Drawing.Point(11, 37);
            this.labelOak.Name = "labelOak";
            this.labelOak.Size = new System.Drawing.Size(41, 16);
            this.labelOak.TabIndex = 0;
            this.labelOak.Text = "Oak : ";
            // 
            // groupBoxBuyAxes
            // 
            this.groupBoxBuyAxes.Controls.Add(this.buttonBuyDiamond);
            this.groupBoxBuyAxes.Controls.Add(this.buttonBuyIron);
            this.groupBoxBuyAxes.Controls.Add(this.labelDiamondAxe);
            this.groupBoxBuyAxes.Controls.Add(this.labelIronAxe);
            this.groupBoxBuyAxes.Controls.Add(this.labelEquipped);
            this.groupBoxBuyAxes.Controls.Add(this.labelOwn);
            this.groupBoxBuyAxes.Location = new System.Drawing.Point(430, 65);
            this.groupBoxBuyAxes.Name = "groupBoxBuyAxes";
            this.groupBoxBuyAxes.Size = new System.Drawing.Size(337, 286);
            this.groupBoxBuyAxes.TabIndex = 2;
            this.groupBoxBuyAxes.TabStop = false;
            this.groupBoxBuyAxes.Text = "buy axes";
            // 
            // buttonBuyDiamond
            // 
            this.buttonBuyDiamond.Location = new System.Drawing.Point(209, 163);
            this.buttonBuyDiamond.Name = "buttonBuyDiamond";
            this.buttonBuyDiamond.Size = new System.Drawing.Size(110, 29);
            this.buttonBuyDiamond.TabIndex = 10;
            this.buttonBuyDiamond.Text = "Buy Diamond";
            this.buttonBuyDiamond.UseVisualStyleBackColor = true;
            this.buttonBuyDiamond.Click += new System.EventHandler(this.buttonBuyDiamond_Click);
            // 
            // buttonBuyIron
            // 
            this.buttonBuyIron.Location = new System.Drawing.Point(209, 123);
            this.buttonBuyIron.Name = "buttonBuyIron";
            this.buttonBuyIron.Size = new System.Drawing.Size(110, 29);
            this.buttonBuyIron.TabIndex = 6;
            this.buttonBuyIron.Text = "Buy Iron";
            this.buttonBuyIron.UseVisualStyleBackColor = true;
            this.buttonBuyIron.Click += new System.EventHandler(this.buttonBuyIron_Click);
            // 
            // labelDiamondAxe
            // 
            this.labelDiamondAxe.AutoSize = true;
            this.labelDiamondAxe.Location = new System.Drawing.Point(20, 170);
            this.labelDiamondAxe.Name = "labelDiamondAxe";
            this.labelDiamondAxe.Size = new System.Drawing.Size(150, 16);
            this.labelDiamondAxe.TabIndex = 9;
            this.labelDiamondAxe.Text = "Diamond Axe - Rp 6.000";
            // 
            // labelIronAxe
            // 
            this.labelIronAxe.AutoSize = true;
            this.labelIronAxe.Location = new System.Drawing.Point(20, 129);
            this.labelIronAxe.Name = "labelIronAxe";
            this.labelIronAxe.Size = new System.Drawing.Size(117, 16);
            this.labelIronAxe.TabIndex = 8;
            this.labelIronAxe.Text = "Iron Axe - Rp 1.500";
            // 
            // labelEquipped
            // 
            this.labelEquipped.AutoSize = true;
            this.labelEquipped.Location = new System.Drawing.Point(20, 72);
            this.labelEquipped.Name = "labelEquipped";
            this.labelEquipped.Size = new System.Drawing.Size(75, 16);
            this.labelEquipped.TabIndex = 7;
            this.labelEquipped.Text = "Equipped : ";
            // 
            // labelOwn
            // 
            this.labelOwn.AutoSize = true;
            this.labelOwn.Location = new System.Drawing.Point(20, 43);
            this.labelOwn.Name = "labelOwn";
            this.labelOwn.Size = new System.Drawing.Size(58, 16);
            this.labelOwn.TabIndex = 6;
            this.labelOwn.Text = "Owned : ";
            // 
            // buttonSellAll
            // 
            this.buttonSellAll.Location = new System.Drawing.Point(33, 367);
            this.buttonSellAll.Name = "buttonSellAll";
            this.buttonSellAll.Size = new System.Drawing.Size(734, 36);
            this.buttonSellAll.TabIndex = 6;
            this.buttonSellAll.Text = "SELL OLL";
            this.buttonSellAll.UseVisualStyleBackColor = true;
            this.buttonSellAll.Click += new System.EventHandler(this.buttonSellAll_Click);
            // 
            // shop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSellAll);
            this.Controls.Add(this.groupBoxBuyAxes);
            this.Controls.Add(this.groupBoxSellWood);
            this.Controls.Add(this.labelUang);
            this.Name = "shop";
            this.Text = "shop";
            this.Load += new System.EventHandler(this.shop_Load);
            this.groupBoxSellWood.ResumeLayout(false);
            this.groupBoxSellWood.PerformLayout();
            this.groupBoxBuyAxes.ResumeLayout(false);
            this.groupBoxBuyAxes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUang;
        private System.Windows.Forms.GroupBox groupBoxSellWood;
        private System.Windows.Forms.Label labelMystic;
        private System.Windows.Forms.Label labelMahogany;
        private System.Windows.Forms.Label labelOak;
        private System.Windows.Forms.GroupBox groupBoxBuyAxes;
        private System.Windows.Forms.Button buttonSellMystic;
        private System.Windows.Forms.Button buttonSellMahgony;
        private System.Windows.Forms.Button buttonSellOak;
        private System.Windows.Forms.Button buttonBuyDiamond;
        private System.Windows.Forms.Button buttonBuyIron;
        private System.Windows.Forms.Label labelDiamondAxe;
        private System.Windows.Forms.Label labelIronAxe;
        private System.Windows.Forms.Label labelEquipped;
        private System.Windows.Forms.Label labelOwn;
        private System.Windows.Forms.Button buttonSellAll;
    }
}