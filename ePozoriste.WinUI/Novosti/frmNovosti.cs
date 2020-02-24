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

namespace ePozoriste.WinUI.Novosti
{
    public partial class frmNovosti : Form
    {
        private readonly APIService _novosti = new APIService("novosti");

        public frmNovosti()
        {
            InitializeComponent();
            this.dgvNovosti.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvNovosti_DataError);

        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new NovostiSearchRequest()
            {
                Naziv = txtNaziv.Text
            };
            var result = await _novosti.Get<List<Model.Novosti>>(search);
            dgvNovosti.AutoGenerateColumns = false;
            dgvNovosti.DataSource = result;
        }

        private void dgvNovosti_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvNovosti.SelectedRows[0].Cells[0].Value;

            frmNovostiDetalji frm = new frmNovostiDetalji(int.Parse(id.ToString()));
            frm.Show();
        }

        private void dgvNovosti_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmNovostiDetalji frm = new frmNovostiDetalji();
            frm.Show();
        }
    }
}
