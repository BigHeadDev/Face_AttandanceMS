using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 人脸识别考勤系统.Model
{
    public class Weather
    {
        public int code { get; set; }
        public Holiday holiday { get; set; }
    }

    public class Holiday
    {
        public bool holiday { get; set; }
        public string name { get; set; }
    }
}
