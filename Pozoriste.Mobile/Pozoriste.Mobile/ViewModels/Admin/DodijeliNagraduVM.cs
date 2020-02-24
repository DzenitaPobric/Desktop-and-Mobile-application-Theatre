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
     public class DodijeliNagraduVM
    {
        private readonly APIService _apiServiceKupac = new APIService("Kupac");
        private readonly APIService _apiServiceNagradnaIgra = new APIService("NagradnaIgra");
        private readonly APIService _apiServiceKupacNagradnaIgra = new APIService("KupacNagradnaIgra");

        public KupacNagradnaIgra KupacNagradnaIgra { get; set; }
        public NagradnaIgra NagradnaIgra { get; set; }
        public Kupac Kupac { get; set; }

        public ObservableCollection<KupacNagradnaIgra> KupacNagradnaIgraList { get; set; } = new ObservableCollection<KupacNagradnaIgra>();
        public ObservableCollection<NagradnaIgra> NagradnaIgraList { get; set; } = new ObservableCollection<NagradnaIgra>();
        public ObservableCollection<Kupac> KupacList { get; set; } = new ObservableCollection<Kupac>();

        public DodijeliNagraduVM()
        {
            InitCommand = new Command(async () => await Init());
            InitCommand2 = new Command(async () => await Init2());
        }

        public ICommand InitCommand { get; set; }
        public ICommand InitCommand2 { get; set; }


        static Random random = new Random();

        public async Task Init()
        {
            var list = await _apiServiceKupac.Get<List<Kupac>>(null);
            int brojKupaca = list.Count;
            int[] nizKupci = new int[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                nizKupci[i] = list[i].KupacId;
            }
            KupacNagradnaIgraInsertRequest req = new KupacNagradnaIgraInsertRequest();
            int _kupac= random.Next(0, brojKupaca);
            req.KupacId = nizKupci[_kupac];
            req.NagradnaIgraId = NagradnaIgra.NagradnaIgraId;

            
            await _apiServiceKupacNagradnaIgra.Insert<KupacNagradnaIgra>(req);

            Kupac x = await _apiServiceKupac.GetById<Kupac>(req.KupacId);
            int brojTokenaZaPoklon = random.Next(5, 20);
            x.BrojTokena += brojTokenaZaPoklon;
            await _apiServiceKupac.Update<Kupac>(req.KupacId, x);
        }


        public async Task Init2()
        {
            var list = await _apiServiceKupacNagradnaIgra.Get<IEnumerable<KupacNagradnaIgra>>(null);
            KupacNagradnaIgraList.Clear();
            foreach (var k in list)
            {
                KupacNagradnaIgraList.Add(k);
            }
        }
    }
}
