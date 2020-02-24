using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ePozoriste.Model.Requests
{
    public class NovostiInsertRequest
    {
       
        public string Naziv { get; set; }
  
        public string Tekst { get; set; }
    
        public DateTime DatumVrijemeObjave { get; set; }
       
     
        public byte[] Slika { get; set; }
    
        public int KorisnikId { get; set; }
    }
}
