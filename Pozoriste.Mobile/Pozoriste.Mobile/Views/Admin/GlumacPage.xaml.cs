using Pozoriste.Mobile.ViewModels;
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
    public partial class GlumacPage : ContentPage
    {
        GlumacViewModelAdmin vm = null;
        public GlumacPage()
        {
            InitializeComponent();
            BindingContext = vm = new GlumacViewModelAdmin();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //  await vm.Init();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DodajGlumcaPage());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PrikazGlumcaPage());

        }

        //private void Button_Clicked_2(object sender, EventArgs e)
        //{
        //     Navigation.PushAsync(new UrediZanrPage(vm.Zanr));
        //}
    }
}