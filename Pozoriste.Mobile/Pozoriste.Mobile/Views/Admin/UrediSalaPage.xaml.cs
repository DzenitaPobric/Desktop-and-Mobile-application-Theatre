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
    public partial class UrediSalaPage : ContentPage
    {
        public APIService _sala = new APIService("Sala");
        private Sala z = null;

        public UrediSalaVM salaVM { get; set; }
        public UrediSalaPage(Sala sala)
        {
            InitializeComponent();
            BindingContext = salaVM = new UrediSalaVM() { Sala = sala };
            z = sala;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(this.Naziv.Text, @"^[a-zA-Z ]+$"))
            {
                await DisplayAlert("Greška", "Naziv se sastoji samo od slova", "OK");
            }
            else if (!Regex.IsMatch(this.Kapacitet.Text, @"^[0-9]+$"))
            {
                await DisplayAlert("Greška", "Kapacitet sadrzi samo brojeve", "OK");
            }
            else
            {
                try
                {
                    SalaUpsertRequest req = new SalaUpsertRequest()
            {

                Naziv = this.Naziv.Text,
                Kapacitet =Convert.ToInt32(this.Kapacitet.Text),
            };

                await _sala.Update<dynamic>(salaVM.Sala.SalaId, req);
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




