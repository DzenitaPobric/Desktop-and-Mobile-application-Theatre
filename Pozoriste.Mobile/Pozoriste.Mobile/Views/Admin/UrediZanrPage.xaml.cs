using ePozoriste.Model;
using ePozoriste.Model.Requests;
using Pozoriste.Mobile.ViewModels;
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
    public partial class UrediZanrPage : ContentPage
    {
        public APIService _apiServiceZanr = new APIService("Zanr");
        private Zanr z = null;

        public UrediZanrVM zanrVM { get; set; }
        public UrediZanrPage(Zanr zanr)
        {
            InitializeComponent();
            BindingContext = zanrVM = new UrediZanrVM() { Zanr = zanr };
            z = zanr;
        }
        protected  override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(this.Naziv.Text, @"^[a-zA-Z ]+$"))
            {
                await DisplayAlert("Greška", "Naziv se sastoji samo od slova", "OK");
            }
            else
            {
                try
                {
                    ZanrInsertRequest req = new ZanrInsertRequest()
                {

                    Naziv = this.Naziv.Text,
                };
            
            await _apiServiceZanr.Update<dynamic>(zanrVM.Zanr.ZanrID, req);
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