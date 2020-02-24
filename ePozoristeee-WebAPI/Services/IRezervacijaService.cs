using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public  interface IRezervacijaService
    {
        List<Model.Rezervacija> Get(RezervacijaSearchRequest request);

        Model.Rezervacija GetById(int id);

        Model.Rezervacija Insert(RezervacijaUpsertRequest request);

        Model.Rezervacija Update(int id, RezervacijaUpsertRequest request);

        Model.Rezervacija Delete(int id);


    }
}
