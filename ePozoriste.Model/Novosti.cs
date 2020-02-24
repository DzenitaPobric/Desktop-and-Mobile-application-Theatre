using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model
{
    public class Novosti
    {
        public int NovostiId { get; set; }
        public string Naziv { get; set; }
        public string Tekst { get; set; }
        public DateTime DatumVrijemeObjave { get; set; }
        public byte[] Slika { get; set; }
        public int KorisnikId { get; set; }
    }
}
