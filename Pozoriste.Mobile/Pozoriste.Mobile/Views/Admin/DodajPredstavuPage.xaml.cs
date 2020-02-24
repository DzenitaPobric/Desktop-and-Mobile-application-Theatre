using ePozoriste.Model;
using Pozoriste.Mobile.ViewModels;
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
    public partial class DodajPredstavuPage : ContentPage
    {
        PredstavaVIewModelAdmin vm = null;
        //  public APIService _servicePredstava = new APIService("Predstava");

        public DodajPredstavuPage()
        {
            InitializeComponent();
            BindingContext = vm = new PredstavaVIewModelAdmin();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.Init();
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
                await DisplayAlert("Greška", "Trajanje sadrzi samo brojeve", "OK");
            }
            else if (!Regex.IsMatch(this.Opis.Text, @"^[a-zA-Z ]+$"))
            {
                await DisplayAlert("Greška", "Opis se sastoji samo od slova", "OK");
            }
            else if (this.Zanrovi.SelectedItem == null)
            {
                await DisplayAlert("Greška", "Morate odabrati žanr", "OK");
            }
            else
            {
                try
                {
                    vm.Naziv = this.Naziv.Text;
                    Zanr z = this.Zanrovi.SelectedItem as Zanr;
                    vm.ZanrId = z.ZanrID;
                    vm.Reziser = this.Reziser.Text;
                    vm.Trajanje = Convert.ToInt32(this.Trajanje.Text);
                    vm.Opis = this.Opis.Text;
                    await vm.DodajPredstavu();
                }

                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }
            }
        }
    }
}