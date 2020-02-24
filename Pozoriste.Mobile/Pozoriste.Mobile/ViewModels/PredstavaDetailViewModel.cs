using ePozoriste.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pozoriste.Mobile.ViewModels
{
    class PredstavaDetailViewModel : BaseViewModel
    {
        public PredstavaDetailViewModel()
        {           
        }

        public Predstava Predstava { get; set; }

    }
}
