using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Albatross.Example.Domain;
using Albatross.Example.Services.Interfaces;
using Microsoft.AspNet.SignalR;

namespace Albatross.Example.API
{
    public class ToDoHub : Hub
    {
        private readonly IToDoService _toDoService;

        public ToDoHub(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public void Send(ToDo todo)
        {
            Clients.All.sendToDo(todo);
        }
    }
}
