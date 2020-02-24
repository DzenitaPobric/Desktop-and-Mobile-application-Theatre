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
    public partial class PredstavePage : ContentPage
    {
        private PredstavaViewModel model = null;
        public PredstavePage()
        {
            InitializeComponent();
            BindingContext = model = new PredstavaViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Predstava;

            await Navigation.PushAsync(new PredstavaDetailPage(item));
        }

        private async void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            await model.Init();
        }
    }
}