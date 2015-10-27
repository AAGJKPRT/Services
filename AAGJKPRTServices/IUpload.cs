using LMTDataContract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace AAGJKPRTServices
{
    [ServiceContract]
    public interface IUpload
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/File/{fileName},{fileExtension}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Stream DownloadFile(string fileName, string fileExtension);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UploadFile", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        FileUpload UploadFile(Stream stream);
    }
}
