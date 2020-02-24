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
    public partial class PrikazSalaPage : ContentPage
    {
        public APIService _apiServiceSala = new APIService("Sala");

        SalaViewModelAdmin vm = null;
        public PrikazSalaPage()
        {
            InitializeComponent();
            BindingContext = vm = new SalaViewModelAdmin();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.PrikazSalu();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Sala;

            await Navigation.PushAsync(new UrediSalaPage(item));
        }

     
        }
    }
