using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 人脸识别考勤系统.Model;
using 人脸识别考勤系统.Properties;

namespace 人脸识别考勤系统.Helper
{
    public class ConfigHelper
    {
        public static ClientConfig GetClientConfig()
        {
            ClientConfig cg = new ClientConfig
            {
                ImgSrc = Settings.Default.ImgSrc,
                CompanyName= Settings.Default.CompanyName,
                ThemeColor= Settings.Default.ThemeColor.Name,
                SignSwitch= Settings.Default.SignSwitch,
                RankSwitch= Settings.Default.RankSwitch,
                WeatherSwitch= Settings.Default.WeatherSwitch,
                City= Settings.Default.City,
                NotifySwitch= Settings.Default.NotifySwitch,
                BirthdaySwitch= Settings.Default.BirthdaySwitch,
                LooksSwitch= Settings.Default.LooksSwitch,
                TimeLimitSwitch= Settings.Default.TimeLimitSwitch,
                LateTime= Settings.Default.LateTime,
                EarlyTime= Settings.Default.EarlyTime,
                HolidayCgSwitch= Settings.Default.HolidayCgSwitch
            };
            return cg;
        }
    }
}
