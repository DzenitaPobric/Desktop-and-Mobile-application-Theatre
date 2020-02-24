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
    class PredstavaVIewModelAdmin : BaseViewModel
    {
        public PredstavaVIewModelAdmin()
        {
            InitCommand = new Command(async () => await Init());
            DodajPredstavuCommand = new Command(async () => await DodajPredstavu());
            PrikazPredstavaCommand = new Command(async () => await PrikazPredstave());
        }

        public ICommand DodajPredstavuCommand { get; set; }
        public ICommand PrikazPredstavaCommand { get; set; }
        public ICommand InitCommand { get; set; }

        private APIService _service = new APIService("PredstavaMobile");
        private APIService _zanr = new APIService("Zanr");

        public ObservableCollection<Predstava> PredstavaList { get; set; } = new ObservableCollection<Predstava>();
        public ObservableCollection<Zanr> ZanrList { get; set; } = new ObservableCollection<Zanr>();

        public Predstava predstava { get; set; }


        public async Task Init()
        {
            var list = await _zanr.Get<List<Zanr>>(null);
            ZanrList.Clear();
            foreach (var z in list)
            {
                ZanrList.Add(z);
            }
        }
        public async Task DodajPredstavu()
        {
            IsBusy = true;
            await _service.Insert<Predstava>(new PredstavaUpsertRequest()
            {
                Naziv = _naziv,
                Opis=_opis,
                Reziser=_reziser,
                Trajanje=_trajanje,
                ZanrId=_zanrId
                
            });
           await Application.Current.MainPage.DisplayAlert(" ", "Uspješno sačuvani podaci", "OK");

           
        }
        public async Task PrikazPredstave()
        {
            var list = await _service.Get<IEnumerable<Predstava>>(null);
            PredstavaList.Clear();
            foreach (var predstava in list)
            {
                PredstavaList.Add(predstava);
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

        string _reziser = string.Empty;
        public string Reziser
        {
            get { return _reziser; }
            set { SetProperty(ref _reziser, value); }
        }

        int _trajanje = 0;
        public int Trajanje
        {
            get { return _trajanje; }
            set { SetProperty(ref _trajanje, value); }
        }

        int _zanrId = 0;
        public int ZanrId
        {
            get { return _zanrId; }
            set { SetProperty(ref _zanrId, value); }
        }

    }
}