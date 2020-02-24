using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model
{
    public class Sjediste
    {
        public int SjedisteId { get; set; }
        public int Red { get; set; }
        public int Kolona { get; set; }
        public int SalaId { get; set; }
        public string SalaNaziv { get; set; }
    
        public string SjedistePodaci { get { return SalaNaziv + " / " + Red + " " + Kolona; } }

    }
}
