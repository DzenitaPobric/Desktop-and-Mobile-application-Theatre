using ePozoriste.Model;
using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pozoriste.Mobile.ViewModels
{
    public class KomentarViewModel : BaseViewModel
    {
        private APIService _komentar = new APIService("Komentar");
        private APIService _kupac = new APIService("Kupac");
        private APIService _predstava = new APIService("Predstava");

        public Komentar komentar { get; set; }
        public Predstava predstava { get; set; }

        public KomentarViewModel(Predstava predstava)
        {          
            DodajKomentarCommand = new Command(async () => await DodajKomentar());
            this.predstava = predstava;
        }

      

        public ICommand DodajKomentarCommand { get; set; }

        private APIService _service = new APIService("Kupac");
        public Kupac kupac { get; set; }


    
        public async Task DodajKomentar()
        {
            var username = APIService.Username;
            List<Kupac> listKupci = await _kupac.Get<List<Kupac>>(null);
            foreach (var k in listKupci)
            {
                if (k.KorisnickoIme == username)
                {
                    kupac = k;
                    break;
                }
            }

  
            KomentarUpsertRequest req = new KomentarUpsertRequest();
             req.KupacId = kupac.KupacId;
            
            req.PredstavaId = predstava.PredstavaId;

            req.Odobrena = false;
            req.Sadrzaj = _sadrzaj;
            req.VrijemeKreiranja = DateTime.Now;

            await _komentar.Insert<Komentar>(req);

            await Application.Current.MainPage.DisplayAlert(" ", "Komentar sačuvan", "OK");

        }



        string _sadrzaj = string.Empty;
        public string Sadrzaj
        {
            get { return _sadrzaj; }
            set { SetProperty(ref _sadrzaj, value); }
        }



    }
}