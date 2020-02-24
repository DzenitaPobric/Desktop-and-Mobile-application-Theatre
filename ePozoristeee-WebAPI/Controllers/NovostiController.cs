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

    public class NovostiController : BaseCRUDController<Model.Novosti, NovostiSearchRequest, NovostiInsertRequest, NovostiInsertRequest>
    {
        public NovostiController(ICRUDService<Novosti, NovostiSearchRequest, NovostiInsertRequest, NovostiInsertRequest> service) : base(service)
        {
        }
    }
}