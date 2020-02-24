using Pozoriste.Mobile.ViewModels;
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
    public partial class DodajSponzorPage : ContentPage
    {
        SponzorViewModel vm = null;
        public APIService _serviceSponzor = new APIService("Sponzor");

        public DodajSponzorPage()
        {
            InitializeComponent();
            BindingContext = vm = new SponzorViewModel();
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
                    vm.Naziv = this.Naziv.Text;
                    vm.BrojTelefona = this.BrojTelefona.Text;
                    await vm.DodajSponzor();
                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }
            }
        }
    }
}