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
    public partial class NovostiDetailPage : ContentPage
    {
        private NovostiDetailViewModel model = null;

        public NovostiDetailPage(Novosti novosti)
        {
            InitializeComponent();
            BindingContext = model = new NovostiDetailViewModel()
            {
                Novosti = novosti
            };
        }
    }
}