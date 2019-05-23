using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 人脸识别考勤系统.Helper;
using 人脸识别考勤系统.Model;

namespace 人脸识别考勤系统.DAL
{
    public class DepartmentDal
    {
        public ObservableCollection<Department> GetDepartments()
        {
            ObservableCollection<Department> lists = new ObservableCollection<Department>();
            string sql = "select a.*,b.DemployeeNums from DepartmentTable a left join (select EdepartId,count(*) DemployeeNums from EmployeeTable group by EdepartId) b on a.Did=b.EdepartId";
            DataTable dt = SQLHelper.GetDataTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                lists.Add(new Department
                {
                    Did = Convert.ToInt32(row["Did"]),
                    Dname = row["Dname"].ToString(),
                    Dintroduce = row["Dintroduce"].ToString(),
                    DemployeeNums= row["DemployeeNums"].Equals(DBNull.Value)?0:Convert.ToInt32(row["DemployeeNums"])
                });
            }
            return lists;
        }

        public int DeleteDepartment(Department dp)
        {
            string sql = "delete from DepartmentTable where Did=" + dp.Did;
            return SQLHelper.ExecuteNonQuery(sql);
        }

        public int UpdateDepartment(Department dp)
        {
            string sql = "update DepartmentTable set Dname=@name,Dintroduce=@introduce where Did=@id";
            SqlParameter[] ps = new SqlParameter[]
            {
                new SqlParameter("@id",dp.Did),
                new SqlParameter("@name",dp.Dname),
                new SqlParameter("@introduce",dp.Dintroduce),
            };
            return SQLHelper.ExecuteNonQuery(sql, ps);
        }

        public int InserDepartment(Department dp)
        {
            string sql = "insert into DepartmentTable (Did,Dname,Dintroduce) values(@id,@name,@introduce)";
            SqlParameter[] ps = new SqlParameter[]
            {
                new SqlParameter("@id",dp.Did),
                new SqlParameter("@name",dp.Dname),
                new SqlParameter("@introduce",dp.Dintroduce),
            };
            return SQLHelper.ExecuteNonQuery(sql, ps);
        }

        public int GetNewId()
        {
            string sql = "select Max(Did) from DepartmentTable";
            var dbresult = SQLHelper.ExecuteScalar(sql);
            int id = dbresult.Equals(DBNull.Value) ? -1 : Convert.ToInt32(dbresult);
            return id + 1;
        }
    }
}
