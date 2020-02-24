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
    public class NagradnaIgraViewModelAdmin : BaseViewModel
    {
        public NagradnaIgraViewModelAdmin()
        {
            DodajNagradnaIgraCommand = new Command(async () => await DodajNagradnaIgra());
            PrikazNagradnaIgraCommand = new Command(async () => await PrikazNagradnaIgra());
        }

        public ICommand DodajNagradnaIgraCommand { get; set; }
        public ICommand PrikazNagradnaIgraCommand { get; set; }
        public ICommand InitCommand { get; set; }

        private APIService _nagradnaigra = new APIService("NagradnaIgraMobile");
        private APIService _korisnikService = new APIService("Korisnik");


        public ObservableCollection<NagradnaIgra> NagradnaIgraList { get; set; } = new ObservableCollection<NagradnaIgra>();

        public NagradnaIgra NagradnaIgra { get; set; }



        public async Task DodajNagradnaIgra()
        {
            Korisnik korisnik = new Korisnik();
            var username = APIService.Username;
            List<Korisnik> lista = await _korisnikService.Get<List<Korisnik>>(null);
            foreach (var k in lista)
            {
                if (k.KorisnickoIme == username)
                {
                    korisnik = k;
                    break;
                }
            }
            IsBusy = true;
            NagradnaIgraInsertRequest req = new NagradnaIgraInsertRequest();
            req.Pocetak = _pocetak;
            req.Kraj = _kraj;
            req.Naziv = _naziv;
            req.Opis = _opis;
            req.KorisnikId = korisnik.KorisnikId;
            await _nagradnaigra.Insert<NagradnaIgra>(req);

            await Application.Current.MainPage.DisplayAlert(" ", "Uspješno sačuvani podaci", "OK");
        }

        public async Task PrikazNagradnaIgra()
        {
            var list = await _nagradnaigra.Get<IEnumerable<NagradnaIgra>>(null);
            NagradnaIgraList.Clear();
            foreach (var ni in list)
            {
                NagradnaIgraList.Add(ni);
            }
        }




        string _naziv = string.Empty;
        public string Naziv
        {
            get { return _naziv; }
            set { SetProperty(ref _naziv, value); }
        }
        string _opis = string.Empty;
        public string Opis
        {
            get { return _opis; }
            set { SetProperty(ref _opis, value); }
        }

        DateTime _pocetak = DateTime.Now;
        public DateTime Pocetak
        {
            get { return _pocetak; }
            set { SetProperty(ref _pocetak, value); }
        }

        DateTime _kraj = DateTime.Now;
        public DateTime Kraj
        {
            get { return _kraj; }
            set { SetProperty(ref _kraj, value); }
        }

    }
}