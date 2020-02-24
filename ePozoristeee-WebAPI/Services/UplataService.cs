
using AutoMapper;
using ePozoriste.Model.Requests;
using ePozoriste.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public class UplataService : BaseCRUDService<Model.Uplata, UplataSearchRequest, Database.Uplata, UplataUpsertRequest, UplataUpsertRequest>
    {
        public UplataService(ePozoristeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Uplata> Get(UplataSearchRequest search)
        {
            var q = _context.Set<Database.Uplata>().AsQueryable();
            if (!string.IsNullOrEmpty(search?.Naziv) && search?.SponzorId.HasValue == true)
            {
                q = q.Where(s => s.Naziv.Equals(search.Naziv) && s.SponzorId == search.SponzorId);
            }
            else
            {
                if (!string.IsNullOrEmpty(search?.Naziv))
                {
                    q = q.Where(x => x.Naziv.ToLower().StartsWith(search.Naziv) || x.Naziv.ToUpper().StartsWith(search.Naziv));
                }
                if (search?.SponzorId.HasValue == true)
                {
                    q = q.Where(s => s.Sponzor.SponzorId == search.SponzorId);
                }
            }
            if (search?.Godina.HasValue == true)
            {
                q = q.Where(s => s.DatumUplate.Year == search.Godina);
                
            }
            q = q.OrderBy(x => x.Naziv);
            var list = q.ToList();
            return _mapper.Map<List<Model.Uplata>>(list);

        }
    }
}
