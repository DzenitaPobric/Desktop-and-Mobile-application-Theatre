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

    public class UlaznicaController : BaseCRUDController<Model.Ulaznica, UlaznicaSearchRequest, UlaznicaUpsertRequest, UlaznicaUpsertRequest>
    {
        public UlaznicaController(ICRUDService<Ulaznica, UlaznicaSearchRequest, UlaznicaUpsertRequest, UlaznicaUpsertRequest> service) : base(service)
        {
        }
    }
}