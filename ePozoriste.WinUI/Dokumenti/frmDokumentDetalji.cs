using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ePozoriste.WinUI.Dokumenti
{
    public partial class frmDokumentDetalji : Form
    {
        private readonly APIService _apiService = new APIService("Dokument");
        private int? _id = null;


        public frmDokumentDetalji(int? dokumentId = null)
        {
            InitializeComponent();
            _id = dokumentId;
        }

        DokumentUpsertRequest request = new DokumentUpsertRequest();

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            request.NazivDokumenta = txtNaziv.Text;
            request.FileName = lblFileName.Text;

            if (_id.HasValue)
            {
                await _apiService.Update<Model.Dokument>(_id.Value, request);
            }
            else
            {
                await _apiService.Insert<Model.Dokument>(request);
            }
            MessageBox.Show("Uspješno sačuvani podaci");
            this.Close();
        }

        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                lblFileName.Text = Path.GetFileName(fileName);

                var file = File.ReadAllBytes(fileName);
                request.Sadrzaj = file;

            }
        }

        private async void frmDokumentDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var dokument = await _apiService.GetById<Model.Dokument>(_id);
                txtNaziv.Text = dokument.NazivDokumenta;
                lblFileName.Text = dokument.FileName;
            }
        }

    }
}
