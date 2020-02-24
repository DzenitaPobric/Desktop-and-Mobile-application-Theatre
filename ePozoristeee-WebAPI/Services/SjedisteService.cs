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
    public class SjedisteService : BaseCRUDService<Model.Sjediste, SjedisteSearchRequest, Database.Sjediste, SjedisteUpsertRequest, SjedisteUpsertRequest>
    {
        public SjedisteService(ePozoristeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Sjediste> Get(SjedisteSearchRequest search)
        {

            //foreach (var sala in _context.Sala.ToList())
            //{
            //    for (int i = 1; i <= 10; i++)
            //    {
            //        for (int j = 1; j <= 10; j++)
            //        {
            //            _context.Sjediste.Add(new Database.Sjediste
            //            {
            //                Red = i,
            //                Kolona = j,
            //                SalaId = sala.SalaId
            //            });
            //        }
            //    }
            //}
            //_context.SaveChanges();


            var query = _context.Set<Database.Sjediste>().AsQueryable();
            if (search?.SalaId.HasValue == true)
            {
                query = query.Where(x => x.SalaId == search.SalaId);
            }
            query = query.OrderBy(x => x.Kolona).OrderBy(x => x.Red);
            var list = query.ToList();
            return _mapper.Map<List<Model.Sjediste>>(list);
        }
    }
}
