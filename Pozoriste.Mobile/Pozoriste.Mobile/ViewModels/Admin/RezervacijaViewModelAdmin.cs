using ePozoriste.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pozoriste.Mobile.ViewModels.Admin
{
    public class RezervacijaViewModelAdmin : BaseViewModel
    {
        public RezervacijaViewModelAdmin()
        {
            InitCommand = new Command(async () => await Init());
            InitCommand2 = new Command(async () => await Init2());
            PrikazRezervacijaCommand = new Command(async () => await PrikazRezervacija());
        }

        public ICommand PrikazRezervacijaCommand { get; set; }
        public ICommand InitCommand { get; set; }
        public ICommand InitCommand2 { get; set; }

        private APIService _rezervacija = new APIService("Rezervacija");
        private APIService _prikazivanje = new APIService("Prikazivanje");
        private APIService _kupac = new APIService("Kupac");

        public ObservableCollection<Rezervacija> RezervacijaList { get; set; } = new ObservableCollection<Rezervacija>();
        public ObservableCollection<Prikazivanje> PrikazivanjeList { get; set; } = new ObservableCollection<Prikazivanje>();
        public ObservableCollection<Kupac> KupacList { get; set; } = new ObservableCollection<Kupac>();

        public Predstava predstava { get; set; }
        public Komentar komentar { get; set; }


        public async Task Init()
        {
            var list = await _prikazivanje.Get<List<Prikazivanje>>(null);
            PrikazivanjeList.Clear();
            foreach (var p in list)
            {
                PrikazivanjeList.Add(p);
            }
        }

        public async Task Init2()
        {
            var list = await _kupac.Get<List<Kupac>>(null);
            KupacList.Clear();
            foreach (var k in list)
            {
                KupacList.Add(k);
            }
        }

        public async Task PrikazRezervacija()
        {
            var list = await _rezervacija.Get<IEnumerable<Rezervacija>>(null);
            RezervacijaList.Clear();
            foreach (var r in list)
            {
                RezervacijaList.Add(r);
            }
        }




        int _brojRezervacije = 0;
        public int BrojRezervacije
        {
            get { return _brojRezervacije; }
            set { SetProperty(ref _brojRezervacije, value); }
        }

        bool _odobrena = false;
        public bool Odobrena
        {
            get { return _odobrena; }
            set { SetProperty(ref _odobrena, value); }
        }


        DateTime _datumRezervacije = DateTime.Now;
        public DateTime DatumRezervacije
        {
            get { return _datumRezervacije; }
            set { SetProperty(ref _datumRezervacije, value); }
        }

        int _prikazivanjeId = 0;
        public int PrikazivanjeId
        {
            get { return _prikazivanjeId; }
            set { SetProperty(ref _prikazivanjeId, value); }
        }

        int _kupacId = 0;
        public int KupacId
        {
            get { return _kupacId; }
            set { SetProperty(ref _kupacId, value); }
        }

    }
}