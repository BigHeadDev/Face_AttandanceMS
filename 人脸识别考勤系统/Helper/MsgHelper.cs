using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 人脸识别考勤系统.Helper
{
    public delegate void RefreshDataGridHandle();
    public delegate void RefreshComboxHandle();
    public delegate void RefreshWeatherHandel();
    public static class MsgHelper
    {
        public static event RefreshComboxHandle RefreshComboxEvent;
        public static event RefreshDataGridHandle RefreshDataGridEvent;
        public static event RefreshWeatherHandel RefreshWeatherEvent;
        public static void RefreshDataGrid()
        {
            RefreshDataGridEvent();
        }
        public static void RefreshCombox()
        {
            RefreshComboxEvent();
        }
        public static void RefreshWeather()
        {
            RefreshWeatherEvent();
        }
    }
}
