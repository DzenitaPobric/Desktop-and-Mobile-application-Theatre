using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model.Requests
{
    public class NotfikacijaInsertRequest
    {
       
        public int NovostiId { get; set; }
        public int NotifikacijaId { get; set; }
        public DateTime DatumSlanja { get; set; }
        public bool IsProcitano { get; set; }

    }
}
