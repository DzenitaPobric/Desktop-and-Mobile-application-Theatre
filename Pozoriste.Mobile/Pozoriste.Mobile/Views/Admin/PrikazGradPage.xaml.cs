using ePozoriste.Model;
using Pozoriste.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pozoriste.Mobile.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrikazGrad : ContentPage
    {
        public APIService _apiServiceGrad = new APIService("Grad");

        GradViewModel vm = null;
        public PrikazGrad()
        {
            InitializeComponent();
            BindingContext = vm = new GradViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.PrikazGrad();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Grad;

            await Navigation.PushAsync(new UrediGradPage(item));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Grad;

            await _apiServiceGrad.Delete<Grad>(item.GradID);
            await DisplayAlert("OK", "Uspješno ste izbrisali podatke", "OK");
            await Navigation.PushAsync(new PrikazGrad());


        }


    }
}