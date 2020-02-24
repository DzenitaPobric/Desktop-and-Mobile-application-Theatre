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
    public partial class MojeUlaznicePage : ContentPage
    {
        public MojeUlazniceViewModel mojeUlazniceVM { get; set; }
        public MojeUlaznicePage()
        {
            InitializeComponent();
            BindingContext = mojeUlazniceVM = new MojeUlazniceViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await mojeUlazniceVM.Init();

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn.BindingContext as Ulaznica;

        }

    }
}