using ePozoriste.Model;
using ePozoriste.Model.Requests;
using Pozoriste.Mobile.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pozoriste.Mobile.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UrediPrikazivanjePage : ContentPage
    {
        public APIService _prikazivanje = new APIService("PrikazivanjeMobile");
        private Prikazivanje z = null;

        public PrikazivanjeUrediVM prikazivanjeVM { get; set; }
        public UrediPrikazivanjePage(Prikazivanje prikazivanje)
        {
            InitializeComponent();
            BindingContext = prikazivanjeVM = new PrikazivanjeUrediVM() { Prikazivanje = prikazivanje };
            z = prikazivanje;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await prikazivanjeVM.Init();
            await prikazivanjeVM.Init2();
            this.Predstave.SelectedItem = prikazivanjeVM.PredstavaList.FirstOrDefault(s => s.PredstavaId == prikazivanjeVM.Prikazivanje.PredstavaId);
            this.Sale.SelectedItem = prikazivanjeVM.SalaList.FirstOrDefault(s => s.SalaId == prikazivanjeVM.Prikazivanje.SalaId);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (this.DatumPrikazivanja.Date <= new DateTime(2000, 01, 01))
            {
                await DisplayAlert("Greška", "Neispravan datum", "OK");
            }
            else if (!Regex.IsMatch(this.Cijena.Text, @"^[0-9]+$"))
            {
                await DisplayAlert("Greška", "Cijena sadrzi samo brojeve", "OK");
            }
            else if (this.Sale.SelectedItem == null)
            {
                await DisplayAlert("Greška", "Morate odabrati salu", "OK");
            }
            else if (this.Predstave.SelectedItem == null)
            {
                await DisplayAlert("Greška", "Morate odabrati predstavu!", "OK");
            }
            else
            {
                try
                {
                    PrikazivanjeUpsertRequest req = new PrikazivanjeUpsertRequest();
            req.Cijena = Convert.ToDecimal(this.Cijena.Text);
            req.DatumPrikazivanja= this.DatumPrikazivanja.Date.AddSeconds(this.VrijemePrikazivanja.Time.TotalSeconds);
            Sala s = this.Sale.SelectedItem as Sala;
            req.SalaId = s.SalaId;
            Predstava p = this.Predstave.SelectedItem as Predstava;
            req.PredstavaId = p.PredstavaId;

            await _prikazivanje.Update<dynamic>(prikazivanjeVM.Prikazivanje.PrikazivanjeId, req);
            await DisplayAlert("OK", "Uspješno uneseni podaci", "OK");
                    // await  Navigation.PushAsync(new ZanrPage());
                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }
            }
        }

    }

}


