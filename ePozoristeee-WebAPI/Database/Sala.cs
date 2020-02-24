using System;
using System.Collections.Generic;

namespace ePozoriste.WebAPI.Database
{
    public partial class Sala
    {
        public Sala()
        {
            Prikazivanje = new HashSet<Prikazivanje>();
            Sjediste = new HashSet<Sjediste>();
        }

        public int SalaId { get; set; }
        public string Naziv { get; set; }
        public int Kapacitet { get; set; }
        public bool Klimatizacija { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }

        public ICollection<Prikazivanje> Prikazivanje { get; set; }
        public ICollection<Sjediste> Sjediste { get; set; }
    }
}
