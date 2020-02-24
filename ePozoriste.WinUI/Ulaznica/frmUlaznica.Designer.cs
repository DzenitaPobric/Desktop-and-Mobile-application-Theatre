namespace ePozoriste.WinUI.Ulaznica
{
    partial class frmUlaznica
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
            this.cmbKupacIme = new System.Windows.Forms.ComboBox();
            this.Kupac = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvUlaznice = new System.Windows.Forms.DataGridView();
            this.UlaznicaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrikazivanjeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KupacId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SjedisteId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RezervacijaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QRKod = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUlaznice)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbKupacIme
            // 
            this.cmbKupacIme.FormattingEnabled = true;
            this.cmbKupacIme.Location = new System.Drawing.Point(217, 34);
            this.cmbKupacIme.Margin = new System.Windows.Forms.Padding(4);
            this.cmbKupacIme.Name = "cmbKupacIme";
            this.cmbKupacIme.Size = new System.Drawing.Size(285, 24);
            this.cmbKupacIme.TabIndex = 0;
            this.cmbKupacIme.SelectedIndexChanged += new System.EventHandler(this.cmbKupacIme_SelectedIndexChanged);
            // 
            // Kupac
            // 
            this.Kupac.AutoSize = true;
            this.Kupac.Location = new System.Drawing.Point(119, 44);
            this.Kupac.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Kupac.Name = "Kupac";
            this.Kupac.Size = new System.Drawing.Size(48, 17);
            this.Kupac.TabIndex = 1;
            this.Kupac.Text = "Kupac";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvUlaznice);
            this.groupBox1.Location = new System.Drawing.Point(17, 106);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(767, 310);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // dgvUlaznice
            // 
            this.dgvUlaznice.AllowUserToAddRows = false;
            this.dgvUlaznice.AllowUserToDeleteRows = false;
            this.dgvUlaznice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUlaznice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UlaznicaId,
            this.PrikazivanjeId,
            this.KupacId,
            this.SjedisteId,
            this.RezervacijaId,
            this.QRKod});
            this.dgvUlaznice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUlaznice.Location = new System.Drawing.Point(4, 19);
            this.dgvUlaznice.Margin = new System.Windows.Forms.Padding(4);
            this.dgvUlaznice.Name = "dgvUlaznice";
            this.dgvUlaznice.ReadOnly = true;
            this.dgvUlaznice.RowHeadersWidth = 51;
            this.dgvUlaznice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUlaznice.Size = new System.Drawing.Size(759, 287);
            this.dgvUlaznice.TabIndex = 0;
            this.dgvUlaznice.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvUlaznice_MouseDoubleClick);
            // 
            // UlaznicaId
            // 
            this.UlaznicaId.DataPropertyName = "UlaznicaId";
            this.UlaznicaId.HeaderText = "UlaznicaId";
            this.UlaznicaId.MinimumWidth = 6;
            this.UlaznicaId.Name = "UlaznicaId";
            this.UlaznicaId.ReadOnly = true;
            this.UlaznicaId.Visible = false;
            this.UlaznicaId.Width = 36;
            // 
            // PrikazivanjeId
            // 
            this.PrikazivanjeId.DataPropertyName = "PrikazivanjeId";
            this.PrikazivanjeId.HeaderText = "PrikazivanjeId";
            this.PrikazivanjeId.MinimumWidth = 6;
            this.PrikazivanjeId.Name = "PrikazivanjeId";
            this.PrikazivanjeId.ReadOnly = true;
            this.PrikazivanjeId.Visible = false;
            this.PrikazivanjeId.Width = 150;
            // 
            // KupacId
            // 
            this.KupacId.DataPropertyName = "KupacId";
            this.KupacId.HeaderText = "KupacId";
            this.KupacId.MinimumWidth = 6;
            this.KupacId.Name = "KupacId";
            this.KupacId.ReadOnly = true;
            this.KupacId.Visible = false;
            this.KupacId.Width = 150;
            // 
            // SjedisteId
            // 
            this.SjedisteId.DataPropertyName = "SjedisteId";
            this.SjedisteId.HeaderText = "SjedisteId";
            this.SjedisteId.MinimumWidth = 6;
            this.SjedisteId.Name = "SjedisteId";
            this.SjedisteId.ReadOnly = true;
            this.SjedisteId.Visible = false;
            this.SjedisteId.Width = 150;
            // 
            // RezervacijaId
            // 
            this.RezervacijaId.DataPropertyName = "RezervacijaId";
            this.RezervacijaId.HeaderText = "RezervacijaId";
            this.RezervacijaId.MinimumWidth = 6;
            this.RezervacijaId.Name = "RezervacijaId";
            this.RezervacijaId.ReadOnly = true;
            this.RezervacijaId.Visible = false;
            this.RezervacijaId.Width = 150;
            // 
            // QRKod
            // 
            this.QRKod.DataPropertyName = "QRKod";
            this.QRKod.FillWeight = 500F;
            this.QRKod.HeaderText = "QRkod";
            this.QRKod.MinimumWidth = 100;
            this.QRKod.Name = "QRKod";
            this.QRKod.ReadOnly = true;
            this.QRKod.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.QRKod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.QRKod.Width = 150;
            // 
            // frmUlaznica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Kupac);
            this.Controls.Add(this.cmbKupacIme);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmUlaznica";
            this.Text = "frmUlaznica";
            this.Load += new System.EventHandler(this.frmUlaznica_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUlaznice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbKupacIme;
        private System.Windows.Forms.Label Kupac;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvUlaznice;
        private System.Windows.Forms.DataGridViewTextBoxColumn UlaznicaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrikazivanjeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn KupacId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SjedisteId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RezervacijaId;
        private System.Windows.Forms.DataGridViewImageColumn QRKod;
    }
}