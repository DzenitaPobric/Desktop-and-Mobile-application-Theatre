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
using ePozoriste.Model.Requests;

namespace ePozoriste.WinUI.Predstava
{
    public partial class frmPredstava : Form
    {
        private readonly APIService _zanr = new APIService("zanr");
        private readonly APIService _predstave = new APIService("predstava");
        private int? _id = null;

        public frmPredstava(int? predstavaId = null)
        {
            InitializeComponent();
            _id = predstavaId;
        }


        private async void frmPredstava_Load(object sender, EventArgs e)
        {
            await LoadZanr();
            if (_id.HasValue)
            {
                var predstava = await _predstave.GetById<Model.Predstava>(_id);
                txtNaziv.Text = predstava.Naziv;
                txtOpis.Text = predstava.Opis;
                txtReziser.Text = predstava.Reziser;
                txtTrajanje.Text = (predstava.Trajanje).ToString();
                cmbZanr.SelectedValue = int.Parse(predstava.ZanrId.ToString());
            }
        }

        private async Task LoadZanr()
        {
            var result = await _zanr.Get<List<Model.Zanr>>(null);
            cmbZanr.DisplayMember = "Naziv";
            cmbZanr.ValueMember = "ZanrId";
            cmbZanr.SelectedItem = null;
            cmbZanr.SelectedText = "--Odaberite--";
            cmbZanr.DataSource = result;
        }

        private async void cmbZanr_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbZanr.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadPredstave(id);
            }
        }

        private async Task LoadPredstave(int zanrId)
        {
            var result = await _predstave.Get<List<Model.Predstava>>(new PredstavaSearchRequest()
            {
                ZanrId = zanrId
            });
            dgvPredstave.DataSource = result;
        }

        PredstavaUpsertRequest request = new PredstavaUpsertRequest();
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var idObj = cmbZanr.SelectedValue;
                if (int.TryParse(idObj.ToString(), out int zanrid))
                {
                    request.ZanrId = zanrid;

                    request.Naziv = txtNaziv.Text;
                    request.Opis = txtOpis.Text;
                    request.Reziser = txtReziser.Text;
                    request.Trajanje = int.Parse(txtTrajanje.Text);
                }
                if (_id.HasValue)
                {
                    try
                    {
                        await _predstave.Update<Model.Predstava>(_id.Value, request);
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
                        await _predstave.Insert<Model.Predstava>(request);
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

        private void dgvPredstave_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvPredstave.SelectedRows[0].Cells[0].Value;

            frmPredstava frm = new frmPredstava(int.Parse(id.ToString()));
            frm.Show();
        }

        private void cmbZanr_Validating(object sender, CancelEventArgs e)
        {
            if (cmbZanr.ValueMember == null)
            {
                errorProvider1.SetError(txtTrajanje, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            {
                errorProvider1.SetError(cmbZanr, null);
            }
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

            private void txtOpis_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtOpis.Text))
            {
                errorProvider1.SetError(txtOpis, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtOpis.Text, @"^[a-zA-Z ]+$"))
            {
                errorProvider1.SetError(txtOpis, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtOpis, null);
            }
        }

        private void txtReziser_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtReziser.Text))
            {
                errorProvider1.SetError(txtReziser, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtReziser.Text, @"^[a-zA-Z ]+$"))
            {
                errorProvider1.SetError(txtReziser, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtReziser, null);
            }
        }

        private void txtTrajanje_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTrajanje.Text))
            {
                errorProvider1.SetError(txtTrajanje, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtTrajanje.Text, @"^[0-9]+$"))
            {
                errorProvider1.SetError(txtTrajanje, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtTrajanje, null);
            }
        }

  
    }
}
