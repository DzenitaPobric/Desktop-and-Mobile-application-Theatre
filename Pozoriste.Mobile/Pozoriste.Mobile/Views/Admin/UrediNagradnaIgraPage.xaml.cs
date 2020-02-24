using ePozoriste.Model;
using ePozoriste.Model.Requests;
using Pozoriste.Mobile.ViewModels.Admin;
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
    public partial class UrediNagradnaIgraPage : ContentPage
    {
        public APIService _nagradnaIgraService = new APIService("NagradnaIgraMobile");
        public APIService _aPIServiceKorisnik = new APIService("Korisnik");
        private NagradnaIgra u = null;

        public UrediNagradnaIgraVM nagradnaIgraVM { get; set; }
        public UrediNagradnaIgraPage(NagradnaIgra nagradnaIgra)
        {
            InitializeComponent();
            BindingContext = nagradnaIgraVM = new UrediNagradnaIgraVM() { NagradnaIgra = nagradnaIgra };
            u = nagradnaIgra;
        }

        private async void Button_Clicked(object sender, EventArgs e)
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
                    NagradnaIgraInsertRequest req = new NagradnaIgraInsertRequest();
                    req.Naziv = this.Naziv.Text;
                    req.Opis = this.Opis.Text;                       
                    req.Kraj = this.Kraj.Date;
                    req.Pocetak = this.Pocetak.Date;
                    req.KorisnikId = korisnik.KorisnikId;


                    await _nagradnaIgraService.Update<NagradnaIgra>(nagradnaIgraVM.NagradnaIgra.NagradnaIgraId, req);
                    await DisplayAlert("OK", "Uspješno uneseni podaci", "OK");

                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }
            }
        }
               
     }
}

