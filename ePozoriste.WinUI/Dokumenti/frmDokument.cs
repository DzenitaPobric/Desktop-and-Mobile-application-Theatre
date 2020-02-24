using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ePozoriste.WinUI.Dokumenti
{
    public partial class frmDokument : Form
    {
        private readonly APIService _apiService = new APIService("Dokument");

        public frmDokument()
        {
            InitializeComponent();
            this.dgvDokumenti.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDokument_DataError);

        }


        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new DokumentSearchRequest()
            {
                Naziv = txtNaziv.Text
            };
            var result = await _apiService.Get<List<Model.Dokument>>(search);
            dgvDokumenti.AutoGenerateColumns = false;
            dgvDokumenti.DataSource = result;

        }



        private void dgvDokumenti_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvDokumenti.SelectedRows[0].Cells[0].Value;

            frmDokumentDetalji frm = new frmDokumentDetalji(int.Parse(id.ToString()));
            frm.Show();
        }

        private void dgvDokument_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;

        }
    }
}
