using ePozoriste.Model;
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
    public partial class PrikazZanr : ContentPage
    {
        public APIService _apiServiceZanr = new APIService("Zanr");

        ZanrViewModel vm = null;
        public PrikazZanr()
        {
            InitializeComponent();
            BindingContext = vm = new ZanrViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.PrikazZanr();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Zanr;

            await Navigation.PushAsync(new UrediZanrPage(item));


        }

      


    }
}