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
using System.Windows.Navigation;
using System.Windows.Shapes;
using 人脸识别考勤系统.Helper;
using 人脸识别考勤系统.Model;
using 人脸识别考勤系统.View.AddView;

namespace 人脸识别考勤系统.Pages.ManagePage
{
    /// <summary>
    /// NotificationManagePage.xaml 的交互逻辑
    /// </summary>
    public partial class NotificationManagePage : Page
    {
        public NotificationManagePage()
        {
            InitializeComponent();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PublishNewNotifyWindow publishNewNotifyWindow = new PublishNewNotifyWindow((sender as DataGrid).SelectedItem as Notification);
            publishNewNotifyWindow.ShowDialog();
        }

        private void PublishNotification_Click(object sender, RoutedEventArgs e)
        {
            PublishNewNotifyWindow publishNewNotifyWindow = new PublishNewNotifyWindow();
            publishNewNotifyWindow.ShowDialog();
        }
    }
}
