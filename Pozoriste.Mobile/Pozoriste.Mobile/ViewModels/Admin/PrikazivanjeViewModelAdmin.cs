using ePozoriste.Model;
using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pozoriste.Mobile.ViewModels.Admin
{
    public class PrikazivanjeViewModelAdmin : BaseViewModel
    {
        public PrikazivanjeViewModelAdmin()
        {
            InitCommand = new Command(async () => await Init());
            InitCommand2 = new Command(async () => await Init2());
            DodajPrikazivanjeCommand = new Command(async () => await DodajPrikazivanje());
            PrikazPrikazivanjaCommand = new Command(async () => await PrikazPrikazivanje());
        }

        public ICommand DodajPrikazivanjeCommand { get; set; }
        public ICommand PrikazPrikazivanjaCommand { get; set; }
        public ICommand InitCommand { get; set; }
        public ICommand InitCommand2 { get; set; }

        private APIService _prikazivanje = new APIService("PrikazivanjeMobile");
        private APIService _predstava = new APIService("Predstava");
        private APIService _sala = new APIService("Sala");

        public ObservableCollection<Prikazivanje> PrikazivanjeList { get; set; } = new ObservableCollection<Prikazivanje>();
        public ObservableCollection<Predstava> PredstavaList { get; set; } = new ObservableCollection<Predstava>();
        public ObservableCollection<Sala> SalaList { get; set; } = new ObservableCollection<Sala>();

        public Prikazivanje prikazivanje { get; set; }


        public async Task Init()
        {
            var list = await _predstava.Get<List<Predstava>>(null);
            PredstavaList.Clear();
            foreach (var z in list)
            {
                PredstavaList.Add(z);
            }
        }

        public async Task Init2()
        {
            var list = await _sala.Get<List<Sala>>(null);
            SalaList.Clear();
            foreach (var z in list)
            {
                SalaList.Add(z);
            }
        }
        public async Task DodajPrikazivanje()
        {
            IsBusy = true;
            await _prikazivanje.Insert<Prikazivanje>(new PrikazivanjeUpsertRequest()
            {
                DatumPrikazivanja = _datumPikazivanja,
                Cijena = _cijena,
                PredstavaId = _predstavaId,
                SalaId = _salaId
            });
            await Application.Current.MainPage.DisplayAlert(" ", "Uspješno sačuvani podaci", "OK");


        }

        public async Task PrikazPrikazivanje()
        {
            var list = await _prikazivanje.Get<IEnumerable<Prikazivanje>>(null);
            PrikazivanjeList.Clear();
            foreach (var p in list)
            {
                PrikazivanjeList.Add(p);
            }
        }

        decimal _cijena = 0;
        public decimal Cijena
        {
            get { return _cijena; }
            set { SetProperty(ref _cijena, value); }
        }

        DateTime _datumPikazivanja = DateTime.Now;
        public DateTime DatumPikazivanja
        {
            get { return _datumPikazivanja; }
            set { SetProperty(ref _datumPikazivanja, value); }
        }

        int _salaId = 0;
        public int SalaId
        {
            get { return _salaId; }
            set { SetProperty(ref _salaId, value); }
        }

        int _predstavaId = 0;
        public int PredstavaId
        {
            get { return _predstavaId; }
            set { SetProperty(ref _predstavaId, value); }
        }

    }
}
