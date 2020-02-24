using Pozoriste.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pozoriste.Mobile.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DodajGradPage : ContentPage
    {
        GradViewModel vm = null;
        public APIService _serviceGrad = new APIService("Grad");

        public DodajGradPage()
        {
            InitializeComponent();
            BindingContext = vm = new GradViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(this.Naziv.Text, @"^[a-zA-Z]+$"))
            {
                await DisplayAlert("Greška", "Naziv se sastoji samo od slova", "OK");
            }
            else
            {
                try
                {
                    vm.Naziv = this.Naziv.Text;
                    await vm.DodajGrad();
                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }
            }
        }
    }
}