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

namespace ePozoriste.WinUI.Prikazivanje
{
    public partial class frmPrikazivanje : Form
    {
        private readonly APIService _predstava = new APIService("predstava");
        private readonly APIService _sala = new APIService("sala");
        private readonly APIService _prikazivanje = new APIService("prikazivanje");
        private int? _id = null;

        public frmPrikazivanje(int? prikazivanjeId = null)
        {
            InitializeComponent();
            _id = prikazivanjeId;

        }


        private async void frmPrikazivanje_Load(object sender, EventArgs e)
        {
            await LoadPredstave();
            await LoadSale();
            if (_id.HasValue)
            {
                var prikazivanje = await _prikazivanje.GetById<Model.Prikazivanje>(_id);
                dateTimePicker1.Value = prikazivanje.DatumPrikazivanja;
                cmbPredstava.SelectedValue = int.Parse(prikazivanje.PredstavaId.ToString());
                cmbSala.SelectedValue = int.Parse(prikazivanje.SalaId.ToString());
                txtCijena.Text = (prikazivanje.Cijena).ToString();
            }
        }

        private async Task LoadPredstave()
        {
            var result = await _predstava.Get<List<Model.Predstava>>(null);
            cmbPredstava.DisplayMember = "Naziv";
            cmbPredstava.ValueMember = "PredstavaId";
            cmbPredstava.SelectedItem = null;
            cmbPredstava.SelectedText = "--Odaberite--";
            cmbPredstava.DataSource = result;
        }

        private async Task LoadSale()
        {
            var result = await _sala.Get<List<Model.Sala>>(null);
            cmbSala.DisplayMember = "Naziv";
            cmbSala.ValueMember = "SalaId";
            cmbSala.SelectedItem = null;
            cmbSala.SelectedText = "--Odaberite--";
            cmbSala.DataSource = result;
        }


        PrikazivanjeUpsertRequest request = new PrikazivanjeUpsertRequest();

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var idObj = cmbPredstava.SelectedValue;

            if (int.TryParse(idObj.ToString(), out int predstavaId))
            {
                request.PredstavaId = predstavaId;
            }

            var salaIdObj = cmbSala.SelectedValue;

            if (int.TryParse(salaIdObj.ToString(), out int salaId))
            {
                request.SalaId = salaId;
            }

            request.DatumPrikazivanja = dateTimePicker1.Value;
            request.Cijena =Convert.ToDecimal(txtCijena.Text);

            if (_id.HasValue)
            {
                    try
                    {
                        await _prikazivanje.Update<Model.Prikazivanje>(_id.Value, request);
                        MessageBox.Show("Uspješno sačuvani podaci");
                        this.Close();
                    }

                    catch (Exception)
                    {
                        DialogResult r = MessageBox.Show("Nemate pravo pristupa");
                        if (r == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                }
            else
            {
                    try
                    {
                        await _prikazivanje.Insert<Model.Prikazivanje>(request);
                        MessageBox.Show("Uspješno sačuvani podaci");
                        this.Close();
                    }

                    catch (Exception)
                    {
                        DialogResult r = MessageBox.Show("Nemate pravo pristupa");
                        if (r == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                }
        }
            else
            {
                MessageBox.Show("Operacija nije uspjela");
                this.Close();
    }

}

        private void cmbPredstava_Validating(object sender, CancelEventArgs e)
        {
            if (cmbPredstava.ValueMember == null)
            {
                errorProvider.SetError(cmbPredstava, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            {
                errorProvider.SetError(cmbPredstava, null);
            }
        }

        private void txtCijena_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCijena.Text))
            {
                errorProvider.SetError(txtCijena, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtCijena.Text, @"^[0-9]+$"))
            {
                errorProvider.SetError(txtCijena, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtCijena, null);
            }
        }

  
    }
}
