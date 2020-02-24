using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public interface IDokumentService
    {
        List<Model.Dokument> Get(DokumentSearchRequest request);

        Model.Dokument GetById(int id);

        Model.Dokument Insert(DokumentUpsertRequest request);

        Model.Dokument Update(int id, DokumentUpsertRequest request);
        Model.Dokument Delete(int id);
    }
}
