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
    public class PredstavaMobileController : ControllerBase
    {
        private readonly IPredstavaService _service;

        public PredstavaMobileController(IPredstavaService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Predstava> Get([FromQuery]PredstavaSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpPost]
        public Model.Predstava Insert(PredstavaUpsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public Model.Predstava Update(int id, [FromBody]PredstavaUpsertRequest request)
        {
            return _service.Update(id, request);
        }

        [HttpGet("{id}")]
        public Model.Predstava GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpDelete("{id}")]
        public Model.Predstava Delete(int id)
        {
            return _service.Delete(id);
        }

    }
}