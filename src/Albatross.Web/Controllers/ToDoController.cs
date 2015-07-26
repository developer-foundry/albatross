using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albatross.Repositories;
using Albatross.Web.Models;
using Microsoft.AspNet.Mvc;

namespace Albatross.Web.Controllers
{
    [Route("api/todo")]
    public class ToDoController : Controller
    {
        private readonly IAlbatrossRepository<ToDo> _repository;

        public ToDoController()
        {
            _repository = new ReThinkDbRepository<ToDo>("albatross");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_repository.Get());
        }
    }
}
