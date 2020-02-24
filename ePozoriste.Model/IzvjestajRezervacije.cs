using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model
{
    public class IzvjestajRezervacije
    {
        public string Zanr{ get; set; }
        public string Predstava{ get; set; }
        public int BrojRezervacija { get; set; }
        public decimal Zarada { get; set; }
    }
}
