using ePozoriste.Model;
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
    public partial class PrikazNovostPage : ContentPage
    {
        public APIService _apiServiceNovosti = new APIService("Novosti");
        public APIService _apiServiceNotif = new APIService("Notifikacija");

        NovostiViewModelAdmin vm = null;
        public PrikazNovostPage()
        {
            InitializeComponent();
            BindingContext = vm = new NovostiViewModelAdmin();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.PrikazNovost();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Novosti;

            await Navigation.PushAsync(new UrediNovostiPage(item));
        }

      
    }
}