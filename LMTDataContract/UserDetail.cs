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
        [DataMember(Order = 0)]
        public bool Status { get; set; }

        [DataMember(Order = 1)]
        public string Message { get; set; }

        [DataMember(Order = 2)]
        public List<User> Data;

        public UserDetail()
        {
            Data = new List<User>();
        }

    }

    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public string UserCategory { get; set; }
        public string UserEmail { get; set; }
        public string RedirectingUrl { get; set; }
    }
}
