namespace ePozoriste.WinUI.Ulaznica
{
    partial class frmUlaznicaDetalji
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
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.cmbPrikazivanje = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSjediste = new System.Windows.Forms.ComboBox();
            this.cmbREzervacija = new System.Windows.Forms.ComboBox();
            this.cmbKupac = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(302, 284);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(75, 23);
            this.btnSacuvaj.TabIndex = 21;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // cmbPrikazivanje
            // 
            this.cmbPrikazivanje.FormattingEnabled = true;
            this.cmbPrikazivanje.Location = new System.Drawing.Point(124, 49);
            this.cmbPrikazivanje.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPrikazivanje.Name = "cmbPrikazivanje";
            this.cmbPrikazivanje.Size = new System.Drawing.Size(253, 21);
            this.cmbPrikazivanje.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 57);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Prikazivanje";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Sjediste";
            // 
            // cmbSjediste
            // 
            this.cmbSjediste.FormattingEnabled = true;
            this.cmbSjediste.Location = new System.Drawing.Point(124, 92);
            this.cmbSjediste.Name = "cmbSjediste";
            this.cmbSjediste.Size = new System.Drawing.Size(253, 21);
            this.cmbSjediste.TabIndex = 22;
            // 
            // cmbREzervacija
            // 
            this.cmbREzervacija.FormattingEnabled = true;
            this.cmbREzervacija.Location = new System.Drawing.Point(124, 181);
            this.cmbREzervacija.Name = "cmbREzervacija";
            this.cmbREzervacija.Size = new System.Drawing.Size(253, 21);
            this.cmbREzervacija.TabIndex = 26;
            // 
            // cmbKupac
            // 
            this.cmbKupac.FormattingEnabled = true;
            this.cmbKupac.Location = new System.Drawing.Point(124, 136);
            this.cmbKupac.Margin = new System.Windows.Forms.Padding(2);
            this.cmbKupac.Name = "cmbKupac";
            this.cmbKupac.Size = new System.Drawing.Size(253, 21);
            this.cmbKupac.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 144);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Kupac";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 184);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Rezervacija";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmUlaznicaDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 400);
            this.Controls.Add(this.cmbREzervacija);
            this.Controls.Add(this.cmbKupac);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSjediste);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.cmbPrikazivanje);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "frmUlaznicaDetalji";
            this.Text = "frmUlaznicaDetalji";
            this.Load += new System.EventHandler(this.frmUlaznicaDetalji_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.ComboBox cmbPrikazivanje;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSjediste;
        private System.Windows.Forms.ComboBox cmbREzervacija;
        private System.Windows.Forms.ComboBox cmbKupac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}