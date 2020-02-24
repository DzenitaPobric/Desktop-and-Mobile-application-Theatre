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

    public class NotifikacijaController : BaseCRUDController<Model.Notifikacija, object, NotfikacijaInsertRequest, NotfikacijaInsertRequest>
    {
        public NotifikacijaController(ICRUDService<Notifikacija, object, NotfikacijaInsertRequest, NotfikacijaInsertRequest> service) : base(service)
        {
        }
    }
}