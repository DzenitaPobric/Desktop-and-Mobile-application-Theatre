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
    public partial class frmRezervacije : Form
    {
        private readonly APIService _rezervacije = new APIService("rezervacija");
        private readonly APIService _kupac = new APIService("kupac");
        private readonly APIService _prikazivanje = new APIService("prikazivanje");

        public frmRezervacije()
        {
            InitializeComponent();
        }

        private async Task LoadKupceIme()
        {
            var result = await _kupac.Get<List<Model.Kupac>>(null);
            cmbIme.DisplayMember = "Ime";
            cmbIme.ValueMember = "KupacId";
            result.Insert(0, new Model.Kupac());
            cmbIme.DataSource = result;
        }
      
        private async Task LoadRezervacije(int id)
        {
            var result = await _rezervacije.Get<List<Model.Rezervacija>>(new RezervacijaSearchRequest()
            {
                KupacId = id
            });
            dgvRezervacija.AutoGenerateColumns = false;
            dgvRezervacija.DataSource = result;
        }

   
        private async void frmRezervacije_Load(object sender, EventArgs e)
        {
            await LoadKupceIme();
        }

        private void dgvRezervacija_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvRezervacija.SelectedRows[0].Cells[0].Value;
            var frm = new frmRezervacijeDetalji(int.Parse(id.ToString()));
            frm.Show();
        }

        private async void cmbIme_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbIme.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadRezervacije(id);
            }
        }
    }
}
