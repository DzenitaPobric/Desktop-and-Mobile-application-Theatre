using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.Model
{
    public class Dokument
    {
        public int DokumentId { get; set; }
        public string NazivDokumenta { get; set; }

        public byte[] Sadrzaj { get; set; }
        public string FileName { get; set; }
    }
}
