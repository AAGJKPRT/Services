using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using LMTDataContract;
using System.ServiceModel.Web;

namespace AAGJKPRTServices
{
    [ServiceContract]
    public interface ILogin
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/ValidateSupplier/{username},{password}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        UserDetail ValidateSupplier(string username, string password);
    }
}
