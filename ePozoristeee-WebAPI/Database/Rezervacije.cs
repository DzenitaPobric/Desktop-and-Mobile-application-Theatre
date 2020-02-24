using System;
using System.Collections.Generic;

namespace ePozoriste.WebAPI.Database
{
    public partial class Rezervacije
    {
        public Rezervacije()
        {
            Ulaznica = new HashSet<Ulaznica>();
        }

        public int RezervacijaId { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public bool Odobrena { get; set; }
        public int BrojRezervacije { get; set; }
        public int KupacId { get; set; }
        public int PrikazivanjeId { get; set; }

        public Kupac Kupac { get; set; }
        public Prikazivanje Prikazivanje { get; set; }
        public ICollection<Ulaznica> Ulaznica { get; set; }
    }
}
