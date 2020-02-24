using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model
{
    public class Prikazivanje
    {
        public int PrikazivanjeId { get; set; }
        public DateTime DatumPrikazivanja { get; set; }
        public int SalaId { get; set; }
        public int PredstavaId { get; set; }
     //   public int BrojDostupnihMjesta { get; set; }
        public decimal Cijena { get; set; }
        public string NazivPredstave { get; set; }
        public string NazivSale { get; set; }
    }
}
