using ePozoriste.Model;
using ePozoriste.Model.Requests;
using Pozoriste.Mobile.ViewModels.Admin;
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
    public partial class PrikazGlumcaPage : ContentPage
    {
        public APIService _apiServiceGlumac = new APIService("Glumac");
        public APIService _apiServiceGlumacPredstava = new APIService("GlumacPredstava");

        GlumacViewModelAdmin vm = null;
        public PrikazGlumcaPage()
        {
            InitializeComponent();
            BindingContext = vm = new GlumacViewModelAdmin();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.PrikazGlumca();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Glumac;

            await Navigation.PushAsync(new UrediGlumacPage(item));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Glumac;

            GlumacPredstavaSearchRequest search = new GlumacPredstavaSearchRequest();
            var p = item.GlumacId;
            search.GlumacId = p;
            var list = await _apiServiceGlumacPredstava.Get<IEnumerable<GlumacPredstava>>(search);
            foreach (var y in list)
            {
                await _apiServiceGlumacPredstava.Delete<GlumacPredstava>(y.GlumacPredstavaId);
            }
            await _apiServiceGlumac.Delete<Glumac>(item.GlumacId);
            await DisplayAlert("OK", "Uspješno ste izbrisali podatke", "OK");
            await Navigation.PushAsync(new PrikazGlumcaPage());


        }
    }
}