using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model
{
    public class Ulaznica
    {
        public int UlaznicaId { get; set; }
        public int PrikazivanjeId { get; set; }
        public int SjedisteId { get; set; }
        public int KupacId { get; set; }   
        public int? RezervacijaId { get; set; }
        public byte[] Qrkod { get; set; }
        public string Color { get; set; }
        public string prikazivanje { get; set; }
        public string kupac { get; set; }
        public string oznakaSjedista { get; set; }


    }
}
