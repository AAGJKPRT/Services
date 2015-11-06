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
        [WebInvoke(Method = "GET", UriTemplate = "/InsertLabour/{FullName},{FatherName},{CurrentAddress},{CurrentStateID},{CurrentCityID},{CurrentPincode},{PermanentAddress},{PermanentStateID},{PermanentCityID},{PermanentPincode},{PhoneNo},{SectorType},{LabourType},{Specialization},{Experience},{Wages},{Lbr_Skill},{Bool_Verification},{SupplierID},{Belonging1},{Belonging2},{Belonging3},{Belonging4}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        LabourDetails InsertLabour(string FullName, string FatherName, string CurrentAddress, string CurrentStateID, string CurrentCityID, string CurrentPincode, string PermanentAddress, string PermanentStateID, string PermanentCityID, string PermanentPincode, string PhoneNo, string SectorType, string LabourType, string Specialization, string Experience, string Wages, string Lbr_Skill, string Bool_Verification, string SupplierID, string Belonging1, string Belonging2, string Belonging3, string Belonging4);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetLabourList/", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        LabourDetails GetLabourList();
    }
}
