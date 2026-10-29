namespace week3
{
    partial class tebangPohon
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelHit = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelMiss = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelWarnaIjo = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "tekan CHOP / Space saat bar anda berada pada area hijau";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "target hit: 3";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(50, 106);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(558, 36);
            this.progressBar1.TabIndex = 2;
            // 
            // labelHit
            // 
            this.labelHit.AutoSize = true;
            this.labelHit.Location = new System.Drawing.Point(47, 160);
            this.labelHit.Name = "labelHit";
            this.labelHit.Size = new System.Drawing.Size(26, 16);
            this.labelHit.TabIndex = 3;
            this.labelHit.Text = "hit: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "I";
            // 
            // labelMiss
            // 
            this.labelMiss.AutoSize = true;
            this.labelMiss.Location = new System.Drawing.Point(121, 160);
            this.labelMiss.Name = "labelMiss";
            this.labelMiss.Size = new System.Drawing.Size(41, 16);
            this.labelMiss.TabIndex = 5;
            this.labelMiss.Text = "Miss: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(501, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "CHOP(space)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelWarnaIjo
            // 
            this.panelWarnaIjo.BackColor = System.Drawing.Color.LightGreen;
            this.panelWarnaIjo.Location = new System.Drawing.Point(323, 106);
            this.panelWarnaIjo.Name = "panelWarnaIjo";
            this.panelWarnaIjo.Size = new System.Drawing.Size(181, 36);
            this.panelWarnaIjo.TabIndex = 7;
            // 
            // tebangPohon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 253);
            this.Controls.Add(this.panelWarnaIjo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelMiss);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelHit);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "tebangPohon";
            this.Text = "tebangPohon";
            this.Load += new System.EventHandler(this.tebangPohon_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tebangPohon_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tebangPohon_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelHit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelMiss;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelWarnaIjo;
    }
}