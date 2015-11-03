using System;
using System.Configuration;
using System.Web;

using AAGJKPRTServices.DataContract;
using ErrorLogger;
using LMTDatabaseLayer;
using LMTDataContract;
using System.Web.UI;
using System.Data;
using System.Web.Hosting;
using System.IO;
using System.ServiceModel.Web;
using System.Net;



namespace AAGJKPRTServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1, ILogin, ISupplier, ILookUp, IUpload
    {

        public UserInfoDataContract GetUserlist()
        {
            UserInfoDataContract userInfoDataContract = new UserInfoDataContract();
            try
            {
                userinfo userinfo;
                //This is just to check the change in code base...
                userInfoDataContract.Message = "Service Call !!!";
                userInfoDataContract.Status = true;
                DateTime dt = Convert.ToDateTime("0w204/1990ww");
                for (int counter = 0; counter < 10; counter++)
                {
                    userinfo = new userinfo();
                    userinfo.UserId = counter + 1;
                    userinfo.fname = "Gaurav";
                    userinfo.mname = "";
                    userinfo.lname = "Kaushik";
                    userinfo.age = 24;
                    userinfo.DOB = "02/04/1990";
                    userInfoDataContract.Data.Add(userinfo);
                }
            }
            catch (Exception exception)
            {
                Logger Err = new Logger();
                Err.ErrorLog(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ErrorLogPath"]), exception.Message, exception.StackTrace);
                userInfoDataContract.Message = "Error occured and logged please connect the Service Manager !";
                userInfoDataContract.Status = false;
            }
            return userInfoDataContract;
        }
        public UserInfoDataContract Getuserinfo(string username)
        {
            UserInfoDataContract userInfoDataContract = new UserInfoDataContract();
            userinfo userinfo;
            try
            {
                //This is just to check the change in code base...
                //checking the git process by khushbu 
                userInfoDataContract.Message = "Service Call !!!";
                userInfoDataContract.Status = true;
                if (username.ToLower() == "gaurav")
                {
                    userinfo = new userinfo();
                    userinfo.UserId = 1;
                    userinfo.fname = "Gaurav";
                    userinfo.mname = "";
                    userinfo.lname = "Kaushik";
                    userinfo.age = 24;
                    userinfo.DOB = "02/04/1990";
                    userInfoDataContract.Data.Add(userinfo);
                }
                else if (username.ToLower() == "jai")
                {
                    userinfo = new userinfo();
                    userinfo.UserId = 2;
                    userinfo.fname = "Jai";
                    userinfo.mname = "";
                    userinfo.lname = "Sajwan";
                    userinfo.age = 24;
                    userinfo.DOB = "02/04/1990";
                    userInfoDataContract.Data.Add(userinfo);
                }
                else
                {
                    //userinfo = new userinfo();
                    //userinfo.UserId = 0;
                    //userinfo.fname = "";
                    //userinfo.mname = "";
                    //userinfo.lname = "";
                    //userinfo.age = 0;
                    //userinfo.DOB = "";
                    userInfoDataContract.Message = "User not found !";
                    userInfoDataContract.Status = true;
                    //userInfoDataContract.Data.Add(userinfo);
                }
            }
            catch (Exception exception)
            {
                Logger Err = new Logger();
                Err.ErrorLog(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ErrorLogPath"]), exception.Message, exception.StackTrace);
                userInfoDataContract.Message = "Error occured and logged please connect the Service Manager !";
                userInfoDataContract.Status = false;
            }
            return userInfoDataContract;
        }

        public UserInfoDataContract Validate_User(string username, string pwd)
        {
            UserInfoDataContract userInfoDataContract = new UserInfoDataContract();
            userinfo userinfo;
            try
            {
                if (username == "jai" && pwd == "123")
                {
                    userInfoDataContract.Message = "Hello Jai !";
                    userInfoDataContract.Status = true;
                    userinfo = new userinfo();
                    userinfo.UserId = 2;
                    userinfo.fname = "Jaipal";
                    userinfo.mname = "";
                    userinfo.lname = "Sajwan";
                    userinfo.age = 24;
                    userinfo.DOB = "01/09/1990";
                    userInfoDataContract.Data.Add(userinfo);
                }
                else if (username != "jai" && pwd != "123")
                {
                    userInfoDataContract.Message = "User not found !";
                    userInfoDataContract.Status = true;
                }
                else if (username != "jai")
                {
                    userInfoDataContract.Message = "Username is not correct !";
                    userInfoDataContract.Status = true;
                }
                else if (pwd != "123")
                {
                    userInfoDataContract.Message = "Password is not correct !";
                    userInfoDataContract.Status = true;
                }
            }
            catch (Exception exception)
            {
                Logger Err = new Logger();
                Err.ErrorLog(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ErrorLogPath"]), exception.Message, exception.StackTrace);
                userInfoDataContract.Message = "Error occured and logged please connect the Service Manager !";
                userInfoDataContract.Status = false;
            }
            return userInfoDataContract;
        }

        public LabourDetails InsertLabour(string LabourCode, string FullName, string FatherName, string username, string CurrentAddress, string CurrentStateID, string CurrentCityID, string CurrentPincode, string PermanentAddress, string PermanentStateID, string PermanentCityID, string PermanentPincode, string PhoneNo, string SectorType, string LabourType, string Specialization, string Experience, string Wages, string Lbr_Skill, string Bool_Verification, string SupplierID, string Belonging1, string Belonging2, string Belonging3, string Belonging4)
        {
            LabourDetails labourDetails = new LabourDetails();
            Labour labour = new Labour();
            SupplierDAL supplierDAL = new SupplierDAL();
            System.Net.WebHeaderCollection webHeaderCollection = WebOperationContext.Current.IncomingRequest.Headers;
            try
            {
                //labour.LabourID = csLabourRegistration.GetLabourMaxId();
                labour.LabourCode = LabourCode.ToUpper() == "NULL" ? "" : LabourCode;
                labour.FullName = FullName.ToUpper() == "NULL" ? "" : FullName;
                labour.FatherName = FatherName.ToUpper() == "NULL" ? "" : FatherName;
                labour.CurrentAddress = CurrentAddress.ToUpper() == "NULL" ? "" : CurrentAddress;
                labour.CurrentStateID = CurrentStateID.ToUpper() == "NULL" ? 0 : Convert.ToInt32(CurrentStateID); ;
                labour.CurrentCityID = CurrentCityID.ToUpper() == "NULL" ? 0 : Convert.ToInt32(CurrentCityID); ;
                labour.CurrentPincode = CurrentPincode.ToUpper() == "NULL" ? 0 : Convert.ToInt32(CurrentPincode);
                labour.PermanentAddress = PermanentAddress.ToUpper() == "NULL" ? "" : PermanentAddress;
                labour.PermanentStateID = PermanentStateID.ToUpper() == "NULL" ? 0 : Convert.ToInt32(PermanentStateID);
                labour.PermanentCityID = PermanentCityID.ToUpper() == "NULL" ? 0 : Convert.ToInt32(PermanentCityID); ;
                labour.PermanentPincode = PermanentPincode.ToUpper() == "NULL" ? 0 : Convert.ToInt32(PermanentPincode);
                labour.PhoneNo = PhoneNo.ToUpper() == "NULL" ? "0" : PhoneNo;
                labour.SectorType = SectorType.ToUpper() == "NULL" ? "0" : SectorType;
                labour.LabourType = LabourType.ToUpper() == "NULL" ? "0" : LabourType;
                labour.Specialization = Specialization.ToUpper() == "NULL" ? "0" : Specialization;
                labour.Experience = Experience.ToUpper() == "NULL" ? 0 : Convert.ToInt32(Experience);
                labour.Wages = Wages.ToUpper() == "NULL" ? 0 : Convert.ToInt32(Wages);
                labour.Lbr_Skill = Lbr_Skill.ToUpper() == "NULL" ? "" : Lbr_Skill;
                labour.Verification = Bool_Verification.ToUpper() == "NULL" ? false : true;
                labour.SupplierID = SupplierID.ToUpper() == "NULL" ? 0 : Convert.ToInt32(SupplierID);
                labour.Belonging1 = Belonging1.ToUpper() == "NULL" ? "0" : Belonging1;
                labour.Belonging2 = Belonging2.ToUpper() == "NULL" ? "0" : Belonging2;
                labour.Belonging3 = Belonging3.ToUpper() == "NULL" ? "0" : Belonging3;
                labour.Belonging4 = Belonging4.ToUpper() == "NULL" ? "0" : Belonging4;

                labour.Image_URL = webHeaderCollection["Image_URL"] == null ? "" : webHeaderCollection["Image_URL"].ToString();
                labour.Doc1_URL = webHeaderCollection["Doc1_URL"] == null ? "" : webHeaderCollection["Doc1_URL"].ToString();
                labour.Doc2_URL = webHeaderCollection["Doc2_URL"] == null ? "" : webHeaderCollection["Doc2_URL"].ToString();
                labour.Doc3_URL = webHeaderCollection["Doc3_URL"] == null ? "" : webHeaderCollection["Doc3_URL"].ToString();
                labour.Doc4_URL = webHeaderCollection["Doc4_URL"] == null ? "" : webHeaderCollection["Doc4_URL"].ToString();

                supplierDAL.InsertNewLabourData("INSERT", labour);
                labourDetails.Message = "Labour inserted successfully !";
                labourDetails.Status = true;
                return labourDetails;
            }
            catch (Exception exception)
            {
                Logger Err = new Logger();
                Err.ErrorLog(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ErrorLogPath"]), exception.Message, exception.StackTrace);
                labourDetails.Message = "Error occured and logged please connect the Service Manager !";
                labourDetails.Status = false;
                return labourDetails;
            }
        }


        //From ILogin interface
        public UserDetail ValidateSupplier(string username, string password)
        {
            UserDetail userDetail = new UserDetail();
            User user = new User();
            Login login = new Login();
            try
            {
                if (username != "" && password != "")
                {
                    DataTable dt = login.ExecuteProcedure(username);
                    if (dt.Rows.Count > 0)
                    {
                        if (password == Login.DecodeFrom64(dt.Rows[0]["Pwd"].ToString()))//Static function.
                        {

                            user.UserId = Convert.ToInt32(dt.Rows[0]["UserID"] == null ? 0 : dt.Rows[0]["UserID"]);
                            user.UserName = dt.Rows[0]["UserName"].ToString();
                            user.UserType = dt.Rows[0]["UserType"].ToString();
                            user.UserEmail = dt.Rows[0]["EmailID"].ToString();
                            user.UserCategory = dt.Rows[0]["UserCategory"].ToString();
                            user.RedirectingUrl = "/MasterPages/SupplierMenuboard.aspx";
                            userDetail.Data.Add(user);
                            userDetail.Status = true;
                            userDetail.Message = "Welcome to Easy labour Supplier Panel";
                        }
                        else
                        {
                            userDetail.Status = false;
                            userDetail.Message = "Invalid Password !";
                        }
                    }
                    else
                    {
                        userDetail.Status = false;
                        userDetail.Message = "Invalid UserName !";
                    }
                }
                else
                {
                    userDetail.Status = false;
                    userDetail.Message = "Username and password can not be blank !";
                }
            }
            catch (Exception exception)
            {
                userDetail.Status = false;
                userDetail.Message = "Opps something went worng, please check with application admin !";
                Logger Err = new Logger();
                Err.ErrorLog(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ErrorLogPath"]), exception.Message, exception.StackTrace);
            }
            return userDetail;
        }
        public LabourDetails GetLabourList()
        {
            LabourDetails labourDetails = new LabourDetails();
            Labour labour;
            SupplierDAL supplierDAL = new SupplierDAL();
            try
            {
                DataTable dt = supplierDAL.GetLaboursList();
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        labour = new Labour();
                        labour.CurrentPincode = Convert.ToInt32(dr["CurrentPincode"] == null ? 0 : dr["CurrentPincode"]);
                        labour.Doc1_URL = dr["Doc1_URL"].ToString().TrimStart('.');
                        labour.Doc2_URL = dr["Doc2_URL"].ToString().TrimStart('.');
                        labour.Doc3_URL = dr["Doc3_URL"].ToString().TrimStart('.');
                        labour.Doc4_URL = dr["Doc4_URL"].ToString().TrimStart('.');
                        labour.Experience = Convert.ToInt32(dr["Experience"] == null ? 0 : dr["Experience"]);
                        labour.FullName = dr["FullName"].ToString();
                        labour.Image_URL = dr["Image_URL"].ToString().TrimStart('.');
                        labour.LabourCode = dr["LabourCode"].ToString();
                        labour.LabourID = Convert.ToInt32(dr["Experience"] == null ? 0 : dr["Experience"]);
                        labour.LabourType = dr["LabourType"].ToString();
                        labour.Lbr_Skill = dr["Lbr_Skill"].ToString();
                        labour.SectorType = dr["SectorType"].ToString();
                        labour.Specialization = dr["Specialization"].ToString();
                        labour.SupplierID = Convert.ToInt32(dr["SupplierID"] == null ? 0 : dr["SupplierID"]);
                        labour.SupplierName = dr["SupplierName"].ToString();
                        string Verification = dr["Verification"] == null ? "0" : dr["Verification"].ToString();
                        labour.Verification = Verification == "1" ? true : false;
                        labour.Wages = Convert.ToInt32(dr["Wages"] == null ? 0 : dr["Wages"]);
                        labourDetails.Data.Add(labour);
                    }
                    labourDetails.ApplicationUrl = ConfigurationManager.AppSettings["ApplicationUrl"].ToString();//"http://dev.easylabour.com";
                    labourDetails.Count = dt.Rows.Count;
                    labourDetails.Status = true;
                    labourDetails.Message = "List of Labours !";
                }
                else
                {
                    labourDetails.Status = false;
                    labourDetails.Message = "No Labour exists !";
                }
            }
            catch (Exception exception)
            {
                labourDetails.Status = false;
                labourDetails.Message = "Opps something went worng, please check with application admin !";
                Logger Err = new Logger();
                Err.ErrorLog(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ErrorLogPath"]), exception.Message, exception.StackTrace);
            }
            return labourDetails;
        }
        public LookupList GetStateList()
        {
            LookupList stateList = new LookupList();
            Lookup stateLookup;
            LookUpDAL lookUpDAL = new LookUpDAL();
            try
            {
                DataTable dt = lookUpDAL.GetStateList();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        stateLookup = new Lookup();
                        stateLookup.Id = Convert.ToInt32(dr["LID"] == null ? 0 : dr["LID"]);
                        stateLookup.Name = dr["LDESC"].ToString();
                        stateList.Data.Add(stateLookup);
                    }
                    stateList.Status = true;
                    stateList.Message = "List of States !";
                }
                else
                {
                    stateList.Status = false;
                    stateList.Message = "No State exists !";
                }
            }
            catch (Exception exception)
            {
                stateList.Status = false;
                stateList.Message = "Opps something went worng, please check with application admin !";
                Logger Err = new Logger();
                Err.ErrorLog(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ErrorLogPath"]), exception.Message, exception.StackTrace);
            }
            return stateList;
        }
        public LookupList GetCityListbyStateID(string StateID)
        {
            int IntStateID;
            LookupList CitylookupList = new LookupList();
            Lookup cityLookup;
            LookUpDAL lookUpDAL = new LookUpDAL();
            try
            {
                IntStateID = Convert.ToInt32(StateID);
            }
            catch (Exception exception)
            {
                CitylookupList.Status = false;
                CitylookupList.Message = "Opps something went worng, with supplied Param !";
                Logger Err = new Logger();
                Err.ErrorLog(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ErrorLogPath"]), exception.Message, exception.StackTrace);
                return CitylookupList;
            }
            try
            {
                DataTable dt = lookUpDAL.GetCityListbyStateID(IntStateID);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        cityLookup = new Lookup();
                        cityLookup.Id = Convert.ToInt32(dr["ID"] == null ? 0 : dr["ID"]);
                        cityLookup.Name = dr["Name"].ToString();
                        CitylookupList.Data.Add(cityLookup);
                    }
                    CitylookupList.Status = true;
                    CitylookupList.Message = "List of cities !";
                }
                else
                {
                    CitylookupList.Status = false;
                    CitylookupList.Message = "No city exists !";
                }
            }
            catch (Exception exception)
            {
                CitylookupList.Status = false;
                CitylookupList.Message = "Opps something went worng, please check with application admin !";
                Logger Err = new Logger();
                Err.ErrorLog(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ErrorLogPath"]), exception.Message, exception.StackTrace);
            }
            return CitylookupList;
        }
        public LookupList GetSectorTypeList()
        {
            LookupList SectorTypeList = new LookupList();
            Lookup SectorTypeLookup;
            LookUpDAL lookUpDAL = new LookUpDAL();
            try
            {
                DataTable dt = lookUpDAL.GetSectorType();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        SectorTypeLookup = new Lookup();
                        SectorTypeLookup.Id = Convert.ToInt32(dr["ID"] == null ? 0 : dr["ID"]);
                        SectorTypeLookup.Name = dr["Name"].ToString();
                        SectorTypeList.Data.Add(SectorTypeLookup);
                    }
                    SectorTypeList.Status = true;
                    SectorTypeList.Message = "List of Sector Type !";
                }
                else
                {
                    SectorTypeList.Status = false;
                    SectorTypeList.Message = "No Sector Type exists !";
                }
            }
            catch (Exception exception)
            {
                SectorTypeList.Status = false;
                SectorTypeList.Message = "Opps something went worng, please check with application admin !";
                Logger Err = new Logger();
                Err.ErrorLog(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ErrorLogPath"]), exception.Message, exception.StackTrace);
            }
            return SectorTypeList;
        }
        public LookupList GetLabourTypebySectorID(string SectorID)
        {
            int IntSectorID;
            LookupList LabourTypelookupList = new LookupList();
            Lookup LabourTypeLookup;
            LookUpDAL lookUpDAL = new LookUpDAL();
            try
            {
                IntSectorID = Convert.ToInt32(SectorID);
            }
            catch (Exception exception)
            {
                LabourTypelookupList.Status = false;
                LabourTypelookupList.Message = "Opps something went worng, with supplied Param !";
                Logger Err = new Logger();
                Err.ErrorLog(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ErrorLogPath"]), exception.Message, exception.StackTrace);
                return LabourTypelookupList;
            }
            try
            {
                DataTable dt = lookUpDAL.GetLabourTypebyID(IntSectorID);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        LabourTypeLookup = new Lookup();
                        LabourTypeLookup.Id = Convert.ToInt32(dr["ID"] == null ? 0 : dr["ID"]);
                        LabourTypeLookup.Name = dr["Name"].ToString();
                        LabourTypelookupList.Data.Add(LabourTypeLookup);
                    }
                    LabourTypelookupList.Status = true;
                    LabourTypelookupList.Message = "List of Labour Type !";
                }
                else
                {
                    LabourTypelookupList.Status = true;
                    LabourTypelookupList.Message = "No Labour Type exists !";
                }
            }
            catch (Exception exception)
            {
                LabourTypelookupList.Status = false;
                LabourTypelookupList.Message = "Opps something went worng, please check with application admin !";
                Logger Err = new Logger();
                Err.ErrorLog(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ErrorLogPath"]), exception.Message, exception.StackTrace);
            }
            return LabourTypelookupList;
        }

        public System.IO.Stream DownloadFile(string fileName, string fileExtension)
        {
            string downloadFilePath = Path.Combine(HostingEnvironment.MapPath("~/FileServer/Extracts"), fileName + "." + fileExtension);

            //Write logic to create the file
            File.Create(downloadFilePath);

            String headerInfo = "attachment; filename=" + fileName + "." + fileExtension;
            WebOperationContext.Current.OutgoingResponse.Headers["Content-Disposition"] = headerInfo;

            WebOperationContext.Current.OutgoingResponse.ContentType = "application/octet-stream";

            return File.OpenRead(downloadFilePath);
        }

        public FileUpload UploadFile(Stream stream)
        {
            FileUpload fileUpload = new FileUpload();
            try
            {
                //string FilePath = "D://LMT_Services//Services//AAGJKPRTServices//LabourImage//abc.txt";
                System.Net.WebHeaderCollection webHeaderCollection = WebOperationContext.Current.IncomingRequest.Headers;
                string fileextn = webHeaderCollection["FileExtension"].ToString();
                string FilePath = "";// ConfigurationManager.AppSettings["LabourImagePath"].ToString();//"C://HostingSpaces//oadenterprises//dev.easylabour.com//wwwroot//labourimages";
                FilePath = webHeaderCollection["FileUploadType"].ToString() == "Document" ? ConfigurationManager.AppSettings["LabourDocPath"].ToString() : ConfigurationManager.AppSettings["LabourImagePath"].ToString();
                string filename = Guid.NewGuid() + fileextn;
                FilePath = FilePath + filename;
                int length = 0;
                using (FileStream writer = new FileStream(FilePath, FileMode.Create))
                {
                    int readCount;
                    var buffer = new byte[8192];
                    while ((readCount = stream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        writer.Write(buffer, 0, readCount);
                        length += readCount;
                    }
                }
                fileUpload.ApplicationUrl = ConfigurationManager.AppSettings["ApplicationUrl"].ToString();
                fileUpload.FileUrl = webHeaderCollection["FileUploadType"].ToString() == "Document" ? @"/LabourDocs/" + filename : @"/labourimages/" + filename;
                fileUpload.FileExtension = fileextn;
                fileUpload.Status = true;
                fileUpload.Message = "File uploaded successfully !";
            }
            catch (Exception exception)
            {
                fileUpload.Status = false;
                fileUpload.Message = "Opps something went worng, please check with application admin !";
                Logger Err = new Logger();
                Err.ErrorLog(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ErrorLogPath"]), exception.Message, exception.StackTrace);
            }
            return fileUpload;
        }

    }
}
