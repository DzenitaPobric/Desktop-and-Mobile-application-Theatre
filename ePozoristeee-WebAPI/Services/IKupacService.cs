using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public interface IKupacService
    {
        List<Model.Kupac> Get(KupacSearchRequest request);

        Model.Kupac GetById(int id);

        Model.Kupac Insert(KupacUpsertRequest request);

        Model.Kupac Update(int id, KupacUpsertRequest request);

        Model.Kupac AuthenticirajKupca(string username, string pass);

    }
}
