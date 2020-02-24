using AutoMapper;
using ePozoriste.Model.Requests;
using ePozoriste.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public class KupacNagradnaIgraService : BaseCRUDService<Model.KupacNagradnaIgra, KupacNagradnaIgraSearchRequest, Database.KupacNagradnaIgra, KupacNagradnaIgraInsertRequest, KupacNagradnaIgraInsertRequest>
    {
        public KupacNagradnaIgraService(ePozoristeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.KupacNagradnaIgra> Get(KupacNagradnaIgraSearchRequest search)
        {
            var q = _context.Set<Database.KupacNagradnaIgra>().AsQueryable();

            if (search?.NagradnaIgraId.HasValue == true)
            {
                q = q.Where(s => s.NagradnaIgra.NagradnaIgraId == search.NagradnaIgraId);
            }
            if (search?.KupacId.HasValue == true)
            {
                q = q.Where(s => s.Kupac.KupacId == search.KupacId);
            }
            var list = q.ToList();
            return _mapper.Map<List<Model.KupacNagradnaIgra>>(list);
        }
    }
}
