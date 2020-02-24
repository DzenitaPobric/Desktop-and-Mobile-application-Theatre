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

namespace ePozoriste.WinUI.Sala
{
    public partial class frmSala : Form
    {
        private readonly APIService _apiService = new APIService("sala");

        public frmSala()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new SalaSearchRequest()
            {
                Naziv = txtPretraga.Text
            };
            var result = await _apiService.Get<List<Model.Sala>>(search);
            dgvSala.AutoGenerateColumns = false;
            dgvSala.DataSource = result;
        }


        private void dgvSala_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvSala.SelectedRows[0].Cells[0].Value;

            frmSalaDetalji frm = new frmSalaDetalji(int.Parse(id.ToString()));
            frm.Show();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmSalaDetalji frm = new frmSalaDetalji();
            frm.Show();
        }


    }
}
