using ePozoriste.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace Pozoriste.Mobile.ViewModels.Admin
{
    public class UrediNovostiVM:BaseViewModel
    {
        private Novosti _novosti;


        public Novosti Novosti
        {
            get { return _novosti; }
            set { SetProperty(ref _novosti, value); }
        }


        private byte[] _slika;

        public byte[] Slika
        {
            get { return _slika; }
            set { SetProperty(ref _slika, value); }
        }

        public UrediNovostiVM(Novosti novosti)
        {
            this.Novosti = novosti;
        }
     
    }

}
