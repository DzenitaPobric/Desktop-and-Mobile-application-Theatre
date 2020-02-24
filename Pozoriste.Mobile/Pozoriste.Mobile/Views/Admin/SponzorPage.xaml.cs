using ePozoriste.Model.Requests;
using Pozoriste.Mobile.ViewModels;
using Pozoriste.Mobile.Views.Admin;
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
    public partial class SponzorPage : ContentPage
    {
        SponzorViewModel vm = null;
        public SponzorPage()
        {
            InitializeComponent();
            BindingContext = vm = new SponzorViewModel();
        }
        protected  override void OnAppearing()
        {
            base.OnAppearing();
            //  await vm.Init();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DodajSponzorPage());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PrikazSponzor());

        }

    }
}