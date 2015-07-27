using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Albatross.Web.Controllers
{
    public class ToDoController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ToDoPage()
        {
            return View();
        }
    }
}
