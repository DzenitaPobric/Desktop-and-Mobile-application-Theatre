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

namespace ePozoriste.WinUI.Ulaznica
{
    public partial class frmUlaznica : Form
    {
        private readonly APIService _ulaznice = new APIService("Ulaznica");
        private readonly APIService _rezervacije = new APIService("Rezervacija");
        private readonly APIService _kupac = new APIService("Kupac");
        private readonly APIService _prikazivanje = new APIService("Prikazivanje");
        private readonly APIService _sjediste = new APIService("Sjediste");

        private readonly APIService _apiService = new APIService("ulaznica");
        public frmUlaznica()
        {
            InitializeComponent();
            this.dgvUlaznice.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvUlaznice_DataError);

        }


        private async Task LoadKupci()
        {
            var result = await _kupac.Get<List<Model.Kupac>>(null);
            cmbKupacIme.DisplayMember = "KupacPodaci";
            cmbKupacIme.ValueMember = "KupacId";
            result.Insert(0, new Model.Kupac());
            cmbKupacIme.DataSource = result;
            cmbKupacIme.Text = "--Odaberite kupca--";
        }


        private async Task LoadUlaznice(int id)
        {
            var result = await _ulaznice.Get<List<Model.Ulaznica>>(new UlaznicaSearchRequest()
            {
                KupacId = id
            });
            dgvUlaznice.AutoGenerateColumns = false;
            dgvUlaznice.DataSource = result;
            foreach (DataGridViewRow row in dgvUlaznice.Rows)
            {
                row.Height = 200;
            }
            
        }

 
        private async  void frmUlaznica_Load(object sender, EventArgs e)
        {
            await LoadKupci();
        }

        private async void cmbKupacIme_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbKupacIme.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadUlaznice(id);
            }
        }

        private void dgvUlaznice_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvUlaznice.SelectedRows[0].Cells[0].Value;
            var frm = new frmUlaznicaDetalji(int.Parse(id.ToString()));
            frm.Show();
        }

 

        private void dgvUlaznice_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;

        }
    }
}
