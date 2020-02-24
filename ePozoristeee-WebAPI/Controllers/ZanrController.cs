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
    public class ZanrController : BaseCRUDController<Model.Zanr, ZanrSearchRequest, ZanrInsertRequest, ZanrInsertRequest>
    {
        
        public ZanrController(ICRUDService<Model.Zanr, ZanrSearchRequest, ZanrInsertRequest, ZanrInsertRequest> service) : base(service)
        {
        }
    }

}