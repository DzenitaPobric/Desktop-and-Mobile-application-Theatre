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
    public partial class GlumacDetailPage : ContentPage
    {
        private GlumacDetailViewModel model = null;
        public GlumacDetailPage(Glumac glumac)
        {
            InitializeComponent();
            BindingContext = model = new GlumacDetailViewModel()
            {
                Glumac = glumac
            };
        }
    }
}