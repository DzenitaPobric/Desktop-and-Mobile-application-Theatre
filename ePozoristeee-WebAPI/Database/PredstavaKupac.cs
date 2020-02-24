using System;
using System.Collections.Generic;

namespace ePozoriste.WebAPI.Database
{
    public partial class PredstavaKupac
    {
        public int PredstavaKupacId { get; set; }
        public double Ocjena { get; set; }
        public int PredstavaId { get; set; }
        public int KupacId { get; set; }

        public Kupac Kupac { get; set; }
        public Predstava Predstava { get; set; }
    }
}
