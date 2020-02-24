using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model.Requests
{
    public class KomentarSearchRequest
    {
        public int? PredstavaId { get; set; }
        public int? KupacId { get; set; }
        public string Naziv { get; set; }

                
}
}
