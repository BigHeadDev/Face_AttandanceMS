using MahApps.Metro.Controls;
using System;
using System.Windows;
using WPFMediaKit.DirectShow.Controls;
using 人脸识别考勤系统.BLL;
using 人脸识别考勤系统.Helper;
using 人脸识别考勤系统.Model;
using System.Windows.Threading;
using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;
using System.Threading;
using 人脸识别考勤系统.Properties;
using System.Windows.Controls.Primitives;

namespace 人脸识别考勤系统.View
{
    /// <summary>
    /// CameraWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SignFacesWindow : MetroWindow
    {
        private DispatcherTimer timer;
        public static string base64IMG = "";
        public EmployeeBLL employeeBLL = new EmployeeBLL();
        public FaceBLL faceBLL = new FaceBLL();
        Weather weather = new Weather();
        public SignFacesWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(FaceTick);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
            string[] s = MultimediaUtil.VideoInputNames;
            if (s.Length == 0)
            {
                this.ShowMessageAsync("提示","未检测到摄像头");
            }
            else
            {
                aceAdd.VideoCaptureSource = s[0];
            }
            string wt=NetHelper.GetHtml("http://timor.tech/api/holiday/info/" + DateTime.Now.Date.ToString("yyyy-MM-dd"));
            try
            {
                weather = new JsonHelper().GetView<Weather>(wt);
            }
            catch
            {

            }
            finally
            {
                weather.holiday = null;
            }
        }

        private void FaceTick(object sender, EventArgs e)
        {
            CheckFace();
        }

        //获取ID
        public string GetFaceID()
        {
            return faceBLL.SearchId(base64IMG, "User");
        }
        public async void CheckFace()
        {
            base64IMG = aceAdd.GetCameraImg();//获取摄像头图像
            if (base64IMG=="")
            {
                return;
            }
            var info = await Task.Run(() =>
            {
                return faceBLL.CheckFace(base64IMG);
            });
            if (Convert.ToInt32(info["error_code"]) == 0)//识别到人了!
            {
                timer.Stop();
                var id = await Task.Run(()=>
                {
                    return faceBLL.SearchId(base64IMG, "User");
                });//根据图像在百度查询id
                if (id != ""&&id!=null)//识别到数据库中有id的人了!
                {
                    Employee result = employeeBLL.GetEmployeeById(id);//根据ID拿到人了!
                    if (result.ElastSignTime==""||(DateTime.Now-Convert.ToDateTime(result.ElastSignTime)).TotalHours>6)
                    {
                        employeeBLL.SignById(id);//签到!
                        string msg = "签到成功!!";
                        string title = "欢迎您 " + result.Ename + " 本次是第" + (result.EattendanceTimes+1) + "次签到";
                        if (Settings.Default.LooksSwitch)
                        {
                            switch (info["result"]["face_list"][0]["expression"]["type"].ToString())
                            {
                                case "smile":
                                    msg += "\r\n你的笑容就像山间轻柔的风将我心田融化";
                                    break;
                                case "laugh":
                                    msg += "\r\n你笑啥呢，这么开心！周围人都被你感染开心的";
                                    break;
                                case "none":
                                    msg += "\r\n希望你能够开心一点，难过也是一天，开心也是一天。为什么不开心一点呢~";
                                    break;
                            }
                        }
                        if (Settings.Default.BirthdaySwitch)
                        {
                            if (Convert.ToDateTime(result.Ebirthday).ToString("MM-dd") == DateTime.Now.ToString("MM-dd"))
                            {
                                msg += "\r\n 生日快乐哦~今天吃好喝好~祝福你大寿星！！";
                            }
                        }
                        if (Settings.Default.HolidayCgSwitch)
                        {
                            if (weather.holiday != null)
                            {
                                msg += "\r\n 今天是" + weather.holiday.name + "，加班之余享受节日的快乐哦！";
                            }
                        }
                        if (Settings.Default.TimeLimitSwitch)
                        {
                            var hour = DateTime.Now.Hour;
                            if (hour < 12)//早上
                            {
                                if (hour >= Settings.Default.LateTime)
                                {
                                    title = "【迟到】" + title;
                                    employeeBLL.Late(result.Eid);
                                }
                            }
                            else
                            {
                                if (hour < Settings.Default.EarlyTime)
                                {
                                    title = "【早退】" + title;
                                    employeeBLL.Early(result.Eid);
                                }
                            }
                        }
                        MsgHelper.RefreshDataGrid();
                        await this.ShowMessageAsync(title, msg);
                    }
                    else
                    {
                        await this.ShowMessageAsync("温馨提示","还没到下次签到时间!");
                    }
                }
                await Task.Delay(1000);
                timer.Start();
            }
        }
    }
}
