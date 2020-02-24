using System;
using System.Collections.Generic;

namespace ePozoriste.WebAPI.Database
{
    public partial class Sjediste
    {
        public Sjediste()
        {
            Ulaznica = new HashSet<Ulaznica>();
        }

        public int SjedisteId { get; set; }
        public int Red { get; set; }
        public int Kolona { get; set; }
        public int SalaId { get; set; }

        public Sala Sala { get; set; }
        public ICollection<Ulaznica> Ulaznica { get; set; }
    }
}
