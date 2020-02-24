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
    public class MojeRezervacijeViewModel : BaseViewModel
    {
        private APIService _reezrvacije = new APIService("Rezervacija");
        private APIService _kupac = new APIService("Kupac");

        public MojeRezervacijeViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public Kupac kupac { get; set; }
        public ObservableCollection<Rezervacija> RezervacijaList { get; set; } = new ObservableCollection<Rezervacija>();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var username = APIService.Username;
            List<Kupac> listKupci = await _kupac.Get<List<Kupac>>(null);
            foreach (var k in listKupci)
            {
                if (k.KorisnickoIme == username)
                {
                    kupac = k;
                    break;
                }
            }
            var list = await _reezrvacije.Get<IEnumerable<Rezervacija>>(new RezervacijaSearchRequest() { KupacId = kupac.KupacId });
            RezervacijaList.Clear();
            foreach (var rezervacija in list)
            {                
                RezervacijaList.Add(rezervacija);
            }
        }

    }


}


