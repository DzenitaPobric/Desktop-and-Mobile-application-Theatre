using System;
using System.Collections.Generic;

namespace ePozoriste.WebAPI.Database
{
    public partial class Prikazivanje
    {
        public Prikazivanje()
        {
            Rezervacije = new HashSet<Rezervacije>();
            Ulaznica = new HashSet<Ulaznica>();
        }

        public int PrikazivanjeId { get; set; }
        public DateTime DatumPrikazivanja { get; set; }
        public int SalaId { get; set; }
        public int PredstavaId { get; set; }
        public decimal Cijena { get; set; }

        public Predstava Predstava { get; set; }
        public Sala Sala { get; set; }
        public ICollection<Rezervacije> Rezervacije { get; set; }
        public ICollection<Ulaznica> Ulaznica { get; set; }
    }
}
