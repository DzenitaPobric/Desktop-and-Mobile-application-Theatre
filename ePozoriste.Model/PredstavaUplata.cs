using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model
{
    public class PredstavaUplata
    {
        public int PredstavaUplataId { get; set; }
        public DateTime DatumUplate { get; set; }
        public int PredstavaId { get; set; }
        public int UplataId { get; set; }

    }
}
