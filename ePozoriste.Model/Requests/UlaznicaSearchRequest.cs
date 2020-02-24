using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model.Requests
{
    public class UlaznicaSearchRequest
    {
        public int? PrikazivanjeId { get; set; }
        public int? SjedisteId { get; set; }
        public int? KupacId { get; set; }
        public string NazivKupca { get; set; }
        public int? RezervacijaId { get; set; }
    }
}
