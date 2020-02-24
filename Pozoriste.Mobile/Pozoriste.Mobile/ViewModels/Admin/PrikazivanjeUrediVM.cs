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
    public class PrikazivanjeUrediVM
    {
        public Prikazivanje Prikazivanje { get; set; }
        private APIService _apiServiceSala = new APIService("Sala");
        private APIService _apiServicePedstava = new APIService("Predstava");
        public ObservableCollection<Sala> SalaList { get; set; } = new ObservableCollection<Sala>();
        public ObservableCollection<Predstava> PredstavaList { get; set; } = new ObservableCollection<Predstava>();

        public ICommand InitCommand { get; set; }
        public ICommand InitCommand2 { get; set; }

        public PrikazivanjeUrediVM()
        {
            InitCommand = new Command(async () => await Init());
            InitCommand2 = new Command(async () => await Init2());
        }
        public async Task Init()
        {
            var list = await _apiServiceSala.Get<List<Sala>>(null);
            SalaList.Clear();
            foreach (var s in list)
            {
                SalaList.Add(s);
            }
        }

        public async Task Init2()
        {
            var list = await _apiServicePedstava.Get<List<Predstava>>(null);
            PredstavaList.Clear();
            foreach (var g in list)
            {
                PredstavaList.Add(g);
            }
        }

    }
}
