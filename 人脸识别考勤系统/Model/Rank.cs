using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 人脸识别考勤系统.Model
{
    public class Rank
    {
        public string Rname{ get; set; }
        public int Rscore { get; set; }
        public int Rrank { get; set; }
        public int RsignTimes { get; set; }
        public int RlateTimes { get; set; }
        public int RearlyTimes { get; set; }
    }
}
