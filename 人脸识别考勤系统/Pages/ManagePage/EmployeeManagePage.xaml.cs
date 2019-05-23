using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using 人脸识别考勤系统.Helper;
using 人脸识别考勤系统.Model;
using 人脸识别考勤系统.View;
using 人脸识别考勤系统.ViewModel;

namespace 人脸识别考勤系统.Pages.ManagePage
{
    /// <summary>
    /// EmployeeManagePage.xaml 的交互逻辑
    /// </summary>
    public partial class EmployeeManagePage : Page
    {
        public EmployeeManagePage()
        {
            InitializeComponent();
            MsgHelper.RefreshComboxEvent += MsgHelper_RefreshComboxEvent;
            MsgHelper_RefreshComboxEvent();
        }

        private void MsgHelper_RefreshComboxEvent()
        {
            cboxDepart.ItemsSource = new DepartmentManageViewModel().DepartmentsModel;
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow();
            addEmployeeWindow.ShowDialog();
        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            cboxDepart.SelectedIndex = -1;
            txtKeyWords.Text = String.Empty;
        }
        private void dg_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var ep = (sender as DataGrid).SelectedItem as Employee;
            if (ep!=null)
            {
                AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow(ep);
                addEmployeeWindow.ShowDialog();
            }
            
        }
    }
}
