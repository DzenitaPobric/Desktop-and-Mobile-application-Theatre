using System;
using System.Collections.Generic;

namespace ePozoriste.WebAPI.Database
{
    public partial class Ulaznica
    {
        public int UlaznicaId { get; set; }
        public int PrikazivanjeId { get; set; }
        public int SjedisteId { get; set; }
        public int KupacId { get; set; }
        public int? RezervacijaId { get; set; }
        public byte[] Qrkod { get; set; }

        public Kupac Kupac { get; set; }
        public Prikazivanje Prikazivanje { get; set; }
        public Rezervacije Rezervacija { get; set; }
        public Sjediste Sjediste { get; set; }
    }
}
