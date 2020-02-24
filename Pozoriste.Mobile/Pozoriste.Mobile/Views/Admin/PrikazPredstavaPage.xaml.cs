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
    public partial class PrikazPredstavaPage : ContentPage
    {
        public APIService _apiServicePredsrava = new APIService("PredstavaMobile");
        public APIService _apiServiceZanr = new APIService("Zanr");
        public APIService _apiServicePrikazivanje = new APIService("PrikazivanjeMobile");
        public APIService _apiServiceRezervacija = new APIService("Rezervacija");
        public APIService _apiServiceUlaznica = new APIService("Ulaznica");
        public APIService _apiServicePredstavaKupac = new APIService("PredstavaKupac");
        public APIService _apiServicePredstavaGlumac = new APIService("GlumacPredstava");
        public APIService _apiServicePredstavaUplata= new APIService("PredstavaUplata");
        public APIService _apiServiceKomentar = new APIService("Komentar");

        PredstavaVIewModelAdmin vm = null;
        public PrikazPredstavaPage()
        {
            InitializeComponent();
            BindingContext = vm = new PredstavaVIewModelAdmin();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.PrikazPredstave();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Predstava;

            await Navigation.PushAsync(new UrediPredstavaPage(item));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Predstava;
         
            var p = item.PredstavaId;

            PrikazivanjeSearchRequest search = new PrikazivanjeSearchRequest();
            PredstavaKupacSearchRequest searchpk = new PredstavaKupacSearchRequest();
            KomentarSearchRequest searchkom = new KomentarSearchRequest();
            GlumacPredstavaSearchRequest searchPG = new GlumacPredstavaSearchRequest();
            PredstavaUplataSearchRequest searchPU = new PredstavaUplataSearchRequest();

            search.PredstavaId = p;
            searchpk.PredstavaId = p;
            searchkom.PredstavaId = p;
            searchPG.PredstavaId = p;
            searchPU.PredstavaId = p;

            var list = await _apiServicePrikazivanje.Get<IEnumerable<Prikazivanje>>(search);
            var listpk = await _apiServicePredstavaKupac.Get<IEnumerable<PredstavaKupac>>(searchpk);
            var listKom = await _apiServiceKomentar.Get<IEnumerable<Komentar>>(searchkom);
            var listPG = await _apiServicePredstavaGlumac.Get<IEnumerable<GlumacPredstava>>(searchPG);
            var listPU = await _apiServicePredstavaUplata.Get<IEnumerable<PredstavaUplata>>(searchPU);
            foreach (var y in list)
            {
                var prik = y.PrikazivanjeId;
                RezervacijaSearchRequest search2 = new RezervacijaSearchRequest();
                search2.PrikazivanjeId = prik;
                var list2 = await _apiServiceRezervacija.Get<IEnumerable<Rezervacija>>(search2);
                foreach(var z in list2)
                {
                    var rez = z.RezervacijaId;
                    UlaznicaSearchRequest search3 = new UlaznicaSearchRequest();
                    search3.RezervacijaId = rez;
                    var list3 = await _apiServiceUlaznica.Get<IEnumerable<Ulaznica>>(search3);
                    foreach(var yz in list3)
                    {
                        await _apiServiceUlaznica.Delete<Ulaznica>(yz.UlaznicaId);                   
                    }
                    await _apiServiceRezervacija.Delete<Rezervacija>(z.RezervacijaId);
                }
                await _apiServicePrikazivanje.Delete<Prikazivanje>(y.PrikazivanjeId);
            }
            foreach (var y in listpk)
            {
                await _apiServicePredstavaKupac.Delete<PredstavaKupac>(y.PredstavaKupacId);
            }
            foreach (var y in listKom)
            {
                await _apiServiceKomentar.Delete<Komentar>(y.KomentarId);
            }
            foreach (var y in listPG)
            {
                await _apiServicePredstavaGlumac.Delete<GlumacPredstava>(y.GlumacPredstavaId);
            }
            foreach (var y in listPU)
            {
                await _apiServicePredstavaUplata.Delete<PredstavaUplata>(y.PredstavaUplataId);
            }
            await _apiServicePredsrava.Delete<Predstava>(item.PredstavaId);
            await DisplayAlert("OK", "Uspješno ste izbrisali podatke", "OK");
            await Navigation.PushAsync(new PrikazPredstavaPage());
        }
    }
}

