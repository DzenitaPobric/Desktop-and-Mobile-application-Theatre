using ePozoriste.Model;
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
    public partial class PrikazKomentaraPage : ContentPage
    {
        public APIService _apiServiceKoemnatr = new APIService("Komentar");

        PrikazKomentaraViewModel vm = null;
        public PrikazKomentaraPage()
        {
            InitializeComponent();
            BindingContext = vm = new PrikazKomentaraViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
           
            await vm.PrikazKomentara();
        }

    

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Komentar;

            if (item.Odobrena == false)
            {
                item.Odobrena = true;

                await _apiServiceKoemnatr.Update<Komentar>(item.KomentarId, item);

              
                await Application.Current.MainPage.DisplayAlert(" ", "Uspjesno ste odobrili komentar korisnika: " + " " + item.Kupac + " za predstavu: " + item.NazivPredstave, "OK");

            }
            else
            {

                await Application.Current.MainPage.DisplayAlert(" ", "Komentar je vec odobren", "OK");

            }

            await vm.PrikazKomentara();
        }
    }
}