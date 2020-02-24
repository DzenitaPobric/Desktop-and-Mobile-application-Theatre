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
    public class PredstavaViewModel : BaseViewModel
    {
        private readonly APIService _predstaveService = new APIService("Predstava");
        private readonly APIService _zanrService = new APIService("Zanr");
        public PredstavaViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Predstava> PredstaveList { get; set; } = new ObservableCollection<Predstava>();
        public ObservableCollection<Zanr> ZanrList { get; set; } = new ObservableCollection<Zanr>();
        public ObservableCollection<string> SortList { get; set; } = new ObservableCollection<string>();

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

        private int _selectedSort;

        public int SelectedSort
        {
            get { return _selectedSort; }
            set
            {
                SetProperty(ref _selectedSort, value);

                InitCommand.Execute(null);
            }
        }


        private string _trajanjeOd;

        public string TrajanjeOd
        {
            get { return _trajanjeOd; }
            set { SetProperty(ref _trajanjeOd, value); }
        }

        private string _trajanjeDo;

        public string TrajanjeDo
        {
            get { return _trajanjeDo; }
            set { SetProperty(ref _trajanjeDo, value); }
        }

        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            if (ZanrList.Count == 0)
            {
                SortList.Add("Naziv");
                SortList.Add("Najveća ocjena");

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

            if (int.TryParse(TrajanjeOd, out int _TrajanjeOd))
            {
                search.TrajanjeOd = _TrajanjeOd;
            }
            if (int.TryParse(TrajanjeDo, out int _TrajanjeDo))
            {
                search.TrajanjeDo = _TrajanjeDo;
            }

            search.Sort = SelectedSort;

            var list = await _predstaveService.Get<IEnumerable<Predstava>>(search);
            PredstaveList.Clear();
            foreach (var predstava in list)
            {
                PredstaveList.Add(predstava);
            }
        }
    }
}
