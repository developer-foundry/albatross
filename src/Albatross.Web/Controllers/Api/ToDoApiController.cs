using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albatross.Configuration;
using Albatross.Controllers.Interfaces;
using Albatross.Repositories;
using Albatross.Services;
using Albatross.Services.Interfaces;
using Albatross.Web.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;

namespace Albatross.Web.Controllers.Api
{
    [Route("api/todo")]
    public class ToDoApiController : Controller, IAlbatrossController
    {
        private readonly IAlbatrossService<ToDo> _toDoService;

        public ToDoApiController(IAlbatrossService<ToDo> toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Task.Run(() => new JsonResult(_toDoService.Get()));
        }
    }
}
