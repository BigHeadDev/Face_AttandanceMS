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
using 人脸识别考勤系统.View;

namespace 人脸识别考勤系统.ViewModel
{
    public class EmployeeManageViewModel : ViewModelBase
    {
        FaceBLL faceBLL = new FaceBLL();
        private RelayCommand<object> addFaceCommand
        {
            get;
            set;
        }
        public RelayCommand<object> AddFaceCommand
        {
            get
            {
                if (addFaceCommand == null)
                    addFaceCommand = new RelayCommand<object>(x => AddFace(x));
                return addFaceCommand;
            }
        }
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
        public RelayCommand<int> SelectionChangedCommand
        {
            get;
            set;
        }
        public RelayCommand<string> TextChangedCommand
        {
            get;
            set;
        }
        public Dictionary<string, string> DepartmentParameters = new Dictionary<string, string>();
        public Dictionary<string, string> NameParameters = new Dictionary<string, string>();
        private ObservableCollection<Employee> employeeModelList;
        public ObservableCollection<Employee> EmployeeModelList
        {
            get { return employeeModelList; }
            set
            {
                employeeModelList = value;
                RaisePropertyChanged("EmployeeModelList");
            }
        }
        public EmployeeBLL employeeBLL = new EmployeeBLL();
        public EmployeeManageViewModel()
        {
            SelectionChangedCommand = new RelayCommand<int>(ComboxSelectionChanged);
            TextChangedCommand = new RelayCommand<string>(TextChanged);

            MsgHelper.RefreshDataGridEvent += MsgHelper_RefreshDataGridEvent;
            if (IsInDesignMode)
            {

            }
            else
            {
                EmployeeModelList = employeeBLL.GetEmployees(DepartmentParameters, NameParameters);
            }
        }

        private void Delete(object obj)
        {
            var ep = obj as Employee;
            MessageBoxResult confirmToDel = MessageBox.Show("确认要删除员工" + ep.Ename + "吗?", "删除提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirmToDel == MessageBoxResult.Yes)
            {
                if (faceBLL.DeleteUser(ep.Eid))
                {
                    MessageBox.Show("人脸删除成功!");
                }
                else
                {
                    MessageBox.Show("人脸删除失败!");
                }
                if (employeeBLL.DeleteEmployee(ep))
                {
                    EmployeeModelList.Remove(ep);
                    MessageBox.Show("用户信息删除成功!");
                }
                else
                {
                    MessageBox.Show("用户信息删除失败!");
                }
                MsgHelper.RefreshDataGrid();
            }
        }
        private void AddFace(object x)
        {
            int id = (x as Employee).Eid;
            RegistFacesWindow registFacesWindow = new RegistFacesWindow(id);
            registFacesWindow.ShowDialog();
        }

        private void TextChanged(string text)
        {
            if (text == "")
            {
                NameParameters.Clear();
            }
            else
            {
                NameParameters.Clear();
                NameParameters.Add("E.Ename", text);
            }
            EmployeeModelList = employeeBLL.GetEmployees(DepartmentParameters, NameParameters);
        }

        private void ComboxSelectionChanged(int index)
        {
            if (index == -1)
            {
                DepartmentParameters.Clear();
            }
            else
            {
                DepartmentParameters.Clear();
                DepartmentParameters.Add("E.EdepartId", index.ToString());
            }
            EmployeeModelList = employeeBLL.GetEmployees(DepartmentParameters, NameParameters);
        }

        private void MsgHelper_RefreshDataGridEvent()
        {
            EmployeeModelList = employeeBLL.GetEmployees(DepartmentParameters, NameParameters);
        }
    }
}
