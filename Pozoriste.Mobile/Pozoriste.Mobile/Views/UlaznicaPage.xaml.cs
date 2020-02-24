using ePozoriste.Model;
using Pozoriste.Mobile.Models;
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
    public partial class UlaznicaPage : ContentPage
    {
        private UlaznicaViewModel model = null;

        public UlaznicaPage(Rezervacija r, Sjediste odabranoSjedaloObj)
        {
            InitializeComponent();
            BindingContext = model = new UlaznicaViewModel(r, odabranoSjedaloObj);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MainPage(MenuItemType.Prikazivanja);
        }
    }
}