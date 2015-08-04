using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Albatross.Models;

namespace Albatross.Tests.Unit.Models
{
    [DataContract]
    public class ToDo : IEquatable<ToDo>, IAlbatrossEntity
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "priority")]
        public int Priority { get; set; }

        public bool Equals(ToDo other)
        {
            return this.Id == other.Id;
        }
    }
}
