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
    public class KupacController : ControllerBase
    {
        private readonly IKupacService _service;

        public KupacController(IKupacService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Kupac> Get([FromQuery]KupacSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpPost]
        public Model.Kupac Insert(KupacUpsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public Model.Kupac Update(int id, [FromBody]KupacUpsertRequest request)
        {
            return _service.Update(id, request);
        }

        [HttpGet("{id}")]
        public Model.Kupac GetById(int id)
        {
            return _service.GetById(id);
        }
    }

}
