using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public interface IPrikazivanjeService
    {
        List<Model.Prikazivanje> Get(PrikazivanjeSearchRequest request);

        Model.Prikazivanje GetById(int id);

        Model.Prikazivanje Insert(PrikazivanjeUpsertRequest request);

        Model.Prikazivanje Update(int id, PrikazivanjeUpsertRequest request);
        Model.Prikazivanje Delete(int id);

    }

}
