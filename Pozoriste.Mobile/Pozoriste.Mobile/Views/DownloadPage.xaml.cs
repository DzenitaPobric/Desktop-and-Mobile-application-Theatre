using ePozoriste.Model;
using GalaSoft.MvvmLight.Ioc;
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
    public partial class DownloadPage : ContentPage
    {
        private readonly DownloadViewModel VM;
        private readonly Dokument dokument;

        public DownloadPage(Dokument dokument)
        {
            InitializeComponent();
            this.BindingContext = VM = SimpleIoc.Default.GetInstance<DownloadViewModel>();
            this.dokument = dokument;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            VM.Init(dokument);

            Navigation.PopAsync();
        }
    }
}