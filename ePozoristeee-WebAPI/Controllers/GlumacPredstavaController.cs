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

    public class GlumacPredstavaController : BaseCRUDController<Model.GlumacPredstava, GlumacPredstavaSearchRequest, GlumacPredstavaInsertRequest, GlumacPredstavaInsertRequest>
    {
        public GlumacPredstavaController(ICRUDService<GlumacPredstava, GlumacPredstavaSearchRequest, GlumacPredstavaInsertRequest, GlumacPredstavaInsertRequest> service) : base(service)
        {
        }
    }
}