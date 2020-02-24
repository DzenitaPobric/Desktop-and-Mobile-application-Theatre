using System;
using System.Collections.Generic;

namespace ePozoriste.WebAPI.Database
{
    public partial class KupacNagradnaIgra
    {
        public int KupacNagradnaIgraId { get; set; }
        public int NagradnaIgraId { get; set; }
        public int KupacId { get; set; }

        public Kupac Kupac { get; set; }
        public NagradnaIgra NagradnaIgra { get; set; }
    }
}
