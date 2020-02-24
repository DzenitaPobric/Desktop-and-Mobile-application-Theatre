using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ePozoriste.Model;
using ePozoriste.Model.Requests;
using ePozoriste.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ePozoriste.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RezervacijaController : ControllerBase
    {
        private readonly IRezervacijaService _service;

        public RezervacijaController(IRezervacijaService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Rezervacija> Get([FromQuery]RezervacijaSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpPost]
        public Model.Rezervacija Insert(RezervacijaUpsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public Model.Rezervacija Update(int id, [FromBody]RezervacijaUpsertRequest request)
        {
            return _service.Update(id, request);
        }

        [HttpGet("{id}")]
        public Model.Rezervacija GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpDelete("{id}")]
        public Model.Rezervacija Delete(int id)
        {
              return _service.Delete(id);
        }
        
    }
}