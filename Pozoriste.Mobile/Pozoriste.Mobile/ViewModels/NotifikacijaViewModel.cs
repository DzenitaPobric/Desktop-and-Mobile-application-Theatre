using ePozoriste.Model;
using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pozoriste.Mobile.ViewModels
{
    public class NotifikacijaViewModel
    {
        private readonly APIService _notif = new APIService("notifikacija");
        private readonly APIService _novosti = new APIService("novosti");

        public NotifikacijaViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

    //    public ObservableCollection<Notifikacija> NotifikacijaList { get; set; } = new ObservableCollection<Notifikacija>();
        public ObservableCollection<NotifikacijaList> NotifikacijaListPrikaz { get; set; } = new ObservableCollection<NotifikacijaList>();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var list = await _notif.Get<IEnumerable<Notifikacija>>(null);
            NotifikacijaListPrikaz.Clear();
            foreach (var notif in list)
            {
                var entity = await _novosti.GetById<Novosti>(notif.NovostiId);
                NotifikacijaListPrikaz.Add(new NotifikacijaList(){
                    DatumVrijemeObjave=entity.DatumVrijemeObjave,
                    NazivNovosti=entity.Naziv,
                    NotifikacijaListId=notif.NotifikacijaId,
                    NovostiId=entity.NovostiId
                });
            }
        }


        public async Task Procitano(NotifikacijaList n)
        {
            var entity = await _notif.Update<Notifikacija>(n.NotifikacijaListId, new NotfikacijaInsertRequest
            {
                NovostiId = n.NovostiId,
                DatumSlanja = n.DatumVrijemeObjave,
                IsProcitano = true,
                NotifikacijaId=n.NotifikacijaListId
            });
            if (entity != null)
            {
                //int broj = int.Parse(APIService.BrojNotifikacija);
                //broj -= 1;
                //APIService.BrojNotifikacija = broj.ToString();
                NotifikacijaListPrikaz.Remove(n);
                await Application.Current.MainPage.DisplayAlert(" ", "Notifikacija je oznacena kao procitana!", "OK");
            }
        }
    }
}
