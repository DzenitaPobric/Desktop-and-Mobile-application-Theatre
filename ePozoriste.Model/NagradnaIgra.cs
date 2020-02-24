using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model
{
    public class NagradnaIgra
    {
        public int NagradnaIgraId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
        public int KorisnikId { get; set; }
    }
}
