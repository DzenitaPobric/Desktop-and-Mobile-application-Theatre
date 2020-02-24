using ePozoriste.Model;
using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pozoriste.Mobile.ViewModels.Admin
{
    public class NovostiViewModelAdmin : BaseViewModel
    {
        public NovostiViewModelAdmin()
        {
            DodajNovostCommand = new Command(async () => await DodajNovost());
            PrikazNovostCommand = new Command(async () => await PrikazNovost());
            byte[] defaultPhoto = File.ReadAllBytes("noPhoto.png");
            Slika = defaultPhoto;
        }

        public ICommand DodajNovostCommand { get; set; }
        public ICommand PrikazNovostCommand { get; set; }
        public ICommand InitCommand { get; set; }

        private APIService _apiServiceNovost = new APIService("Novosti");
        private APIService _aPIServiceKorisnik = new APIService("Korisnik");
        private readonly APIService _notif = new APIService("notifikacija");


        public ObservableCollection<Novosti> NovostList { get; set; } = new ObservableCollection<Novosti>();

        public Novosti novosti { get; set; }



        public async Task DodajNovost()
        {
            IsBusy = true;
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
            req.DatumVrijemeObjave = _datumVrijemeObjave;
            req.Slika = _slika;
            req.Tekst = _tekst;
            req.Naziv = _naziv;
            req.KorisnikId = korisnik.KorisnikId;
            var entity = await _apiServiceNovost.Insert<Novosti>(req);

            if (entity != null)
            {
                await _notif.Insert<Notifikacija>(new NotfikacijaInsertRequest
                {
                    DatumSlanja = DateTime.Now,
                    IsProcitano = false,
                    NovostiId = entity.NovostiId
                });
            }
            await Application.Current.MainPage.DisplayAlert(" ", "Uspješno sačuvani podaci", "OK");
        }

    
        public async Task PrikazNovost()
        {
            var list = await _apiServiceNovost.Get<IEnumerable<Novosti>>(null);
            NovostList.Clear();
            foreach (var s in list)
            {
                NovostList.Add(s);
            }
        }




        string _naziv = string.Empty;
        public string Naziv
        {
            get { return _naziv; }
            set { SetProperty(ref _naziv, value); }
        }
        string _tekst = string.Empty;
        public string Tekst
        {
            get { return _tekst; }
            set { SetProperty(ref _tekst, value); }
        }

        DateTime _datumVrijemeObjave = DateTime.Now;
        public DateTime DatumVrijemeObjave
        {
            get { return _datumVrijemeObjave; }
            set { SetProperty(ref _datumVrijemeObjave, value); }
        }
       
        byte[] _slika = new byte[0];
        public byte[] Slika
        {
            get { return _slika; }
            set { SetProperty(ref _slika, value); }
        }

    }
}