using System;
using System.Collections.Generic;

namespace ePozoriste.WebAPI.Database
{
    public partial class Uplata
    {
        public Uplata()
        {
            PredstavaUplata = new HashSet<PredstavaUplata>();
        }

        public int UplataId { get; set; }
        public string Naziv { get; set; }
        public string Svrha { get; set; }
        public double Iznos { get; set; }
        public DateTime DatumUplate { get; set; }
        public int SponzorId { get; set; }

        public Sponzor Sponzor { get; set; }
        public ICollection<PredstavaUplata> PredstavaUplata { get; set; }
    }
}
