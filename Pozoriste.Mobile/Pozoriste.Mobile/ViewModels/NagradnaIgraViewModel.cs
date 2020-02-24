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
    public class NagradnaIgraViewModel
    {
        private readonly APIService _NagradnaIgra = new APIService("NagradnaIgra");
        public NagradnaIgraViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<NagradnaIgra> NagradnaIgraList { get; set; } = new ObservableCollection<NagradnaIgra>();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var list = await _NagradnaIgra.Get<IEnumerable<NagradnaIgra>>(null);
            NagradnaIgraList.Clear();
            foreach (var n in list)
            {
                NagradnaIgraList.Add(n);
            }
        }


    }
}
