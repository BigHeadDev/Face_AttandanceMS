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
using System.Windows.Navigation;
using System.Windows.Shapes;
using 人脸识别考勤系统.BLL;
using 人脸识别考勤系统.Model;
using 人脸识别考勤系统.View;
using 人脸识别考勤系统.ViewModel;

namespace 人脸识别考勤系统.Pages.ManagePage
{
    /// <summary>
    /// DepartmentManagePage.xaml 的交互逻辑
    /// </summary>
    public partial class DepartmentManagePage : Page
    {
        public DepartmentManagePage()
        {
            InitializeComponent();
        }
       
        private void AddDepartment_Click(object sender, RoutedEventArgs e)
        {
            AddDepartmentWindow addDepartmentWindow = new AddDepartmentWindow();
            addDepartmentWindow.ShowDialog();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AddDepartmentWindow addDepartmentWindow = new AddDepartmentWindow((sender as DataGrid).SelectedItem as Department);
            addDepartmentWindow.ShowDialog();
        }
    }
}
