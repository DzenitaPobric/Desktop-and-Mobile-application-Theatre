using Pozoriste.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pozoriste.Mobile
{
    public static class ReservationService
    {
        public static  Dictionary<int, PrikazivanjeDetailViewModel> Reservation { get; set; } = new Dictionary<int, PrikazivanjeDetailViewModel>();
    }
}
