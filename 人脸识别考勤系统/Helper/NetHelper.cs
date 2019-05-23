using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace 人脸识别考勤系统.Helper
{
    public class NetHelper
    {
        public static string GetHtml(string url)
        {
            string result = "";
            using (HttpClient client =new HttpClient())
            {
                result = client.GetStringAsync(new Uri(url)).Result;
            }
            
            return result;
        }
    }
}

