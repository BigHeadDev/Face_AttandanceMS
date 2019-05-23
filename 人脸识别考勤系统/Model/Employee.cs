using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 人脸识别考勤系统.Model
{
    public class Employee
    {
        public int Eid { get; set; }
        public string Ename { get; set; }
        public int Esex { get; set; }
        public string Ebirthday { get; set; }
        public int EattendanceTimes { get; set; }
        public string ElastSignTime { get; set; }
        public string EdepartName { get; set; }
        public int EdepartId { get; set; }
    }
}
