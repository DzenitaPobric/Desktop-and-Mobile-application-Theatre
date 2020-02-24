using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using Flurl;
using ePozoriste.Model.Requests;

namespace ePozoriste.WinUI.Grad
{
    public partial class frmGrad : Form
    {

        private readonly APIService _apiService = new APIService("grad");

        public frmGrad()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new GradSearchRequest()
            {
                Naziv = txtPretraga.Text
            };
            var result = await _apiService.Get<List<Model.Grad>>(search);
            dgvGrad.AutoGenerateColumns = false;
            dgvGrad.DataSource = result;
        }

        private void dgvGrad_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvGrad.SelectedRows[0].Cells[0].Value;

            frmGradDetalji frm = new frmGradDetalji(int.Parse(id.ToString()));
            frm.Show();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmGradDetalji frm = new frmGradDetalji();
            frm.Show();
        }
    }
}
