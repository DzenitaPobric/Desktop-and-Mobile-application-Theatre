using AutoMapper;
using ePozoriste.Model.Requests;
using ePozoriste.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public class NovostiService : BaseCRUDService<Model.Novosti, NovostiSearchRequest, Database.Novosti, NovostiInsertRequest, NovostiInsertRequest>
    {
        public NovostiService(ePozoristeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Novosti> Get(NovostiSearchRequest search)
        {
            var query = _context.Novosti.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.ToLower().StartsWith(search.Naziv) || x.Naziv.ToUpper().StartsWith(search.Naziv));
            }

            var list = query.ToList();
            return _mapper.Map<List<Model.Novosti>>(list);
        }
    }
}
