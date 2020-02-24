using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model
{
    public class Sala
    {
        public int SalaId { get; set; }
        public string Naziv { get; set; }
        public int Kapacitet { get; set; }
        public bool Klimatizacija { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
    }
}
