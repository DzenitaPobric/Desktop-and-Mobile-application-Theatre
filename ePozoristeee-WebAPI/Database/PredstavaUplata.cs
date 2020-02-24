using System;
using System.Collections.Generic;

namespace ePozoriste.WebAPI.Database
{
    public partial class PredstavaUplata
    {
        public int PredstavaUplataId { get; set; }
        public DateTime DatumUplate { get; set; }
        public int PredstavaId { get; set; }
        public int UplataId { get; set; }

        public Predstava Predstava { get; set; }
        public Uplata Uplata { get; set; }
    }
}
