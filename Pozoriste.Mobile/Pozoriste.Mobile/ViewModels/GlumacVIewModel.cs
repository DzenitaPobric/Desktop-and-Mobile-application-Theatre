using ePozoriste.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pozoriste.Mobile.ViewModels
{
    public class GlumacVIewModel
    {
        private readonly APIService _glumci = new APIService("glumac");
      
        public GlumacVIewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Glumac> GlumacList { get; set; } = new ObservableCollection<Glumac>();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var list = await _glumci.Get<IEnumerable<Glumac>>(null);
            GlumacList.Clear();
            foreach (var glumac in list)
            {
                GlumacList.Add(glumac);
            }
        }
    }
}
