using AutoMapper;
using ePozoriste.Model.Requests;
using ePozoriste.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public class GlumacPredstavaService : BaseCRUDService<Model.GlumacPredstava, GlumacPredstavaSearchRequest, Database.GlumacPredstava, GlumacPredstavaInsertRequest, GlumacPredstavaInsertRequest>
    {
        public GlumacPredstavaService(ePozoristeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.GlumacPredstava> Get(GlumacPredstavaSearchRequest search)
        {
            var q = _context.Set<Database.GlumacPredstava>().AsQueryable();

            if (search?.PredstavaId.HasValue == true)
            {
                q = q.Where(s => s.Predstava.PredstavaId == search.PredstavaId);
            }
            if (search?.GlumacId.HasValue == true)
            {
                q = q.Where(s => s.Glumac.GlumacId == search.GlumacId);
            }

            var list = q.ToList();
            return _mapper.Map<List<Model.GlumacPredstava>>(list);
        }
    }

       
}
