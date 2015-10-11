using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LMTDataContract
{
    [DataContract]
    public class UserDetail
    {
        [DataMember]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
