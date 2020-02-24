using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public interface ILoginService
    {
        Model.KorisnikLogin Authenticiraj(string username, string pass);
        Model.KorisnikLogin AuthenticirajKupca(string username, string pass);


    }
}
