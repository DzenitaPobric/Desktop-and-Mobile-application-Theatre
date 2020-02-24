using AutoMapper;
using ePozoriste.Model;
using ePozoriste.Model.Requests;
using ePozoriste.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public class ZanrService : BaseCRUDService<Model.Zanr, ZanrSearchRequest, Database.Zanr, ZanrInsertRequest, ZanrInsertRequest>
    {

        public ZanrService(ePozoristeContext context, IMapper mapper) : base(context, mapper)
        {
        }    

        public override List<Model.Zanr> Get(ZanrSearchRequest search)
        {
            var query = _context.Zanr.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.ToLower().StartsWith(search.Naziv) || x.Naziv.ToUpper().StartsWith(search.Naziv));
            }

            var list = query.ToList();
            return _mapper.Map<List<Model.Zanr>>(list);
        }


    }
}
