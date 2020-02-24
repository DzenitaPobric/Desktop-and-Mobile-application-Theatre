using System;
using System.Collections.Generic;

namespace ePozoriste.WebAPI.Database
{
    public partial class Glumac
    {
        public Glumac()
        {
            GlumacPredstava = new HashSet<GlumacPredstava>();
        }

        public int GlumacId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public long BrojUgovora { get; set; }
        public string Email { get; set; }
        public byte[] Slika { get; set; }

        public ICollection<GlumacPredstava> GlumacPredstava { get; set; }
    }
}
