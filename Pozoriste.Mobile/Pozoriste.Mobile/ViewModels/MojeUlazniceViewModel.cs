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
    public class MojeUlazniceViewModel : BaseViewModel
    {
        private APIService _ulaznice = new APIService("Ulaznica");
        private APIService _kupac = new APIService("Kupac");
        private APIService _prikazivanje = new APIService("Prikazivanje");

        public MojeUlazniceViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public Kupac kupac { get; set; }
        public ObservableCollection<Ulaznica> UlazniceList { get; set; } = new ObservableCollection<Ulaznica>();

        public Ulaznica ulaznica { get; set; }
        public ICommand InitCommand { get; set; }

        private byte[] _qrCode = new byte[0];

        public byte[] qrCode
        {
            get { return _qrCode; }
            set { SetProperty(ref _qrCode, value); }
        }


        public async Task Init()
        {
            var username = APIService.Username;
            List<Kupac> KupacList = await _kupac.Get<List<Kupac>>(null);
            foreach (var k in KupacList)
            {
                if (k.KorisnickoIme == username)
                {
                    kupac = k;
                    break;
                }
            }
            var list = await _ulaznice.Get<IEnumerable<Ulaznica>>(new UlaznicaSearchRequest() { KupacId = kupac.KupacId });
            UlazniceList.Clear();
            foreach (var ulaznica in list)
            {
                Prikazivanje p = await _prikazivanje.GetById<Prikazivanje>(ulaznica.PrikazivanjeId);
                //if (p.DatumPrikazivanja < DateTime.Now)
                //    ulaznica.Color = "LightGray";
                //else
                //    ulaznica.Color = "LightGreen";
                UlazniceList.Add(ulaznica);
                qrCode = ulaznica.Qrkod;
               
            }
        }

    }


}

