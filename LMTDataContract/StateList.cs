using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace LMTDataContract
{
    [DataContract]
    public class LookupList
    {
        [DataMember(Order = 0)]
        public bool Status { get; set; }
        [DataMember(Order = 1)]
        public string Message { get; set; }
        [DataMember(Order = 2)]
        public List<Lookup> Data;

        public LookupList()
        {
            Data = new List<Lookup>();
        }
    }
    public class Lookup
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
