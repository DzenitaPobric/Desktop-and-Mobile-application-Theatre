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
    public partial class SalaPage : ContentPage
    {
        SalaViewModel salaVM = null;
        public SalaPage()
        {
            InitializeComponent();
            BindingContext = salaVM = new SalaViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await salaVM.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Sala;
            await Navigation.PushAsync(new SalaDetailPage(item));
        }

    }
}