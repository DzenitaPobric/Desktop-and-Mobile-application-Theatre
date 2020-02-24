using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public interface INagradnaIgraService
    {
        List<Model.NagradnaIgra> Get(NagradnaIgraSearchRequest request);

        Model.NagradnaIgra GetById(int id);

        Model.NagradnaIgra Insert(NagradnaIgraInsertRequest request);

        Model.NagradnaIgra Update(int id, NagradnaIgraInsertRequest request);
        Model.NagradnaIgra Delete(int id);

    }
}
