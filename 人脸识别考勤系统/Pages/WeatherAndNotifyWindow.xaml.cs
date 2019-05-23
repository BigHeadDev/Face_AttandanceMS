using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using 人脸识别考勤系统.Helper;
using 人脸识别考勤系统.Model;
using 人脸识别考勤系统.Pages;
using 人脸识别考勤系统.Properties;

namespace 人脸识别考勤系统.Pages
{
    /// <summary>
    /// WeatherAndNotifyWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WeatherAndNotifyWindow : Page
    {
        public WeatherAndNotifyWindow()
        {
            InitializeComponent();
            RefreshWeather();
            MsgHelper.RefreshWeatherEvent += RefreshWeather; 
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Notification nf = (sender as ListView).SelectedItem as Notification;
            NotificationDisplayWindow notificationDisplayWindow = new NotificationDisplayWindow(nf);
            notificationDisplayWindow.ShowDialog();
        }
        private void RefreshWeather()
        {
           string s = "https://tianqiapi.com/api.php?style=tw&skin=pitaya&city="+Settings.Default.City;
           webWeather.Navigate(s);
        }
    }
}
