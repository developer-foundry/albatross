using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albatross.Models
{
    public interface IAlbatrossEntity
    {
        Guid Id { get; set; }
    }
}
