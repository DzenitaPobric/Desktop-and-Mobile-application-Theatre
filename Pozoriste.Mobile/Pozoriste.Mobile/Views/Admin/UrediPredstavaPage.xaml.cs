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
    public partial class UrediPredstavaPage : ContentPage
    {
        public APIService _predstava = new APIService("PredstavaMobile");
        private Predstava z = null;

        public UrediPredstavaVM predstavaVM { get; set; }
        public UrediPredstavaPage(Predstava predstava)
        {
            InitializeComponent();
            BindingContext = predstavaVM = new UrediPredstavaVM() { Predstava = predstava };
            z = predstava;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await predstavaVM.Init();
            this.Zanrovi.SelectedItem = predstavaVM.ZanrList.FirstOrDefault(s => s.ZanrID == predstavaVM.Predstava.ZanrId);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(this.Naziv.Text, @"^[a-zA-Z ]+$"))
            {
                await DisplayAlert("Greška", "Naziv se sastoji samo od slova", "OK");
            }
            else if (!Regex.IsMatch(this.Reziser.Text, @"^[a-zA-Z ]+$"))
            {
                await DisplayAlert("Greška", "Režiser polje se sastoji samo od slova", "OK");
            }
            else if (!Regex.IsMatch(this.Trajanje.Text, @"^[0-9]+$"))
            {
                await DisplayAlert("Greška", "Format telefona je: +123 45 678 910", "OK");
            }
            else if (!Regex.IsMatch(this.Opis.Text, @"^[a-zA-Z ]+$"))
            {
                await DisplayAlert("Greška", "Opis se sastoji samo od slova", "OK");
            }
            else if (this.Zanrovi.SelectedItem == null)
            {
                await DisplayAlert("Greška", "Trebate odabrati žanr", "OK");
            }
            else
            {
                try
                {
                    PredstavaUpsertRequest req = new PredstavaUpsertRequest();
                    req.Naziv = this.Naziv.Text;
                    req.Opis = this.Opis.Text;
                    req.Reziser = this.Reziser.Text;
                    req.Trajanje = Convert.ToInt32(this.Trajanje.Text);
                    Zanr z = this.Zanrovi.SelectedItem as Zanr;
                    req.ZanrId = z.ZanrID;
    

                    await _predstava.Update<dynamic>(predstavaVM.Predstava.PredstavaId, req);
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



