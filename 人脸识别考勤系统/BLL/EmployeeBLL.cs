using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 人脸识别考勤系统.DAL;
using 人脸识别考勤系统.Model;

namespace 人脸识别考勤系统.BLL
{
    public class EmployeeBLL
    {
        public EmployeeDal employeeDal = new EmployeeDal();
        public ObservableCollection<Employee> GetEmployees(Dictionary<string,string> dic1,Dictionary<string,string> dic2)
        {
            Dictionary<string,string> dic3 = dic1.Concat(dic2).ToDictionary(k => k.Key, v => v.Value);
            return employeeDal.GetEmployees(dic3);
        }
        public int GetNewId()
        {
            return employeeDal.GetNewId();
        }
        public bool InsertEmployee(Employee ep)
        {
            return employeeDal.InsertEmployee(ep) > 0;
        }

        public ObservableCollection<Rank> GetRanks()
        {
            return employeeDal.GetRanks();
        }

        public bool UpdateEmployee(Employee ep)
        {
            return employeeDal.UpdateEmployee(ep) > 0;
        }
        public Employee GetEmployeeById(string id)
        {
            return employeeDal.GetEmployeeById(id);
        }
        public bool SignById(string id)
        {
            return employeeDal.SignById(id)>0;
        }

        public bool DeleteEmployee(Employee ep)
        {
            return employeeDal.DeleteEmployee(ep) > 0;
        }
        public bool Late(int id)
        {
            return employeeDal.Late(id.ToString())>0;
        }
        public bool Early(int id)
        {
            return employeeDal.Early(id.ToString())>0;
        }
    }
}
