using ePozoriste.Model;
using ePozoriste.Model.Requests;
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
    public partial class PrikazSponzor : ContentPage
    {
        public APIService _apiServiceSponzor = new APIService("Sponzor");
        public APIService _apiServiceUplata = new APIService("Uplata");
        public APIService _apiServicePredstavaUplata = new APIService("PredstavaUplata");

        SponzorViewModel vm = null;
        public PrikazSponzor()
        {
            InitializeComponent();
            BindingContext = vm = new SponzorViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.PrikazSponzor();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Sponzor;

            await Navigation.PushAsync(new UrediSponzorPage(item));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Sponzor;


            UplataSearchRequest search = new UplataSearchRequest();
            var p = item.SponzorId;
            search.SponzorId = p;
            var list = await _apiServiceUplata.Get<IEnumerable<Uplata>>(search);
            foreach(var y in list)
            {
                var pu = y.UplataId;
                PredstavaUplataSearchRequest search2 = new PredstavaUplataSearchRequest();
                search2.UplataId = pu;
                var list2 = await _apiServicePredstavaUplata.Get<IEnumerable<PredstavaUplata>>(search2);
                foreach (var z in list2)
                {
                    await _apiServicePredstavaUplata.Delete<PredstavaUplata>(z.PredstavaUplataId);
                }
                await _apiServiceUplata.Delete<Uplata>(y.UplataId);

            }
            await _apiServiceSponzor.Delete<Sponzor>(item.SponzorId);
            await Navigation.PushAsync(new PrikazSponzor());

            await DisplayAlert("OK", "Uspješno ste izbrisali podatke", "OK");


        }
    }
}