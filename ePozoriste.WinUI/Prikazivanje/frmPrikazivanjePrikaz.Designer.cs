namespace ePozoriste.WinUI.Prikazivanje
{
    partial class frmPrikazivanjePrikaz
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
            this.cmbPredstava = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPRikazivanje = new System.Windows.Forms.DataGridView();
            this.PrikazivanjeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PredstavaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumPrikazivanja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
        //    this.BrojDostupnihMjesta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRikazivanje)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPredstava
            // 
            this.cmbPredstava.FormattingEnabled = true;
            this.cmbPredstava.Location = new System.Drawing.Point(155, 42);
            this.cmbPredstava.Name = "cmbPredstava";
            this.cmbPredstava.Size = new System.Drawing.Size(203, 21);
            this.cmbPredstava.TabIndex = 0;
            this.cmbPredstava.SelectedIndexChanged += new System.EventHandler(this.cmbPredstava_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Predstava";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPRikazivanje);
            this.groupBox1.Location = new System.Drawing.Point(60, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 296);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dgvPRikazivanje
            // 
            this.dgvPRikazivanje.AllowUserToAddRows = false;
            this.dgvPRikazivanje.AllowUserToDeleteRows = false;
            this.dgvPRikazivanje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPRikazivanje.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PrikazivanjeId,
            this.PredstavaId,
            this.SalaId,
            this.DatumPrikazivanja,
            this.Cijena });
         //   this.BrojDostupnihMjesta});
            this.dgvPRikazivanje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPRikazivanje.Location = new System.Drawing.Point(3, 16);
            this.dgvPRikazivanje.Name = "dgvPRikazivanje";
            this.dgvPRikazivanje.ReadOnly = true;
            this.dgvPRikazivanje.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPRikazivanje.Size = new System.Drawing.Size(408, 277);
            this.dgvPRikazivanje.TabIndex = 0;
            this.dgvPRikazivanje.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvPRikazivanje_MouseDoubleClick);
            // 
            // PrikazivanjeId
            // 
            this.PrikazivanjeId.DataPropertyName = "PrikazivanjeId";
            this.PrikazivanjeId.HeaderText = "PrikazivanjeId";
            this.PrikazivanjeId.Name = "PrikazivanjeId";
            this.PrikazivanjeId.ReadOnly = true;
            this.PrikazivanjeId.Visible = false;
            // 
            // PredstavaId
            // 
            this.PredstavaId.DataPropertyName = "PredstavaId";
            this.PredstavaId.HeaderText = "PredstavaId";
            this.PredstavaId.Name = "PredstavaId";
            this.PredstavaId.ReadOnly = true;
            this.PredstavaId.Visible = false;
            // 
            // SalaId
            // 
            this.SalaId.DataPropertyName = "SalaId";
            this.SalaId.HeaderText = "SalaId";
            this.SalaId.Name = "SalaId";
            this.SalaId.ReadOnly = true;
            this.SalaId.Visible = false;
            // 
            // DatumPrikazivanja
            // 
            this.DatumPrikazivanja.DataPropertyName = "DatumPrikazivanja";
            this.DatumPrikazivanja.HeaderText = "Datum prikazivanja";
            this.DatumPrikazivanja.Name = "DatumPrikazivanja";
            this.DatumPrikazivanja.ReadOnly = true;
            // 
            // Cijena
            // 
            this.Cijena.DataPropertyName = "Cijena";
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            // 
            // BrojDostupnihMjesta
            //// 
            //this.BrojDostupnihMjesta.DataPropertyName = "BrojDostupnihMjesta";
            //this.BrojDostupnihMjesta.HeaderText = "Broj slobodnih mjesta";
            //this.BrojDostupnihMjesta.Name = "BrojDostupnihMjesta";
            //this.BrojDostupnihMjesta.ReadOnly = true;
            //// 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(441, 401);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(75, 23);
            this.btnDodaj.TabIndex = 4;
            this.btnDodaj.Text = "Dodaj novo";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // frmPrikazivanjePrikaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPredstava);
            this.Name = "frmPrikazivanjePrikaz";
            this.Text = "frmPrikazivanjePrikaz";
            this.Load += new System.EventHandler(this.frmPrikazivanjePrikaz_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRikazivanje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPredstava;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvPRikazivanje;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrikazivanjeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PredstavaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumPrikazivanja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
    }
}