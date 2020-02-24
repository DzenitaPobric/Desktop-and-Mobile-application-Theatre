using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ePozoriste.Model.Requests
{
    public class UplataUpsertRequest
    {
      
        public string Naziv { get; set; }
      
        public string Svrha { get; set; }
        public double Iznos { get; set; }
        public int SponzorId { get; set; }
        public DateTime DatumUplate { get; set; }

    }
}
