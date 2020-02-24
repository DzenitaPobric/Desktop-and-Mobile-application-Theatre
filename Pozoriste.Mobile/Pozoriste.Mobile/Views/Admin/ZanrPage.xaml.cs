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
    public partial class ZanrPage : ContentPage
    {
        ZanrViewModel vm = null;
        public ZanrPage()
        {
            InitializeComponent();
            BindingContext = vm = new ZanrViewModel();
        }
        protected  override void OnAppearing()
        {
            base.OnAppearing();
            //  await vm.Init();
        }

        private  void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DodajZanrPage());

        }

        private  void Button_Clicked_1(object sender, EventArgs e)
        {
             Navigation.PushAsync(new PrikazZanr());

        }

     
    }
}