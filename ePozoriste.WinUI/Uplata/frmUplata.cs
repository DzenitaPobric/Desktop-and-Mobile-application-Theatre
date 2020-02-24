using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ePozoriste.WinUI.Uplata
{
    public partial class frmUplata : Form
    {

        private readonly APIService _sponzor = new APIService("sponzor");
        private readonly APIService _uplata = new APIService("uplata");
        private int? _id = null;

        
        public frmUplata(int? uplataId = null)
        {
            InitializeComponent();
            _id = uplataId;
        }


        private async void frmUplata_Load(object sender, EventArgs e)
        {
            await LoadSponzor();
            if (_id.HasValue)
            {
                var uplata = await _uplata.GetById<Model.Uplata>(_id);
                txtNaziv.Text = uplata.Naziv;
                txtIznos.Text = (uplata.Iznos).ToString();
                txtSvrhqa.Text = uplata.Svrha;
                cmbSponzor.SelectedValue = int.Parse(uplata.SponzorId.ToString());
                dateTimePicker1.Value = uplata.DatumUplate;
            }
        }

        private async Task LoadSponzor()
        {
            var result = await _sponzor.Get<List<Model.Sponzor>>(null);
           cmbSponzor.DisplayMember = "Naziv";
           cmbSponzor.ValueMember = "SponzorId";
           cmbSponzor.SelectedItem = null;
           cmbSponzor.SelectedText = "--Odaberite--";
           cmbSponzor.DataSource = result;
        }

        private async void cmbSponzor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbSponzor.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadUplate(id);
            }
        }

        private async Task LoadUplate(int sponzorId)
        {
            var result = await _uplata.Get<List<Model.Uplata>>(new UplataSearchRequest()
            {
                SponzorId = sponzorId
            });
            dgvUplata.DataSource = result;
        }

        UplataUpsertRequest request = new UplataUpsertRequest();

        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var idObj = cmbSponzor.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int sponzorId))
            {
                request.SponzorId = sponzorId;
                request.Naziv = txtNaziv.Text;
                request.Iznos = double.Parse(txtIznos.Text);
                request.Svrha = txtSvrhqa.Text;
                request.DatumUplate = dateTimePicker1.Value;
            }
            if (_id.HasValue)
            {
                await _uplata.Update<Model.Uplata>(_id.Value, request);
            }
            else
            {
                await _uplata.Insert<Model.Uplata>(request);
            }
            MessageBox.Show("Uspješno sačuvani podaci");
                this.Close();
            }
            else
            {
                MessageBox.Show("Operacija nije uspjela");
                this.Close();
            }
        }

        private void dgvUplata_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvUplata.SelectedRows[0].Cells[0].Value;

            frmUplata frm = new frmUplata(int.Parse(id.ToString()));
            frm.Show();
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtNaziv.Text, @"^[a-zA-Z ]+$"))
            {
                errorProvider1.SetError(txtNaziv, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNaziv, null);
            }
        }

        private void txtIznos_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtIznos.Text))
            {
                errorProvider1.SetError(txtIznos, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtIznos.Text, @"^[0-9]+$"))
            {
                errorProvider1.SetError(txtIznos, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtIznos, null);
            }
        }

        private void txtSvrhqa_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSvrhqa.Text))
            {
                errorProvider1.SetError(txtSvrhqa, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtSvrhqa.Text, @"^[a-zA-Z ]+$"))
            {
                errorProvider1.SetError(txtSvrhqa, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtSvrhqa, null);
            }
        }
    }
}
