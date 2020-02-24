using ePozoriste.Model;
using ePozoriste.Model.Requests;
using Pozoriste.Mobile.ViewModels;
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
    public partial class PrikazUplataPage : ContentPage
    {
        public APIService _apiServiceUplata = new APIService("Uplata");
        public APIService _apiServicePredstavaUplata = new APIService("PredstavaUplata");

        UplataViewModelAdmin vm = null;
        public PrikazUplataPage()
        {
            InitializeComponent();
            BindingContext = vm = new UplataViewModelAdmin();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.PrikazUplate();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Uplata;

            await Navigation.PushAsync(new UrediUplataPage(item));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Uplata;


            PredstavaUplataSearchRequest search = new PredstavaUplataSearchRequest();
            var p = item.UplataId;
            search.UplataId = p;
            var list = await _apiServicePredstavaUplata.Get<IEnumerable<PredstavaUplata>>(search);
            foreach (var y in list)
            {
                await _apiServicePredstavaUplata.Delete<PredstavaUplata>(y.PredstavaUplataId);
            }
            await _apiServiceUplata.Delete<Uplata>(item.UplataId);
            await DisplayAlert("OK", "Uspješno ste izbrisali podatke", "OK");
            await Navigation.PushAsync(new PrikazUplataPage());


        }
    }
}