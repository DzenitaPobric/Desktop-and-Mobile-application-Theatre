namespace ePozoriste.WinUI.Rezervacije
{
    partial class frmRezervacije
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbIme = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvRezervacija = new System.Windows.Forms.DataGridView();
            this.RezervacijaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumRezervacije = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojRezervacije = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Odobrena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KupacId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrikazivanjeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervacija)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ime";
            // 
            // cmbIme
            // 
            this.cmbIme.FormattingEnabled = true;
            this.cmbIme.Location = new System.Drawing.Point(102, 17);
            this.cmbIme.Margin = new System.Windows.Forms.Padding(2);
            this.cmbIme.Name = "cmbIme";
            this.cmbIme.Size = new System.Drawing.Size(142, 21);
            this.cmbIme.TabIndex = 1;
            this.cmbIme.SelectedIndexChanged += new System.EventHandler(this.cmbIme_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvRezervacija);
            this.groupBox1.Location = new System.Drawing.Point(9, 53);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(444, 303);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dgvRezervacija
            // 
            this.dgvRezervacija.AllowUserToAddRows = false;
            this.dgvRezervacija.AllowUserToDeleteRows = false;
            this.dgvRezervacija.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRezervacija.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RezervacijaId,
            this.DatumRezervacije,
            this.BrojRezervacije,
            this.Odobrena,
            this.KupacId,
            this.PrikazivanjeId});
            this.dgvRezervacija.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRezervacija.Location = new System.Drawing.Point(2, 15);
            this.dgvRezervacija.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRezervacija.Name = "dgvRezervacija";
            this.dgvRezervacija.ReadOnly = true;
            this.dgvRezervacija.RowHeadersWidth = 51;
            this.dgvRezervacija.RowTemplate.Height = 24;
            this.dgvRezervacija.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRezervacija.Size = new System.Drawing.Size(440, 286);
            this.dgvRezervacija.TabIndex = 0;
            this.dgvRezervacija.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvRezervacija_MouseDoubleClick);
            // 
            // RezervacijaId
            // 
            this.RezervacijaId.DataPropertyName = "RezervacijaId";
            this.RezervacijaId.HeaderText = "RezervacijaId";
            this.RezervacijaId.MinimumWidth = 6;
            this.RezervacijaId.Name = "RezervacijaId";
            this.RezervacijaId.ReadOnly = true;
            this.RezervacijaId.Visible = false;
            this.RezervacijaId.Width = 125;
            // 
            // DatumRezervacije
            // 
            this.DatumRezervacije.DataPropertyName = "DatumRezervacije";
            this.DatumRezervacije.HeaderText = "Datum rezervacije";
            this.DatumRezervacije.MinimumWidth = 6;
            this.DatumRezervacije.Name = "DatumRezervacije";
            this.DatumRezervacije.ReadOnly = true;
            this.DatumRezervacije.Width = 125;
            // 
            // BrojRezervacije
            // 
            this.BrojRezervacije.DataPropertyName = "BrojRezervacije";
            this.BrojRezervacije.HeaderText = "Broj rezervacije";
            this.BrojRezervacije.MinimumWidth = 6;
            this.BrojRezervacije.Name = "BrojRezervacije";
            this.BrojRezervacije.ReadOnly = true;
            this.BrojRezervacije.Width = 125;
            // 
            // Odobrena
            // 
            this.Odobrena.DataPropertyName = "Odobrena";
            this.Odobrena.HeaderText = "Odobrena";
            this.Odobrena.MinimumWidth = 6;
            this.Odobrena.Name = "Odobrena";
            this.Odobrena.ReadOnly = true;
            this.Odobrena.Width = 125;
            // 
            // KupacId
            // 
            this.KupacId.DataPropertyName = "KupacId";
            this.KupacId.HeaderText = "KupacId";
            this.KupacId.MinimumWidth = 6;
            this.KupacId.Name = "KupacId";
            this.KupacId.ReadOnly = true;
            this.KupacId.Visible = false;
            this.KupacId.Width = 125;
            // 
            // PrikazivanjeId
            // 
            this.PrikazivanjeId.DataPropertyName = "PrikazivanjeId";
            this.PrikazivanjeId.HeaderText = "PrikazivanjeId";
            this.PrikazivanjeId.MinimumWidth = 6;
            this.PrikazivanjeId.Name = "PrikazivanjeId";
            this.PrikazivanjeId.ReadOnly = true;
            this.PrikazivanjeId.Visible = false;
            this.PrikazivanjeId.Width = 125;
            // 
            // frmRezervacije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 366);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbIme);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmRezervacije";
            this.Text = "frmRezervacije";
            this.Load += new System.EventHandler(this.frmRezervacije_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervacija)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbIme;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvRezervacija;
        private System.Windows.Forms.DataGridViewTextBoxColumn RezervacijaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumRezervacije;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojRezervacije;
        private System.Windows.Forms.DataGridViewTextBoxColumn Odobrena;
        private System.Windows.Forms.DataGridViewTextBoxColumn KupacId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrikazivanjeId;
    }
}