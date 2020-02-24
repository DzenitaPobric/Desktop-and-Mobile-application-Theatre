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

namespace ePozoriste.WinUI.NagradnaIgra
{
    public partial class frmNagradnaIgra : Form
    {
        private readonly APIService _nagradnaIgra = new APIService("NagradnaIgra");
        private readonly APIService _korisnik = new APIService("korisnik");
        private int? _id = null;
        public frmNagradnaIgra(int? korisnikId = null)
        {
            InitializeComponent();
            _id = korisnikId;
        }

    

        private async void frmNagradnaIgra_Load(object sender, EventArgs e)
        {

            if (_id.HasValue)
            {
                var igra = await _nagradnaIgra.GetById<Model.NagradnaIgra>(_id);
                txtNaziv.Text = igra.Naziv;
                txtOpis.Text = igra.Opis;
                dtPocetak.Value = igra.Pocetak;
                dtKraj.Value = igra.Kraj;
            }
        }


        NagradnaIgraInsertRequest request = new NagradnaIgraInsertRequest();

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
                if (this.ValidateChildren())
            {
                var request = new NagradnaIgraInsertRequest()
                {
                    Naziv = txtNaziv.Text,
                    Opis = txtOpis.Text,
                    Kraj = dtKraj.Value,
                    Pocetak = dtPocetak.Value,
                    KorisnikId = 2

                };
                if (_id.HasValue)
                {
                    try
                    {
                        await _nagradnaIgra.Update<Model.NagradnaIgra>(_id.Value, request);
                        MessageBox.Show("Uspješno sačuvani podaci");
                        this.Close();
                    }

                    catch (Exception)
                    {
                        DialogResult r = MessageBox.Show("Nemate pravo pristupa");
                        if (r == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                }
                else
                {
                    try
                    {
                        await _nagradnaIgra.Insert<Model.NagradnaIgra>(request);
                        MessageBox.Show("Uspješno sačuvani podaci");
                        this.Close();
                    }

                    catch (Exception)
                    {
                        DialogResult r = MessageBox.Show("Nemate pravo pristupa");
                        if (r == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Operacija nije uspjela");
                this.Close();
            }
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtNaziv.Text))
            {
                errorProvider.SetError(txtNaziv, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtNaziv.Text, @"^[a-zA-Z ]+$"))
            {
                errorProvider.SetError(txtNaziv, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtNaziv, null);
            }
        }

        private void txtOpis_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtOpis.Text))
            {
                errorProvider.SetError(txtOpis, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtOpis.Text, @"^[a-zA-Z ]+$"))
            {
                errorProvider.SetError(txtOpis, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtOpis, null);
            }
        }


    }
}
