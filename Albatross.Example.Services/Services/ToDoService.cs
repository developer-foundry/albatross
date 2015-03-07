using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albatross.Example.Domain;
using Albatross.Example.Services.Interfaces;
using Albatross.Repositories;
using Albatross.Services;

namespace Albatross.Example.Services.Services
{
    public class ToDoService : AbstractService<ToDo>, IToDoService
    {
        public ToDoService(IRepository<ToDo> repository) : base(repository)
        {
        }
    }
}
