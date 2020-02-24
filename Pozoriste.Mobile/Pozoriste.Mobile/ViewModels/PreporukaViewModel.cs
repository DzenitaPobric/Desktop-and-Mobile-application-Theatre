
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
    public class PreporukaViewModel : BaseViewModel
    {
        private readonly APIService _apiServicePreporuke = new APIService("Preporuka");
        private readonly APIService _apiServiceKupci = new APIService("Kupac");

        public ObservableCollection<Predstava> PredstavaList { get; set; } = new ObservableCollection<Predstava>();

        public PreporukaViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ICommand InitCommand { get; set; }


        public async Task Init()
        {
            Kupac kupac = new Kupac();
            var username = APIService.Username;
            List<Kupac> lista = await _apiServiceKupci.Get<List<Kupac>>(null);
            foreach (var k in lista)
            {
                if (k.KorisnickoIme == username)
                {
                    kupac = k;
                    break;
                }
            }

            var list = await _apiServicePreporuke.GetById<List<Predstava>>(kupac.KupacId);
            PredstavaList.Clear();

            foreach (var item in list)
            {
                PredstavaList.Add(item);
            }
        }


    }
}
