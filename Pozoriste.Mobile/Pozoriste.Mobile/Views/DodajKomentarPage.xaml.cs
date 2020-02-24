using ePozoriste.Model;
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
    public partial class DodajKomentarPage : ContentPage
    {
        private KomentarViewModel model = null;

        private Predstava p = null;
     
        public DodajKomentarPage(Predstava pred)
        {
            InitializeComponent();
            BindingContext = model = new KomentarViewModel(pred)
            {
                predstava = pred
            };
           
            p = pred;
        }
 

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {

            model.Sadrzaj = this.Sadrzaj.Text;
            await model.DodajKomentar();
        }

      
    }
}