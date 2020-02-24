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
    public class SponzorController : BaseCRUDController<Model.Sponzor, SponzorSearchRequest, SponzorInsertRequest, SponzorInsertRequest>
    {
        public SponzorController(ICRUDService<Model.Sponzor, SponzorSearchRequest, SponzorInsertRequest, SponzorInsertRequest> service) : base(service)
        {
        }
    }
}