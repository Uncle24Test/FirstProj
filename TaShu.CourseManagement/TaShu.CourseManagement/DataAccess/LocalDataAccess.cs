using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using TaShu.CourseManagement.DataAccess.DataEntity;

namespace TaShu.CourseManagement.DataAccess
{
    public class LocalDataAccess
    {
        private static LocalDataAccess instance;
        private LocalDataAccess() { }

        public static LocalDataAccess GetInstance()
        {
            return instance ?? (instance = new LocalDataAccess());
        }


        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapter;

        private bool DBConnection()
        {
            if (conn == null)
            {
                conn = new SqlConnection("");
            }
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private void Dispose()
        {
            if (adapter != null)
            {
                adapter.Dispose();
                adapter = null;
            }

            if (comm != null)
            {
                comm.Dispose();
                comm = null;
            }

            if (conn != null)
            {
                conn.Dispose();
                conn = null;
            }
        }

        public UserEntity CheckUserInfo(string name, string pwd)
        {
            //正常应该使用加密过的密码去数据库查询,或者使用EF
            //string MD5pwd = MD5Provider.GetMD5($"{name}@{pwd}");
            //string sql = "select * from users where name = @name and password = @password";

            //Task.Run(() =>
            //{
            //Thread.Sleep(TimeSpan.FromSeconds(2));
            if (name.Equals("他二十四叔") && pwd.Equals("123456"))
            {
                return new UserEntity { UserName = name, PassWord = pwd, RealName = "真·他二十四叔", Gender = 1, Avatar = "../Assets/Images/user.png" };
            }
            if (name.Equals("他二十四姨") && pwd.Equals("123456"))
            {
                return new UserEntity { UserName = name, PassWord = pwd, RealName = "真·他二十四姨", Gender = 2, Avatar = "../Assets/Images/user.png" };
            }
            //});
            return null;
        }

    }
}
