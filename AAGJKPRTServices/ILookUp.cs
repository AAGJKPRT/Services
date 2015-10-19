using LMTDataContract;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace AAGJKPRTServices
{
    [ServiceContract]
    public interface ILookUp
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetStateList/", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        LookupList GetStateList();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetCityListbyStateID/{StateID}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        LookupList GetCityListbyStateID(string StateID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetSectorTypeList/", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        LookupList GetSectorTypeList();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetLabourTypebySectorId/{SectorID}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        LookupList GetLabourTypebySectorID(string SectorID);
    }
}
