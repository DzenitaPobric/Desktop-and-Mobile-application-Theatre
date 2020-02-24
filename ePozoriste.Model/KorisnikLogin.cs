using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model
{
    public class KorisnikLogin
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public bool Status { get; set; }

        public ICollection<KorisnikUloga> KorisnikUloga { get; set; }
    }
}
