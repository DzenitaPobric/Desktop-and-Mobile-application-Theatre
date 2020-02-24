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
    public class GradService :BaseCRUDService<Model.Grad, GradSearchRequest, Database.Grad, GradInsertRequest, GradInsertRequest>
    {

        public GradService(ePozoristeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Grad> Get(GradSearchRequest search)
        {
            var query = _context.Grad.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.ToLower().StartsWith(search.Naziv) ||  x.Naziv.ToUpper().StartsWith(search.Naziv));
            }

            var list = query.ToList();
            return _mapper.Map<List<Model.Grad>>(list);
        }

    }
}


