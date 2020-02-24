using System;
using System.Collections.Generic;

namespace ePozoriste.WebAPI.Database
{
    public partial class GlumacPredstava
    {
        public int GlumacPredstavaId { get; set; }
        public int PredstavaId { get; set; }
        public int GlumacId { get; set; }

        public Glumac Glumac { get; set; }
        public Predstava Predstava { get; set; }
    }
}
