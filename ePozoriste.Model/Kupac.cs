using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model
{
    public class Kupac
    {
        public int KupacId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KupacPodaci { get { return Ime + " " + Prezime; } }

        public DateTime DatumRegistracije { get; set; }
        public string Email { get; set; }
        public string KorisnickoIme { get; set; }
        public string BrojTelefona { get; set; }
        public int BrojTokena { get; set; }

    }
}
