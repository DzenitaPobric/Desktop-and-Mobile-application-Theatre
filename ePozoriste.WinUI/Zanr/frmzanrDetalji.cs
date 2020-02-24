using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ePozoriste.WinUI.Zanr
{

    public partial class frmzanrDetalji : Form
    {
        private readonly APIService _apiService = new APIService("zanr");
        private int? _id = null;

        public frmzanrDetalji(int? zanrId = null)
        {
            InitializeComponent();
            _id = zanrId;
        }

        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var request = new ZanrInsertRequest()
                {
                    Naziv = txtNaziv.Text
                };
                if (_id.HasValue)
                {
                    await _apiService.Update<Model.Zanr>(_id.Value, request);
                }
                else
                {
                    await _apiService.Insert<Model.Zanr>(request);
                }
                MessageBox.Show("Uspješno sačuvani podaci");
                this.Close();

            }
        }

        private async void frmzanrDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var zanr = await _apiService.GetById<Model.Zanr>(_id);
                txtNaziv.Text = zanr.Naziv;
            }
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtNaziv.Text, @"^[a-zA-Z ]+$"))
            {
                errorProvider1.SetError(txtNaziv, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNaziv, null);
            }
        }
    }
}
