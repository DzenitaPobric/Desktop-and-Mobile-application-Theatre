using AutoMapper;
using ePozoriste.Model.Requests;
using ePozoriste.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public class GlumacService : BaseCRUDService<Model.Glumac, GlumacSearcRequest, Database.Glumac, GlumacUpsertRequest, GlumacUpsertRequest>
    {      
        public GlumacService(ePozoristeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Glumac> Get(GlumacSearcRequest search)
        {
            var query = _context.Glumac.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                query = query.Where(x => x.Ime.ToLower().StartsWith(search.Ime) || x.Ime.ToUpper().StartsWith(search.Ime));

            }
            if (!string.IsNullOrWhiteSpace(search?.Prezime))
            {
                query = query.Where(x => x.Prezime.ToLower().StartsWith(search.Prezime) || x.Prezime.ToUpper().StartsWith(search.Prezime));

            }

            var list = query.ToList();
            return _mapper.Map<List<Model.Glumac>>(list);
        }

    }
}
