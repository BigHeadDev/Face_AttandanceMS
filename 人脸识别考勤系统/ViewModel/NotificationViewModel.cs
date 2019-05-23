using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using 人脸识别考勤系统.BLL;
using 人脸识别考勤系统.Helper;
using 人脸识别考勤系统.Model;

namespace 人脸识别考勤系统.ViewModel
{
    public class NotificationViewModel:ViewModelBase
    {
        private RelayCommand<object> deleteCommand
        {
            get;
            set;
        }
        public RelayCommand<object> DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                    deleteCommand = new RelayCommand<object>(x => Delete(x));
                return deleteCommand;
            }
        }
        private void Delete(object x)
        {
            var nf = x as Notification;
            MessageBoxResult confirmToDel = MessageBox.Show("确认要删除通知" + nf.Ntitle + "吗?", "删除提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirmToDel == MessageBoxResult.Yes)
            {
                if (notificationBLL.DeleteNotification(nf))
                {
                    Notifications.Remove(nf);
                    MessageBox.Show("通知信息删除成功!");
                }
                else
                {
                    MessageBox.Show("通知信息删除失败!");
                }
            }
        }
        public ObservableCollection<Notification> notifications;
        NotificationBLL notificationBLL = new NotificationBLL();
        public ObservableCollection<Notification> Notifications
        {
            get { return notifications; }
            set
            {
                notifications = value;
                RaisePropertyChanged("Notifications");
            }
        }
        public NotificationViewModel()
        {
            MsgHelper.RefreshDataGridEvent += MsgHelper_RefreshDataGridEvent;
            if (IsInDesignMode)
            {

            }
            else
            {
                Notifications = notificationBLL.GetNotifications();
            }
        }

        private void MsgHelper_RefreshDataGridEvent()
        {
            Notifications= notificationBLL.GetNotifications();
        }
    }
}
