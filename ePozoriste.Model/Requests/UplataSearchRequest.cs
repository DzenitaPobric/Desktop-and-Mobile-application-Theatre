using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model.Requests
{
    public class UplataSearchRequest
    {
        public int? SponzorId { get; set; }
        public string Naziv { get; set; }
        public int? Godina { get; set; }

    }
}
