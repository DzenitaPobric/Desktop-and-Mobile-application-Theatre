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

namespace ePozoriste.WinUI.Glumac
{
    public partial class frmGlumac : Form
    {
        private readonly APIService _apiService = new APIService("glumac");

        public frmGlumac()
        {
            InitializeComponent();
            this.dgvGlumac.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvGlumac_DataError);

        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new GlumacSearcRequest()
            {
                Ime = txtIme.Text,
                Prezime=txtPrezime.Text
            };
            var result = await _apiService.Get<List<Model.Glumac>>(search);
            dgvGlumac.AutoGenerateColumns = false;
            dgvGlumac.DataSource = result;
      
        }

        private void dgvGlumac_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvGlumac.SelectedRows[0].Cells[0].Value;

            frmGlumacDetalji frm = new frmGlumacDetalji(int.Parse(id.ToString()));
            frm.Show();
        }


        private void dgvGlumac_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmGlumacDetalji frm = new frmGlumacDetalji();
            frm.Show();
        }

    

    }
}
