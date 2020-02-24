using ePozoriste.Model;
using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pozoriste.Mobile.ViewModels.Admin
{
    public class PretragaUplataVM : BaseViewModel
    {
        private readonly APIService _uplata = new APIService("Uplata");
        private readonly APIService _sponzor = new APIService("Sponzor");
        public PretragaUplataVM()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Uplata> UplataList { get; set; } = new ObservableCollection<Uplata>();
        public ObservableCollection<Sponzor> SponzorList { get; set; } = new ObservableCollection<Sponzor>();

        Sponzor _selectedSponzor = null;
        public Sponzor SelectedSponzor
        {
            get { return _selectedSponzor; }
            set
            {
                SetProperty(ref _selectedSponzor, value);

                if (value != null)
                {
                    InitCommand.Execute(null);
                }
            }
        }

        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            if (SponzorList.Count == 0)
            {
                var sponzorlist = await _sponzor.Get<List<Sponzor>>(null);
                foreach (var s in sponzorlist)
                {
                    SponzorList.Add(s);
                }
            }
            if (SelectedSponzor != null)
            {
                UplataSearchRequest search = new UplataSearchRequest();
                search.SponzorId = SelectedSponzor.SponzorId;

                var list = await _uplata.Get<IEnumerable<Uplata>>(search);
                UplataList.Clear();
                foreach (var u in list)
                {
                    UplataList.Add(u);
                }
            }
        }
    }
}
