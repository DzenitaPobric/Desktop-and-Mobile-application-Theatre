using ePozoriste.Model;
using Plugin.Messaging;
using Pozoriste.Mobile.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pozoriste.Mobile.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrikazRezervacijaPage : ContentPage
    {
        public APIService _apiServiceRezerv = new APIService("Rezervacija");

        RezervacijaViewModelAdmin vm = null;
        private readonly Rezervacija r;
        public PrikazRezervacijaPage()
        {
            InitializeComponent();
            BindingContext = vm = new RezervacijaViewModelAdmin();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await vm.PrikazRezervacija();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Rezervacija;

            if (item.Odobrena == false)
            {
                item.Odobrena = true;

                await _apiServiceRezerv.Update<Rezervacija>(item.RezervacijaId, item);

                var emailMessenger = CrossMessaging.Current.EmailMessenger;
                if (emailMessenger.CanSendEmail)
                {
                    emailMessenger.SendEmail(item.MailKupca.ToString(), "subject", "Vasa rezervacija je odobrena!");
                }
                await Application.Current.MainPage.DisplayAlert(" ", "Uspjesno ste odobrili rezervaciju kupcu: "+" " + item.Kupac, "OK");
          
            }
            else
            {
                
                await Application.Current.MainPage.DisplayAlert(" ", "Rezervacija je vec odobrena", "OK");

            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Rezervacija;

            if (item.Odobrena == false)
            {
                item.Odobrena = true;
                await Navigation.PushAsync(new PosaljiSMS());
                await _apiServiceRezerv.Update<Rezervacija>(item.RezervacijaId, item);
                await Application.Current.MainPage.DisplayAlert(" ", "Uspjesno ste odobrili rezervaciju kupcu: " + " " + item.Kupac, "OK");

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(" ", "Rezervacija je vec odobrena", "OK");

            }
        }      
    }
}