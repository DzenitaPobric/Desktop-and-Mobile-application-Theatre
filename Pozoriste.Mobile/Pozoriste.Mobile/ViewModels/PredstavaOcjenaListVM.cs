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
    public class PredstavaOcjenaListVM : BaseViewModel
    {
        private readonly APIService _predstaveService = new APIService("PredstavaMobile");
        private readonly APIService _predstavaKupacService = new APIService("PredstavaKupac");
        private readonly APIService _zanrService = new APIService("Zanr");

        public PredstavaOcjenaListVM()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Predstava> PredstavaList { get; set; } = new ObservableCollection<Predstava>();
        public ObservableCollection<Zanr> ZanrList { get; set; } = new ObservableCollection<Zanr>();

        Zanr _selectedZanr = null;
        public Zanr SelectedZanr
        {
            get { return _selectedZanr; }
            set
            {
                SetProperty(ref _selectedZanr, value);

                if (value != null)
                {
                    InitCommand.Execute(null);
                }
            }
        }

        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            if (ZanrList.Count == 0)
            {                
                var zanrList = await _zanrService.Get<List<Zanr>>(null);
                foreach (var zanr in zanrList)
                {
                    ZanrList.Add(zanr);
                }
            }

            PredstavaSearchRequest search = new PredstavaSearchRequest();
            if (SelectedZanr != null)
            {
                search.ZanrId = SelectedZanr.ZanrID;
            }

            var list = await _predstaveService.Get<IEnumerable<Predstava>>(search);
            PredstavaList.Clear();
            foreach (var predstava in list)
            {
                PredstavaList.Add(predstava);
            }
        }

     
    }
}
