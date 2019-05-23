using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace 人脸识别考勤系统.Converter
{
    public class ComboxEventArgsConverter : IEventArgsConverter
    {
        public object Convert(object value, object parameter)
        {
            var cb = parameter as ComboBox;
            return cb.SelectedIndex;
        }
    }
}
