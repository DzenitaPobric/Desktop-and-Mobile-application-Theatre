using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ePozoriste.Model;
using ePozoriste.Model.Requests;
using ePozoriste.WebAPI.Database;
using ePozoriste.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ePozoriste.WebAPI.Controllers
{

    public class GradController : BaseCRUDController<Model.Grad, GradSearchRequest, GradInsertRequest, GradInsertRequest>
    {
        public GradController(ICRUDService<Model.Grad, GradSearchRequest, GradInsertRequest, GradInsertRequest> service) : base(service)
        {
        }
    }
}
