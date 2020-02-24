using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ePozoriste.Model;
using ePozoriste.Model.Requests;
using ePozoriste.WebAPI.Database;
using ePozoriste.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ePozoriste.WebAPI.Controllers
{
    public class SalaController : BaseCRUDController<Model.Sala, SalaSearchRequest, SalaUpsertRequest, SalaUpsertRequest>
    {
        
        public SalaController(ICRUDService<Model.Sala, SalaSearchRequest, SalaUpsertRequest, SalaUpsertRequest> service) : base(service)
        {
        }
    }
}