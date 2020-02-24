using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ePozoriste.Model.Requests
{
    public class PrikazivanjeUpsertRequest
    {
        public DateTime DatumPrikazivanja { get; set; }
        public int SalaId { get; set; }
        public int PredstavaId { get; set; }
    //    public int BrojDostupnihMjesta { get; set; }
        public decimal Cijena { get; set; }

    }
}
