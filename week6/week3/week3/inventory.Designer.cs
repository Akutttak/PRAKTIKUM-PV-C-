namespace week3
{
    partial class inventory
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
            this.groupBoxWood = new System.Windows.Forms.GroupBox();
            this.labelMystic = new System.Windows.Forms.Label();
            this.labelMahogany = new System.Windows.Forms.Label();
            this.labelOak = new System.Windows.Forms.Label();
            this.groupBoxAxe = new System.Windows.Forms.GroupBox();
            this.radioButtonDiamond = new System.Windows.Forms.RadioButton();
            this.radioButtonIron = new System.Windows.Forms.RadioButton();
            this.radioButtonStoneAxe = new System.Windows.Forms.RadioButton();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxWood.SuspendLayout();
            this.groupBoxAxe.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUang
            // 
            this.labelUang.AutoSize = true;
            this.labelUang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUang.Location = new System.Drawing.Point(28, 27);
            this.labelUang.Name = "labelUang";
            this.labelUang.Size = new System.Drawing.Size(64, 20);
            this.labelUang.TabIndex = 0;
            this.labelUang.Text = "Uang: ";
            // 
            // groupBoxWood
            // 
            this.groupBoxWood.Controls.Add(this.labelMystic);
            this.groupBoxWood.Controls.Add(this.labelMahogany);
            this.groupBoxWood.Controls.Add(this.labelOak);
            this.groupBoxWood.Location = new System.Drawing.Point(32, 71);
            this.groupBoxWood.Name = "groupBoxWood";
            this.groupBoxWood.Size = new System.Drawing.Size(262, 236);
            this.groupBoxWood.TabIndex = 1;
            this.groupBoxWood.TabStop = false;
            this.groupBoxWood.Text = "Woods";
            // 
            // labelMystic
            // 
            this.labelMystic.AutoSize = true;
            this.labelMystic.Location = new System.Drawing.Point(16, 87);
            this.labelMystic.Name = "labelMystic";
            this.labelMystic.Size = new System.Drawing.Size(51, 16);
            this.labelMystic.TabIndex = 2;
            this.labelMystic.Text = "Mystic: ";
            // 
            // labelMahogany
            // 
            this.labelMahogany.AutoSize = true;
            this.labelMahogany.Location = new System.Drawing.Point(16, 68);
            this.labelMahogany.Name = "labelMahogany";
            this.labelMahogany.Size = new System.Drawing.Size(77, 16);
            this.labelMahogany.TabIndex = 1;
            this.labelMahogany.Text = "Mahogany: ";
            // 
            // labelOak
            // 
            this.labelOak.AutoSize = true;
            this.labelOak.Location = new System.Drawing.Point(16, 50);
            this.labelOak.Name = "labelOak";
            this.labelOak.Size = new System.Drawing.Size(38, 16);
            this.labelOak.TabIndex = 0;
            this.labelOak.Text = "Oak: ";
            // 
            // groupBoxAxe
            // 
            this.groupBoxAxe.Controls.Add(this.radioButtonDiamond);
            this.groupBoxAxe.Controls.Add(this.radioButtonIron);
            this.groupBoxAxe.Controls.Add(this.radioButtonStoneAxe);
            this.groupBoxAxe.Location = new System.Drawing.Point(312, 71);
            this.groupBoxAxe.Name = "groupBoxAxe";
            this.groupBoxAxe.Size = new System.Drawing.Size(262, 236);
            this.groupBoxAxe.TabIndex = 2;
            this.groupBoxAxe.TabStop = false;
            this.groupBoxAxe.Text = "Axes";
            // 
            // radioButtonDiamond
            // 
            this.radioButtonDiamond.AutoSize = true;
            this.radioButtonDiamond.Location = new System.Drawing.Point(30, 120);
            this.radioButtonDiamond.Name = "radioButtonDiamond";
            this.radioButtonDiamond.Size = new System.Drawing.Size(83, 20);
            this.radioButtonDiamond.TabIndex = 2;
            this.radioButtonDiamond.TabStop = true;
            this.radioButtonDiamond.Text = "Diamond";
            this.radioButtonDiamond.UseVisualStyleBackColor = true;
            // 
            // radioButtonIron
            // 
            this.radioButtonIron.AutoSize = true;
            this.radioButtonIron.Location = new System.Drawing.Point(30, 85);
            this.radioButtonIron.Name = "radioButtonIron";
            this.radioButtonIron.Size = new System.Drawing.Size(50, 20);
            this.radioButtonIron.TabIndex = 1;
            this.radioButtonIron.TabStop = true;
            this.radioButtonIron.Text = "Iron";
            this.radioButtonIron.UseVisualStyleBackColor = true;
            // 
            // radioButtonStoneAxe
            // 
            this.radioButtonStoneAxe.AutoSize = true;
            this.radioButtonStoneAxe.Location = new System.Drawing.Point(30, 50);
            this.radioButtonStoneAxe.Name = "radioButtonStoneAxe";
            this.radioButtonStoneAxe.Size = new System.Drawing.Size(63, 20);
            this.radioButtonStoneAxe.TabIndex = 0;
            this.radioButtonStoneAxe.TabStop = true;
            this.radioButtonStoneAxe.Text = "Stone";
            this.radioButtonStoneAxe.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(487, 323);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(86, 29);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Uang: ";
            // 
            // inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 366);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBoxAxe);
            this.Controls.Add(this.groupBoxWood);
            this.Controls.Add(this.labelUang);
            this.Name = "inventory";
            this.Text = "inventory";
            this.Load += new System.EventHandler(this.inventory_Load);
            this.groupBoxWood.ResumeLayout(false);
            this.groupBoxWood.PerformLayout();
            this.groupBoxAxe.ResumeLayout(false);
            this.groupBoxAxe.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUang;
        private System.Windows.Forms.GroupBox groupBoxWood;
        private System.Windows.Forms.Label labelMystic;
        private System.Windows.Forms.Label labelMahogany;
        private System.Windows.Forms.Label labelOak;
        private System.Windows.Forms.GroupBox groupBoxAxe;
        private System.Windows.Forms.RadioButton radioButtonDiamond;
        private System.Windows.Forms.RadioButton radioButtonIron;
        private System.Windows.Forms.RadioButton radioButtonStoneAxe;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label1;
    }
}