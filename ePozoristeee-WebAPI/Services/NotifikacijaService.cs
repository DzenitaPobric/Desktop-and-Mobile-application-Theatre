using AutoMapper;
using ePozoriste.Model.Requests;
using ePozoriste.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public class NotifikacijaService : BaseCRUDService<Model.Notifikacija, object, Database.Notifikacija, NotfikacijaInsertRequest, NotfikacijaInsertRequest>
    {
        public NotifikacijaService(ePozoristeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Notifikacija> Get(object search)
        {
            var query = _context.Notifikacija.Where(x => x.IsProcitano == false).ToList();
           

           
            return _mapper.Map<List<Model.Notifikacija>>(query);

        }
    }
}
