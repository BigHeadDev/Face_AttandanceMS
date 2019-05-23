using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 人脸识别考勤系统.BLL;
using 人脸识别考勤系统.Model;

namespace 人脸识别考勤系统.ViewModel
{
    public class DepartmentInfoViewModel:ViewModelBase
    {
        public Department departmentModel { get; set; }
        public DepartmentBLL departmentBLL = new DepartmentBLL();
        public DepartmentInfoViewModel()
        {
            if (IsInDesignMode)
            {
                departmentModel = new Department { Did=1,Dname="技术部",DemployeeNums=10,Dintroduce="技术部介绍" };
            }
            else
            {
                int id = departmentBLL.GetNewId();
                departmentModel = new Department
                {
                    Did = id,
                    DemployeeNums=0
                };
            }
        }
        public DepartmentInfoViewModel(Department dm)
        {
            departmentModel = dm;
        }
    }
}
