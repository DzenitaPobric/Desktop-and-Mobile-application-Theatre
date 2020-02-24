using ePozoriste.Model;
using ePozoriste.Model.Requests;
using Pozoriste.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pozoriste.Mobile.ViewModels
{
    public class SponzorViewModel : BaseViewModel
    {
        public SponzorViewModel()
        {
            DodajSponzorCommand = new Command(async () => await DodajSponzor());
            PrikazSponzorCommand = new Command(async () => await PrikazSponzor());
        }

        public ICommand DodajSponzorCommand { get; set; }
        public ICommand PrikazSponzorCommand { get; set; }
        public ICommand InitCommand { get; set; }

        private APIService _service = new APIService("Sponzor");

        public ObservableCollection<Sponzor> SponzorList { get; set; } = new ObservableCollection<Sponzor>();

        public Sponzor sponzor { get; set; }



        public async Task DodajSponzor()
        {
            IsBusy = true;
            await _service.Insert<Sponzor>(new SponzorInsertRequest()
            {
                Naziv = _naziv,
                BrojTelefona = _brojtelefona
            });
            await Application.Current.MainPage.DisplayAlert(" ", "Uspješno sačuvani podaci", "OK");
        }


        public async Task PrikazSponzor()
        {
            var list = await _service.Get<IEnumerable<Sponzor>>(null);
            SponzorList.Clear();
            foreach (var s in list)
            {
                SponzorList.Add(s);
            }
        }




        string _naziv = string.Empty;
        public string Naziv
        {
            get { return _naziv; }
            set { SetProperty(ref _naziv, value); }
        }
        string _brojtelefona = string.Empty;
        public string BrojTelefona
        {
            get { return _brojtelefona; }
            set { SetProperty(ref _brojtelefona, value); }
        }


    }
}