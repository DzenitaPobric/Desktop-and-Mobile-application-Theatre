using ePozoriste.Model;
using ePozoriste.Model.Requests;
using Pozoriste.Mobile.Views.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pozoriste.Mobile.ViewModels.Admin
{
    class UplataViewModelAdmin : BaseViewModel
    {
        public UplataViewModelAdmin()
        {
            InitCommand = new Command(async () => await Init());
            DodajUplatuCommand = new Command(async () => await DodajUplatu());
            PrikazUplataCommand = new Command(async () => await PrikazUplate());
        }

        public ICommand DodajUplatuCommand { get; set; }
        public ICommand PrikazUplataCommand { get; set; }
        public ICommand InitCommand { get; set; }

        private APIService _service = new APIService("Uplata");
        private APIService _sponzor = new APIService("Sponzor");

        public ObservableCollection<Uplata> UplataList { get; set; } = new ObservableCollection<Uplata>();
        public ObservableCollection<Sponzor> SponzorList { get; set; } = new ObservableCollection<Sponzor>();

        public Uplata Uplata { get; set; }


        public async Task Init()
        {
            var list = await _sponzor.Get<List<Sponzor>>(null);
            SponzorList.Clear();
            foreach (var s in list)
            {
                SponzorList.Add(s);
            }
        }
        public async Task DodajUplatu()
        {
            IsBusy = true;
            await _service.Insert<Uplata>(new UplataUpsertRequest()
            {
                Naziv = _naziv,
                DatumUplate = DateTime.Now,
                Iznos = _iznos,
                Svrha = _svrha,
                SponzorId = _SponzorId

            });
            await Application.Current.MainPage.DisplayAlert(" ", "Uspješno sačuvani podaci", "OK");


        }

        public async Task PrikazUplate()
        {
            var list = await _service.Get<IEnumerable<Uplata>>(null);
            UplataList.Clear();
            foreach (var Uplata in list)
            {
                UplataList.Add(Uplata);
            }
        }




        string _naziv = string.Empty;
        public string Naziv
        {
            get { return _naziv; }
            set { SetProperty(ref _naziv, value); }
        }

        string _svrha = string.Empty;
        public string Svrha
        {
            get { return _svrha; }
            set { SetProperty(ref _svrha, value); }
        }

        string _opis = string.Empty;
        public string Opis
        {
            get { return _opis; }
            set { SetProperty(ref _opis, value); }
        }

       

        int _iznos = 0;
        public int Iznos
        {
            get { return _iznos; }
            set { SetProperty(ref _iznos, value); }
        }

        int _SponzorId = 0;
        public int SponzorId
        {
            get { return _SponzorId; }
            set { SetProperty(ref _SponzorId, value); }
        }

    }
}