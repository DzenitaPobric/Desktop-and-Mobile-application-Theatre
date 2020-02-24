using System;
using System.Collections.Generic;

namespace ePozoriste.WebAPI.Database
{
    public partial class Predstava
    {
        public Predstava()
        {
            GlumacPredstava = new HashSet<GlumacPredstava>();
            Komentar = new HashSet<Komentar>();
            PredstavaKupac = new HashSet<PredstavaKupac>();
            PredstavaUplata = new HashSet<PredstavaUplata>();
            Prikazivanje = new HashSet<Prikazivanje>();
        }

        public int PredstavaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Reziser { get; set; }
        public int Trajanje { get; set; }
        public int ZanrId { get; set; }

        public Zanr Zanr { get; set; }
        public ICollection<GlumacPredstava> GlumacPredstava { get; set; }
        public ICollection<Komentar> Komentar { get; set; }
        public ICollection<PredstavaKupac> PredstavaKupac { get; set; }
        public ICollection<PredstavaUplata> PredstavaUplata { get; set; }
        public ICollection<Prikazivanje> Prikazivanje { get; set; }
    }
}
