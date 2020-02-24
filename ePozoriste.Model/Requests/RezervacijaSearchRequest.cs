using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model.Requests
{
    public class RezervacijaSearchRequest
    {
        public int? PrikazivanjeId { get; set; }
        public int? KupacId{ get; set; }
        public string Ime{ get; set; }
        public DateTime? DatumOd { get; set; }
        public DateTime? DatumDo { get; set; }




    }
}
