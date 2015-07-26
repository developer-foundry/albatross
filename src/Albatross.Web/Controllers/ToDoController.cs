using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albatross.Configuration;
using Albatross.Repositories;
using Albatross.Services;
using Albatross.Web.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;

namespace Albatross.Web.Controllers
{
    [Route("api/todo")]
    public class ToDoController : Controller
    {
        private readonly IAlbatrossService<ToDo> _toDoService;

        public ToDoController(IAlbatrossService<ToDo> toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_toDoService.Get());
        }
    }
}
