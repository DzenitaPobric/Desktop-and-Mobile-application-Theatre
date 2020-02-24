using ePozoriste.Model.Requests;
using ePozoriste.WinUI.Kupac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ePozoriste.WinUI
{
    public partial class frmKupac : Form
    {
        private readonly APIService _apiService = new APIService("kupac");

        public frmKupac()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new KupacSearchRequest()
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text
            };
            var result = await _apiService.Get<List<Model.Kupac>>(search);
            dgvKupac.AutoGenerateColumns = false;
            dgvKupac.DataSource = result;
        }

        private void dgvKupac_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvKupac.SelectedRows[0].Cells[0].Value;

            frmKupacDetalji frm = new frmKupacDetalji(int.Parse(id.ToString()));
            frm.Show();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmKupacDetalji frm = new frmKupacDetalji();
            frm.Show();
        }
    }
}
