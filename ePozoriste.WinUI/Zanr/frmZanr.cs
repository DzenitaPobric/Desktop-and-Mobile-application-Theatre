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

namespace ePozoriste.WinUI.Zanr
{
    public partial class frmZanr : Form
    {
        private readonly APIService _apiService = new APIService("zanr");

        public frmZanr()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new ZanrSearchRequest()
            {
                Naziv = txtPretraga.Text
            };
            var result = await _apiService.Get<List<Model.Zanr>>(search);
            dgvZanr.AutoGenerateColumns = false;
            dgvZanr.DataSource = result;
        }

        private void dgvZanr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvZanr.SelectedRows[0].Cells[0].Value;

            frmzanrDetalji frm = new frmzanrDetalji(int.Parse(id.ToString()));
            frm.Show();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmzanrDetalji frm = new frmzanrDetalji();
            frm.Show();
        }
    }
}
