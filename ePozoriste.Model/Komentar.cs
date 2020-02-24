using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model
{
    public class Komentar
    {
        public int KomentarId { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime VrijemeKreiranja { get; set; }
        public bool Odobrena { get; set; }
        public int KupacId { get; set; }
        public int PredstavaId { get; set; }

        public bool NotOdobren { get => !Odobrena; }

        public string NazivPredstave { get; set; }
        public string Kupac { get; set; }

    }
}
