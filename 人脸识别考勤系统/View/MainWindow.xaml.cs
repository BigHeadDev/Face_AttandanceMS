using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;
using WPFMediaKit.DirectShow.Controls;
using 人脸识别考勤系统.BLL;
using 人脸识别考勤系统.Helper;
using 人脸识别考勤系统.Model;
using MahApps.Metro.Controls;
using System.Windows.Navigation;
using 人脸识别考勤系统.Pages;
using 人脸识别考勤系统.Properties;
using MahApps.Metro.Controls.Dialogs;

namespace 人脸识别考勤系统.View
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += ShowTime;
            timer.Start();
        }
        DispatcherTimer timer = new DispatcherTimer();
        private void ShowTime(object sender, EventArgs e)
        {
            this.txtTime.Content = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss dddd");
        }

        private async void Sign_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.Default.SignSwitch)
            {
                await this.ShowMessageAsync("提示", "签到暂时关闭~");
                return;
            }
            SignFacesWindow signFacesWindow = new SignFacesWindow();
            signFacesWindow.ShowDialog();
        }

        private async void Navigate_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Tag)
            {
                case "1":
                    frameOther.Navigate(new Uri("\\Pages\\WeatherAndNotifyWindow.xaml", UriKind.Relative));
                    break;
                case "2":
                    if (Settings.Default.RankSwitch)
                    {
                        frameOther.Navigate(new Uri("\\Pages\\RankPage.xaml", UriKind.Relative));
                    }
                    else
                    {
                        await this.ShowMessageAsync("提示", "排行榜暂未开放~");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
