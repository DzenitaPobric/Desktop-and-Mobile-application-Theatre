using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model
{
    public class PredstavaKupac
    {
        public int PredstavaKupacId { get; set; }
        public decimal Ocjena { get; set; }
        public int PredstavaId { get; set; }
        public int KupacId { get; set; }
        public string nazivKupca { get; set; }
        public string NazivPredstave { get; set; }
    }
}
