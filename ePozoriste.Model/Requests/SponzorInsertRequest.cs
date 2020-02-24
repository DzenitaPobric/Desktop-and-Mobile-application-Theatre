using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ePozoriste.Model.Requests
{
    public class SponzorInsertRequest
    {
        public string Naziv { get; set; }
      
        public string BrojTelefona { get; set; }

    }
}
