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

namespace ePozoriste.WinUI.Predstava
{
    public partial class frmPredstavaPrikaz : Form
    {
        private readonly APIService _predstave = new APIService("predstava");
        private readonly APIService _zanr = new APIService("zanr");
        public frmPredstavaPrikaz()
        {
            InitializeComponent();
        }

        private async Task LoadZanrove()
        {
            var result = await _zanr.Get<List<Model.Zanr>>(null);
            cmbZanr.DisplayMember = "Naziv";
            cmbZanr.ValueMember = "ZanrId";
            cmbZanr.DataSource = result;
        }

        private async Task LoadPredstave(int id)
        {
            var result = await _predstave.Get<List<Model.Predstava>>(new PredstavaSearchRequest()
            {
                ZanrId = id
            });
            dgvPredstave.AutoGenerateColumns = false;
            dgvPredstave.DataSource = result;
        }

        private async void frmPredstavaPrikaz_Load(object sender, EventArgs e)
        { 
                await LoadZanrove();         
        }

        private void dgvPredstave_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvPredstave.SelectedRows[0].Cells[0].Value;
            var frm = new frmPredstava(int.Parse(id.ToString()));
            frm.Show();
        }

        private async void cmbZanr_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbZanr.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadPredstave(id);
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmPredstava frm = new frmPredstava();
            frm.Show();
        }


    }
}
