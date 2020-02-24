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
    public class DokumentiViewModel : BaseViewModel
    {
        private readonly APIService _predstaveService = new APIService("Dokument");
        public DokumentiViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Dokument> DokumentiList { get; set; } = new ObservableCollection<Dokument>();

        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            var list = await _predstaveService.Get<IEnumerable<Dokument>>(null);
            DokumentiList.Clear();
            foreach (var Dokumenti in list)
            {
                DokumentiList.Add(Dokumenti);
            }
        }
    }
}
