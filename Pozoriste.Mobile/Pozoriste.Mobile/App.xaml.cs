using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pozoriste.Mobile.Services;
using Pozoriste.Mobile.Views;
using Plugin.Multilingual;
using System.Globalization;
using System.Threading;

namespace Pozoriste.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            //var str = TestResource.NekiString;
            //var predstave = TestResource.Shows;

            // TestResource.Culture = new CultureInfo("en-US");

            MainPage = new ContentPage();
        }

        protected override void OnStart()
        {
            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            //TestResource.Culture = CrossMultilingual.Current.DeviceCultureInfo;
           // MainPage = new NavigationPage(new LoginPage());



            // Handle when your app starts
            Bootstrap.Instance.Setup();

            MainPage = new LoginPage();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
