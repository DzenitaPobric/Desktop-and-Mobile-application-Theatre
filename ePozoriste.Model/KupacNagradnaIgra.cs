using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model
{
    public class KupacNagradnaIgra
    {
        public int KupacNagradnaIgraId { get; set; }
        public int NagradnaIgraId { get; set; }
        public int KupacId { get; set; }

        public string nagrada { get; set; }
        public string kupac { get; set; }
    }
}
