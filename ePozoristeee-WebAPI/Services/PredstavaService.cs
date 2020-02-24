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
    public class PredstavaService : IPredstavaService
        {

        private readonly ePozoristeContext _context;
        private readonly IMapper _mapper;
        public PredstavaService(ePozoristeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public  List<Model.Predstava> Get(PredstavaSearchRequest search)
        {
            var q = _context.Set<Database.Predstava>().AsQueryable();
            if (!string.IsNullOrEmpty(search?.Naziv) && search?.ZanrId.HasValue == true)
            {
                q = q.Where(s => s.Naziv.Equals(search.Naziv) && s.ZanrId == search.ZanrId);
            }
            else
            {
                if (!string.IsNullOrEmpty(search?.Naziv))
                {
                    q = q.Where(x => x.Naziv.ToLower().StartsWith(search.Naziv) || x.Naziv.ToUpper().StartsWith(search.Naziv));
                }
                if (search?.ZanrId.HasValue == true)
                {
                    q = q.Where(s => s.Zanr.ZanrId == search.ZanrId);
                }
                if(search.TrajanjeOd.HasValue)
                {
                    q = q.Where(s => s.Trajanje >= search.TrajanjeOd.Value);
                }
                if (search.TrajanjeDo.HasValue)
                {
                    q = q.Where(s => s.Trajanje <= search.TrajanjeDo.Value);
                }

                if (search.Sort == 0)
                {
                    q = q.OrderBy(x=>x.Naziv);
                }
                else if (search.Sort == 1)
                {
                    q = q.OrderByDescending(x => x.PredstavaKupac.Average(a => (double?)a.Ocjena ?? 0.0));
                }
            }
            var list = q.ToList();
            
            var list2 = _mapper.Map<List<Model.Predstava>>(list);

            foreach (var predstava in list2)
            {
                predstava.ProsjecnaOcjena = _context.PredstavaKupac
                    .Where(x => x.PredstavaId == predstava.PredstavaId)
                    .Average(x => (decimal?)x.Ocjena) ?? new decimal(0);
            }

            return list2;
        }

        public Model.Predstava GetById(int id)
        {
            var entity = _context.Predstava.Find(id);

            return _mapper.Map<Model.Predstava>(entity);
        }

        public Model.Predstava Insert(PredstavaUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Predstava>(request);
            _context.Predstava.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Predstava>(entity);
        }

        public Model.Predstava Update(int id, PredstavaUpsertRequest request)
        {
            var entity = _context.Predstava.Find(id);
            _context.Predstava.Attach(entity);
            _context.Predstava.Update(entity);
            _mapper.Map(request, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Predstava>(entity);
        }

        public Model.Predstava Delete(int id)
        {
            var entity = _context.Predstava.Find(id);

            _context.Predstava.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Predstava>(entity);


        }
    }
}
