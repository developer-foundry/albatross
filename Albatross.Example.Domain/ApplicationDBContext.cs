using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Example.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public IDbSet<ToDo> Stocks { get; set; }
    }
}
