using System;
using System.Collections.Generic;

namespace ePozoriste.WebAPI.Database
{
    public partial class Dokument
    {
        public int DokumentId { get; set; }
        public string NazivDokumenta { get; set; }
        public byte[] Sadrzaj { get; set; }
        public string FileName { get; set; }
    }
}
