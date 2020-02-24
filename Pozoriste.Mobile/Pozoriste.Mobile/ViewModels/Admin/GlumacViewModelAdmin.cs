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
using System.Drawing;

namespace Pozoriste.Mobile.ViewModels.Admin
{
    public class GlumacViewModelAdmin : BaseViewModel
    {
        public GlumacViewModelAdmin()
        {
            DodajGlumcaCommand = new Command(async () => await DodajGlumca());
            PrikazGlumcaCommand = new Command(async () => await PrikazGlumca());
            byte[] defaultPhoto = File.ReadAllBytes("noPhoto.png");
            Slika = defaultPhoto;
        }

        public ICommand DodajGlumcaCommand { get; set; }
        public ICommand PrikazGlumcaCommand { get; set; }
        public ICommand InitCommand { get; set; }

        private APIService _glumac = new APIService("Glumac");

        public ObservableCollection<Glumac> GlumacList { get; set; } = new ObservableCollection<Glumac>();

        public Glumac glumac { get; set; }



        public async Task DodajGlumca()
        {
            IsBusy = true;
            await _glumac.Insert<Glumac>(new GlumacUpsertRequest()
            {
                Ime = _ime,
                Prezime = _prezime,
                BrojUgovora = _brojUgovora,
                DatumRodjenja = _datumRodjenja,
                Email = _email,
                Slika = _slika

            });
            await Application.Current.MainPage.DisplayAlert(" ", "Uspješno sačuvani podaci", "OK");
        }
        public async Task PrikazGlumca()
        {
            var list = await _glumac.Get<IEnumerable<Glumac>>(null);
            GlumacList.Clear();
            foreach (var s in list)
            {
                GlumacList.Add(s);
            }
        }




        string _ime = string.Empty;
        public string Ime
        {
            get { return _ime; }
            set { SetProperty(ref _ime, value); }
        }
        string _prezime = string.Empty;
        public string Prezime
        {
            get { return _prezime; }
            set { SetProperty(ref _prezime, value); }
        }

        DateTime _datumRodjenja = DateTime.Now;
        public DateTime DatumRodjenja
        {
            get { return _datumRodjenja; }
            set { SetProperty(ref _datumRodjenja, value); }
        }
        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        long _brojUgovora = 0;
        public long BrojUgovora
        {
            get { return _brojUgovora; }
            set { SetProperty(ref _brojUgovora, value); }
        }

        byte[] _slika = new byte[0];
        public byte[] Slika
        {
            get { return _slika; }
            set { SetProperty(ref _slika, value); }
        }

    }
}