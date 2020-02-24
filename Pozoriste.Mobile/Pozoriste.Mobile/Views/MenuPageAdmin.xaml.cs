using Pozoriste.Mobile.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pozoriste.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPageAdmin : ContentPage
    {
        MainPageAdmin RootPage { get => Application.Current.MainPage as MainPageAdmin; }
        List<HomeMenuItemAdmin> menuItems;
        public MenuPageAdmin()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItemAdmin>
            {
                //new HomeMenuItemAdmin {Id = MenuItemTypeAdmin.Browse, Title="Browse" },
                //new HomeMenuItemAdmin {Id = MenuItemTypeAdmin.About, Title="About" },

                new HomeMenuItemAdmin {Id = MenuItemTypeAdmin.Zanr, Title="Žanr" },
                new HomeMenuItemAdmin {Id = MenuItemTypeAdmin.Predstave, Title="Predstave" },
                new HomeMenuItemAdmin {Id = MenuItemTypeAdmin.Prikazivanja, Title="Prikazivanja" },
                new HomeMenuItemAdmin {Id = MenuItemTypeAdmin.Sponzori, Title="Sponzori" },
                new HomeMenuItemAdmin {Id = MenuItemTypeAdmin.Uplate, Title="Uplate" },
                new HomeMenuItemAdmin {Id = MenuItemTypeAdmin.Sale, Title="Sale" },
                new HomeMenuItemAdmin {Id = MenuItemTypeAdmin.Glumci, Title="Glumci" },
                new HomeMenuItemAdmin {Id = MenuItemTypeAdmin.Gradovi, Title="Gradovi" },
                new HomeMenuItemAdmin {Id = MenuItemTypeAdmin.Komentari, Title="Komentari" },
                new HomeMenuItemAdmin {Id = MenuItemTypeAdmin.Rezervacije, Title="Rezervacije" },
                new HomeMenuItemAdmin {Id = MenuItemTypeAdmin.Novosti, Title="Novosti" },
                new HomeMenuItemAdmin {Id = MenuItemTypeAdmin.NagradnaIgra, Title="Nagradne igre" },
                new HomeMenuItemAdmin {Id = MenuItemTypeAdmin.Odjava, Title="Odjava" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItemAdmin)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}