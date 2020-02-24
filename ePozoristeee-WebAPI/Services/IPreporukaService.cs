using ePozoriste.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public interface IPreporukaService
    {
        List<Predstava> GetPreporuka(int id);
    }
}
