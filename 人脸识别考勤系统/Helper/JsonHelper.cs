using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 人脸识别考勤系统.Helper
{
    public class JsonHelper
    {
        /// <summary>
        /// 创建JsonSerializer对象
        /// </summary>
        JsonSerializer jsonSerializer = JsonSerializer.Create();
        /// <summary>
        /// 格式话Json字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public T GetView<T>(string json)
        {
            return jsonSerializer.Deserialize<T>(new JsonTextReader(new StringReader(json)));
        }

    }
}
