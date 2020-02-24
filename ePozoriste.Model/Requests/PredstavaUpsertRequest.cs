using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ePozoriste.Model.Requests
{
    public class PredstavaUpsertRequest
    {

        public string Naziv { get; set; }
      
        public string Opis { get; set; }
      
        public string Reziser { get; set; }
   
        public int Trajanje { get; set; }

        public int ZanrId { get; set; }
    }
}
