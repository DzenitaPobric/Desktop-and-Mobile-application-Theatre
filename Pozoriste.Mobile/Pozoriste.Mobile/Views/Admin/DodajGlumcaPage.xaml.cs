//using Android.Graphics;
using Plugin.Media;
using Pozoriste.Mobile.Converters;
using Pozoriste.Mobile.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;

namespace Pozoriste.Mobile.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DodajGlumcaPage : ContentPage
    {
        GlumacViewModelAdmin vm = null;
        public APIService _glumac = new APIService("Glumac");

        public DodajGlumcaPage()
        {
            InitializeComponent();
            BindingContext = vm = new GlumacViewModelAdmin();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(this.Ime.Text, @"^[a-zA-Z]+$"))
            {
                await DisplayAlert("Greška", "Naziv se sastoji samo od slova", "OK");
            }
            else if (!Regex.IsMatch(this.Prezime.Text, @"^[a-zA-Z]+$"))
            {
                await DisplayAlert("Greška", "Polje opis se sastoji samo od slova", "OK");
            }
            else if (this.DatumRodjena.Date <= new DateTime(1920, 01, 01))
            {
                await DisplayAlert("Greška", "Neispravan datum", "OK");
            }
            else if (!Regex.IsMatch(this.BrojUgovora.Text, @"^[0-9]+$"))
            {
                await DisplayAlert("Greška", "Broj ugovora sadrzi samo brojeve", "OK");
            }
            else
            {
                try
                {
                    vm.Ime = this.Ime.Text;
                    vm.Prezime = this.Prezime.Text;
                    vm.BrojUgovora = Convert.ToInt32(this.BrojUgovora.Text);
                    vm.Email = this.Email.Text;
                    vm.DatumRodjenja = this.DatumRodjena.Date;
                    await vm.DodajGlumca();
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