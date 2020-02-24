using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model
{
    public class NotifikacijaList
    {
        public int NotifikacijaListId { get; set; }
        public string NazivNovosti { get; set; }
        public DateTime DatumVrijemeObjave { get; set; }
        public int NovostiId { get; set; }
    }
}
