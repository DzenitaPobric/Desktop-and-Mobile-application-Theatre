namespace ePozoriste.WinUI.Uplata
{
    partial class frmUplataPrikaz
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvUplata = new System.Windows.Forms.DataGridView();
            this.UplataId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Svrha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iznos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SponzorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumUplate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbSponzor = new System.Windows.Forms.ComboBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUplata)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvUplata);
            this.groupBox1.Location = new System.Drawing.Point(9, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 220);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dgvUplata
            // 
            this.dgvUplata.AllowUserToAddRows = false;
            this.dgvUplata.AllowUserToDeleteRows = false;
            this.dgvUplata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUplata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UplataId,
            this.Naziv,
            this.Svrha,
            this.Iznos,
            this.SponzorId,
            this.DatumUplate});
            this.dgvUplata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUplata.Location = new System.Drawing.Point(3, 16);
            this.dgvUplata.Name = "dgvUplata";
            this.dgvUplata.ReadOnly = true;
            this.dgvUplata.RowHeadersWidth = 51;
            this.dgvUplata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUplata.Size = new System.Drawing.Size(558, 201);
            this.dgvUplata.TabIndex = 0;
            this.dgvUplata.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvUplata_MouseDoubleClick);
            // 
            // UplataId
            // 
            this.UplataId.DataPropertyName = "UplataId";
            this.UplataId.HeaderText = "UplataId";
            this.UplataId.MinimumWidth = 6;
            this.UplataId.Name = "UplataId";
            this.UplataId.ReadOnly = true;
            this.UplataId.Visible = false;
            this.UplataId.Width = 125;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.MinimumWidth = 6;
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            this.Naziv.Width = 125;
            // 
            // Svrha
            // 
            this.Svrha.DataPropertyName = "Svrha";
            this.Svrha.HeaderText = "Svrha";
            this.Svrha.MinimumWidth = 6;
            this.Svrha.Name = "Svrha";
            this.Svrha.ReadOnly = true;
            this.Svrha.Width = 125;
            // 
            // Iznos
            // 
            this.Iznos.DataPropertyName = "Iznos";
            this.Iznos.HeaderText = "Iznos";
            this.Iznos.MinimumWidth = 6;
            this.Iznos.Name = "Iznos";
            this.Iznos.ReadOnly = true;
            this.Iznos.Width = 125;
            // 
            // SponzorId
            // 
            this.SponzorId.DataPropertyName = "SponzorId";
            this.SponzorId.HeaderText = "SponzorId";
            this.SponzorId.MinimumWidth = 6;
            this.SponzorId.Name = "SponzorId";
            this.SponzorId.ReadOnly = true;
            this.SponzorId.Visible = false;
            this.SponzorId.Width = 125;
            // 
            // DatumUplate
            // 
            this.DatumUplate.DataPropertyName = "DatumUplate";
            this.DatumUplate.HeaderText = "DatumUplate";
            this.DatumUplate.MinimumWidth = 6;
            this.DatumUplate.Name = "DatumUplate";
            this.DatumUplate.ReadOnly = true;
            this.DatumUplate.Width = 125;
            // 
            // cmbSponzor
            // 
            this.cmbSponzor.FormattingEnabled = true;
            this.cmbSponzor.Location = new System.Drawing.Point(102, 43);
            this.cmbSponzor.Name = "cmbSponzor";
            this.cmbSponzor.Size = new System.Drawing.Size(210, 21);
            this.cmbSponzor.TabIndex = 6;
            this.cmbSponzor.SelectedIndexChanged += new System.EventHandler(this.cmbSponzor_SelectedIndexChanged);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(384, 374);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(75, 23);
            this.btnDodaj.TabIndex = 7;
            this.btnDodaj.Text = "Dodaj novi";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Sponzor";
            // 
            // frmUplataPrikaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 445);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.cmbSponzor);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmUplataPrikaz";
            this.Text = "frmUplataPrikaz";
            this.Load += new System.EventHandler(this.frmUplataPrikaz_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUplata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvUplata;
        private System.Windows.Forms.ComboBox cmbSponzor;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn UplataId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Svrha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iznos;
        private System.Windows.Forms.DataGridViewTextBoxColumn SponzorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumUplate;
    }
}