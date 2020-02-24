using AutoMapper;
using ePozoriste.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public class PreporukaService : IPreporukaService
    {
        private readonly ePozoristeContext _context;
        private readonly IMapper _mapper;
        public int BrojPreporuka = 5;
        public PreporukaService(ePozoristeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<Model.Predstava> GetPreporuka(int KupacId)
        {
            List<Ulaznica> MojeUlaznice = _context.Ulaznica.Where(x => x.KupacId == KupacId)
                .Include(x => x.Prikazivanje.Predstava.Zanr)
                .ToList();

            if (MojeUlaznice.Count() > 0)
            {
                List<Zanr> sviZanrovi = new List<Zanr>();
                foreach (var ulaznica in MojeUlaznice)
                {

                    var predstavaZanr = ulaznica.Prikazivanje.Predstava.Zanr;

                    bool add = true;
                    for (int i = 0; i < sviZanrovi.Count; i++)
                    {
                        if (predstavaZanr.ZanrId == sviZanrovi[i].ZanrId)
                        {
                            add = false;
                        }
                    }

                    if (add)
                    {
                        sviZanrovi.Add(predstavaZanr);
                    }
                }

                List<Predstava> ListaPreporucenihPredstava = new List<Predstava>();
                foreach (var Zanr in sviZanrovi)
                {
                    var PredstaveTogZanra = _context.Predstava
                        .Where(n => n.ZanrId == Zanr.ZanrId)
                        .ToList();

                    foreach (var predstava in PredstaveTogZanra)
                    {
                        bool add = true;
                        for (int i = 0; i < ListaPreporucenihPredstava.Count; i++)
                        {
                            if (predstava.PredstavaId == ListaPreporucenihPredstava[i].PredstavaId)
                            {
                                add = false;
                            }
                        }

                        foreach (var ulaznica in MojeUlaznice)
                        {
                            if (predstava.PredstavaId == ulaznica.Prikazivanje.PredstavaId)
                            {
                                add = false;
                            }
                        }

                        if (add)
                        {
                            ListaPreporucenihPredstava.Add(predstava);
                        }
                    }
                }

                ListaPreporucenihPredstava = ListaPreporucenihPredstava.OrderBy(x => Guid.NewGuid()).Take(BrojPreporuka).ToList();

                if (ListaPreporucenihPredstava.Count == 0)
                {
                    ListaPreporucenihPredstava = _context.Predstava.Take(BrojPreporuka).OrderBy(x => Guid.NewGuid()).ToList();
                }

                var list2 = _mapper.Map<List<Model.Predstava>>(ListaPreporucenihPredstava);
                foreach (var predstava in list2)
                {
                    predstava.ProsjecnaOcjena = _context.PredstavaKupac
                        .Where(x => x.PredstavaId == predstava.PredstavaId)
                        .Average(x => (decimal?)x.Ocjena) ?? new decimal(0);
                }

                return list2;

            }

            var ListaSvihPredstava = _context.Predstava.Take(BrojPreporuka).OrderBy(x => Guid.NewGuid()).ToList();
            var list1 = _mapper.Map<List<Model.Predstava>>(ListaSvihPredstava);

            foreach (var predstava in list1)
            {
                predstava.ProsjecnaOcjena = _context.PredstavaKupac
                    .Where(x => x.PredstavaId == predstava.PredstavaId)
                    .Average(x => (decimal?)x.Ocjena) ?? new decimal(0);
            }

            return list1;

        }

    }
}
