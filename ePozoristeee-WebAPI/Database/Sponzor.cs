using System;
using System.Collections.Generic;

namespace ePozoriste.WebAPI.Database
{
    public partial class Sponzor
    {
        public Sponzor()
        {
            Uplata = new HashSet<Uplata>();
        }

        public int SponzorId { get; set; }
        public string Naziv { get; set; }
        public string BrojTelefona { get; set; }

        public ICollection<Uplata> Uplata { get; set; }
    }
}
