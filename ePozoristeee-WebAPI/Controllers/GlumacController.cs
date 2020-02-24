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
    public class GlumacController : BaseCRUDController<Model.Glumac, GlumacSearcRequest, GlumacUpsertRequest, GlumacUpsertRequest>
    {
        
        public GlumacController(ICRUDService<Model.Glumac, GlumacSearcRequest, GlumacUpsertRequest, GlumacUpsertRequest> service) : base(service)
        {
        }
    }
}