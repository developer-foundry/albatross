using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Albatross.Controllers.Interfaces
{
    public interface IAlbatrossController
    {
        Task<IActionResult> Get();
    }
}
