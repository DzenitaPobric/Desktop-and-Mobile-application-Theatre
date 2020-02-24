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

    public class PredstavaUplataController : BaseCRUDController<Model.PredstavaUplata, PredstavaUplataSearchRequest, PredstavaUplataInsertRequest, PredstavaUplataInsertRequest>
    {
        public PredstavaUplataController(ICRUDService<PredstavaUplata, PredstavaUplataSearchRequest, PredstavaUplataInsertRequest, PredstavaUplataInsertRequest> service) : base(service)
        {
        }
    }
}