using ePozoriste.Model;
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
    public partial class PredstavaOcjenaPage : ContentPage
    {
        public APIService _apiServicePredsrava = new APIService("PredstavaMobile");

        PredstavaOcjenaListVM vm = null;
        public PredstavaOcjenaPage()
        {
            InitializeComponent();
            BindingContext = vm = new PredstavaOcjenaListVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.Init();
          
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Predstava;

            await Navigation.PushAsync(new OcijeniPredstavuPage(item));
        }
     
    }
}