using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Albatross.Example.Domain;
using Albatross.Example.Services.Interfaces;

namespace Albatross.Example.API.Controllers
{
    public class ToDoController : ApiController
    {
        private readonly IToDoService _service;

        public ToDoController(IToDoService service)
        {
            _service = service;
        }

        public IEnumerable<ToDo> Get()
        {
            return _service.Get();
        }
    }
}
