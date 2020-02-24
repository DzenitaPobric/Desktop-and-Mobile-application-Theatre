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
    public partial class NotifikacijaPage : ContentPage
    {
        private NotifikacijaViewModel model = null;
        public NotifikacijaPage()
        {
            InitializeComponent();
            BindingContext = model = new NotifikacijaViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as NotifikacijaList;
            await model.Procitano(item);

            
            await Navigation.PushAsync(new NotifikacijaPage());
        }

    }
}