using Plugin.Media;
using Pozoriste.Mobile.Converters;
using Pozoriste.Mobile.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pozoriste.Mobile.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DodajNagradnaIgraPage : ContentPage
    {
        NagradnaIgraViewModelAdmin vm = null;
        public APIService _NagradnaIgra = new APIService("NagradnaIgraMobile");

        public DodajNagradnaIgraPage()
        {
            InitializeComponent();
            BindingContext = vm = new NagradnaIgraViewModelAdmin();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(this.Naziv.Text, @"^[a-zA-Z ]+$"))
            {
                await DisplayAlert("Greška", "Polje naziv se sastoji samo od slova", "OK");
            }
            else if (!Regex.IsMatch(this.Opis.Text, @"^[a-zA-Z ]+$"))
            {
                await DisplayAlert("Greška", "Polje opis se sastoji samo od slova", "OK");
            }            
            else if (this.Kraj.Date <= this.Pocetak.Date)
            {
                await DisplayAlert("Greška", "Datum kraja nagradne igre ne može niti manji od datuma početka!", "OK");
            }           
            else
            {
                try
                {
                    vm.Naziv = this.Naziv.Text;
                    vm.Opis = this.Opis.Text;
                    vm.Pocetak = DateTime.Now;
                    vm.Kraj = DateTime.Now;
                    await vm.DodajNagradnaIgra();
                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }
            }
        }
    }
}