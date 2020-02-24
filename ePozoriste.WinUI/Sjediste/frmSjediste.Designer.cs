namespace ePozoriste.WinUI.Sjediste
{
    partial class frmSjediste
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
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSala = new System.Windows.Forms.ComboBox();
            this.txtRed = new System.Windows.Forms.TextBox();
            this.txtKolona = new System.Windows.Forms.TextBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.dgvSjediste = new System.Windows.Forms.DataGridView();
            this.SjedisteId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Red = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kolona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSjediste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sala";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Red";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 166);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kolona";
            // 
            // cmbSala
            // 
            this.cmbSala.FormattingEnabled = true;
            this.cmbSala.Location = new System.Drawing.Point(209, 60);
            this.cmbSala.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbSala.Name = "cmbSala";
            this.cmbSala.Size = new System.Drawing.Size(196, 24);
            this.cmbSala.TabIndex = 3;
            this.cmbSala.SelectedIndexChanged += new System.EventHandler(this.cmbSala_SelectedIndexChanged);
            // 
            // txtRed
            // 
            this.txtRed.Location = new System.Drawing.Point(209, 108);
            this.txtRed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRed.Name = "txtRed";
            this.txtRed.Size = new System.Drawing.Size(196, 22);
            this.txtRed.TabIndex = 4;
            this.txtRed.Validating += new System.ComponentModel.CancelEventHandler(this.txtRed_Validating);
            // 
            // txtKolona
            // 
            this.txtKolona.Location = new System.Drawing.Point(209, 167);
            this.txtKolona.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtKolona.Name = "txtKolona";
            this.txtKolona.Size = new System.Drawing.Size(196, 22);
            this.txtKolona.TabIndex = 5;
            this.txtKolona.Validating += new System.ComponentModel.CancelEventHandler(this.txtKolona_Validating);
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(411, 223);
            this.btnSacuvaj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(100, 28);
            this.btnSacuvaj.TabIndex = 6;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // dgvSjediste
            // 
            this.dgvSjediste.AllowUserToAddRows = false;
            this.dgvSjediste.AllowUserToDeleteRows = false;
            this.dgvSjediste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSjediste.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SjedisteId,
            this.Red,
            this.Kolona,
            this.SalaId});
            this.dgvSjediste.Location = new System.Drawing.Point(64, 282);
            this.dgvSjediste.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvSjediste.Name = "dgvSjediste";
            this.dgvSjediste.ReadOnly = true;
            this.dgvSjediste.RowHeadersWidth = 51;
            this.dgvSjediste.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSjediste.Size = new System.Drawing.Size(447, 235);
            this.dgvSjediste.TabIndex = 7;
            // 
            // SjedisteId
            // 
            this.SjedisteId.DataPropertyName = "SjedisteId";
            this.SjedisteId.HeaderText = "SjedisteId";
            this.SjedisteId.MinimumWidth = 6;
            this.SjedisteId.Name = "SjedisteId";
            this.SjedisteId.ReadOnly = true;
            this.SjedisteId.Visible = false;
            this.SjedisteId.Width = 125;
            // 
            // Red
            // 
            this.Red.DataPropertyName = "Red";
            this.Red.HeaderText = "Red";
            this.Red.MinimumWidth = 6;
            this.Red.Name = "Red";
            this.Red.ReadOnly = true;
            this.Red.Width = 125;
            // 
            // Kolona
            // 
            this.Kolona.DataPropertyName = "Kolona";
            this.Kolona.HeaderText = "Kolona";
            this.Kolona.MinimumWidth = 6;
            this.Kolona.Name = "Kolona";
            this.Kolona.ReadOnly = true;
            this.Kolona.Width = 125;
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
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmSjediste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 544);
            this.Controls.Add(this.dgvSjediste);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.txtKolona);
            this.Controls.Add(this.txtRed);
            this.Controls.Add(this.cmbSala);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmSjediste";
            this.Text = "frmSjediste";
            this.Load += new System.EventHandler(this.frmSjediste_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSjediste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSala;
        private System.Windows.Forms.TextBox txtRed;
        private System.Windows.Forms.TextBox txtKolona;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.DataGridView dgvSjediste;
        private System.Windows.Forms.DataGridViewTextBoxColumn SjedisteId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Red;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kolona;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalaId;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}