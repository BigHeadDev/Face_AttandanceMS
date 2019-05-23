using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 人脸识别考勤系统.Helper
{
    public static class SQLHelper
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["FaceAttendance"].ConnectionString;
        /// <summary>
        /// 执行删除,增加,修改(不需要返回具体数据的SQL)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql,params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(ps);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// 返回第一行数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(ps);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }
        //获取结果集
        public static DataTable GetDataTable(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                //适配器对象
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                //构建数据表，用于接收查询结果
                DataTable dt = new DataTable();
                //添加参数
                adapter.SelectCommand.Parameters.AddRange(ps);
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}
