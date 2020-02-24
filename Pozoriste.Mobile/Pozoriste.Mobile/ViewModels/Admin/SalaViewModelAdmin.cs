using ePozoriste.Model;
using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pozoriste.Mobile.ViewModels.Admin
{
    public class SalaViewModelAdmin : BaseViewModel
    {
        public SalaViewModelAdmin()
        {
            DodajSaluCommand = new Command(async () => await DodajSalu());
            PrikazSaluCommand = new Command(async () => await PrikazSalu());
            // UrediZanrCommand = new Command(async () => await UrediZanr());
        }

        public ICommand DodajSaluCommand { get; set; }
        public ICommand PrikazSaluCommand { get; set; }
        //    public ICommand UrediZanrCommand { get; set; }
        public ICommand InitCommand { get; set; }

        private APIService _service = new APIService("Sala");

        public ObservableCollection<Sala> SalaList { get; set; } = new ObservableCollection<Sala>();

        public Sala sala { get; set; }



        public async Task DodajSalu()
        {
            IsBusy = true;
            await _service.Insert<Sala>(new SalaUpsertRequest()
            {
                Naziv = _naziv,
                Kapacitet=_kapacitet,
                Klimatizacija=_klimatizacija
            });
            await Application.Current.MainPage.DisplayAlert(" ", "Uspješno sačuvani podaci", "OK");
        }


        public async Task PrikazSalu()
        {
            var list = await _service.Get<IEnumerable<Sala>>(null);
            SalaList.Clear();
            foreach (var sala in list)
            {
                SalaList.Add(sala);
            }
        }




        string _naziv = string.Empty;
        public string Naziv
        {
            get { return _naziv; }
            set { SetProperty(ref _naziv, value); }
        }

        int _kapacitet = 0;
        public int Kapacitet
        {
            get { return _kapacitet; }
            set { SetProperty(ref _kapacitet, value); }
        }

        bool _klimatizacija = false;
        public bool Klimatizacija
        {
            get { return _klimatizacija; }
            set { SetProperty(ref _klimatizacija, value); }
        }



    }
}