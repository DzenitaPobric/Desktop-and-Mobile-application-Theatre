using ePozoriste.Model;
using Plugin.Multilingual;
using Pozoriste.Mobile.Models;
using Pozoriste.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pozoriste.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PredstavaDetailPage : ContentPage
	{
		private APIService _predstava = new APIService("Predstava");
		//public ObservableCollection<Language> Languages { get; }

		private PredstavaDetailViewModel model = null;
		public PredstavaDetailPage(Predstava predstava)
		{
			InitializeComponent();
			BindingContext = model = new PredstavaDetailViewModel()
			{
				Predstava = predstava
			};
			//Languages = new ObservableCollection<Language>()
			//{

			//	new Language { DisplayName =  "English", ShortName = "en" },
			//	new Language { DisplayName =  "Bosnian - Bosnian", ShortName = "bs" }
			//};

			//BindingContext = this;

			//PickerLanguages.SelectedIndexChanged += PickerLanguages_SelectedIndexChanged;
		}

		//private void PickerLanguages_SelectedIndexChanged(object sender, EventArgs e)
		//{
		//	var language = Languages[PickerLanguages.SelectedIndex];

		//	try
		//	{
		//		var culture = new CultureInfo(language.ShortName);
		//		TestResource.Culture = culture;
		//		CrossMultilingual.Current.CurrentCultureInfo = culture;
		//	}
		//	catch (Exception)
		//	{
		//	}
		//	LabelTranslate.Text = TestResource.Genre;
		//	//LabelTranslate1.Text = TestResource.News;
		//	//LabelTranslate2.Text = TestResource.Shows;
		//}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			var item = model.Predstava;

			await Navigation.PushAsync(new DodajKomentarPage(item));
		}



	}
}