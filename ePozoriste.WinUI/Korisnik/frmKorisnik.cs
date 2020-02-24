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

namespace ePozoriste.WinUI.Korisnik
{
    public partial class frmKorisnik : Form
    {
        APIService _apiService = new APIService("korisnik");
        public frmKorisnik()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
                var search = new KorisnikSearchRequest()
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                };

                var list = await _apiService.Get<List<Model.Korisnik>>(search);
                dgvKorisnik.AutoGenerateColumns = false;
                dgvKorisnik.DataSource = list;
            
        }   
     

        private void dgvKorisnici_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var korisnikId = int.Parse(dgvKorisnik.SelectedRows[0].Cells[0].Value.ToString());

            frmKorisnikDetails frm = new frmKorisnikDetails(korisnikId);
            frm.Show();
        }
    }
}
