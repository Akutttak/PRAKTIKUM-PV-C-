namespace Week1
{
    partial class DoHomework
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
            this.textBoxJawabanUser = new System.Windows.Forms.TextBox();
            this.labelPertanyaan = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxJawabanUser
            // 
            this.textBoxJawabanUser.Location = new System.Drawing.Point(37, 66);
            this.textBoxJawabanUser.Name = "textBoxJawabanUser";
            this.textBoxJawabanUser.Size = new System.Drawing.Size(501, 22);
            this.textBoxJawabanUser.TabIndex = 0;
            // 
            // labelPertanyaan
            // 
            this.labelPertanyaan.AutoSize = true;
            this.labelPertanyaan.Location = new System.Drawing.Point(37, 39);
            this.labelPertanyaan.Name = "labelPertanyaan";
            this.labelPertanyaan.Size = new System.Drawing.Size(44, 16);
            this.labelPertanyaan.TabIndex = 1;
            this.labelPertanyaan.Text = "label1";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(372, 110);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(463, 110);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // DoHomework
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 156);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelPertanyaan);
            this.Controls.Add(this.textBoxJawabanUser);
            this.Name = "DoHomework";
            this.Text = "Do Homework!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxJawabanUser;
        private System.Windows.Forms.Label labelPertanyaan;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}