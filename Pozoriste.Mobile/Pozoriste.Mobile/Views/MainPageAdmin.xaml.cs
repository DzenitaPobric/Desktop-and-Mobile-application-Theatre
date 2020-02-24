using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Pozoriste.Mobile.Models;
using ePozoriste.Model;
using Pozoriste.Mobile.Views.Admin;

namespace Pozoriste.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPageAdmin : MasterDetailPage
    {
        public APIService aPIServiceKorisnik = new APIService("Korisnik");

        Dictionary<int, NavigationPage> MenuPagesAdmin = new Dictionary<int, NavigationPage>();
        public MainPageAdmin()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

           // MenuPagesAdmin.Add((int)MenuItemTypeAdmin.Browse, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPagesAdmin.ContainsKey(id))
            {
                switch (id)
                {
                    //case (int)MenuItemTypeAdmin.Browse:
                    //    MenuPagesAdmin.Add(id, new NavigationPage(new ItemsPage()));
                    //    break;
                    //case (int)MenuItemTypeAdmin.About:
                    //    MenuPagesAdmin.Add(id, new NavigationPage(new AboutPage()));
                    //    break;                  
                    case (int)MenuItemTypeAdmin.Zanr:
                        MenuPagesAdmin.Add(id, new NavigationPage(new ZanrPage()));
                        break;
                    case (int)MenuItemTypeAdmin.Predstave:
                        MenuPagesAdmin.Add(id, new NavigationPage(new PredstavaPage()));
                        break;
                    case (int)MenuItemTypeAdmin.Prikazivanja:
                        MenuPagesAdmin.Add(id, new NavigationPage(new PrikazivanjePageAdmin()));
                        break;
                    case (int)MenuItemTypeAdmin.Sponzori:
                        MenuPagesAdmin.Add(id, new NavigationPage(new SponzorPage()));
                        break;
                    case (int)MenuItemTypeAdmin.Uplate:
                        MenuPagesAdmin.Add(id, new NavigationPage(new UplataPage()));
                        break;
                    case (int)MenuItemTypeAdmin.Sale:
                        MenuPagesAdmin.Add(id, new NavigationPage(new SalaPageAdmin()));
                        break;
                    case (int)MenuItemTypeAdmin.Glumci:
                        MenuPagesAdmin.Add(id, new NavigationPage(new GlumacPage()));
                        break;
                    case (int)MenuItemTypeAdmin.Gradovi:
                        MenuPagesAdmin.Add(id, new NavigationPage(new GradPage()));
                        break;
                    case (int)MenuItemTypeAdmin.Komentari:
                        MenuPagesAdmin.Add(id, new NavigationPage(new PrikazKomentaraPage()));
                        break;             
                    case (int)MenuItemTypeAdmin.Rezervacije:
                        MenuPagesAdmin.Add(id, new NavigationPage(new PrikazRezervacijaPage()));
                        break;
                    case (int)MenuItemTypeAdmin.Novosti:
                        MenuPagesAdmin.Add(id, new NavigationPage(new NovostiPageAdmin()));
                        break;
                    case (int)MenuItemTypeAdmin.NagradnaIgra:
                        MenuPagesAdmin.Add(id, new NavigationPage(new NagradnaIgraPageAdmin()));
                        break;
                    case (int)MenuItemTypeAdmin.Odjava:
                        MenuPagesAdmin.Add(id, new NavigationPage(new LoginPage()));
                        break;
                }
            }

            var newPage = MenuPagesAdmin[id];

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