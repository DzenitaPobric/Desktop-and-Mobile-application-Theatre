using AutoMapper;
using ePozoriste.Model.Requests;
using ePozoriste.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public class PredstavaKupacService : BaseCRUDService<Model.PredstavaKupac, PredstavaKupacSearchRequest, Database.PredstavaKupac, PRedstavaKupacInsertRequest, PRedstavaKupacInsertRequest>
    {
        public PredstavaKupacService(ePozoristeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.PredstavaKupac> Get(PredstavaKupacSearchRequest search)
        {
            var q = _context.Set<Database.PredstavaKupac>().AsQueryable();

            if (search?.PredstavaId.HasValue == true)
            {
                q = q.Where(s => s.Predstava.PredstavaId == search.PredstavaId);
            }
            if (search?.KupacId.HasValue == true)
            {
                q = q.Where(s => s.Kupac.KupacId == search.KupacId);
            }
            var list = q.ToList();
            return _mapper.Map<List<Model.PredstavaKupac>>(list);
        }
    }
}
