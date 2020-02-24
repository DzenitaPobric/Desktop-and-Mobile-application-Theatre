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

namespace ePozoriste.WinUI.Sponzor
{
    public partial class frmSponzor : Form
    {
        private readonly APIService _apiService = new APIService("sponzor");
        public frmSponzor()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new SponzorSearchRequest()
            {
                Naziv = txtPretraga.Text
            };
            var result = await _apiService.Get<List<Model.Sponzor>>(search);
            dgvSponzor.AutoGenerateColumns = false;
            dgvSponzor.DataSource = result;
        }

        private void dgvSponzor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvSponzor.SelectedRows[0].Cells[0].Value;

            frmSponzorDetalji frm = new frmSponzorDetalji(int.Parse(id.ToString()));
            frm.Show();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmSponzorDetalji frm = new frmSponzorDetalji();
            frm.Show();
        }
    }
}
