using ePozoriste.Model;
using ePozoriste.Model.Requests;
using Pozoriste.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pozoriste.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OcijeniPredstavuPage : ContentPage
    {
        public APIService _predstavaKupac = new APIService("PredstavaKupac");
        public APIService _apiserviceKupac = new APIService("Kupac");
        private Predstava p = null;

        public OcijeniPredstavuVM model { get; set; }
        public OcijeniPredstavuPage(Predstava predstava)
        {
            InitializeComponent();
            BindingContext = model = new OcijeniPredstavuVM() { Predstava = predstava };
            p = predstava;
        }
        protected  override async void OnAppearing()
        {
            base.OnAppearing();

            await model.Init();
          }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(!decimal.TryParse(this.Ocjena.Text, out decimal Ocjena) || Ocjena < 1 || Ocjena > 10)
            {
                await DisplayAlert("Greška", "Ocjena mora biti između 1 i 10.", "OK");
                return;
            }

            Kupac kupac = new Kupac();
            var username = APIService.Username;
            List<Kupac> lista = await _apiserviceKupac.Get<List<Kupac>>(null);
            foreach (var k in lista)
            {
                if (k.KorisnickoIme == username)
                {
                    kupac = k;
                    break;
                }
            }
            model.Ocjena = Ocjena;
            model.PredstavaId = p.PredstavaId;
            model.KupacId = kupac.KupacId;
          
            await model.DodajOcjenu();
        }

    }

}



