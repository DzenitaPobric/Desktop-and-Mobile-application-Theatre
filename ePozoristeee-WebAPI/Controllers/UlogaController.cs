using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ePozoriste.Model;
using ePozoriste.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ePozoriste.WebAPI.Controllers
{

    public class UlogaController : BaseController<Model.Uloga, object>
    {
        public UlogaController(IService<Uloga, object> service) : base(service)
        {
        }
    }
}