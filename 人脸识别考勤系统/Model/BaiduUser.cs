using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 人脸识别考勤系统.Helper;

namespace 人脸识别考勤系统.Model
{
    public class BaiduUser
    {
        public string APP_ID { get; set; }
        public string API_KEY { get; set; }
        public string SECRET_KEY { get; set; }
        public string token { get; set; }
        public Baidu.Aip.Face.Face client { get; set; }
        public BaiduUser()
        {
            this.APP_ID = "你的APP_ID";
            this.API_KEY = "你的API_KEY";
            this.SECRET_KEY = "你的SECRET_KEY";
            this.client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
            client.Timeout = 60000;
        }  
    }
}
