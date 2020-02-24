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

namespace ePozoriste.WinUI.Sjediste
{
    public partial class frmSjediste : Form
    {
        private readonly APIService _sala = new APIService("sala");
        private readonly APIService _sjediste = new APIService("sjediste");
        private int? _id = null;

        public frmSjediste(int? sjedisteId = null)
        {
            InitializeComponent();
            _id = sjedisteId;
        }

        private async void frmSjediste_Load(object sender, EventArgs e)
        {
            await LoadSala();
            if (_id.HasValue)
            {
                var sjediste = await _sjediste.GetById<Model.Sjediste>(_id);
                txtKolona.Text = (sjediste.Kolona).ToString();
                txtRed.Text = (sjediste.Red).ToString();               
                cmbSala.SelectedValue = int.Parse(sjediste.SalaId.ToString());

            }
        }

        private async Task LoadSala()
        {
            var result = await _sala.Get<List<Model.Sala>>(null);
            cmbSala.DisplayMember = "Naziv";
            cmbSala.ValueMember = "SalaId";
            cmbSala.SelectedItem = null;
            cmbSala.SelectedText = "--Odaberite--";
            cmbSala.DataSource = result;
        }

        private async void cmbSala_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbSala.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadSjediste(id);
            }
        }

        private async Task LoadSjediste(int salaId)
        {
            var result = await _sjediste.Get<List<Model.Sjediste>>(new SjedisteSearchRequest()
            {
                SalaId = salaId
            });
           
            dgvSjediste.DataSource = result;
        }

        SjedisteUpsertRequest request = new SjedisteUpsertRequest();

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            var idObj = cmbSala.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int salaId))
            {
                request.SalaId = salaId;
            }
            request.Red = Convert.ToInt32(txtRed.Text);
            request.Kolona = Convert.ToInt32(txtKolona.Text);

            if (_id.HasValue)
            {
                await _sjediste.Update<Model.Sjediste>(_id.Value, request);
            }
            else
            {
                await _sjediste.Insert<Model.Sjediste>(request);
            }
            MessageBox.Show("Uspješno sačuvani podaci");
            this.Close();
        }

        private void txtRed_Validating(object sender, CancelEventArgs e)
        {
            for (int i = 0; i < txtRed.Text.Length; i++)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtRed.Text[i].ToString(), "[^0-9]"))
                {
                    MessageBox.Show("Molimo unesite samo brojeve.");
                    txtRed.Text = txtRed.Text.Remove(txtRed.Text.Length - 1);
                }
            }
        }

        private void txtKolona_Validating(object sender, CancelEventArgs e)
        {
            for (int i = 0; i < txtKolona.Text.Length; i++)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtKolona.Text[i].ToString(), "[^0-9]"))
                {
                    MessageBox.Show("Molimo unesite samo brojeve.");
                    txtKolona.Text = txtKolona.Text.Remove(txtKolona.Text.Length - 1);
                }
            }
        }
    }
}
