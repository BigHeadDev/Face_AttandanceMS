using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;

namespace 人脸识别考勤系统.Converter
{
    public class TextBoxEventArgsConverter : IEventArgsConverter
    {
        public object Convert(object value, object parameter)
        {
            var tbox = parameter as TextBox;
            return tbox.Text;
        }
    }
}
