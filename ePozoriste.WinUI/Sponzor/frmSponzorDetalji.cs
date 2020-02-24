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

namespace ePozoriste.WinUI.Sponzor
{
    public partial class frmSponzorDetalji : Form
    {
        private readonly APIService _apiService = new APIService("sponzor");
        private int? _id = null;
        public frmSponzorDetalji(int? sponzorId = null)
        {
            InitializeComponent();
            _id = sponzorId;

        }

        private async void btnSAcuvaj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var request = new SponzorInsertRequest()
                {
                    Naziv = txtNaziv.Text,
                    BrojTelefona = txtTelefon.Text
                };
                if (_id.HasValue)
                {
                    await _apiService.Update<Model.Sponzor>(_id.Value, request);
                }
                else
                {
                    await _apiService.Insert<Model.Sponzor>(request);
                }
                MessageBox.Show("Uspješno sačuvani podaci");
                this.Close();

            }
            else
            {
                MessageBox.Show("Operacija nije uspjela");
                this.Close();
            }
        }

        private async void frmSponzorDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var sponzor = await _apiService.GetById<Model.Sponzor>(_id);
                txtNaziv.Text = sponzor.Naziv;
                txtTelefon.Text = sponzor.BrojTelefona;
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

        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTelefon.Text))
            {
                errorProvider1.SetError(txtTelefon, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtTelefon.Text, @"^[+]{1}\d{3}[ ]?\d{2}[ ]?\d{3}[ ]?\d{3}"))
            {
                errorProvider1.SetError(txtTelefon, "Format telefona je: +123 45 678 910");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtTelefon, null);
            }
        }
    }
}
