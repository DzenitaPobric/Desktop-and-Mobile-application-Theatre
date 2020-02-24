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
    class PrikazKomentaraViewModel : BaseViewModel
    {
        public PrikazKomentaraViewModel()
        {
            InitCommand = new Command(async () => await Init());
            InitCommand2 = new Command(async () => await Init2());
            PrikazKomentaraCommand = new Command(async () => await PrikazKomentara());
        }

        public ICommand PrikazKomentaraCommand { get; set; }
        public ICommand InitCommand { get; set; }
        public ICommand InitCommand2 { get; set; }

        private APIService _komentar = new APIService("Komentar");
        private APIService _predstava = new APIService("Predstava");
        private APIService _kupac = new APIService("Kupac");

        public ObservableCollection<Komentar> KomentarList { get; set; } = new ObservableCollection<Komentar>();
        public ObservableCollection<Predstava> PredstavaList { get; set; } = new ObservableCollection<Predstava>();
        public ObservableCollection<Kupac> KupacList { get; set; } = new ObservableCollection<Kupac>();

        public Predstava predstava { get; set; }
        public Komentar komentar { get; set; }


        public async Task Init()
        {
            var list = await _predstava.Get<List<Predstava>>(null);
            PredstavaList.Clear();
            foreach (var p in list)
            {
                PredstavaList.Add(p);
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
      
        public async Task PrikazKomentara()
        {
            var list = await _komentar.Get<IEnumerable<Komentar>>(null);
            KomentarList.Clear();
            foreach (var komentar in list)
            {
                KomentarList.Add(komentar);
            }
        }




        string _sadrzaj = string.Empty;
        public string Sadrzaj
        {
            get { return _sadrzaj; }
            set { SetProperty(ref _sadrzaj, value); }
        }

     

        int _kupacId = 0;
        public int KupacId
        {
            get { return _kupacId; }
            set { SetProperty(ref _kupacId, value); }
        }

        int _predstavaId = 0;
        public int PredstavaId
        {
            get { return _predstavaId; }
            set { SetProperty(ref _predstavaId, value); }
        }

    }
}