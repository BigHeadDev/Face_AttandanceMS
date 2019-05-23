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
    public class EmployeeDal
    {
        public ObservableCollection<Employee> GetEmployees(Dictionary<string,string> keyValues)
        {
            ObservableCollection<Employee> lists = new ObservableCollection<Employee>();
            string sql = "select E.*,D.Dname from EmployeeTable AS E left outer join departmentTable AS D on E.EdepartId=D.Did where E.EdepartId>=0";
            if (keyValues.Count > 0)
            {
                foreach (var pair in keyValues)
                {
                    sql += " and " + pair.Key + " like  '%" + pair.Value + "%'";
                }
            }
            DataTable dt= SQLHelper.GetDataTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                lists.Add(new Employee
                {
                    Eid = Convert.ToInt32(row["Eid"]),
                    EdepartId=Convert.ToInt32(row["EdepartId"]),
                    Ename = row["Ename"].ToString(),
                    EdepartName = row["Dname"].ToString(),
                    Esex = Convert.ToInt32(row["Esex"]),
                    EattendanceTimes = Convert.ToInt32(row["EattendanceTimes"]),
                    Ebirthday = Convert.ToDateTime(row["Ebirthday"]).ToShortDateString(),
                    ElastSignTime=row["ElastSignTime"].Equals(DBNull.Value)? "": Convert.ToDateTime(row["ElastSignTime"]).ToString()
                });
            }
            return lists;
        }

        public int DeleteEmployee(Employee ep)
        {
            string sql = "delete from EmployeeTable where Eid = "+ep.Eid;
            return SQLHelper.ExecuteNonQuery(sql);
        }
        public int UpdateEmployee(Employee ep)
        {
            string sql = "update EmployeeTable set Ename=@name,Esex=@sex,Ebirthday=@birthday,EdepartId=@departId where Eid=@id";
            SqlParameter[] ps = new SqlParameter[]
            {
                new SqlParameter("@id",ep.Eid),
                new SqlParameter("@name",ep.Ename),
                new SqlParameter("@sex",ep.Esex),
                new SqlParameter("@birthday",ep.Ebirthday.Split(new char[]{' '})[0]),
                new SqlParameter("@departId",ep.EdepartId)
            };
            return SQLHelper.ExecuteNonQuery(sql, ps);
        }
        public int GetNewId()
        {
            string sql = "select Max(Eid) from EmployeeTable";
            var dbresult = SQLHelper.ExecuteScalar(sql);
            int id = dbresult.Equals(DBNull.Value)?9999: Convert.ToInt32(dbresult);
            return id+1;
        }
        public int InsertEmployee(Employee ep)
        {
            string sql= "insert into EmployeeTable (Eid,Ename,Esex,Ebirthday,EdepartId) values(@id,@name,@sex,@birthday,@departId)";
            SqlParameter[] ps = new SqlParameter[]
            {
                new SqlParameter("@id",ep.Eid),
                new SqlParameter("@name",ep.Ename),
                new SqlParameter("@sex",ep.Esex),
                new SqlParameter("@birthday",ep.Ebirthday.Split(new char[]{' ' })[0]),
                new SqlParameter("@departId",ep.EdepartId)
            };
            return SQLHelper.ExecuteNonQuery(sql, ps);
        }
        public Employee GetEmployeeById(string id)
        {
            Employee ep;
            string sql = "select * from EmployeeTable where Eid="+id;
            DataTable dt = SQLHelper.GetDataTable(sql);
            if (dt.Rows.Count>0)
            {
                ep = new Employee
                {
                    Eid = Convert.ToInt32(dt.Rows[0][0]),
                    Ename = dt.Rows[0][1].ToString(),
                    Esex = Convert.ToInt32(dt.Rows[0][2]),
                    Ebirthday = Convert.ToDateTime(dt.Rows[0][3]).ToShortDateString(),
                    EattendanceTimes = Convert.ToInt32(dt.Rows[0][4]), 
                    ElastSignTime = dt.Rows[0][5].Equals(DBNull.Value) ? "" : Convert.ToDateTime(dt.Rows[0][5]).ToString(),
                    EdepartId = Convert.ToInt32(dt.Rows[0][6])                  
                };
            }
            else
            {
                ep = null;
            }
            return ep;
        }
        public int SignById(string id)
        {
            string sql = "update EmployeeTable set EattendanceTimes=EattendanceTimes+1,ElastSignTime=@now where Eid=@id";
            SqlParameter[] ps = new SqlParameter[]
            {
                new SqlParameter("@now",DateTime.Now),
                new SqlParameter("@id",id)
            };
            return SQLHelper.ExecuteNonQuery(sql,ps);
        }
        public ObservableCollection<Rank> GetRanks()
        {
            ObservableCollection<Rank> lists = new ObservableCollection<Rank>();
            string sql = "select row_number() over (order by (EattendanceTimes*10-EearlyTimes*3-ElateTimes*3) desc) as Rrank,Ename,EattendanceTimes,ElateTimes,EearlyTimes,(EattendanceTimes*10-EearlyTimes*3-ElateTimes*3) as Rscore from EmployeeTable order by Rscore desc";
            DataTable dt = SQLHelper.GetDataTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                lists.Add(new Rank
                {
                    Rname = row["Ename"].ToString(),
                    RsignTimes = Convert.ToInt32(row["EattendanceTimes"]),
                    RlateTimes = Convert.ToInt32(row["ElateTimes"]),
                    RearlyTimes = Convert.ToInt32(row["EearlyTimes"]),
                    Rscore = Convert.ToInt32(row["Rscore"]),
                    Rrank = Convert.ToInt32(row["Rrank"])   
                });
            }
            return lists;
        }
        public int Late(string id)
        {
            string sql = "update EmployeeTable set ElateTimes=ElateTimes+1 where Eid=@id";
            SqlParameter[] ps = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            return SQLHelper.ExecuteNonQuery(sql, ps);
        }
        public int Early(string id)
        {
            string sql = "update EmployeeTable set EearlyTimes=EearlyTimes+1 where Eid=@id";
            SqlParameter[] ps = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            return SQLHelper.ExecuteNonQuery(sql, ps);
        }
    }
}
