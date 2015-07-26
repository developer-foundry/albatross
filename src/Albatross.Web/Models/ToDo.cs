using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Albatross.Web.Models
{
    [DataContract]
    public class ToDo
    {
        [DataMember(Name = "id")]
        public Guid Id;

        [DataMember(Name = "name")]
        public string Name;

        [DataMember(Name = "priority")]
        public int Priority;
    }
}
