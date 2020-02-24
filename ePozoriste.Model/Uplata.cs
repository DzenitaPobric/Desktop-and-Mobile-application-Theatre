using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model
{
    public class Uplata
    {
        public int UplataId { get; set; }
        public string Naziv { get; set; }
        public string Svrha { get; set; }
        public double Iznos { get; set; }
        public int SponzorId { get; set; }
        public DateTime DatumUplate { get; set; }
        public string sponzor { get; set; }

    }
}
