using AutoMapper;
using ePozoriste.Model.Requests;
using ePozoriste.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public class SalaService : BaseCRUDService<Model.Sala, SalaSearchRequest, Database.Sala, SalaUpsertRequest, SalaUpsertRequest>
    {
        public SalaService(ePozoristeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Sala> Get(SalaSearchRequest search)
        {
            var query = _context.Sala.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.ToLower().StartsWith(search.Naziv) || x.Naziv.ToUpper().StartsWith(search.Naziv));
            }

            var list = query.ToList();
            return _mapper.Map<List<Model.Sala>>(list);
        }

    }
}
