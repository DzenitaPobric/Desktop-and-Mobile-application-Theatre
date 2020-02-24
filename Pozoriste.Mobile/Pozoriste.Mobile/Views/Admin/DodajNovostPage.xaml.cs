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
    public partial class DodajNovostPage : ContentPage
    {
       NovostiViewModelAdmin vm = null;
        public APIService _Novosti = new APIService("Novosti");

        public DodajNovostPage()
        {
            InitializeComponent();
            BindingContext = vm = new NovostiViewModelAdmin();
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
            else if (!Regex.IsMatch(this.Tekst.Text, @"^[a-zA-Z ]+$"))
            {
                await DisplayAlert("Greška", "Polje opis se sastoji samo od slova", "OK");
            }
            else
            {
                try
                {
                    vm.Naziv = this.Naziv.Text;
                    vm.Tekst = this.Tekst.Text;
                    vm.DatumVrijemeObjave =DateTime.Now;
                    await vm.DodajNovost();
                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }
            }
        }


        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert(" ", "Format slike nije podržan!", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
                return;

            Stream stream = file.GetStream();

            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                vm.Slika = ms.ToArray();
            }

        }

    }
}