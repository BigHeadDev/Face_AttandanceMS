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
    public class DepartmentBLL
    {
        public DepartmentDal departmentDal = new DepartmentDal();
        public ObservableCollection<Department> GetDepartments()
        {
            return departmentDal.GetDepartments();
        }
        public int GetNewId()
        {
            return departmentDal.GetNewId();
        }

        public bool InsertDepartment(Department dp)
        {
            return departmentDal.InserDepartment(dp)>0;
        }

        public bool UpdateDepartment(Department dp)
        {
            return departmentDal.UpdateDepartment(dp)>0;
        }

        public bool DeleteDepartment(Department dp)
        {
            return departmentDal.DeleteDepartment(dp)>0;
        }
    }
}
