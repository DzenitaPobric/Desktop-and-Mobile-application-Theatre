using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model.Requests
{
    public class PrikazivanjeSearchRequest
    {

        public int? PredstavaId { get; set; }
        public int? SalaId { get; set; }
        public string NazivPredstave { get; set; }
        public string NazivSale { get; set; }
        public int? Godina { get; set; }
        public int? Mjesec { get; set; }

    }
}
