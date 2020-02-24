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

namespace ePozoriste.WinUI.Rezervacije
{
    public partial class frmRezervacijeDetalji : Form
    {
        private readonly APIService _rezervacije = new APIService("Rezervacija");
        private readonly APIService _kupac = new APIService("Kupac");
        private readonly APIService _prikazivanje = new APIService("Prikazivanje");

        private int? _id = null;

        public frmRezervacijeDetalji(int? rezervacijaId=null)
        {
            InitializeComponent();
            _id = rezervacijaId;
        }

        private async void frmRezervacijeDetalji_Load(object sender, EventArgs e)
        {
            await LoadKupceIme();
            await LoadPrikazivanje();
            if (_id.HasValue)
            {
                var rezervacija = await _rezervacije.GetById<Model.Rezervacija>(_id);
                txtBrRezervacije.Text = (rezervacija.BrojRezervacije).ToString();
                dateTimePicker1.Value = rezervacija.DatumRezervacije;
                cmbKupac.SelectedValue = int.Parse(rezervacija.KupacId.ToString());
                cmbPrikazivanje.SelectedValue = int.Parse(rezervacija.PrikazivanjeId.ToString());
               
                checkBox1.Text = rezervacija.Odobrena.ToString();

            }
        }
        private async Task LoadPrikazivanje()
        {
            var result = await _prikazivanje.Get<List<Model.Prikazivanje>>(null);
            cmbPrikazivanje.DisplayMember = "DatumPrikazivanja";
            cmbPrikazivanje.ValueMember = "PrikazivanjeId";
            cmbPrikazivanje.SelectedItem = null;
            cmbPrikazivanje.SelectedText = "--Odaberite--";
            cmbPrikazivanje.DataSource = result;
        }
        private async Task LoadKupceIme()
        {
            var result = await _kupac.Get<List<Model.Kupac>>(null);
            cmbKupac.DisplayMember = "Ime";
            cmbKupac.ValueMember = "KupacId";
            cmbKupac.SelectedItem = null;
            cmbKupac.SelectedText = "--Odaberite--";
            cmbKupac.DataSource = result;
        }

        RezervacijaUpsertRequest request = new RezervacijaUpsertRequest();

        static Random random = new Random();

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var idObj = cmbKupac.SelectedValue;

            if (int.TryParse(idObj.ToString(), out int kupacId))
            {
                request.KupacId = kupacId;
            }

            var prikazivanjeObj = cmbPrikazivanje.SelectedValue;

            if (int.TryParse(prikazivanjeObj.ToString(), out int prikazivanjeId))
            {
                request.PrikazivanjeId = prikazivanjeId;
            }

            request.BrojRezervacije = random.Next(0, 10000); 
            request.Odobrena = false;
            request.DatumRezervacije = DateTime.Now;
            

            if (_id.HasValue)
            {
                await _rezervacije.Update<Model.Rezervacija>(_id.Value, request);
            }
            else
            {
                await _rezervacije.Insert<Model.Rezervacija>(request);
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

        private void txtBrRezervacije_Validating(object sender, CancelEventArgs e)
        {
            for (int i = 0; i < txtBrRezervacije.Text.Length; i++)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtBrRezervacije.Text[i].ToString(), "[^0-9]"))
                {
                    MessageBox.Show("Molimo unesite samo brojeve.");
                    txtBrRezervacije.Text = txtBrRezervacije.Text.Remove(txtBrRezervacije.Text.Length - 1);
                }
            }
        }
    }
}
