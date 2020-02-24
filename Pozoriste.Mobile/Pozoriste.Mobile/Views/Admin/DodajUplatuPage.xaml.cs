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
    public partial class DodajUplatuPage : ContentPage
    {
        UplataViewModelAdmin vm = null;

        public DodajUplatuPage()
        {
            InitializeComponent();
            BindingContext = vm = new UplataViewModelAdmin();
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
                await DisplayAlert("Greška", "Polje naziv se sastoji samo od slova!", "OK");
            }
            else if (!Regex.IsMatch(this.Svrha.Text, @"^[a-zA-Z ]+$"))
            {
                await DisplayAlert("Greška", "Polje svrha se sastoji samo od slova!", "OK");
            }
            else if (!Regex.IsMatch(this.Opis.Text, @"^[a-zA-Z ]+$"))
            {
                await DisplayAlert("Greška", "Polje opis se sastoji samo od slova!", "OK");
            }
            else if (!Regex.IsMatch(this.Iznos.Text, @"^[0-9]+$"))
            {
                await DisplayAlert("Greška", "Polje iznos se sastoji samo od brojeva!", "OK");
            }
            else if (this.Sponzori.SelectedItem == null)
            {
                await DisplayAlert("Greška", "Morate odabrati sponzora!", "OK");

            }
            else
            {
                try
                {
                    vm.Naziv = this.Naziv.Text;
                    Sponzor s = this.Sponzori.SelectedItem as Sponzor;
                    vm.SponzorId = s.SponzorId;
                    vm.Svrha = this.Svrha.Text;
                    vm.Iznos = Convert.ToInt32(this.Iznos.Text);
                    vm.Opis = this.Opis.Text;
                    await vm.DodajUplatu();
                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }
            }
        }
    }
}