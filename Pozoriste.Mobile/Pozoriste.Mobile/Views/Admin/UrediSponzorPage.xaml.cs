using ePozoriste.Model;
using ePozoriste.Model.Requests;
using Pozoriste.Mobile.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pozoriste.Mobile.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UrediSponzorPage : ContentPage
    {
        public APIService _sponzor = new APIService("Sponzor");
        private Sponzor z = null;

        public UrediSponzorVM sponzorVM { get; set; }
        public UrediSponzorPage(Sponzor sponzor)
        {
            InitializeComponent();
            BindingContext = sponzorVM = new UrediSponzorVM() { Sponzor = sponzor };
            z = sponzor;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(this.Naziv.Text, @"^[a-zA-Z ]+$"))
            {
                await DisplayAlert("Greška", "Naziv se sastoji samo od slova", "OK");
            }
            else if (!Regex.IsMatch(this.BrojTelefona.Text, @"^[+]{1}\d{3}[ ]?\d{2}[ ]?\d{3}[ ]?\d{3}"))
            {
                await DisplayAlert("Greška", "Format telefona je: +123 45 678 910", "OK");
            }
            else
            {
                try
                {
                    SponzorInsertRequest req = new SponzorInsertRequest()
            {

                Naziv = this.Naziv.Text,
                BrojTelefona = this.BrojTelefona.Text,
            };

            await _sponzor.Update<dynamic>(sponzorVM.Sponzor.SponzorId, req);
            await DisplayAlert("OK", "Uspješno uneseni podaci", "OK");
                    // await  Navigation.PushAsync(new ZanrPage());
                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }
            }
        }

    }

}




