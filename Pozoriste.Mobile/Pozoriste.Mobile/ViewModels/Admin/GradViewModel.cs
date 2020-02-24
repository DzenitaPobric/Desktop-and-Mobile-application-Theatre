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
    public class GradViewModel : BaseViewModel
    {
        public GradViewModel()
        {
            DodajGradCommand = new Command(async () => await DodajGrad());
            PrikazGradCommand = new Command(async () => await PrikazGrad());
        }

        public ICommand DodajGradCommand { get; set; }
        public ICommand PrikazGradCommand { get; set; }
        public ICommand InitCommand { get; set; }

        private APIService _service = new APIService("Grad");

        public ObservableCollection<Grad> GradList { get; set; } = new ObservableCollection<Grad>();

        public Grad Grad { get; set; }



        public async Task DodajGrad()
        {
            IsBusy = true;
            await _service.Insert<Grad>(new GradInsertRequest()
            {
                Naziv = _naziv
            });
            await Application.Current.MainPage.DisplayAlert(" ", "Uspješno sačuvani podaci", "OK");
        }



        public async Task PrikazGrad()
        {
            var list = await _service.Get<IEnumerable<Grad>>(null);
            GradList.Clear();
            foreach (var Grad in list)
            {
                GradList.Add(Grad);
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