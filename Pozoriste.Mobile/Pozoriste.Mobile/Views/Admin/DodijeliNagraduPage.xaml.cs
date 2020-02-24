using ePozoriste.Model;
using Pozoriste.Mobile.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pozoriste.Mobile.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DodijeliNagraduPage : ContentPage
    {
        private NagradnaIgra nagradnaIgra = null;

        public DodijeliNagraduVM nagradaVM { get; set; }


        public DodijeliNagraduPage(NagradnaIgra igra)
        {
            InitializeComponent();
            BindingContext = nagradaVM = new DodijeliNagraduVM { NagradnaIgra = igra };
            nagradnaIgra = igra;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await nagradaVM.Init();
            await nagradaVM.Init2();

        }
    }
}