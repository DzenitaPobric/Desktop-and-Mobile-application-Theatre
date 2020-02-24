using ePozoriste.Model;
using ePozoriste.Model.Requests;
using Plugin.Media;
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
    public partial class UrediGlumacPage : ContentPage
    {
        public APIService _Glumac = new APIService("Glumac");

        public UrediGlumacVM GlumacVM { get; set; }
        public UrediGlumacPage(Glumac Glumac)
        {
            InitializeComponent();
            BindingContext = GlumacVM = new UrediGlumacVM(Glumac);
            GlumacVM.Slika = Glumac.Slika;
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(this.Ime.Text, @"^[a-zA-Z]+$"))
            {
                await DisplayAlert("Greška", "Ime se sastoji samo od slova", "OK");
            }
            else if (!Regex.IsMatch(this.Prezime.Text, @"^[a-zA-Z]+$"))
            {
                await DisplayAlert("Greška", "Prezime se sastoji samo od slova", "OK");
            }
            else if (!Regex.IsMatch(this.Email.Text, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"))
            {
                await DisplayAlert("Greška", "Neispravan format email-a!", "OK");

            }
            else if (!Regex.IsMatch(this.BrojUgovora.Text, @"^[0-9]+$"))
            {
                await DisplayAlert("Greška", "Broj ugovora sadrzi samo brojeve", "OK");
            }
            else
            {
                try
                {
                    GlumacUpsertRequest req = new GlumacUpsertRequest();
                    req.Ime = this.Ime.Text;
                    req.Prezime = this.Prezime.Text;
                    req.BrojUgovora = Convert.ToInt32(this.BrojUgovora.Text);
                    req.Email = this.Email.Text;
                    req.DatumRodjenja = this.DatumRodjenja.Date;
                    req.Slika = GlumacVM.Slika;
                   
                    await _Glumac.Update<dynamic>(GlumacVM.Glumac.GlumacId, req);
                    await DisplayAlert("OK", "Uspješno uneseni podaci", "OK");

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
                GlumacVM.Slika = ms.ToArray();
            }
        }
    }

}


