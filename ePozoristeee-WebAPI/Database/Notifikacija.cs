using System;
using System.Collections.Generic;

namespace ePozoriste.WebAPI.Database
{
    public partial class Notifikacija
    {
        public int NotifikacijaId { get; set; }
        public int NovostiId { get; set; }
        public DateTime DatumSlanja { get; set; }
        public bool IsProcitano { get; set; }

        public Novosti Novosti { get; set; }
    }
}
