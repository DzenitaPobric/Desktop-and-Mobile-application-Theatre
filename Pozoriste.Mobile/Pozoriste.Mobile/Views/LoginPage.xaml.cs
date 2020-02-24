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
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		private void Entry_OnTextChanged(object sender, TextChangedEventArgs e)
		{

		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new RegistracijaPage());
		}
	}
}