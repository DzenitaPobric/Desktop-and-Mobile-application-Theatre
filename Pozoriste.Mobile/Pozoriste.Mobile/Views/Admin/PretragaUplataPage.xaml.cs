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
    public partial class PretragaUplataPage : ContentPage
    {
        private PretragaUplataVM model = null;
        public PretragaUplataPage()
        {
            InitializeComponent();
            BindingContext = model = new PretragaUplataVM();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}