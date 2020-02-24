using ePozoriste.Model.Requests;
using QRCoder;
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

namespace ePozoriste.WinUI.Ulaznica
{
    public partial class frmUlaznicaDetalji : Form
    {
        private readonly APIService _ulaznice = new APIService("Ulaznica");
        private readonly APIService _rezervacije = new APIService("Rezervacija");
        private readonly APIService _kupac = new APIService("Kupac");
        private readonly APIService _prikazivanje = new APIService("Prikazivanje");
        private readonly APIService _sjediste = new APIService("Sjediste");

        private int? _id = null;

        public frmUlaznicaDetalji(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmUlaznicaDetalji_Load(object sender, EventArgs e)
        {
            await LoadPrikazivanje();
            await LoadKupce();
            await LoadSjedista();
            await LoadRezervacije();
            if (_id.HasValue)
            {
                var ulaznica = await _ulaznice.GetById<Model.Ulaznica>(_id);
                cmbPrikazivanje.SelectedValue = int.Parse(ulaznica.PrikazivanjeId.ToString());
                cmbKupac.SelectedValue = int.Parse(ulaznica.KupacId.ToString());
                cmbSjediste.SelectedValue = int.Parse(ulaznica.SjedisteId.ToString());
                cmbREzervacija.SelectedValue = int.Parse(ulaznica.RezervacijaId.ToString());

            }
        }

        public Image BytesToImage(byte[] arr)
        {
            MemoryStream ms = new MemoryStream(arr);
            return Image.FromStream(ms);
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

        private async Task LoadKupce()
        {
            var result = await _kupac.Get<List<Model.Kupac>>(null);
            cmbKupac.DisplayMember = "KupacPodaci";
            cmbKupac.ValueMember = "KupacId";
            cmbKupac.SelectedItem = null;
            cmbKupac.SelectedText = "--Odaberite--";
            cmbKupac.DataSource = result;
        }

        private async Task LoadSjedista()
        {
            var result = await _sjediste.Get<List<Model.Sjediste>>(null);
            cmbSjediste.DisplayMember = "Red";
            cmbSjediste.ValueMember = "SjedisteId";
            cmbSjediste.SelectedItem = null;
            cmbSjediste.SelectedText = "--Odaberite--";
            cmbSjediste.DataSource = result;
        }

        private async Task LoadRezervacije()
        {
            var result = await _rezervacije.Get<List<Model.Rezervacija>>(null);
            cmbREzervacija.DisplayMember = "DatumRezervacije";
            cmbREzervacija.ValueMember = "RezervacijaId";
            cmbREzervacija.SelectedItem = null;
            cmbREzervacija.SelectedText = "--Odaberite--";
            cmbREzervacija.DataSource = result;
        }

        UlaznicaUpsertRequest request = new UlaznicaUpsertRequest();

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var idObj = cmbPrikazivanje.SelectedValue;

                if (int.TryParse(idObj.ToString(), out int prikazivanjeId))
                {
                    request.PrikazivanjeId = prikazivanjeId;
                }

                var kupacIdObj = cmbKupac.SelectedValue;

                if (int.TryParse(kupacIdObj.ToString(), out int kupacId))
                {
                    request.KupacId = kupacId;
                }

                var sjedisteIdObj = cmbSjediste.SelectedValue;

                if (int.TryParse(sjedisteIdObj.ToString(), out int sjedisteId))
                {
                    request.SjedisteId = sjedisteId;
                }

                var rezervIdObj = cmbREzervacija.SelectedValue;

                if (int.TryParse(rezervIdObj.ToString(), out int rezervId))
                {
                    request.RezervacijaId = rezervId;
                }

                if (_id.HasValue)
                {
                    await _ulaznice.Update<Model.Ulaznica>(_id.Value, request);
                }
                else
                {
                    await _ulaznice.Insert<Model.Ulaznica>(request);
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
    }
}
