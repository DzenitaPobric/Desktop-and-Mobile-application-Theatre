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

namespace ePozoriste.WinUI.Prikazivanje
{
    public partial class frmPrikazivanjePrikaz : Form
    {

        private readonly APIService _predstava = new APIService("predstava");
        private readonly APIService _sala = new APIService("sala");
        private readonly APIService _prikazivanje = new APIService("prikazivanje");
        public frmPrikazivanjePrikaz()
        {
            InitializeComponent();
        }

        private async Task LoadPredstave()
        {
            var result = await _predstava.Get<List<Model.Predstava>>(null);
            cmbPredstava.DisplayMember = "Naziv";
            cmbPredstava.ValueMember = "PredstavaId";
            result.Insert(0, new Model.Predstava());
            cmbPredstava.DataSource = result;
        }

     

        private async Task LoadPrikazivanja(int id)
        {
            var result = await _prikazivanje.Get<List<Model.Prikazivanje>>(new PrikazivanjeSearchRequest()
            {
                PredstavaId = id
             
            });
            dgvPRikazivanje.AutoGenerateColumns = false;
            dgvPRikazivanje.DataSource = result;
        }

        private async void frmPrikazivanjePrikaz_Load(object sender, EventArgs e)
        {
            await LoadPredstave();
        }

        private void dgvPRikazivanje_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvPRikazivanje.SelectedRows[0].Cells[0].Value;
            var frm = new frmPrikazivanje(int.Parse(id.ToString()));
            frm.Show();
        }

        private async void cmbPredstava_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbPredstava.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadPrikazivanja(id);
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmPrikazivanje frm = new frmPrikazivanje();
            frm.Show();
        }

      
    }
    }
