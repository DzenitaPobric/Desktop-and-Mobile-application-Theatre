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
    public class UrediPredstavaVM
    {
        public Predstava Predstava { get; set; }
        private APIService _apiServiceZanr= new APIService("Zanr");
        public ObservableCollection<Zanr> ZanrList { get; set; } = new ObservableCollection<Zanr>();

        public ICommand InitCommand { get; set; }

        public UrediPredstavaVM()
        {
            InitCommand = new Command(async () => await Init());
        }
        public async Task Init()
        {
            var list = await _apiServiceZanr.Get<List<Zanr>>(null);
            ZanrList.Clear();
            foreach (var g in list)
            {
                ZanrList.Add(g);
            }
        }

    }
}
