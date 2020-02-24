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

    public class KomentarController : BaseCRUDController<Model.Komentar, KomentarSearchRequest, KomentarUpsertRequest, KomentarUpsertRequest>
    {
        public KomentarController(ICRUDService<Komentar, KomentarSearchRequest, KomentarUpsertRequest, KomentarUpsertRequest> service) : base(service)
        {
        }
    }
}