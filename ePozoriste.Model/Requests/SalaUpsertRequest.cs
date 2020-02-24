using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ePozoriste.Model.Requests
{
    public class SalaUpsertRequest
    {
       
        public string Naziv { get; set; }
        public int Kapacitet { get; set; }
        
        public bool Klimatizacija { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
    }
}
