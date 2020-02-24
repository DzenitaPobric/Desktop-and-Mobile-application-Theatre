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
    public class NagradnaIgraService : INagradnaIgraService
    {

        private readonly ePozoristeContext _context;
        private readonly IMapper _mapper;
        public NagradnaIgraService(ePozoristeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public  List<Model.NagradnaIgra> Get(NagradnaIgraSearchRequest search)
        {
            var query = _context.NagradnaIgra.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.ToLower().StartsWith(search.Naziv) || x.Naziv.ToUpper().StartsWith(search.Naziv));
            }

            var list = query.ToList();
            return _mapper.Map<List<Model.NagradnaIgra>>(list);
        }

        public Model.NagradnaIgra GetById(int id)
        {
            var entity = _context.NagradnaIgra.Find(id);

            return _mapper.Map<Model.NagradnaIgra>(entity);
        }

        public Model.NagradnaIgra Insert(NagradnaIgraInsertRequest request)
        {
            var entity = _mapper.Map<Database.NagradnaIgra>(request);
            _context.NagradnaIgra.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.NagradnaIgra>(entity);
        }

        public Model.NagradnaIgra Update(int id, NagradnaIgraInsertRequest request)
        {
            var entity = _context.NagradnaIgra.Find(id);
            _context.NagradnaIgra.Attach(entity);
            _context.NagradnaIgra.Update(entity);
            _mapper.Map(request, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.NagradnaIgra>(entity);
        }

        public Model.NagradnaIgra Delete(int id)
        {
            var entity = _context.NagradnaIgra.Find(id);

            _context.NagradnaIgra.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.NagradnaIgra>(entity);


        }

    }
}