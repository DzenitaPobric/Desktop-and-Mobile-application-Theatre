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
    public partial class UrediUplataPage : ContentPage
    {
        public APIService _uplata = new APIService("Uplata");
        private Uplata u = null;

        public UrediUplataVM uplataVM { get; set; }
        public UrediUplataPage(Uplata uplata)
        {
            InitializeComponent();
            BindingContext = uplataVM = new UrediUplataVM() { Uplata = uplata };
            u = uplata;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await uplataVM.Init();
            this.Sponzori.SelectedItem = uplataVM.SponzorList.FirstOrDefault(s => s.SponzorId == uplataVM.Uplata.SponzorId);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(this.Naziv.Text, @"^[a-zA-Z ]+$"))
            {
                await DisplayAlert("Greška", "Naziv se sastoji samo od slova", "OK");
            }
            else if (!Regex.IsMatch(this.Svrha.Text, @"^[a-zA-Z ]+$"))
            {
                await DisplayAlert("Greška", "Polje 'Svrha' se sastoji samo od slova", "OK");
            }          
            else if (this.Sponzori.SelectedItem == null)
            {
                await DisplayAlert("Greška", "Trebate odabrati aponzora", "OK");
            }
            else
            {
                try
                {
                    UplataUpsertRequest req = new UplataUpsertRequest();
                    req.Naziv = this.Naziv.Text;
                    req.Svrha = this.Svrha.Text;
                    req.Iznos = Convert.ToDouble(this.Iznos.Text);
                    req.DatumUplate = this.DatumUplate.Date;
                    Sponzor s = this.Sponzori.SelectedItem as Sponzor;
                    req.SponzorId = s.SponzorId;


                    await _uplata.Update<dynamic>(uplataVM.Uplata.UplataId, req);
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


