using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model.Requests
{
    public class KomentarUpsertRequest
    {
        public string Sadrzaj { get; set; }
        public DateTime VrijemeKreiranja { get; set; }
        public bool Odobrena { get; set; }
        public int KupacId { get; set; }
        public int PredstavaId { get; set; }
    }
}
