using ePozoriste.Model;
using Pozoriste.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pozoriste.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SalaDetailPage : ContentPage
    {
        private SalaDetailVM salaDetailVM = null;
        private Sala s = null;
        public SalaDetailPage(Sala sala)
        {
            InitializeComponent();
            BindingContext = salaDetailVM = new SalaDetailVM()
            {
                Sala = sala
            };
            s = sala;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!double.TryParse(s.Lat, out double lat))
                return;
            if (!double.TryParse(s.Lng, out double lng))
                return;

            await Map.OpenAsync(lat, lng, new MapLaunchOptions
            {
                Name = s.Naziv,
                NavigationMode = NavigationMode.None
            });

        }
    }
}