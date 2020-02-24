using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model.Requests
{
    public class PRedstavaKupacInsertRequest
    {
        public decimal Ocjena { get; set; }
        public int PredstavaId { get; set; }
        public int KupacId { get; set; }
    }
}
