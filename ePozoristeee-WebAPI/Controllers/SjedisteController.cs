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
    public class SjedisteController : BaseCRUDController<Model.Sjediste, SjedisteSearchRequest, SjedisteUpsertRequest, SjedisteUpsertRequest>
    {
        public SjedisteController(ICRUDService<Sjediste, SjedisteSearchRequest, SjedisteUpsertRequest, SjedisteUpsertRequest> service) : base(service)
        {
        }
    }
}