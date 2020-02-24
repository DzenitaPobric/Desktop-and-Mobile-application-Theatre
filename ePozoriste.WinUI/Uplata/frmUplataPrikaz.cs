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

namespace ePozoriste.WinUI.Uplata
{
    public partial class frmUplataPrikaz : Form
    {
        private readonly APIService _sponzor = new APIService("sponzor");
        private readonly APIService _uplate = new APIService("uplata");
        public frmUplataPrikaz()
        {
            InitializeComponent();
        }

        private async Task LoadSponzore()
        {
            var result = await _sponzor.Get<List<Model.Sponzor>>(null);
            cmbSponzor.DisplayMember = "Naziv";
            cmbSponzor.ValueMember = "SponzorId";
            result.Insert(0, new Model.Sponzor());
            cmbSponzor.DataSource = result;
        }

        private async Task LoadUplate(int id)
        {
            var result = await _uplate.Get<List<Model.Uplata>>(new UplataSearchRequest()
            {
                SponzorId = id
            });
            dgvUplata.AutoGenerateColumns = false;
            dgvUplata.DataSource = result;
        }

        private async void frmUplataPrikaz_Load(object sender, EventArgs e)
        {
            await LoadSponzore();
        }

        private void dgvUplata_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvUplata.SelectedRows[0].Cells[0].Value;
            var frm = new frmUplata(int.Parse(id.ToString()));
            frm.Show();
        }

     

        private async void cmbSponzor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbSponzor.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadUplate(id);
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmUplata frm = new frmUplata();
            frm.Show();
        }
    }
}
