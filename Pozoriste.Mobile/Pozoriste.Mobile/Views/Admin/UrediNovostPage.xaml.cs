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
    public partial class UrediNovostiPage : ContentPage
    {
        public APIService _Novosti = new APIService("Novosti");
        public APIService _aPIServiceKorisnik = new APIService("Korisnik");
        private Novosti u = null;

        public UrediNovostiVM NovostiVM { get; set; }
        public UrediNovostiPage(Novosti Novosti)
        {
            InitializeComponent();
            BindingContext = NovostiVM = new UrediNovostiVM(Novosti);
            NovostiVM.Slika = Novosti.Slika;
        }
     

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(this.Naziv.Text, @"^[a-zA-Z ]+$"))
            {
                await DisplayAlert("Greška", "Naziv se sastoji samo od slova", "OK");
            }
            else if (!Regex.IsMatch(this.Tekst.Text, @"^[a-zA-Z ]+$"))
            {
                await DisplayAlert("Greška", "Tekst se sastoji samo od slova", "OK");
            }
            else
            {
                try
                {
                    Korisnik korisnik = new Korisnik();
                    var username = APIService.Username;
                    List<Korisnik> lista = await _aPIServiceKorisnik.Get<List<Korisnik>>(null);
                    foreach (var k in lista)
                    {
                        if (k.KorisnickoIme == username)
                        {
                            korisnik = k;
                            break;
                        }
                    }

                    NovostiInsertRequest req = new NovostiInsertRequest();
                    req.Naziv = this.Naziv.Text;
                    req.Tekst = this.Tekst.Text;
                    req.DatumVrijemeObjave = this.DatumVrijemeObjave.Date;                  
                    req.KorisnikId = korisnik.KorisnikId;
                    req.Slika = NovostiVM.Slika;


                    await _Novosti.Update<dynamic>(NovostiVM.Novosti.NovostiId, req);
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
                NovostiVM.Slika = ms.ToArray();
            }
        }
    }

}



