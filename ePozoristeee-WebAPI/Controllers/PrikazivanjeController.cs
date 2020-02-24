using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ePozoriste.Model;
using ePozoriste.Model.Requests;
using ePozoriste.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ePozoriste.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PrikazivanjeController : ControllerBase
    {
        private readonly IPrikazivanjeService _service;

        public PrikazivanjeController(IPrikazivanjeService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Prikazivanje> Get([FromQuery]PrikazivanjeSearchRequest request)
        {
            return _service.Get(request);
        }

        [Authorize(Roles = "Zaposlenik")]
        [HttpPost]
        public Model.Prikazivanje Insert(PrikazivanjeUpsertRequest request)
        {
            return _service.Insert(request);
        }

        [Authorize(Roles = "Zaposlenik")]
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

    }
}