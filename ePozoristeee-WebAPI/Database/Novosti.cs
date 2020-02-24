using System;
using System.Collections.Generic;

namespace ePozoriste.WebAPI.Database
{
    public partial class Novosti
    {
        public Novosti()
        {
            Notifikacija = new HashSet<Notifikacija>();
        }

        public int NovostiId { get; set; }
        public string Naziv { get; set; }
        public string Tekst { get; set; }
        public DateTime DatumVrijemeObjave { get; set; }
        public byte[] Slika { get; set; }
        public int KorisnikId { get; set; }

        public Korisnik Korisnik { get; set; }
        public ICollection<Notifikacija> Notifikacija { get; set; }
    }
}
