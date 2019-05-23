using GalaSoft.MvvmLight;
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
using System.Windows.Threading;
using WPFMediaKit.DirectShow.Controls;
using 人脸识别考勤系统.BLL;
using 人脸识别考勤系统.Helper;
using 人脸识别考勤系统.ViewModel;

namespace 人脸识别考勤系统.View
{
    /// <summary>
    /// RegistFacesWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RegistFacesWindow : MetroWindow
    {
        private DispatcherTimer timer;
        RegistFacesViewModel registFaces { get; set; }
        private int Eid;
        public FaceBLL faceBLL = new FaceBLL();
        private string base64IMG="";
        public RegistFacesWindow(int eid)
        {
            this.Eid = eid;
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(FaceTick);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
            string[] s = MultimediaUtil.VideoInputNames;
            if (s.Length == 0)
            {
                MessageBox.Show("未检测到摄像头");
            }
            else
            {
                aceAdd.VideoCaptureSource = s[0];
            }
            registFaces = new RegistFacesViewModel(eid);
            this.DataContext = registFaces;
        }

        private void FaceTick(object sender, EventArgs e)
        {
            UploadFaceData();
        }
        public async void UploadFaceData()
        {
            base64IMG = aceAdd.GetCameraImg();
            var info = await Task.Run(() =>
            {
                return faceBLL.CheckFace(base64IMG);
            });
            if (Convert.ToInt32(info["error_code"])==0)
            {
                await Task.Run(() =>
                {
                    faceBLL.AddUser(base64IMG, Eid, "User");
                    registFaces.ProcessNum++;
                });
            }
        }

        private async void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (registFaces.ProcessNum==4)
            {
                timer.Stop();
                await Task.Delay(200);
                await this.ShowMessageAsync("提示", "信息添加完成!");
                this.Close();
            }
        }
    }
}
