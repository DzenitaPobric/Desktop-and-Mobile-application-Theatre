using AutoMapper;
using ePozoriste.Model.Requests;
using ePozoriste.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public class DokumentService : IDokumentService
    {
        public DokumentService(ePozoristeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private readonly ePozoristeContext _context;
        private readonly IMapper _mapper;

        public List<Model.Dokument> Get(DokumentSearchRequest search)
        {
            var q = _context.Set<Database.Dokument>().AsQueryable();

            if (!string.IsNullOrEmpty(search?.Naziv))
            {
                q = q.Where(x => x.NazivDokumenta.ToLower().StartsWith(search.Naziv) || x.NazivDokumenta.ToUpper().StartsWith(search.Naziv));
            }

            q = q.OrderBy(x => x.NazivDokumenta);
            var list = q.ToList();

            return _mapper.Map<List<Model.Dokument>>(list);


        }

        public Model.Dokument GetById(int id)
        {
            var entity = _context.Dokument.Find(id);

            return _mapper.Map<Model.Dokument>(entity);
        }

        public Model.Dokument Insert(DokumentUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Dokument>(request);
            _context.Dokument.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Dokument>(entity);
        }

        public Model.Dokument Update(int id, DokumentUpsertRequest request)
        {
            var entity = _context.Dokument.Find(id);
            _context.Dokument.Attach(entity);
            _context.Dokument.Update(entity);
            entity.NazivDokumenta = request.NazivDokumenta;
            entity.FileName = request.FileName;
            if(request.Sadrzaj != null && request.Sadrzaj.Length != 0)
                entity.Sadrzaj = request.Sadrzaj;
            _context.SaveChanges();
            return _mapper.Map<Model.Dokument>(entity);
        }


        public Model.Dokument Delete(int id)
        {
            var entity = _context.Dokument.Find(id);

            _context.Dokument.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Dokument>(entity);


        }

    }
}
