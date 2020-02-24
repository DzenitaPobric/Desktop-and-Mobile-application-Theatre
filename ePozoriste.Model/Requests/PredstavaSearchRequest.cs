using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model.Requests
{
    public class PredstavaSearchRequest
    {
        public int? ZanrId { get; set; }
        public string Naziv { get; set; }
        public int? TrajanjeOd { get; set; }
        public int? TrajanjeDo { get; set; }
        public int Sort { get; set; }
    }
}

