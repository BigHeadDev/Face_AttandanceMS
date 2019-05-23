using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 人脸识别考勤系统.BLL;
using 人脸识别考勤系统.Model;

namespace 人脸识别考勤系统.ViewModel
{
    public class NotificationInfoViewModel:ViewModelBase
    {
        public Notification notificationModel { get; set; }
        public NotificationBLL notificationBLL = new NotificationBLL();
        public NotificationInfoViewModel()
        {
            if (IsInDesignMode)
            {
                
            }
            else
            {
                int id = notificationBLL.GetNewId();
                notificationModel = new Notification
                {
                    Nid = id,
                    Ntime = DateTime.Now.ToString()
                };
            }
        }
        public NotificationInfoViewModel(Notification nf)
        {
            notificationModel = nf;
        }
    }
}
