using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ePozoriste.Model.Requests
{
    public class SjedisteUpsertRequest
    {
 
        public int Red { get; set; }
     
        public int Kolona { get; set; }
 
        public int SalaId { get; set; }
    }
}
