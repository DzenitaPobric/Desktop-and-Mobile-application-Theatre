using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Pozoriste.Mobile.Models;
using ePozoriste.Model;
using Pozoriste.Mobile.Views.Admin;
using XamarinImageSlider;

namespace Pozoriste.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public APIService aPIServiceKupci = new APIService("Kupac");

        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

        }

        public MainPage(MenuItemType type)
        {

            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            _ = NavigateFromMenu((int)type);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                  
                    case (int)MenuItemType.KakoDoNas:
                        MenuPages.Add(id, new NavigationPage(new SalaPage()));
                        break;
                    case (int)MenuItemType.Novosti:
                        MenuPages.Add(id, new NavigationPage(new NovostiPage()));
                        break;
                    case (int)MenuItemType.Predstave:
                        MenuPages.Add(id, new NavigationPage(new PredstavePage()));
                        break;
                    case (int)MenuItemType.Glumci:
                        MenuPages.Add(id, new NavigationPage(new GlumciPage()));
                        break;
                    case (int)MenuItemType.Prikazivanja:
                        MenuPages.Add(id, new NavigationPage(new PrikazivanjaPage()));
                        break;
                  
                    case (int)MenuItemType.MojeRezervacije:
                        MenuPages.Add(id, new NavigationPage(new MojeRezervacijePage()));
                        break;
                   
                    case (int)MenuItemType.KorisnickiProfil:
                        Kupac kupac = new Kupac();
                        var username = APIService.Username;
                        List<Kupac> lista = await aPIServiceKupci.Get<List<Kupac>>(null);
                        foreach (var k in lista)
                        {
                            if (k.KorisnickoIme == username)
                            {
                                kupac = k;
                                break;
                            }
                        }
                        MenuPages.Add(id, new NavigationPage(new KorisnickiProfilPage(kupac)));
                        break;

                    case (int)MenuItemType.MojeUlaznice:
                        MenuPages.Add(id, new NavigationPage(new MojeUlaznicePage()));
                        break;
                    case (int)MenuItemType.NagradnaIgra:
                        MenuPages.Add(id, new NavigationPage(new NagradnaIgraPage()));
                        break;

                    case (int)MenuItemType.Ocjenjivanje:
                        MenuPages.Add(id, new NavigationPage(new PredstavaOcjenaPage()));
                        break;
                    case (int)MenuItemType.Notifikacija:
                        MenuPages.Add(id, new NavigationPage(new NotifikacijaPage()));
                        break;
                    case (int)MenuItemType.Preporuke:
                        MenuPages.Add(id, new NavigationPage(new PreporukaPage()));
                        break;
                    case (int)MenuItemType.Galerija:
                        MenuPages.Add(id, new NavigationPage(new GalerijaPage()));
                        break;
                    case (int)MenuItemType.Dokumenti:
                        MenuPages.Add(id, new NavigationPage(new DokumentiPage()));
                        break;
 
                    case (int)MenuItemType.Odjava:
                        MenuPages.Add(id, new NavigationPage(new LoginPage()));
                        break;

                  

                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}