using System;
using System.Collections.Generic;

namespace ePozoriste.WebAPI.Database
{
    public partial class Kupac
    {
        public Kupac()
        {
            Komentar = new HashSet<Komentar>();
            KupacNagradnaIgra = new HashSet<KupacNagradnaIgra>();
            PredstavaKupac = new HashSet<PredstavaKupac>();
            Rezervacije = new HashSet<Rezervacije>();
            Ulaznica = new HashSet<Ulaznica>();
        }

        public int KupacId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public string Email { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public string BrojTelefona { get; set; }
        public int BrojTokena { get; set; }

        public ICollection<Komentar> Komentar { get; set; }
        public ICollection<KupacNagradnaIgra> KupacNagradnaIgra { get; set; }
        public ICollection<PredstavaKupac> PredstavaKupac { get; set; }
        public ICollection<Rezervacije> Rezervacije { get; set; }
        public ICollection<Ulaznica> Ulaznica { get; set; }
    }
}
