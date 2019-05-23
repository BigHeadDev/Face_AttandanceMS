using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using 人脸识别考勤系统.BLL;
using 人脸识别考勤系统.Model;

namespace 人脸识别考勤系统.ViewModel
{
    public class EmployeeInfoViewModel:ViewModelBase
    {
        public Employee employeeModel { get; set; }
        private RelayCommand<bool> addEmployeeCommand;
        public EmployeeBLL employeeBLL = new EmployeeBLL();
        public EmployeeInfoViewModel()
        {
            if (IsInDesignMode)
            {
                employeeModel = new Employee { Eid = 1, Ename = "test", Ebirthday = "1997-5-5", EattendanceTimes = 1,EdepartId=1, EdepartName = "技术部", ElastSignTime = "2019-1-1", Esex = 1 };
            }
            else
            {
                int id = employeeBLL.GetNewId();
                employeeModel = new Employee
                {
                    Eid = id
                };
            }
        }
        public EmployeeInfoViewModel(Employee ep)
        {
            employeeModel = ep;
        }
        public RelayCommand<bool> AddEmployeeCommand
        {
            get
            {
                if (addEmployeeCommand==null)
                {
                    addEmployeeCommand = new RelayCommand<bool>(x => AddEmployee(employeeModel));
                }
                return addEmployeeCommand;
            }
        }

        private bool AddEmployee(Employee employeeModel)
        {
            return employeeBLL.InsertEmployee(employeeModel);
        }
    }
}
