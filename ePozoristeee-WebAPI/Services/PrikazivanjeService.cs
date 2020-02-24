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
    public class PrikazivanjeService : IPrikazivanjeService
    {

        private readonly ePozoristeContext _context;
        private readonly IMapper _mapper;
        public PrikazivanjeService(ePozoristeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public  List<Model.Prikazivanje> Get(PrikazivanjeSearchRequest search)
        {
            var q = _context.Set<Database.Prikazivanje>().AsQueryable();
            if (!string.IsNullOrEmpty(search?.NazivPredstave) && search?.PredstavaId.HasValue == true)
            {
                q = q.Where(s => s.Predstava.Naziv.Equals(search.NazivPredstave) && s.PredstavaId == search.PredstavaId);
            }
            else
            {
                if (!string.IsNullOrEmpty(search?.NazivPredstave))
                {
                    q = q.Where(x => x.Predstava.Naziv.ToLower().StartsWith(search.NazivPredstave) || x.Predstava.Naziv.ToUpper().StartsWith(search.NazivPredstave));
                }
                if (search?.PredstavaId.HasValue == true)
                {
                    q = q.Where(s => s.Predstava.PredstavaId == search.PredstavaId);
                }
            }

            if (!string.IsNullOrEmpty(search?.NazivSale) && search?.SalaId.HasValue == true)
            {
                q = q.Where(s => s.Sala.Naziv.Equals(search.NazivSale) && s.SalaId == search.SalaId);
            }
            else
            {
                if (!string.IsNullOrEmpty(search?.NazivSale))
                {
                    q = q.Where(x => x.Sala.Naziv.ToLower().StartsWith(search.NazivSale) || x.Sala.Naziv.ToUpper().StartsWith(search.NazivSale));
                }
                if (search?.SalaId.HasValue == true)
                {
                    q = q.Where(s => s.Sala.SalaId == search.SalaId);
                }
            }

    

            if (search?.Godina.HasValue == true)
            {
                q = q.Where(s => s.DatumPrikazivanja.Year == search.Godina);

            }
            if (search?.Mjesec.HasValue == true)
            {
                q = q.Where(s => s.DatumPrikazivanja.Month == search.Mjesec);

            }

            q = q.OrderBy(x => x.Predstava.Naziv);
            var list = q.ToList();
            return _mapper.Map<List<Model.Prikazivanje>>(list);

        }

        public Model.Prikazivanje GetById(int id)
        {
            var entity = _context.Prikazivanje.Find(id);

            return _mapper.Map<Model.Prikazivanje>(entity);
        }

        public Model.Prikazivanje Insert(PrikazivanjeUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Prikazivanje>(request);
            _context.Prikazivanje.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Prikazivanje>(entity);
        }

        public Model.Prikazivanje Update(int id, PrikazivanjeUpsertRequest request)
        {
            var entity = _context.Prikazivanje.Find(id);
            _context.Prikazivanje.Attach(entity);
            _context.Prikazivanje.Update(entity);
            _mapper.Map(request, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Prikazivanje>(entity);
        }


        public Model.Prikazivanje Delete(int id)
        {
            var entity = _context.Prikazivanje.Find(id);

            _context.Prikazivanje.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Prikazivanje>(entity);


        }
    }
}
