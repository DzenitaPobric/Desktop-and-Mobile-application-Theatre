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
    public partial class PrikazPrikazivanjePage : ContentPage
    {
        public APIService _apiServicePrikazivanje = new APIService("PrikazivanjeMobile");
        public APIService _apiServiceRezervacija = new APIService("Rezervacija");
        public APIService _apiServiceUlaznica  = new APIService("Ulaznica");

        PrikazivanjeViewModelAdmin vm = null;
        public PrikazPrikazivanjePage()
        {
            InitializeComponent();
            BindingContext = vm = new PrikazivanjeViewModelAdmin();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.PrikazPrikazivanje();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Prikazivanje;
            await Navigation.PushAsync(new UrediPrikazivanjePage(item));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Prikazivanje;

            var p = item.PrikazivanjeId;

            RezervacijaSearchRequest search = new RezervacijaSearchRequest();
            search.PrikazivanjeId = p;
            var list = await _apiServiceRezervacija.Get<IEnumerable<Rezervacija>>(search);
            foreach (var y in list)
            {
                var rez = y.RezervacijaId;
                UlaznicaSearchRequest search2 = new UlaznicaSearchRequest();
                search2.RezervacijaId = rez;
                var list2 = await _apiServiceUlaznica.Get<IEnumerable<Ulaznica>>(search2);
                foreach (var u in list2)
                {
                    await _apiServiceUlaznica.Delete<Ulaznica>(u.UlaznicaId);
                }
                await _apiServiceRezervacija.Delete<Rezervacija>(y.RezervacijaId);
            }

            await _apiServicePrikazivanje.Delete<Prikazivanje>(item.PrikazivanjeId);
            await DisplayAlert("OK", "Uspješno ste izbrisali podatke", "OK");
            await Navigation.PushAsync(new PrikazPrikazivanjePage());


        }
    }
}