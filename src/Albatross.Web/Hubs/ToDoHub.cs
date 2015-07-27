using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albatross.Hubs.Interfaces;
using Albatross.Web.Models;
using Microsoft.AspNet.SignalR;

namespace Albatross.Web.Hubs
{
    public class ToDoHub : Hub, IAlbatrossHub<ToDo>
    {
        public void Created(ToDo created)
        {
            Clients.All.Created(created);
        }

        public void Deleted(ToDo deleted)
        {
            throw new NotImplementedException();
        }

        public void Updated(ToDo updated)
        {
            throw new NotImplementedException();
        }
    }
}
