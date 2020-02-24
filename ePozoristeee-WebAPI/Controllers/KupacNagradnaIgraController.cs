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

    public class KupacNagradnaIgraController : BaseCRUDController<Model.KupacNagradnaIgra, KupacNagradnaIgraSearchRequest, KupacNagradnaIgraInsertRequest, KupacNagradnaIgraInsertRequest>
    {
        public KupacNagradnaIgraController(ICRUDService<KupacNagradnaIgra, KupacNagradnaIgraSearchRequest, KupacNagradnaIgraInsertRequest, KupacNagradnaIgraInsertRequest> service) : base(service)
        {
        }
    }
}