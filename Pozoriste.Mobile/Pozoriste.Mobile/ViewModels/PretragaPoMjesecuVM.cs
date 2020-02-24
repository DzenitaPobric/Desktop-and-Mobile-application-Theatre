using ePozoriste.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pozoriste.Mobile.ViewModels
{
    public class PretragaPoMjesecuVM : BaseViewModel
    {
        private readonly APIService _prikazivanjaService = new APIService("Prikazivanje");
        private readonly APIService _predstaveService = new APIService("Predstava");

        public PretragaPoMjesecuVM()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Prikazivanje> PrikazivanjaList { get; set; } = new ObservableCollection<Prikazivanje>();
        public ObservableCollection<Predstava> PredstaveList { get; set; } = new ObservableCollection<Predstava>();



        int _selectedMjesec = 0;
        public int SelectedMjesec
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
            var predstavaList = await _predstaveService.Get<List<Predstava>>(null);
            PredstaveList.Clear();
            foreach (var predstava in predstavaList)
            {
                PredstaveList.Add(predstava);
            }
        }

    }
}