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
    public class SjedisteViewModel : BaseViewModel
    {
        private APIService _apiServiceSjedista = new APIService("Sjediste");
        private APIService _apiServiceKupci = new APIService("Kupac");
        private APIService _apiServiceUlaznice= new APIService("Ulaznica");


        public SjedisteViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Sjediste> SjedisteList { get; set; } = new ObservableCollection<Sjediste>();

        public Ulaznica Ulaznica { get; set; }
        public Kupac Kupac { get; set; }
        public Sala sala { get; set; }

        public int BrojSjedala { get; set; }

        public int BrojKolona { get; set; }
        public int BrojRedova { get; set; }

        public ICommand InitCommand { get; set; }
        public List<Ulaznica> UlazniceList { get; set; }

        public async Task Init()
        {
            IsBusy = true;
            var username = APIService.Username;
            List<Kupac> listKupci = await _apiServiceKupci.Get<List<Kupac>>(null);
            foreach (var kupac in listKupci)
            {
                if (kupac.KorisnickoIme == username)
                {
                    Kupac = kupac;
                    break;
                }
            }

            var list = await _apiServiceSjedista.Get<List<Sjediste>>(null);
            BrojSjedala = 0;
            SjedisteList.Clear();
            foreach (var sjedalo in list)
            {
             
                    SjedisteList.Add(sjedalo);
                    BrojSjedala++;
            
            }
            if (BrojSjedala > 10)
                BrojRedova = BrojSjedala / 10;
            else
                BrojRedova = 1;

            UlazniceList = await _apiServiceUlaznice.Get<List<Ulaznica>>(null);
        }

    }
}