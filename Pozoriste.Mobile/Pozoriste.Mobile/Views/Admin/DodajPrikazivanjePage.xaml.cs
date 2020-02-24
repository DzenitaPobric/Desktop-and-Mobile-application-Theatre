using ePozoriste.Model;
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
    public partial class DodajPrikazivanjePage : ContentPage
    {
        PrikazivanjeViewModelAdmin vm = null;

        public DodajPrikazivanjePage()
        {
            InitializeComponent();
            BindingContext = vm = new PrikazivanjeViewModelAdmin();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.Init();
            await vm.Init2();
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
                    Sala s = this.Sale.SelectedItem as Sala;
                     vm.SalaId = s.SalaId;
                     Predstava p = this.Predstave.SelectedItem as Predstava;
                     vm.PredstavaId = p.PredstavaId;
                     vm.DatumPikazivanja = this.DatumPrikazivanja.Date.AddSeconds(this.VrijemePrikazivanja.Time.TotalSeconds);
                     vm.Cijena = Convert.ToDecimal(this.Cijena.Text);
                     await vm.DodajPrikazivanje();
                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }
            }
        }
    }
}