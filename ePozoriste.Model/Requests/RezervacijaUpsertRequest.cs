using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model.Requests
{
    public class RezervacijaUpsertRequest
    {
        public DateTime DatumRezervacije { get; set; }
        public bool Odobrena { get; set; }
        public int BrojRezervacije { get; set; }
        public int KupacId { get; set; }
        public int PrikazivanjeId { get; set; }
    }
}
