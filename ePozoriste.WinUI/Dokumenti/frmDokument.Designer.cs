namespace ePozoriste.WinUI.Dokumenti
{
    partial class frmDokument
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
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.dgvDokumenti = new System.Windows.Forms.DataGridView();
            this.DokumentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NazivDokumenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDokumenti)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Naziv";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(176, 52);
            this.txtNaziv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(221, 22);
            this.txtNaziv.TabIndex = 7;
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Location = new System.Drawing.Point(448, 54);
            this.btnPrikazi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(100, 28);
            this.btnPrikazi.TabIndex = 6;
            this.btnPrikazi.Text = "Prikaži";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // dgvDokumenti
            // 
            this.dgvDokumenti.AllowUserToAddRows = false;
            this.dgvDokumenti.AllowUserToDeleteRows = false;
            this.dgvDokumenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDokumenti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DokumentID,
            this.NazivDokumenta,
            this.FileName});
            this.dgvDokumenti.Location = new System.Drawing.Point(69, 183);
            this.dgvDokumenti.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDokumenti.MultiSelect = false;
            this.dgvDokumenti.Name = "dgvDokumenti";
            this.dgvDokumenti.ReadOnly = true;
            this.dgvDokumenti.RowHeadersWidth = 51;
            this.dgvDokumenti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDokumenti.Size = new System.Drawing.Size(479, 315);
            this.dgvDokumenti.TabIndex = 10;
         
            this.dgvDokumenti.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvDokumenti_MouseDoubleClick);
            // 
            // DokumentID
            // 
            this.DokumentID.DataPropertyName = "DokumentID";
            this.DokumentID.HeaderText = "DokumentID";
            this.DokumentID.MinimumWidth = 6;
            this.DokumentID.Name = "DokumentID";
            this.DokumentID.ReadOnly = true;
            this.DokumentID.Visible = false;
            this.DokumentID.Width = 125;
            // 
            // NazivDokumenta
            // 
            this.NazivDokumenta.DataPropertyName = "NazivDokumenta";
            this.NazivDokumenta.HeaderText = "Naziv dokumenta";
            this.NazivDokumenta.MinimumWidth = 6;
            this.NazivDokumenta.Name = "NazivDokumenta";
            this.NazivDokumenta.ReadOnly = true;
            this.NazivDokumenta.Width = 160;
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "FileName";
            this.FileName.HeaderText = "Naziv datoteke";
            this.FileName.MinimumWidth = 6;
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 170;
            // 
            // frmDokument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 554);
            this.Controls.Add(this.dgvDokumenti);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.btnPrikazi);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmDokument";
            this.Text = "frmDokumenti";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDokumenti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.DataGridView dgvDokumenti;
        private System.Windows.Forms.DataGridViewTextBoxColumn DokumentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NazivDokumenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
    }
}