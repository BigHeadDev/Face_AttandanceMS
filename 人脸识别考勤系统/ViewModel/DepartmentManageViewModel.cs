using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using 人脸识别考勤系统.BLL;
using 人脸识别考勤系统.Helper;
using 人脸识别考勤系统.Model;

namespace 人脸识别考勤系统.ViewModel
{
    public class DepartmentManageViewModel : ViewModelBase
    {
        private RelayCommand<object> deleteCommand
        {
            get;
            set;
        }
        public RelayCommand<object> DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                    deleteCommand = new RelayCommand<object>(x => Delete(x));
                return deleteCommand;
            }
        }

        private void Delete(object x)
        {
            var dp = x as Department;
            MessageBoxResult confirmToDel = MessageBox.Show("确认要删除部门" + dp.Dname + "吗?部门所在员工请自行转移或删除", "删除提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirmToDel == MessageBoxResult.Yes)
            {
                if (departmentBLL.DeleteDepartment(dp))
                {
                    DepartmentsModel.Remove(dp);
                    MessageBox.Show("部门信息删除成功!");
                    MsgHelper.RefreshCombox();
                }
                else
                {
                    MessageBox.Show("部门信息删除失败!");
                }
            }
        }

        public ObservableCollection<Department> departmentsModel;
        public ObservableCollection<Department> DepartmentsModel
        {
            get { return departmentsModel; }
            set
            {
                departmentsModel = value;
                RaisePropertyChanged("DepartmentsModel");
            }
        }
        public DepartmentBLL departmentBLL = new DepartmentBLL();
        public DepartmentManageViewModel()
        {
            MsgHelper.RefreshDataGridEvent += MsgHelper_RefreshDataGridEvent;
            if (IsInDesignMode)
            {
                DepartmentsModel.Add(new Department
                {
                    Did = 1,
                    Dname = "XX部门",
                    DemployeeNums = 12,
                    Dintroduce = "介绍"
                });
            }
            else
            {
                DepartmentsModel = departmentBLL.GetDepartments();
            }
        }

        private void MsgHelper_RefreshDataGridEvent()
        {
            DepartmentsModel = departmentBLL.GetDepartments();
        }
    }
}
