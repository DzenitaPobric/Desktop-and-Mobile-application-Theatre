using AutoMapper;
using ePozoriste.Model.Requests;
using ePozoriste.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public class PredstavaUplataServicw : BaseCRUDService<Model.PredstavaUplata, PredstavaUplataSearchRequest, Database.PredstavaUplata, PredstavaUplataInsertRequest, PredstavaUplataInsertRequest>
    {
        public PredstavaUplataServicw(ePozoristeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.PredstavaUplata> Get(PredstavaUplataSearchRequest search)
        {
            var q = _context.Set<Database.PredstavaUplata>().AsQueryable();

            if (search?.PredstavaId.HasValue == true)
            {
                q = q.Where(s => s.Predstava.PredstavaId == search.PredstavaId);
            }
            if (search?.UplataId.HasValue == true)
            {
                q = q.Where(s => s.Uplata.UplataId == search.UplataId);
            }

            var list = q.ToList();
            return _mapper.Map<List<Model.PredstavaUplata>>(list);
        }
    }
}