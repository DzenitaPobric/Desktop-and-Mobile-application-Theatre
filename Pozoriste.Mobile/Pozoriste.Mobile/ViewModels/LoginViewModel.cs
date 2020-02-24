using ePozoriste.Model;
using Pozoriste.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pozoriste.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("korisnik");
        private readonly APIService _serviceKupci = new APIService("Kupac");

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
        }
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { get; set; }

        async Task Login()
        {
            IsBusy = true;
            APIService.Username = Username;
            APIService.Password = Password;

            try
            {
                await _service.Get<dynamic>(null);

                Kupac kupac = null;
                List<Kupac> lista = await _serviceKupci.Get<List<Kupac>>(null);
                foreach (var k in lista)
                {
                    if (k.KorisnickoIme == Username)
                    {
                        kupac = k;
                        break;
                    }
                }

                if(kupac != null)
                {
                    Application.Current.MainPage = new MainPage();
                }
                else
                {
                    Application.Current.MainPage = new MainPageAdmin();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                IsBusy = false;
            }

          
        }
    }
}
