using System;
using System.Collections.Generic;

namespace ePozoriste.WebAPI.Database
{
    public partial class NagradnaIgra
    {
        public NagradnaIgra()
        {
            KupacNagradnaIgra = new HashSet<KupacNagradnaIgra>();
        }

        public int NagradnaIgraId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
        public int KorisnikId { get; set; }

        public Korisnik Korisnik { get; set; }
        public ICollection<KupacNagradnaIgra> KupacNagradnaIgra { get; set; }
    }
}
