using AAGJKPRTServices.DataContract;
using LMTDataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace AAGJKPRTServices
{
    [ServiceContract]
    public interface ISupplier 
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/InsertNewLabour/", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        UserDetail InsertLabour();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetLabourList/", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        LabourDetails GetLabourList();
    }
}
