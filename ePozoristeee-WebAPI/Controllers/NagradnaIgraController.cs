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
    public class NagradnaIgraController : ControllerBase
    {
        private readonly INagradnaIgraService _service;

        public NagradnaIgraController(INagradnaIgraService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.NagradnaIgra> Get([FromQuery]NagradnaIgraSearchRequest request)
        {
            return _service.Get(request);
        }

        [Authorize(Roles = "Zaposlenik")]
        [HttpPost]
        public Model.NagradnaIgra Insert(NagradnaIgraInsertRequest request)
        {
            return _service.Insert(request);
        }

        [Authorize(Roles = "Zaposlenik")]
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
    }
}