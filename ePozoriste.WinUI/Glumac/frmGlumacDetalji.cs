using ePozoriste.Model.Requests;
using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ePozoriste.WinUI.Glumac
{
    public partial class frmGlumacDetalji : Form
    {
        private readonly APIService _apiService = new APIService("glumac");
        private int? _id = null;

        public frmGlumacDetalji(int? glumacId = null)
        {
            InitializeComponent();
            _id = glumacId;
        }

        ImageConverter imgConverter = new ImageConverter();

        GlumacUpsertRequest request = new GlumacUpsertRequest();


        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                request.Ime = txtIme.Text;
                request.Prezime = txtPrezime.Text;
                request.BrojUgovora = Convert.ToInt32(txtUgovor.Text);
                request.Email = txtEmail.Text;
                request.DatumRodjenja = dateTimeRođenje.Value;
                request.Slika = (System.Byte[])imgConverter.ConvertTo(pictureBox1.Image, Type.GetType("System.Byte[]"));

                if (_id.HasValue)
                {
                    await _apiService.Update<Model.Glumac>(_id.Value, request);
                }
                else
                {
                    await _apiService.Insert<Model.Glumac>(request);
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

        
        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
                var result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var fileName = openFileDialog1.FileName;
                    var file = File.ReadAllBytes(fileName);

                    request.Slika = file;
                    txtInputslike.Text = fileName;

                    Image image = Image.FromFile(fileName);
                    pictureBox1.Image = image;
                }
  
        }

        private async void frmGlumacDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var glumac = await _apiService.GetById<Model.Glumac>(_id);
                txtIme.Text = glumac.Ime;
                txtPrezime.Text = glumac.Prezime;
                txtUgovor.Text = glumac.BrojUgovora.ToString();
                txtEmail.Text = glumac.Email;
                if (glumac.Slika.Length != 0)
                {
                    pictureBox1.Image = BytesToImage(glumac.Slika);
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.noImage1;
                }
            }
        }

        public Image BytesToImage(byte[] arr)
        {
            MemoryStream ms = new MemoryStream(arr);
            return Image.FromStream(ms);
        }

        private void txtIme_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtIme.Text))
            {
                errorProvider.SetError(txtIme, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtIme.Text, @"^[a-zA-Z ]+$"))
            {
                errorProvider.SetError(txtIme, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtIme, null);
            }
        }

        private void txtPrezime_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrezime.Text))
            {
                errorProvider.SetError(txtPrezime, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtPrezime.Text, @"^[a-zA-Z -]+$"))
            {
                errorProvider.SetError(txtPrezime, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPrezime, null);
            }
        }

        private void txtUgovor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUgovor.Text))
            {
                errorProvider.SetError(txtUgovor, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtUgovor.Text, @"^[0-9]+$"))
            {
                errorProvider.SetError(txtUgovor, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtUgovor, null);
            }
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"))
            {
                errorProvider.SetError(txtEmail, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtEmail, null);
            }
        }
    }
}
