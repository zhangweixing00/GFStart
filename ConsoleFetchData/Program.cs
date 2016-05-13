using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ConsoleFetchData
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://www.sgs.gov.cn/shaic/appStat!toNameAppList.action";
            string key = "服装";
            string sTime = "";
            string eTime = "";
            int pIndex = 1;
            string postData = string.Format(@"p={3}&nameSearchCondition.acceptOrgan=&nameSearchCondition.checkName={0}&nameSearchCondition
.startDate ={1}&nameSearchCondition.endDate ={2}", System.Web.HttpUtility.UrlEncode(key), sTime, eTime, pIndex);
            //
            WebClient wb = new WebClient();
            wb.BaseAddress = url;
            wb.Headers.Add("", "");
            wb.Encoding = Encoding.UTF8;
           string aa= wb.UploadString(url, postData);

        }
    }
}
