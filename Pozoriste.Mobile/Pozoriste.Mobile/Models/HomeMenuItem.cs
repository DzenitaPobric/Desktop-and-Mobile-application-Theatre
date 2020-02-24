using System;
using System.Collections.Generic;
using System.Text;

namespace Pozoriste.Mobile.Models
{
    public enum MenuItemType
    {
        //Browse,
        //About,
        KakoDoNas,
        Novosti,
        Predstave,
        Glumci,
        Prikazivanja,
        MojeRezervacije,
        KorisnickiProfil,
        MojeUlaznice,
        NagradnaIgra,
        Ocjenjivanje,
        Notifikacija,
        Preporuke,
        Galerija,
        Dokumenti,
        Odjava,
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }
        public string Title { get; set; }
    }
}
