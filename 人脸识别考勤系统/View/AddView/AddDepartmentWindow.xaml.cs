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
    /// DepartmentInfo.xaml 的交互逻辑
    /// </summary>
    public partial class AddDepartmentWindow : MetroWindow
    {
        public bool isAddNewDepart = true;
        public DepartmentBLL departmentBLL = new DepartmentBLL();
        public DepartmentInfoViewModel DepartmentInfo;
        public AddDepartmentWindow()
        {
            DepartmentInfo = new DepartmentInfoViewModel();
            InitializeComponent();
            this.DataContext = DepartmentInfo;
        }
        public AddDepartmentWindow(Department dm)
        {
            isAddNewDepart = false;
            DepartmentInfo = new DepartmentInfoViewModel(dm);
            InitializeComponent();
            this.DataContext = DepartmentInfo;
        }

        private async void SaveDepartment_Clcik(object sender, RoutedEventArgs e)
        {
            if (isAddNewDepart)
            {
                if (departmentBLL.InsertDepartment(DepartmentInfo.departmentModel))
                {
                    this.Hide();
                    MsgHelper.RefreshDataGrid();
                    MsgHelper.RefreshCombox();
                    await this.ShowMessageAsync("提示","添加成功!");
                    this.Close();
                }
                else
                {
                    await this.ShowMessageAsync("提示", "修改失败");
                }
            }
            else
            {
                if (departmentBLL.UpdateDepartment(DepartmentInfo.departmentModel))
                {
                    this.Hide();
                    MsgHelper.RefreshDataGrid();
                    MsgHelper.RefreshCombox();
                    await this.ShowMessageAsync("提示", "修改成功!!");
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
