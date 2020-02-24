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
    public partial class GlumciPage : ContentPage
    {
        private GlumacVIewModel model = null;

        public GlumciPage()
        {
            InitializeComponent();
            BindingContext = model = new GlumacVIewModel();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Glumac;

            await Navigation.PushAsync(new GlumacDetailPage(item));
        }
    }
}