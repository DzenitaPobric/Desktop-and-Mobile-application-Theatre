using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model.Requests
{
    public class PredstavaUplataInsertRequest
    {
        public DateTime DatumUplate { get; set; }
        public int PredstavaId { get; set; }
        public int UplataId { get; set; }
    }
}
