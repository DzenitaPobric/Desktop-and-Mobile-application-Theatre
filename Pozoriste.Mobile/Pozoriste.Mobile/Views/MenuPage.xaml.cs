using Plugin.Multilingual;
using Pozoriste.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pozoriste.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;

        public MenuPage()
        {
            InitializeComponent();
          

            menuItems = new List<HomeMenuItem>
            {
                //new HomeMenuItem {Id = MenuItemType.KakoDoNas, Title=TestResource.Our_location },
                //new HomeMenuItem {Id = MenuItemType.Novosti, Title=TestResource.News },
                //new HomeMenuItem {Id = MenuItemType.Predstave, Title=TestResource.Shows },
                //new HomeMenuItem {Id = MenuItemType.Glumci, Title=TestResource.Actors },
                //new HomeMenuItem {Id = MenuItemType.Prikazivanja, Title=TestResource.Performances},
                //new HomeMenuItem {Id = MenuItemType.MojeRezervacije, Title=TestResource.My_reservations  },
                //new HomeMenuItem {Id = MenuItemType.KorisnickiProfil, Title= TestResource.My_account  },
                //new HomeMenuItem {Id = MenuItemType.MojeUlaznice, Title=TestResource.My_tickets },
                //new HomeMenuItem {Id = MenuItemType.NagradnaIgra, Title=TestResource.Giveaways },
                //new HomeMenuItem {Id = MenuItemType.Ocjenjivanje, Title=TestResource.Grading },
                //new HomeMenuItem {Id = MenuItemType.Notifikacija, Title=TestResource.Notifications },
                //new HomeMenuItem {Id = MenuItemType.Galerija, Title=TestResource.Gallery },
                //new HomeMenuItem {Id = MenuItemType.Dokumenti, Title=TestResource.Documents },
                //new HomeMenuItem {Id = MenuItemType.Odjava, Title=TestResource.Log_out } 

                new HomeMenuItem {Id = MenuItemType.KakoDoNas, Title="Kako do nas" },
                new HomeMenuItem {Id = MenuItemType.Novosti, Title="Novosti" },
                new HomeMenuItem {Id = MenuItemType.Predstave, Title="Predstave" },
                new HomeMenuItem {Id = MenuItemType.Glumci, Title="Glumci" },
                new HomeMenuItem {Id = MenuItemType.Prikazivanja, Title="Prikazivanja"},
                new HomeMenuItem {Id = MenuItemType.MojeRezervacije, Title="Moje rezervacije"  },
                new HomeMenuItem {Id = MenuItemType.KorisnickiProfil, Title= "Korisnički profil"  },
                new HomeMenuItem {Id = MenuItemType.MojeUlaznice, Title="Moje ulaznice" },
                new HomeMenuItem {Id = MenuItemType.NagradnaIgra, Title="Nagradne igre" },
                new HomeMenuItem {Id = MenuItemType.Ocjenjivanje, Title="Ocjenjivanje" },
                new HomeMenuItem {Id = MenuItemType.Notifikacija, Title="Notifikacije" },
                new HomeMenuItem {Id = MenuItemType.Preporuke, Title="Preporuke" },
                new HomeMenuItem {Id = MenuItemType.Galerija, Title="Galerija"},
                new HomeMenuItem {Id = MenuItemType.Dokumenti, Title="Dokumenti" },
                new HomeMenuItem {Id = MenuItemType.Odjava, Title="Odjava" },
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };         
        }

      
    }
}