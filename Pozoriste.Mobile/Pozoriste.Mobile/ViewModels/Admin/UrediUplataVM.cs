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
    public class UrediUplataVM 
    {
        public Uplata Uplata { get; set; }
        private APIService _apiServiceSponzor = new APIService("Sponzor");
        public ObservableCollection<Sponzor> SponzorList { get; set; } = new ObservableCollection<Sponzor>();

        public ICommand InitCommand { get; set; }

        public UrediUplataVM()
        {
            InitCommand = new Command(async () => await Init());
        }
        public async Task Init()
        {
            var list = await _apiServiceSponzor.Get<List<Sponzor>>(null);
            SponzorList.Clear();
            foreach (var g in list)
            {
                SponzorList.Add(g);
            }
        }

    }

}
