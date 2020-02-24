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
    public partial class NovostiPageAdmin : ContentPage
    {
        NovostiViewModelAdmin vm = null;
        public NovostiPageAdmin()
        {
            InitializeComponent();
            BindingContext = vm = new NovostiViewModelAdmin();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //  await vm.Init();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DodajNovostPage());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PrikazNovostPage());

        }

        //private void Button_Clicked_2(object sender, EventArgs e)
        //{
        //     Navigation.PushAsync(new UrediZanrPage(vm.Zanr));
        //}
    }
}