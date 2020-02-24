using System;
using System.Collections.Generic;

namespace ePozoriste.WebAPI.Database
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            KorisnikUloga = new HashSet<KorisnikUloga>();
            NagradnaIgra = new HashSet<NagradnaIgra>();
            Novosti = new HashSet<Novosti>();
        }

        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }

        public ICollection<KorisnikUloga> KorisnikUloga { get; set; }
        public ICollection<NagradnaIgra> NagradnaIgra { get; set; }
        public ICollection<Novosti> Novosti { get; set; }
    }
}
