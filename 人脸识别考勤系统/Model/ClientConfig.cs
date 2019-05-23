using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 人脸识别考勤系统.Helper;
using 人脸识别考勤系统.Properties;

namespace 人脸识别考勤系统.Model
{
    public class ClientConfig: ObservableObject
    {
        private string imgSrc;
        public string ImgSrc
        {
            get { return imgSrc; }
            set
            {
                Settings.Default.ImgSrc = value;
                Settings.Default.Save();
                imgSrc = value;
                RaisePropertyChanged("ImgSrc");
            }
        }

        private string companyName;
        public string CompanyName
        {
            get {
                return companyName;
            }
            set
            {
                Settings.Default.CompanyName = value;
                Settings.Default.Save();
                companyName = value;
                RaisePropertyChanged("CompanyName");
            }
        }

        private string themeColor;
        public string ThemeColor
        {
            get { return themeColor; }
            set
            {
                Settings.Default.ThemeColor = Color.FromName(value);
                Settings.Default.Save();
                themeColor = value;
                RaisePropertyChanged("ThemeColor");
            }
        }

        private bool signSwitch;
        public bool SignSwitch
        {
            get { return signSwitch; }
            set
            {
                Settings.Default.SignSwitch = value;
                Settings.Default.Save();
                signSwitch = value;
                RaisePropertyChanged("SignSwitch");
            }
        }

        private bool rankSwitch;
        public bool RankSwitch
        {
            get { return rankSwitch; }
            set
            {
                Settings.Default.RankSwitch = value;
                Settings.Default.Save();
                rankSwitch = value;
                RaisePropertyChanged("RankSwitch");
            }
        }

        private bool weatherSwitch;
        public bool WeatherSwitch
        {
            get { return weatherSwitch; }
            set
            {
                Settings.Default.WeatherSwitch = value;
                Settings.Default.Save();
                weatherSwitch = value;
                RaisePropertyChanged("WeatherSwitch");
            }
        }

        private string city;
        public string City
        {
            get { return city; }
            set
            {
                Settings.Default.City = value;
                Settings.Default.Save();
                try
                {
                    MsgHelper.RefreshWeather();
                }
                catch
                {

                }
                city = value;
                RaisePropertyChanged("City");
            }
        }

        private bool notifySwitch;
        public bool NotifySwitch
        {
            get { return notifySwitch; }
            set
            {
                Settings.Default.NotifySwitch = value;
                Settings.Default.Save();
                notifySwitch = value;
                RaisePropertyChanged("NotifySwitch");
            }
        }

        private bool birthdaySwitch ;
        public bool BirthdaySwitch
        {
            get { return birthdaySwitch; }
            set
            {
                Settings.Default.BirthdaySwitch = value;
                Settings.Default.Save();
                birthdaySwitch = value;
                RaisePropertyChanged("BiirthdaySwitch");
            }
        }

        private bool holidaySwitch;
        public bool HolidayCgSwitch
        {
            get { return holidaySwitch; }
            set
            {
                Settings.Default.HolidayCgSwitch = value;
                Settings.Default.Save();
                holidaySwitch = value;
                RaisePropertyChanged("HolidayCgSwitch");
            }
        }

        private bool looksSwitch;
        public bool LooksSwitch
        {
            get { return looksSwitch; }
            set
            {
                Settings.Default.LooksSwitch = value;
                Settings.Default.Save();
                looksSwitch = value;
                RaisePropertyChanged("LooksSwitch");
            }
        }

        private bool timeLimitSwitch;
        public bool TimeLimitSwitch
        {
            get { return timeLimitSwitch; }
            set
            {
                Settings.Default.TimeLimitSwitch = value;
                Settings.Default.Save();
                timeLimitSwitch = value;
                RaisePropertyChanged("TimeLimitSwitch");
            }
        }

        private int lateTime;
        public int LateTime
        {
            get { return lateTime; }
            set
            {
                Settings.Default.LateTime = value;
                Settings.Default.Save();
                lateTime = value;
                RaisePropertyChanged("LateTime");
            }
        }

        private int earlyTime;
        public int EarlyTime
        {
            get { return earlyTime; }
            set
            {
                Settings.Default.EarlyTime = value;
                Settings.Default.Save();
                earlyTime = value;
                RaisePropertyChanged("EarlyTime");
            }
        }
    }
}
