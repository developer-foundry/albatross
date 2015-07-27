using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albatross.Hubs.Interfaces;
using Microsoft.AspNet.SignalR;

namespace Albatross.Hubs
{
    public class AlbatrossHub<T> : Hub, IAlbatrossHub<T> where T : class
    {
        public void Created(T created)
        {
            Clients.All.Created(created);
        }

        public void Deleted(T deleted)
        {
            throw new NotImplementedException();
        }

        public void Updated(T updated)
        {
            throw new NotImplementedException();
        }
    }
}
