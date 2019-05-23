using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
using 人脸识别考勤系统.BLL;
using 人脸识别考勤系统.Helper;
using 人脸识别考勤系统.Model;
using 人脸识别考勤系统.ViewModel;

namespace 人脸识别考勤系统.View.AddView
{
    /// <summary>
    /// PublishNewNotifyWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PublishNewNotifyWindow : MetroWindow
    {
        NotificationInfoViewModel notificationInfo { get; set; }
        public bool isAddNewNotification = true;
        public NotificationBLL notificationBLL = new NotificationBLL();
        public PublishNewNotifyWindow()
        {
            this.Closed += PublishNewNotifyWindow_Closed;
            InitializeComponent();
            notificationInfo = new NotificationInfoViewModel();
            this.DataContext = notificationInfo;
        }

        private void PublishNewNotifyWindow_Closed(object sender, EventArgs e)
        {
            MsgHelper.RefreshDataGrid();
        }

        public PublishNewNotifyWindow(Notification nf)
        {
            InitializeComponent();
            isAddNewNotification = false;
            notificationInfo = new NotificationInfoViewModel(nf);
            this.DataContext = notificationInfo;
        }

        private async void SaveNotification_Clcik(object sender, RoutedEventArgs e)
        {
            if (isAddNewNotification)
            {
                if (notificationBLL.InsertNotification(notificationInfo.notificationModel))
                {
                    MsgHelper.RefreshDataGrid();
                    this.Close();
                }
                else
                {
                    await this.ShowMessageAsync("提示", "添加失败!");
                }
            }
            else//修改
            {
                if (notificationBLL.UpdateNotification(notificationInfo.notificationModel))
                {
                    this.Hide();
                    await this.ShowMessageAsync("提示", "修改成功!");
                    MsgHelper.RefreshDataGrid();
                    this.Close();
                }
                else
                {
                    await this.ShowMessageAsync("提示", "修改失败!");
                }
            }
        }
    }

}
