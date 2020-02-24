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
    public class RezervacijaViewModel : BaseViewModel
    {
        public ObservableCollection<PrikazivanjeDetailViewModel> RezervacijaList { get; set; } = new ObservableCollection<PrikazivanjeDetailViewModel>();

     
        public  void Init()
        {
            RezervacijaList.Clear();

            foreach (var cartValue in ReservationService.Reservation.Values)
            {
                RezervacijaList.Add(cartValue);
            }
        }
         
    }
}

