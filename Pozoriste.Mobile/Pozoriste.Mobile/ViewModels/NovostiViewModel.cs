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
    public class NovostiViewModel
    {
        private readonly APIService _novosti = new APIService("novosti");
        public NovostiViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Novosti> NovostiList { get; set; } = new ObservableCollection<Novosti>();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var list = await _novosti.Get<IEnumerable<Novosti>>(null);
            NovostiList.Clear();
            foreach(var novost in list)
            {
                NovostiList.Add(novost);
            }
        }


    }
}
