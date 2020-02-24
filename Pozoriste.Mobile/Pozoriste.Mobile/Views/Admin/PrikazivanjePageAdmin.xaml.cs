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
    public partial class PrikazivanjePageAdmin : ContentPage
    {
        PrikazivanjeViewModelAdmin vm = null;
        public PrikazivanjePageAdmin()
        {
            InitializeComponent();
            BindingContext = vm = new PrikazivanjeViewModelAdmin();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
              await vm.Init();
              await vm.Init2();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DodajPrikazivanjePage());

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PrikazPrikazivanjePage());

        }

    }
}