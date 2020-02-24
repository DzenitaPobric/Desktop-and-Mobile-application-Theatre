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
    public class OcijeniPredstavuVM : BaseViewModel
    {
        private APIService _predstavaKupac = new APIService("PredstavaKupac");
        private APIService _kupac = new APIService("Kupac");
        private APIService _predstava = new APIService("Predstava");
        public PredstavaKupac PredstavaKupac { get; set; }
        public Predstava Predstava { get; set; }

        public ObservableCollection<Predstava> PredstavaList { get; set; } = new ObservableCollection<Predstava>();
        public ObservableCollection<Kupac> KupacList { get; set; } = new ObservableCollection<Kupac>();


        public OcijeniPredstavuVM()
        {
            InitCommand = new Command(async () => await DodajOcjenu());
        }

        public async Task Init()
        {

            Kupac kupac = new Kupac();
            var username = APIService.Username;
            List<Kupac> lista = await _kupac.Get<List<Kupac>>(null);
            foreach (var k in lista)
            {
                if (k.KorisnickoIme == username)
                {
                    kupac = k;
                    break;
                }
            }

            var request = new PredstavaKupacSearchRequest
            {
                PredstavaId = Predstava.PredstavaId,
                KupacId = kupac.KupacId
            };
            var entity = await _predstavaKupac.Get<List<PredstavaKupac>>(request);
            if(entity != null && entity.Count > 0)
            {
                PredstavaKupac = entity[0];
                Ocjena = PredstavaKupac.Ocjena;
            }
        }

        public ICommand InitCommand { get; set; }

        public async Task DodajOcjenu()
        {
            IsBusy = true;
            if(PredstavaKupac != null)
            {
                await _predstavaKupac.Delete<PredstavaKupac>(PredstavaKupac.PredstavaKupacId);
            }

            PredstavaKupac = await _predstavaKupac.Insert<PredstavaKupac>(new PRedstavaKupacInsertRequest()
            {
                Ocjena=_ocjena,
                KupacId=_kupacId,
                PredstavaId=_predstavaId
            });
            await Application.Current.MainPage.DisplayAlert(" ", "Uspješno sačuvani podaci", "OK");
        }


        decimal _ocjena = 0;
        public decimal Ocjena
        {
            get { return _ocjena; }
            set { SetProperty(ref _ocjena, value); }
        }

        int _predstavaId = 0;
        public int PredstavaId
        {
            get { return _predstavaId; }
            set { SetProperty(ref _predstavaId, value); }
        }

        int _kupacId = 0;

        public int KupacId
        {
            get { return _kupacId; }
            set { SetProperty(ref _kupacId, value); }
        }

    }
}
