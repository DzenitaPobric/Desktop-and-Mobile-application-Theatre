using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public  interface IKorisnikService
    {
        List<Model.Korisnik> Get(KorisnikSearchRequest request);

        Model.Korisnik GetById(int id);

        Model.Korisnik Insert(KorisnikInsertRequest request);

        Model.Korisnik Update(int id, KorisnikInsertRequest request);

        Model.Korisnik Authenticiraj(string username, string pass);
    }
}

