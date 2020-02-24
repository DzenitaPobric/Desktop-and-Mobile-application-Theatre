using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model.Requests
{
    public class UlaznicaUpsertRequest
    {
        public int PrikazivanjeId { get; set; }
        public int SjedisteId { get; set; }
        public int KupacId { get; set; }
        public int? RezervacijaId { get; set; }
        public byte[] Qrkod { get; set; }
    }
}
