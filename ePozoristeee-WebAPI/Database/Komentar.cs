using System;
using System.Collections.Generic;

namespace ePozoriste.WebAPI.Database
{
    public partial class Komentar
    {
        public int KomentarId { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime VrijemeKreiranja { get; set; }
        public bool Odobrena { get; set; }
        public int KupacId { get; set; }
        public int PredstavaId { get; set; }

        public Kupac Kupac { get; set; }
        public Predstava Predstava { get; set; }
    }
}
