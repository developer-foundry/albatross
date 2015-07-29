using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albatross.Tests.Unit.Models
{
    public class ToDo : IEquatable<ToDo>
    {
        public int Id;
        public string Name;
        public int Priority;

        public bool Equals(ToDo other)
        {
            return this.Id == other.Id;
        }
    }
}
