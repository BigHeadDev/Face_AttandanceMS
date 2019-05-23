using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 人脸识别考勤系统.Helper;
using 人脸识别考勤系统.Model;

namespace 人脸识别考勤系统.DAL
{  
    class FaceDAL
    {
        public BaiduUser baiduUser = new BaiduUser();
        public Newtonsoft.Json.Linq.JObject CheckFace(string base64code)
        {
            Newtonsoft.Json.Linq.JObject result = new Newtonsoft.Json.Linq.JObject();
            var image = base64code;
            var imageType = "BASE64";
            var options = new Dictionary<string, object>{{"face_field", "expression"}};
            try
            {
                result = baiduUser.client.Detect(image, imageType,options);
            }
            catch
            {
                //网络错误
            }
            return result;
        }
        public bool AddUser(string base64code,int uid,string group)
        {
            var imageType = "BASE64";
            var result = baiduUser.client.UserAdd(base64code, imageType, group, uid.ToString());
            return Convert.ToInt32(result["error_code"]) == 0 ? true : false;
        }
        public string SearchId(string base64code,string groupList)
        {
            string msg = "";
            var imageType = "BASE64";
            var result = baiduUser.client.Search(base64code, imageType, groupList);
            if (Convert.ToInt32(result["error_code"])==0)
            {
                msg = Convert.ToInt32(result["result"]["user_list"][0]["score"]) > 75 ? result["result"]["user_list"][0]["user_id"].ToString() : null;
            }
            return msg;  
        }
        public bool DeleteUser(string id)
        {
            bool b = false;
            var groupId = "User";
            var userId = id;
            // 调用删除用户，可能会抛出网络等异常，请使用try/catch捕获
            var result = baiduUser.client.UserDelete(groupId, userId);
            if (Convert.ToInt32(result["error_code"])==0)
            {
                b = true;
            }
            return b;
        }
    }
}
