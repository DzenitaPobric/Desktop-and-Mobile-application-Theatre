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

namespace ePozoriste.WinUI.Grad
{
    public partial class frmGradDetalji : Form
    {
        private readonly APIService _apiService = new APIService("grad");

        private int? _id = null;

        public frmGradDetalji(int? gradId = null)
        {
            InitializeComponent();
            _id = gradId;
        }

        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var request = new GradInsertRequest()
                {
                    Naziv = txtNaziv.Text
                };
                if (_id.HasValue)
                {
                    await _apiService.Update<Model.Grad>(_id.Value, request);
                }
                else
                {
                    await _apiService.Insert<Model.Grad>(request);
                }
                MessageBox.Show("Uspješno sačuvani podaci");
                this.Close();
            }
        }

        private async void frmGradDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var grad = await _apiService.GetById<Model.Grad>(_id);
                txtNaziv.Text = grad.Naziv;
            }
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNaziv.Text))
            {
                errorProvider.SetError(txtNaziv, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtNaziv.Text, @"^[a-zA-Z -]+$"))
            {
                errorProvider.SetError(txtNaziv, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtNaziv, null);
            }
        }

     
    }
}
