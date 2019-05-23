using MahApps.Metro.Controls;
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
using 人脸识别考勤系统.Model;
using 人脸识别考勤系统.ViewModel;

namespace 人脸识别考勤系统.Pages
{
    /// <summary>
    /// NotificationDisplayWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NotificationDisplayWindow : MetroWindow
    {
        public NotificationDisplayWindow(Notification nf)
        {
            InitializeComponent();
            this.DataContext = new NotificationInfoViewModel(nf);
        }
    }
}
