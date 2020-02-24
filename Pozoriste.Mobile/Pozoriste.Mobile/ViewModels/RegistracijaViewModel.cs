using ePozoriste.Model;
using ePozoriste.Model.Requests;
using Pozoriste.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pozoriste.Mobile.ViewModels
{
    public class RegistracijaViewModel: BaseViewModel
    {
        public RegistracijaViewModel()
        {
            RegistrationCommand = new Command(async () => await Registration());
        }
      


        public ICommand RegistrationCommand { get; set; }
        public ICommand InitCommand { get; set; }

        private APIService _service = new APIService("Kupac");

    
        public async Task Registration()
        {
            IsBusy = true;    
            await _service.Insert<Kupac>(new KupacUpsertRequest()
            {
                Ime = _ime,
                Prezime = _prezime,
                DatumRegistracije = DateTime.Now,
                BrojTelefona = _telefon,
                Email = _email,
                KorisnickoIme = _korisnickoIme,
                Password = _lozinka,
                PasswordPotvrda = _potvrdaLozinke,
                BrojTokena=50
            });
            Application.Current.MainPage = new LoginPage();          
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
        DateTime _datumRegistracaije = DateTime.Now;
        public DateTime DatumRodjenja
        {
            get { return _datumRegistracaije; }
            set { SetProperty(ref _datumRegistracaije, value); }
        }
        string _telefon = string.Empty;
        public string Telefon
        {
            get { return _telefon; }
            set { SetProperty(ref _telefon, value); }
        }
        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        string _korisnickoIme = string.Empty;
        public string KorisnickoIme
        {
            get { return _korisnickoIme; }
            set { SetProperty(ref _korisnickoIme, value); }
        }

        string _lozinka = string.Empty;
        public string Lozinka
        {
            get { return _lozinka; }
            set { SetProperty(ref _lozinka, value); }
        }
        string _potvrdaLozinke = string.Empty;
        public string PotvrdaLozinke
        {
            get { return _potvrdaLozinke; }
            set { SetProperty(ref _potvrdaLozinke, value); }
        }
       
    }
}