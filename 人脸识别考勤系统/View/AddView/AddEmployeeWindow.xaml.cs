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
using 人脸识别考勤系统.BLL;
using 人脸识别考勤系统.Helper;
using 人脸识别考勤系统.Model;
using 人脸识别考勤系统.ViewModel;

namespace 人脸识别考勤系统.View
{
    /// <summary>
    /// AddEmployeeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AddEmployeeWindow : MetroWindow
    {
        EmployeeInfoViewModel employeeInfo { get; set; }
        public bool isAddNewUser = true;
        public EmployeeBLL employeeBLL = new EmployeeBLL();
        public AddEmployeeWindow()
        {
            InitializeComponent();
            employeeInfo = new EmployeeInfoViewModel();
            this.DataContext = employeeInfo;
            cboxDepart.ItemsSource = new DepartmentManageViewModel().departmentsModel;
        }
        public AddEmployeeWindow(Employee ep)
        {
            InitializeComponent();
            isAddNewUser = false;
            employeeInfo = new EmployeeInfoViewModel(ep);
            this.DataContext = employeeInfo;
            cboxDepart.ItemsSource = new DepartmentManageViewModel().departmentsModel;
        }
        private async void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            //点击添加
            if (isAddNewUser)
            {
                if (employeeBLL.InsertEmployee(employeeInfo.employeeModel))
                {
                    MsgHelper.RefreshDataGrid();
                    this.Hide();
                    RegistFacesWindow registFacesWindow = new RegistFacesWindow(employeeInfo.employeeModel.Eid);
                    registFacesWindow.ShowDialog();
                    this.Close();
                }
                else
                {
                    await this.ShowMessageAsync("提示", "添加失败!");
                }
            }
            else//修改
            {
                if (employeeBLL.UpdateEmployee(employeeInfo.employeeModel))
                {
                    await this.ShowMessageAsync("提示", "修改成功!");
                    MsgHelper.RefreshDataGrid();
                    this.Close();
                }
                else
                {
                    await this.ShowMessageAsync("提示", "修改失败!");
                }
            }
        }
    }
}
