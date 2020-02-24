using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model
{
    public class Predstava
    {
        public int PredstavaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Reziser { get; set; }
        public int Trajanje { get; set; }
        public int ZanrId { get; set; }
        public string NazivZanra { get; set; }
        public decimal ProsjecnaOcjena { get; set; }



    }
}
