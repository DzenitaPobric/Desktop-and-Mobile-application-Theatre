using ePozoriste.Model;
using ePozoriste.Model.Requests;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pozoriste.Mobile.ViewModels
{
    public class PrikazivanjeDetailViewModel : BaseViewModel
    {
        public PrikazivanjeDetailViewModel()
        {
           
            RezervisiCommand = new Command(Rezervsi);
        }

        public Prikazivanje Prikazivanje { get; set; }
        

        private APIService _rezervacije = new APIService("Rezervacija");
        private APIService _kupac = new APIService("Kupac");

        public Kupac kupac { get; set; }
        public ObservableCollection<Kupac> KupacList { get; set; } = new ObservableCollection<Kupac>();

        public Predstava predstava { get; set; }




        static Random random = new Random();

        public ICommand RezervisiCommand { get; set; }

        private async void Rezervsi()
        {
            if (ReservationService.Reservation.ContainsKey(Prikazivanje.PrikazivanjeId))
            {
                ReservationService.Reservation.Remove(Prikazivanje.PrikazivanjeId);
            }
            ReservationService.Reservation.Add(Prikazivanje.PrikazivanjeId, this);

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
            var list = await _rezervacije.Get<IEnumerable<Rezervacija>>(new RezervacijaSearchRequest() { KupacId = kupac.KupacId });


            await _rezervacije.Insert<Rezervacija>(new RezervacijaUpsertRequest()
            {
               DatumRezervacije = DateTime.Now,
               BrojRezervacije= random.Next(0, 10000),
               Odobrena=false,
               KupacId=kupac.KupacId,
               PrikazivanjeId=Prikazivanje.PrikazivanjeId

            });
            await Application.Current.MainPage.DisplayAlert(" ", "Izvršena rezervacija", "OK");
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                emailMessenger.SendEmail("to.dzenita.pobric@hotmail.com", "subject", "Dobili ste novi zahtjev za odobrenje rezervacije za prikazivanje!");
            }


        }
    }
}

