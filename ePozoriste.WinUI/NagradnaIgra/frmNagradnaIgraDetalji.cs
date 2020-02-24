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

namespace ePozoriste.WinUI.NagradnaIgra
{
    public partial class frmNagradnaIgraDetalji : Form
    {
        private readonly APIService _nagradnaIgra = new APIService("NagradnaIgra");

        public frmNagradnaIgraDetalji()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
             
             var search = new NagradnaIgraSearchRequest()
             {
                 Naziv = txtNaziv.Text
             };
             var result = await _nagradnaIgra.Get<List<Model.NagradnaIgra>>(search);
             dgvNagradnaIgra.AutoGenerateColumns = false;
             dgvNagradnaIgra.DataSource = result;
            
        }

        private void dgvNagradnaIgra_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvNagradnaIgra.SelectedRows[0].Cells[0].Value;

            frmNagradnaIgra frm = new frmNagradnaIgra(int.Parse(id.ToString()));
            frm.Show();
        }


        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmNagradnaIgra frm = new frmNagradnaIgra();
            frm.Show();
        }
    }
}
