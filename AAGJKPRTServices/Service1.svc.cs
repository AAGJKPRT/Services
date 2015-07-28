using DataAccessLayer;
using ErrorLogger;
using ServiceDataContract;
using System;
using System.Configuration;
using System.Web;

namespace AAGJKPRTServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
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
        public UserInfoDataContract GetUserlist(string param)
        {
            UserInfoDataContract userInfoDataContract = new UserInfoDataContract();
            try
            {
                userinfo userinfo;
                //This is just to check the change in code base...
                userInfoDataContract.Message = "Service Call !!!";
                userInfoDataContract.Status = true;
                // DateTime dt = Convert.ToDateTime("0w204/1990ww");
                for (int counter = 0; counter < 10; counter++)
                {
                    userinfo = new userinfo();
                    userinfo.UserId = counter + 1;
                    userinfo.fname = "jai";
                    userinfo.mname = "";
                    userinfo.lname = "";
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

    }
}
