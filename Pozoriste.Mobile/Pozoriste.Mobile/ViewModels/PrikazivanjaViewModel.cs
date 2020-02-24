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
    public class PrikazivanjaViewModel : BaseViewModel
    {
        private readonly APIService _prikazivanjaService = new APIService("Prikazivanje");
        private readonly APIService _predstaveService = new APIService("Predstava");

        public PrikazivanjaViewModel()
        {
            FilterCommand = new Command(async () => await FilterPrikazivanja());
        }

        public ObservableCollection<Prikazivanje> PrikazivanjaList { get; set; } = new ObservableCollection<Prikazivanje>();
        public ObservableCollection<Predstava> PredstaveList { get; set; } = new ObservableCollection<Predstava>();
        public ObservableCollection<string> MjeseciList { get; set; } = new ObservableCollection<string>();


        Predstava _selectedPredstava = null;
        public Predstava SelectedPredstava
        {
            get { return _selectedPredstava; }
            set
            {
                SetProperty(ref _selectedPredstava, value);

                if (value != null)
                {
                    FilterCommand.Execute(null);
                }
            }
        }
        private string _selectedMjesec;

        public string SelectedMjesec
        {
            get { return _selectedMjesec; }
            set
            {
                SetProperty(ref _selectedMjesec, value);
                if (value != null)
                {
                    FilterCommand.Execute(null);
                }

            }
        }

        public ICommand FilterCommand { get; set; }
        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            MjeseciList.Clear();
            MjeseciList.Add("");
            for (int i = 1; i <= 12; i++)
            {
                MjeseciList.Add(i.ToString());
            }

            var predstavaList = await _predstaveService.Get<List<Predstava>>(null);
            PredstaveList.Clear();
            foreach (var predstava in predstavaList)
            {
                PredstaveList.Add(predstava);
            }
        }

        private async Task FilterPrikazivanja()
        {
            PrikazivanjeSearchRequest search = new PrikazivanjeSearchRequest();
            if (SelectedPredstava != null)
                search.PredstavaId = SelectedPredstava.PredstavaId;
            if (!string.IsNullOrEmpty(SelectedMjesec))
                search.Mjesec = int.Parse(SelectedMjesec);

            var list = await _prikazivanjaService.Get<IEnumerable<Prikazivanje>>(search);
            PrikazivanjaList.Clear();

            foreach (var prikazivanje in list)
            {
                PrikazivanjaList.Add(prikazivanje);
            }
        }

    }
}