using ePozoriste.Model;
using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ePozoriste.WinUI.Novosti
{
    public partial class frmNovostiDetalji : Form
    {
        private readonly APIService _novosti = new APIService("novosti");
        private readonly APIService _korisnik = new APIService("korisnik");
        private readonly APIService _notif = new APIService("notifikacija");
        private int? _id = null;
        public frmNovostiDetalji(int? korisnikId = null)
        {
            InitializeComponent();
            _id = korisnikId;
        }
        ImageConverter imgConverter = new ImageConverter();
        NovostiInsertRequest request = new NovostiInsertRequest();
        

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var request = new NovostiInsertRequest()
            {
                Naziv = txtNaziv.Text,
                Tekst = richTextBtxtTekstox1.Text,
                DatumVrijemeObjave = dtObjave.Value,
                Slika = (System.Byte[])imgConverter.ConvertTo(pictureBox1.Image, Type.GetType("System.Byte[]")),
                 KorisnikId = 1

            };
            if (_id.HasValue)
            {
                await _novosti.Update<Model.Novosti>(_id.Value, request);
            }
            else
            {
                var entity= await _novosti.Insert<Model.Novosti>(request);
                if (entity != null)
                {
                    await _notif.Insert<Notifikacija>(new NotfikacijaInsertRequest
                    {
                        DatumSlanja=DateTime.Now,
                        IsProcitano=false,
                        NovostiId=entity.NovostiId
                    });
                }
                
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


    
        private async  void frmNovostiDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var novosti = await _novosti.GetById<Model.Novosti>(_id);
                txtNaziv.Text = novosti.Naziv;
                richTextBtxtTekstox1.Text = novosti.Tekst;
                dtObjave.Value = novosti.DatumVrijemeObjave;
                if (novosti.Slika.Length != 0 )
                {
                    pictureBox1.Image = BytesToImage(novosti.Slika);
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

        private void btnSlika_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;

                var file = File.ReadAllBytes(fileName);

                request.Slika = file;
                txtInputSlike.Text = fileName;

                Image image = Image.FromFile(fileName);
                pictureBox1.Image = image;
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

        private void richTextBtxtTekstox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBtxtTekstox1.Text))
            {
                errorProvider.SetError(richTextBtxtTekstox1, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(richTextBtxtTekstox1.Text, @"^[a-zA-Z ]+$"))
            {
                errorProvider.SetError(richTextBtxtTekstox1, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(richTextBtxtTekstox1, null);
            }
        }
    }
}
