using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Albatross.Hubs.Interfaces;
using Albatross.Repositories.Interfaces;
using Albatross.Web.Models;
using Microsoft.AspNet.SignalR;

namespace Albatross.Web.Hubs
{
    public class ToDoHub : Hub<IAlbatrossHubClient<ToDo>>, IAlbatrossHub<ToDo>
    {
        private readonly IAlbatrossObservableRepository<ToDo> _repository;

        public ToDoHub(IAlbatrossObservableRepository<ToDo> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ToDo>> Get()
        {
            return await Task.Run(() => _repository.Get().ToEnumerable());
        } 

        public void Create(ToDo item)
        {
            //create entry in db

            //Clients.All.Created(item);
        }

        public void Delete(ToDo item)
        {
            throw new NotImplementedException();
        }

        public void Update(ToDo item)
        {
            throw new NotImplementedException();
        }
    }
}
