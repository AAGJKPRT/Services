using ServiceDataContract;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace AAGJKPRTServices
{
    [ServiceContract]
    public interface IService1
    {
        // TODO: Add your service operations here
        [OperationContract(Name = "usernameGaurav")]
        [WebInvoke(Method = "GET", UriTemplate = "/usernameGaurav/", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        UserInfoDataContract GetUserlist();

        [OperationContract(Name = "usernameJai")]
        [WebInvoke(Method = "GET", UriTemplate = "/usernameJai/{param}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        UserInfoDataContract GetUserlist(string param);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Getuserinfo/{username}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        UserInfoDataContract Getuserinfo(string username);
    }
}
