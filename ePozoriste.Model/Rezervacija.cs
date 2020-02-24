using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model
{
    public class Rezervacija
    {
        public int RezervacijaId { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public bool Odobrena { get; set; }
        public int BrojRezervacije { get; set; }
        public int KupacId { get; set; }
        public int PrikazivanjeId { get; set; }

        public bool NotOdobren { get => !Odobrena; }

        public string Kupac { get; set; }
        public string Prikazivanje { get; set; }
        public string MailKupca { get; set; }
        public DateTime datumPrikazivanja { get; set; }

    }
}
