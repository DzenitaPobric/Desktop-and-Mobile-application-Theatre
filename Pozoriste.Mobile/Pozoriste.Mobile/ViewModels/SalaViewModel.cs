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
    public class SalaViewModel : BaseViewModel
    {
        private APIService _sala = new APIService("Sala");
        public SalaViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Sala> SalaList { get; set; } = new ObservableCollection<Sala>();
       

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
          
           var list = await _sala.Get<IEnumerable<Sala>>(null);
            SalaList.Clear();
                foreach (var sala in list)
                {
                SalaList.Add(sala);
                }
            

        }
    }
}
