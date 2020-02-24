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
    public class ZanrViewModel : BaseViewModel
    {
        public ZanrViewModel()
        {
            DodajZanrCommand = new Command(async () => await DodajZanr());
            PrikazZanrCommand = new Command(async () => await PrikazZanr());
        }

        public ICommand DodajZanrCommand { get; set; }
        public ICommand PrikazZanrCommand { get; set; }
        public ICommand InitCommand { get; set; }

        private APIService _service = new APIService("Zanr");

        public ObservableCollection<Zanr> ZanrList { get; set; } = new ObservableCollection<Zanr>();

        public Zanr zanr { get; set; }



        public async Task DodajZanr()
        {
            IsBusy = true;
            await _service.Insert<Zanr>(new ZanrInsertRequest()
            {
                Naziv = _naziv
            });
            await Application.Current.MainPage.DisplayAlert(" ", "Uspješno sačuvani podaci", "OK");
        }



        public async Task PrikazZanr()
        {
            var list = await _service.Get<IEnumerable<Zanr>>(null);
            ZanrList.Clear();
            foreach (var zanr in list)
            {
                ZanrList.Add(zanr);
            }
        }




        string _naziv = string.Empty;
        public string Naziv
        {
            get { return _naziv; }
            set { SetProperty(ref _naziv, value); }
        }

       

    }
}