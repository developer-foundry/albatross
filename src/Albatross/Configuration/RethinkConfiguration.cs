using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albatross.Configuration
{
    public class RethinkConfiguration
    {
        public string Database { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }
    }
}
