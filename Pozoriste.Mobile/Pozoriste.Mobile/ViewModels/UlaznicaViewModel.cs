using ePozoriste.Model;
using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pozoriste.Mobile.ViewModels
{
    public class UlaznicaViewModel: BaseViewModel
    {
        private readonly APIService _ulaznica = new APIService("ulaznica");
        private readonly APIService _sjediste = new APIService("sjediste");
        private readonly APIService _kupac = new APIService("kupac");
        private readonly APIService _rezervacija= new APIService("rezervacija");
        private readonly APIService _prikazivanje= new APIService("prikazivanje");
        private readonly Rezervacija rezervacija;
        private readonly Sjediste odabranoSjedalo;

        public UlaznicaViewModel(Rezervacija rezervacija, Sjediste odabranoSjedalo)
        {
            InitCommand = new Command(async () => await Init());
            this.rezervacija = rezervacija;
            this.odabranoSjedalo = odabranoSjedalo;
        }

        public ObservableCollection<Prikazivanje> PrikazivanjeList { get; set; } = new ObservableCollection<Prikazivanje>();
        public ObservableCollection<Kupac> KupacList { get; set; } = new ObservableCollection<Kupac>();
        public ObservableCollection<Rezervacija> RezervacijaList { get; set; } = new ObservableCollection<Rezervacija>();
        public ObservableCollection<Sjediste> SjedisteList { get; set; } = new ObservableCollection<Sjediste>();

        public Ulaznica Ulaznica { get; set; }
        public Sala Sala { get; set; }
        public Sjediste Sjediste { get; set; }
        public Kupac Kupac { get; set; }
        public Prikazivanje Prikazivanje { get; set; }
        public Rezervacija Rezervacija { get; set; }

        private byte[] _qrCode = new byte[0];

        public byte[] qrCode
        {
            get { return _qrCode; }
            set { SetProperty(ref _qrCode, value); }
        }

     

        public ICommand InitCommand { get; set; }




        public async Task Init()
        {
            

            IsBusy = true;

            UlaznicaUpsertRequest req = new UlaznicaUpsertRequest();
            req.KupacId = rezervacija.KupacId;
            req.PrikazivanjeId = rezervacija.PrikazivanjeId;
            req.SjedisteId = odabranoSjedalo.SjedisteId;
            req.RezervacijaId = rezervacija.RezervacijaId;

            Kupac x = await _kupac.GetById<Kupac>(req.KupacId);
            Prikazivanje y = await _prikazivanje.GetById<Prikazivanje>(req.PrikazivanjeId);
            int z = Convert.ToInt32(y.Cijena);

            if (x.BrojTokena < z)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Nedovoljan broj tokena", "OK");
                return;
            }

            Ulaznica ulaznica = await _ulaznica.Insert<Ulaznica>(req);
            qrCode = ulaznica.Qrkod;
          

            await Application.Current.MainPage.DisplayAlert(" ", "Izvršeno", "OK");


            x.BrojTokena -= z;

            await _kupac.Update<Kupac>(req.KupacId, x);
        }
    }
}
