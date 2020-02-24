using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ePozoriste.Model;
using ePozoriste.Model.Requests;
using ePozoriste.WebAPI.Database;
using ePozoriste.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ePozoriste.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DokumentController : ControllerBase
    {
        private readonly IDokumentService _service;

        public DokumentController(IDokumentService service)
        {
            this._service = service;
        }


        [HttpGet("PreuzmiDokument/{id}")]
        [AllowAnonymous]
        public IActionResult PreuzmiDokument(int id)
        {
            Model.Dokument dokument = _service.GetById(id);

            if (dokument == null)
                return NotFound();

            Stream stream = new MemoryStream(dokument.Sadrzaj);
            return File(stream, "application/octet-stream", dokument.FileName);
        }

        [HttpGet]

        public List<Model.Dokument> Get([FromQuery]DokumentSearchRequest request)
        {
            return _service.Get(request);
        }


        [HttpPost]
        public Model.Dokument Insert(DokumentUpsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public Model.Dokument Update(int id, [FromBody]DokumentUpsertRequest request)
        {
            return _service.Update(id, request);
        }

        [HttpGet("{id}")]
        public Model.Dokument GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}