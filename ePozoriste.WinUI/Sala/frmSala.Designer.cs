namespace ePozoriste.WinUI.Sala
{
    partial class frmSala
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
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvSala = new System.Windows.Forms.DataGridView();
            this.SalaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Klimatizacija = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Kapacitet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSala)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Location = new System.Drawing.Point(415, 60);
            this.btnPrikazi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(100, 28);
            this.btnPrikazi.TabIndex = 0;
            this.btnPrikazi.Text = "Prikaži";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(137, 64);
            this.txtPretraga.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(219, 22);
            this.txtPretraga.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvSala);
            this.groupBox1.Location = new System.Drawing.Point(37, 121);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(492, 256);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // dgvSala
            // 
            this.dgvSala.AllowUserToAddRows = false;
            this.dgvSala.AllowUserToDeleteRows = false;
            this.dgvSala.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSala.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SalaId,
            this.Naziv,
            this.Klimatizacija,
            this.Kapacitet});
            this.dgvSala.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSala.Location = new System.Drawing.Point(4, 19);
            this.dgvSala.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvSala.Name = "dgvSala";
            this.dgvSala.ReadOnly = true;
            this.dgvSala.RowHeadersWidth = 51;
            this.dgvSala.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSala.Size = new System.Drawing.Size(484, 233);
            this.dgvSala.TabIndex = 0;
            this.dgvSala.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvSala_MouseDoubleClick);
            // 
            // SalaId
            // 
            this.SalaId.DataPropertyName = "SalaId";
            this.SalaId.HeaderText = "SalaId";
            this.SalaId.MinimumWidth = 6;
            this.SalaId.Name = "SalaId";
            this.SalaId.ReadOnly = true;
            this.SalaId.Visible = false;
            this.SalaId.Width = 125;
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
            // Klimatizacija
            // 
            this.Klimatizacija.DataPropertyName = "Klimatizacija";
            this.Klimatizacija.HeaderText = "Klimatizacija";
            this.Klimatizacija.MinimumWidth = 6;
            this.Klimatizacija.Name = "Klimatizacija";
            this.Klimatizacija.ReadOnly = true;
            this.Klimatizacija.Width = 125;
            // 
            // Kapacitet
            // 
            this.Kapacitet.DataPropertyName = "Kapacitet";
            this.Kapacitet.HeaderText = "Kapacitet";
            this.Kapacitet.MinimumWidth = 6;
            this.Kapacitet.Name = "Kapacitet";
            this.Kapacitet.ReadOnly = true;
            this.Kapacitet.Width = 125;
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(415, 399);
            this.btnDodaj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(100, 28);
            this.btnDodaj.TabIndex = 7;
            this.btnDodaj.Text = "Dodaj novu";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Naziv";
            // 
            // frmSala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 464);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtPretraga);
            this.Controls.Add(this.btnPrikazi);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmSala";
            this.Text = "frmSala";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSala)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvSala;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Klimatizacija;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kapacitet;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Label label1;
    }
}