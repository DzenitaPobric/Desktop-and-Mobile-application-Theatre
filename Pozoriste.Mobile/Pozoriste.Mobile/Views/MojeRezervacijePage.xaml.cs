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

namespace Pozoriste.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MojeRezervacijePage : ContentPage
    {
        public APIService _apiServiceRezerv = new APIService("Rezervacija");
        public APIService _apiServiceUlaznica = new APIService("Ulaznica");

        public MojeRezervacijeViewModel mojeRezervVM { get; set; }
        public MojeRezervacijePage()
        {
            InitializeComponent();
            BindingContext = mojeRezervVM = new MojeRezervacijeViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await mojeRezervVM.Init();

        }
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Rezervacija;
            await Navigation.PushAsync(new SjedistePage(item));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Rezervacija;
            if (item.Odobrena == true)
            {
                await Navigation.PushAsync(new SjedistePage(item));
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(" ", "Vaša rezervacija još uvijek nije odobrena.", "OK");

            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Rezervacija;
            if ((item.datumPrikazivanja - DateTime.Now).TotalDays < 3)
            {
                await Application.Current.MainPage.DisplayAlert(" ", "Ne mozete otkazati rezervaciju, rok za otkazivanje je prosao!", "OK");
            }
            else
            {
               
                Rezervacija m = await _apiServiceRezerv.GetById<Rezervacija>(item.RezervacijaId);

                var rez = item.RezervacijaId;
                UlaznicaSearchRequest search = new UlaznicaSearchRequest();
                search.RezervacijaId = rez;
                var list = await _apiServiceUlaznica.Get<IEnumerable<Ulaznica>>(search);
                foreach (var y in list)
                {
                    await _apiServiceUlaznica.Delete<Ulaznica>(y.UlaznicaId);
                }

                mojeRezervVM.RezervacijaList.Remove(item);
                await _apiServiceRezerv.Delete<Rezervacija>(item.RezervacijaId);
               


               await Application.Current.MainPage.DisplayAlert(" ", "Uspjesno ste otkazali rezervaciju!", "OK");

            }

        }
    }
}