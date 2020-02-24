using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ePozoriste.Model.Requests;
using ePozoriste.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ePozoriste.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrikazivanjeMobileController : ControllerBase
    {
        private readonly IPrikazivanjeService _service;

        public PrikazivanjeMobileController(IPrikazivanjeService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Prikazivanje> Get([FromQuery]PrikazivanjeSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpPost]
        public Model.Prikazivanje Insert(PrikazivanjeUpsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public Model.Prikazivanje Update(int id, [FromBody]PrikazivanjeUpsertRequest request)
        {
            return _service.Update(id, request);
        }

        [HttpGet("{id}")]
        public Model.Prikazivanje GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpDelete("{id}")]
        public Model.Prikazivanje Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}