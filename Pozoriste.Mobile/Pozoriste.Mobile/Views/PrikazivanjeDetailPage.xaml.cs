using ePozoriste.Model;
using Pozoriste.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Messaging;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pozoriste.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrikazivanjeDetailPage : ContentPage
    {
		private PrikazivanjeDetailViewModel model = null;
		public PrikazivanjeDetailPage(Prikazivanje prikazivanje)
		{
			InitializeComponent();
			BindingContext = model = new PrikazivanjeDetailViewModel()
			{
				Prikazivanje = prikazivanje
			};
		}

	
	}
}