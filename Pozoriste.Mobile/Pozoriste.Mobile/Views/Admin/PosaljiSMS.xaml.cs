using ePozoriste.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pozoriste.Mobile.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PosaljiSMS : ContentPage
    {
        public APIService _apiServiceRezerv = new APIService("Rezervacija");

        public PosaljiSMS()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            List<string> brojevi = new List<string>
                {
                    entryBroj.Text
                };
            await Posaljisms(entrytekstPoruke.Text, brojevi);


        }

        public async Task Posaljisms(string tekst, List<string> primalac)
        {
            try
            {
                var poruka = new SmsMessage(tekst, primalac);
                await Sms.ComposeAsync(poruka);
            }
            catch (FeatureNotSupportedException ex)
            {

            }
            catch (Exception ex)
            {

            }

        }
    }
}