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

namespace ePozoriste.WinUI.Sala
{
    public partial class frmSalaDetalji : Form
    {
        private readonly APIService _apiService = new APIService("sala");
        private int? _id = null;

        public frmSalaDetalji(int? salaId = null)
        {
            InitializeComponent();
            _id = salaId;
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var request = new SalaUpsertRequest()
                {
                    Naziv = txtNaziv.Text,
                    Kapacitet = int.Parse(txtKapacitet.Text),
                    Klimatizacija = chBKlimatizacija.Checked,
                    Lat=txtlat.Text,
                    Lng=txtlng.Text
                };
                if (_id.HasValue)
                {
                    await _apiService.Update<Model.Grad>(_id.Value, request);
                }
                else
                {
                    await _apiService.Insert<Model.Grad>(request);
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

        private async void frmSalaDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var sala = await _apiService.GetById<Model.Sala>(_id);
                txtNaziv.Text = sala.Naziv;
                txtKapacitet.Text = sala.Kapacitet.ToString();
                chBKlimatizacija.Text = sala.Klimatizacija.ToString();
                txtlng.Text = sala.Lng;
                txtlat.Text = sala.Lat;
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

        private void txtKapacitet_Validating(object sender, CancelEventArgs e)
        {
          
                if (string.IsNullOrEmpty(txtKapacitet.Text))
                {
                    errorProvider1.SetError(txtKapacitet, Properties.Resources.Validation_RequiredField);
                    e.Cancel = true;
                }
                else if (!Regex.IsMatch(txtKapacitet.Text, @"^[0-9]+$"))
                {
                    errorProvider1.SetError(txtKapacitet, Properties.Resources.NeispravanFormat);
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(txtKapacitet, null);
                }
           
        }

     
    }
}
