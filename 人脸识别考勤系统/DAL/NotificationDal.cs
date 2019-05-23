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
    class NotificationDal
    {
        public ObservableCollection<Notification> GetNotifications()
        {
            ObservableCollection<Notification> lists = new ObservableCollection<Notification>();
            string sql = "select * from NotificationTable";
            DataTable dt = SQLHelper.GetDataTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                lists.Add(new Notification
                {
                    Nid=Convert.ToInt32(row["Nid"]),
                    Ntitle=row["Ntitle"].ToString(),
                    Ncontent=row["Ncontent"].ToString(),
                    NisImportant=Convert.ToBoolean(row["NisImportant"]),
                    Ntime=row["Ntime"].ToString()
                });
            }
            return lists;
        }

        public int DeleteNotification(Notification nf)
        {
            string sql = "delete from NotificationTable where Nid=" + nf.Nid;
            return SQLHelper.ExecuteNonQuery(sql);
        }

        public int InsertNotification(Notification nf)
        {
            string sql = "insert into NotificationTable (Nid,Ntitle,Ncontent,NisImportant,Ntime) values(@id,@title,@content,@isImportant,@time)";
            SqlParameter[] ps = new SqlParameter[]
            {
                new SqlParameter("@id",nf.Nid),
                new SqlParameter("@title",nf.Ntitle),
                new SqlParameter("@content",nf.Ncontent),
                new SqlParameter("@isImportant",nf.NisImportant),
                new SqlParameter("@time",Convert.ToDateTime(nf.Ntime))
            };
            return SQLHelper.ExecuteNonQuery(sql, ps);
        }

        public int UpdateNotification(Notification nf)
        {
            string sql = "update NotificationTable set Ntitle=@title,Ncontent=@content,NisImportant=@isImportant,Ntime=@time where Nid=@id";
            SqlParameter[] ps = new SqlParameter[]
            {
                new SqlParameter("@id",nf.Nid),
                new SqlParameter("@title",nf.Ntitle),
                new SqlParameter("@content",nf.Ncontent),
                new SqlParameter("@isImportant",nf.NisImportant),
                new SqlParameter("@time",Convert.ToDateTime(nf.Ntime))
            };
            return SQLHelper.ExecuteNonQuery(sql, ps);
        }

        public int GetNewId()
        {
            string sql = "select Max(Nid) from NotificationTable";
            var dbresult = SQLHelper.ExecuteScalar(sql);
            int id = dbresult.Equals(DBNull.Value) ? -1 : Convert.ToInt32(dbresult);
            return id + 1;
        }
    }
}
