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
    public partial class PrikazNagradnaIgraPage : ContentPage
    {
        public APIService _apiServiceNagradnaIgra = new APIService("NagradnaIgraMobile");
        public APIService _apiServiceKupacNagradnaIgra = new APIService("KupacNagradnaIgra");

        NagradnaIgraViewModelAdmin vm = null;
        public PrikazNagradnaIgraPage()
        {
            InitializeComponent();
            BindingContext = vm = new NagradnaIgraViewModelAdmin();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.PrikazNagradnaIgra();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as NagradnaIgra;

            await Navigation.PushAsync(new UrediNagradnaIgraPage(item));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as NagradnaIgra;


            KupacNagradnaIgraSearchRequest search = new KupacNagradnaIgraSearchRequest();
            var p = item.NagradnaIgraId;
            search.NagradnaIgraId = p;
            var list = await _apiServiceKupacNagradnaIgra.Get<IEnumerable<KupacNagradnaIgra>>(search);
            foreach (var y in list)
            {
                await _apiServiceKupacNagradnaIgra.Delete<KupacNagradnaIgra>(y.KupacNagradnaIgraId);

            }

            await _apiServiceNagradnaIgra.Delete<NagradnaIgra>(item.NagradnaIgraId);
            await DisplayAlert("OK", "Uspješno ste izbrisali podatke", "OK");
            await Navigation.PushAsync(new PrikazNagradnaIgraPage());


        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as NagradnaIgra;

            await Navigation.PushAsync(new DodijeliNagraduPage(item));
        }

      
    }
}