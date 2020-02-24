using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model
{
    public class Notifikacija
    {
        public int NotifikacijaId { get; set; }
        public int NovostiId { get; set; }
        public DateTime DatumSlanja { get; set; }
        public bool IsProcitano { get; set; }

    }
}
