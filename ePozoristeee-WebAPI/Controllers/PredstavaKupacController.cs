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

    public class PredstavaKupacController : BaseCRUDController<Model.PredstavaKupac, PredstavaKupacSearchRequest, PRedstavaKupacInsertRequest, PRedstavaKupacInsertRequest>
    {
        public PredstavaKupacController(ICRUDService<PredstavaKupac, PredstavaKupacSearchRequest, PRedstavaKupacInsertRequest, PRedstavaKupacInsertRequest> service) : base(service)
        {
        }
    }
}