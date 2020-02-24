using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ePozoriste.Model.Requests
{
    public class KorisnikInsertRequest
    {
       
        public string Ime { get; set; }
      
        public string Prezime { get; set; }
       
        public string Email { get; set; }
      

        public string Telefon { get; set; }
       
        public string KorisnickoIme { get; set; }
     
        public string Password { get; set; }
 
        public string PasswordPotvrda { get; set; }

        public List<int> Uloge { get; set; } = new List<int>();
    }
}
