using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 人脸识别考勤系统.DAL;

namespace 人脸识别考勤系统.BLL
{  
    public class FaceBLL
    {
        FaceDAL faceDAL = new FaceDAL();
        public Newtonsoft.Json.Linq.JObject CheckFace(string base64code)
        {
            return faceDAL.CheckFace(base64code);
        }
        public bool AddUser(string base64code, int uid, string group)
        {
            return faceDAL.AddUser(base64code, uid, group);
        }
        public string SearchId(string base64code, string groupList)
        {
            return faceDAL.SearchId(base64code, groupList);
        }
        public bool DeleteUser(int id)
        {
            return faceDAL.DeleteUser(id.ToString());
        }
    }
}
