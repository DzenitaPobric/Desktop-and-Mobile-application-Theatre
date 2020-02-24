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
    public partial class NagradnaIgraPageAdmin : ContentPage
    {
        NagradnaIgraViewModelAdmin vm = null;
        public NagradnaIgraPageAdmin()
        {
            InitializeComponent();
            BindingContext = vm = new NagradnaIgraViewModelAdmin();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //  await vm.Init();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DodajNagradnaIgraPage());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PrikazNagradnaIgraPage());

        }

    }
}