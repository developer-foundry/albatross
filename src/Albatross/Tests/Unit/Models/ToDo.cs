using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Albatross.Tests.Unit.Models
{
    [DataContract]
    public class ToDo : IEquatable<ToDo>
    {
        [DataMember(Name = "id")]
        public Guid Id;

        [DataMember(Name = "name")]
        public string Name;

        [DataMember(Name = "priority")]
        public int Priority;

        public bool Equals(ToDo other)
        {
            return this.Id == other.Id;
        }
    }
}
