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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NagradnaIgraMobileController : ControllerBase
    {
        private readonly INagradnaIgraService _service;

        public NagradnaIgraMobileController(INagradnaIgraService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.NagradnaIgra> Get([FromQuery]NagradnaIgraSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpPost]
        public Model.NagradnaIgra Insert(NagradnaIgraInsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public Model.NagradnaIgra Update(int id, [FromBody]NagradnaIgraInsertRequest request)
        {
            return _service.Update(id, request);
        }

        [HttpGet("{id}")]
        public Model.NagradnaIgra GetById(int id)
        {
            return _service.GetById(id);
        }


        [HttpDelete("{id}")]
        public Model.NagradnaIgra Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}