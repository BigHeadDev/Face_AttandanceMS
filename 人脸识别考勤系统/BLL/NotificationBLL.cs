using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 人脸识别考勤系统.DAL;
using 人脸识别考勤系统.Model;

namespace 人脸识别考勤系统.BLL
{
    public class NotificationBLL
    {
        NotificationDal notificationDal = new NotificationDal();
        public ObservableCollection<Notification> GetNotifications()
        {
            return notificationDal.GetNotifications();
        }

        public int GetNewId()
        {
            return notificationDal.GetNewId();
        }

        public bool InsertNotification(Notification nf)
        {
            return notificationDal.InsertNotification(nf) > 0;
        }

        public bool UpdateNotification(Notification nf)
        {
            return notificationDal.UpdateNotification(nf) > 0;
        }

        public bool DeleteNotification(Notification nf)
        {
            return notificationDal.DeleteNotification(nf) > 0;
        }
    }
}
