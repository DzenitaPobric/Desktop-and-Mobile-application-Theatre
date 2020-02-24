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
    public partial class UrediGradPage : ContentPage
    {
        public APIService _apiServiceGrad = new APIService("Grad");
        private Grad z = null;

        public UrediGradVM GradVM { get; set; }
        public UrediGradPage(Grad Grad)
        {
            InitializeComponent();
            BindingContext = GradVM = new UrediGradVM() { Grad = Grad };
            z = Grad;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(this.Naziv.Text, @"^[a-zA-Z]+$"))
            {
                await DisplayAlert("Greška", "Naziv se sastoji samo od slova", "OK");
            }
            else
            {
                try
                {

                    GradInsertRequest req = new GradInsertRequest()
            {

                Naziv = this.Naziv.Text,
            };

            await _apiServiceGrad.Update<dynamic>(GradVM.Grad.GradID, req);
            await DisplayAlert("OK", "Uspješno uneseni podaci", "OK");
                    // await  Navigation.PushAsync(new GradPage());
                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }
            }
        }

    }

}