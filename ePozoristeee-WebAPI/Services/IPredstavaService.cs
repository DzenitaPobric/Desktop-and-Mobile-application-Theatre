using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public interface IPredstavaService
    {
        List<Model.Predstava> Get(PredstavaSearchRequest request);

        Model.Predstava GetById(int id);

        Model.Predstava Insert(PredstavaUpsertRequest request);

        Model.Predstava Update(int id, PredstavaUpsertRequest request);

        Model.Predstava Delete(int id);

    }
}
