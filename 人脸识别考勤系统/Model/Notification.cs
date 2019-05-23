using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 人脸识别考勤系统.Model
{
    public class Notification
    {
        public int Nid { get; set; }
        public string Ntitle { get; set; }
        public string Ncontent { get; set; }
        public bool NisImportant { get; set; }
        public string Ntime { get; set; }
    }
}
