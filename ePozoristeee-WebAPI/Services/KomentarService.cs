using AutoMapper;
using ePozoriste.Model.Requests;
using ePozoriste.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public class KomentarService : BaseCRUDService<Model.Komentar, KomentarSearchRequest, Database.Komentar, KomentarUpsertRequest, KomentarUpsertRequest>
    {
        public KomentarService(ePozoristeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Komentar> Get(KomentarSearchRequest search)
        {
            var q = _context.Set<Database.Komentar>().AsQueryable();
            if (!string.IsNullOrEmpty(search?.Naziv) && search?.PredstavaId.HasValue == true)
            {
                q = q.Where(s => s.Predstava.Naziv.Equals(search.Naziv) && s.PredstavaId == search.PredstavaId);
            }
            else
            {
                if (!string.IsNullOrEmpty(search?.Naziv))
                {
                    q = q.Where(x => x.Predstava.Naziv.ToLower().StartsWith(search.Naziv) || x.Predstava.Naziv.ToUpper().StartsWith(search.Naziv));
                }
                if (search?.PredstavaId.HasValue == true)
                {
                    q = q.Where(s => s.Predstava.PredstavaId == search.PredstavaId);
                }
            }
            if (search?.KupacId.HasValue == true)
            {
                q = q.Where(s => s.Kupac.KupacId == search.KupacId);
            }
         
            q = q.OrderBy(x => x.Predstava.Naziv);
            var list = q.ToList();
            return _mapper.Map<List<Model.Komentar>>(list);
        }
    }
}
