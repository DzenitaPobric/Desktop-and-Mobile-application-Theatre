using System;
using System.Collections.Generic;
using System.Text;

namespace Pozoriste.Mobile.Models
{
    public enum MenuItemTypeAdmin
    {
        //Browse,
        //About, 
        Zanr,
        Predstave,
        Prikazivanja,
        Sponzori,
        Uplate,
        Sale,
        Glumci,
        Gradovi,
        Komentari,
        Rezervacije,
        Novosti,
        NagradnaIgra,
        Odjava
    }
    public class HomeMenuItemAdmin
    {
        public MenuItemTypeAdmin Id { get; set; }
        public string Title { get; set; }
    }
}
