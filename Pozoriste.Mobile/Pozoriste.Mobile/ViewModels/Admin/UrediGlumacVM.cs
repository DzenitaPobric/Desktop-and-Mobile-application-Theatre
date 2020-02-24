using ePozoriste.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pozoriste.Mobile.ViewModels.Admin
{
    public class UrediGlumacVM: BaseViewModel
	{
		private Glumac _glumac;
		public Glumac Glumac
		{
			get { return _glumac; }
			set { SetProperty(ref _glumac, value); }
		}


		private byte[] _slika;

		public byte[] Slika
		{
			get { return _slika; }
			set { SetProperty(ref _slika, value); }
		}


		public UrediGlumacVM(Glumac glumac)
		{
			this.Glumac = glumac;
		}

		

    }
}
