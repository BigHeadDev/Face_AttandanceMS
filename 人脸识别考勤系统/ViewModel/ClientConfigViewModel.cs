using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using 人脸识别考勤系统.Helper;
using 人脸识别考勤系统.Model;

namespace 人脸识别考勤系统.ViewModel
{
    public class ClientConfigViewModel:ViewModelBase
    {
        private RelayCommand imgChangeCommand
        {
            get;
            set;
        }
        public RelayCommand ImgChangeCommand
        {
            get
            {
                if (imgChangeCommand == null)
                    imgChangeCommand = new RelayCommand(()=>ImgChange());
                return imgChangeCommand;
            }
        }
        private void ImgChange()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\User\cy4486\Music";
            ofd.Filter = "图片文件|*.jpg;*.png;*.bmp";
            ofd.Multiselect = false;
            ofd.Title = "请选择LOGO图片";
            ofd.ShowDialog();
            //获得对话框的所有文件
            string path = ofd.FileName;
            if (path!="")
            {
                Clientcfg.ImgSrc = path;
            }
            
        }
        private RelayCommand themeChangeCommand
        {
            get;
            set;
        }
        public RelayCommand ThemeChangeCommand
        {
            get
            {
                if (themeChangeCommand == null)
                    themeChangeCommand = new RelayCommand(() => ThemeChange());
                return themeChangeCommand;
            }
        }

        private void ThemeChange()
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            colorDialog.ShowHelp = true;
            //初始化当前文本框中的字体颜色，  
            colorDialog.Color = Color.FromName(Clientcfg.ThemeColor);
            //当用户在ColorDialog对话框中点击"确定"按钮  
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string colorname = colorDialog.Color.Name;
                Clientcfg.ThemeColor = colorname.Length==8 ? "#" + colorname.Substring(2, 6) : colorname;
            }
        }

        private ClientConfig clientcfg;
        public ClientConfig Clientcfg
        {
            get { return clientcfg; }
            set
            {
                clientcfg = value;
                RaisePropertyChanged("Clientcfg");
            }
        }
        public ClientConfigViewModel()
        {
            Clientcfg = ConfigHelper.GetClientConfig();
        }


    }
}
