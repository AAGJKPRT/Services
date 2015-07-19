using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorLogger
{
    public class Logger
    {
        private string sLogFormat;
        private string sErrorTime;

        public Logger()
        {
            //sLogFormat used to create log files format :
            // dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message
            sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";

            //this variable used to create log filename format "
            //for example filename : ErrorLogYYYYMMDD
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            sErrorTime = sYear + sMonth + sDay;
        }
        public void ErrorLog(string sPathName, string sErrMsg, string strStackTrace)
        {
            File.AppendAllText(sPathName + sErrorTime + ".txt", sLogFormat + "Message: " + sErrMsg + "Stack Trace:  " + strStackTrace);
            //StreamWriter sw = new StreamWriter(sErrorTime, true);
            //sw.WriteLine(sLogFormat + "Message: " + sErrMsg + "Stack Trace:  " + strStackTrace);
            //sw.Flush();
            //sw.Close();
        }
    }
}
