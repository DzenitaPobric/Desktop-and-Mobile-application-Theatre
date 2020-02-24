using System;

using Pozoriste.Mobile.Models;

namespace Pozoriste.Mobile.ViewModels
{
    public class ItemDetailViewModelAdmin : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModelAdmin(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
