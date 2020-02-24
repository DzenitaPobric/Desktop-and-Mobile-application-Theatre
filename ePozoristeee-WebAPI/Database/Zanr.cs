using System;
using System.Collections.Generic;

namespace ePozoriste.WebAPI.Database
{
    public partial class Zanr
    {
        public Zanr()
        {
            Predstava = new HashSet<Predstava>();
        }

        public int ZanrId { get; set; }
        public string Naziv { get; set; }

        public ICollection<Predstava> Predstava { get; set; }
    }
}
