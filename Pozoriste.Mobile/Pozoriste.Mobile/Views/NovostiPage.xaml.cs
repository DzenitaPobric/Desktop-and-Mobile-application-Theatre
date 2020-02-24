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
    public partial class NovostiPage : ContentPage
    {
        private NovostiViewModel model = null;

        public NovostiPage()
        {
            InitializeComponent();
            BindingContext = model = new NovostiViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Novosti;

            await Navigation.PushAsync(new NovostiDetailPage(item));
        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void ListView_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void ListView_ItemSelected_2(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}