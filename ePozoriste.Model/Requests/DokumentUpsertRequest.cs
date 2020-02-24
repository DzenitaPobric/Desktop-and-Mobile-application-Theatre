using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model.Requests
{
    public class DokumentUpsertRequest
    {
        public string NazivDokumenta { get; set; }

        public byte[] Sadrzaj { get; set; }
        public string FileName { get; set; }
    }
}
