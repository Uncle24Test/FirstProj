using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using TaShu.CourseManagement.DataAccess.DataEntity;
using TaShu.CourseManagement.Model;

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

        public List<CourseSeriesModel> GetCoursePlayRecord()
        {
            //select a.course_name,a.course_id,b.play_count,b.is_growing,b.growing_rate,c.platform_id from courses a
            //left join play_record b on a.course_id = b.course_id
            //left join platforms c on b.platform_id = c.platform_id
            //order by a.course_id,c.platform_id

            List<CourseSeriesModel> rList = new List<CourseSeriesModel>();
            #region 添加数据，模拟数据库
            rList.Add(new CourseSeriesModel
            {
                CourseName = "C#/.net架构师蜕变之他二十四叔",
                SeriesCollection = new LiveCharts.SeriesCollection
                 {
                     new PieSeries
                     {
                         Title="他大叔",
                         Values=new ChartValues<ObservableValue>{new ObservableValue(111) },
                          DataLabels=false
                     },
                    new PieSeries
                     {
                         Title="他二叔",
                         Values=new ChartValues<ObservableValue>{new ObservableValue(222) },
                          DataLabels=false
                     },
                    new PieSeries
                     {
                         Title="他三叔",
                         Values=new ChartValues<ObservableValue>{new ObservableValue(333) },
                          DataLabels=false
                     }
                 },
                SeriesList = new ObservableCollection<SeriesModel>
                 {
                     new SeriesModel
                     {
                          ChangeRate=70,
                          IsGrowing=true,
                          SeriesName="B站",
                          SeriesValue=161
                     },
                     new SeriesModel
                     {
                          ChangeRate=70,
                          IsGrowing=true,
                          SeriesName="B站",
                          SeriesValue=161
                     },
                     new SeriesModel
                     {
                          ChangeRate=70,
                          IsGrowing=true,
                          SeriesName="B站",
                          SeriesValue=161
                     },
                     new SeriesModel
                     {
                          ChangeRate=70,
                          IsGrowing=true,
                          SeriesName="B站",
                          SeriesValue=161
                     },
                     new SeriesModel
                     {
                          ChangeRate=70,
                          IsGrowing=false,
                          SeriesName="B站",
                          SeriesValue=161
                     }
                 }
            });
            rList.Add(new CourseSeriesModel
            {
                CourseName = "Java架构师蜕变之他二十四叔",
                SeriesCollection = new LiveCharts.SeriesCollection
                 {
                     new PieSeries
                     {
                         Title="他大叔",
                         Values=new ChartValues<ObservableValue>{new ObservableValue(111) },
                          DataLabels=false
                     },
                    new PieSeries
                     {
                         Title="他二叔",
                         Values=new ChartValues<ObservableValue>{new ObservableValue(222) },
                          DataLabels=false
                     },
                    new PieSeries
                     {
                         Title="他三叔",
                         Values=new ChartValues<ObservableValue>{new ObservableValue(333) },
                          DataLabels=false
                     }
                 },
                SeriesList = new ObservableCollection<SeriesModel>
                 {
                     new SeriesModel
                     {
                          ChangeRate=70,
                          IsGrowing=true,
                          SeriesName="B站",
                          SeriesValue=161
                     },
                     new SeriesModel
                     {
                          ChangeRate=70,
                          IsGrowing=true,
                          SeriesName="B站",
                          SeriesValue=161
                     },
                     new SeriesModel
                     {
                          ChangeRate=70,
                          IsGrowing=true,
                          SeriesName="B站",
                          SeriesValue=161
                     },
                     new SeriesModel
                     {
                          ChangeRate=70,
                          IsGrowing=true,
                          SeriesName="B站",
                          SeriesValue=161
                     },
                     new SeriesModel
                     {
                          ChangeRate=70,
                          IsGrowing=false,
                          SeriesName="B站",
                          SeriesValue=161
                     }
                 }
            });
            rList.Add(new CourseSeriesModel
            {
                CourseName = "Python架构师蜕变之他二十四叔",
                SeriesCollection = new LiveCharts.SeriesCollection
                 {
                     new PieSeries
                     {
                         Title="他大叔",
                         Values=new ChartValues<ObservableValue>{new ObservableValue(111) },
                          DataLabels=false
                     },
                    new PieSeries
                     {
                         Title="他二叔",
                         Values=new ChartValues<ObservableValue>{new ObservableValue(222) },
                          DataLabels=false
                     },
                    new PieSeries
                     {
                         Title="他三叔",
                         Values=new ChartValues<ObservableValue>{new ObservableValue(333) },
                          DataLabels=false
                     }
                 },
                SeriesList = new ObservableCollection<SeriesModel>
                 {
                     new SeriesModel
                     {
                          ChangeRate=70,
                          IsGrowing=true,
                          SeriesName="B站",
                          SeriesValue=161
                     },
                     new SeriesModel
                     {
                          ChangeRate=70,
                          IsGrowing=true,
                          SeriesName="B站",
                          SeriesValue=161
                     },
                     new SeriesModel
                     {
                          ChangeRate=70,
                          IsGrowing=true,
                          SeriesName="B站",
                          SeriesValue=161
                     },
                     new SeriesModel
                     {
                          ChangeRate=70,
                          IsGrowing=true,
                          SeriesName="B站",
                          SeriesValue=161
                     },
                     new SeriesModel
                     {
                          ChangeRate=70,
                          IsGrowing=false,
                          SeriesName="B站",
                          SeriesValue=161
                     }
                 }
            });
            rList.Add(new CourseSeriesModel
            {
                CourseName = "Python架构师蜕变之他二十四叔",
                SeriesCollection = new LiveCharts.SeriesCollection
                 {
                     new PieSeries
                     {
                         Title="他大叔",
                         Values=new ChartValues<ObservableValue>{new ObservableValue(111) },
                          DataLabels=false
                     },
                    new PieSeries
                     {
                         Title="他二叔",
                         Values=new ChartValues<ObservableValue>{new ObservableValue(222) },
                          DataLabels=false
                     },
                    new PieSeries
                     {
                         Title="他三叔",
                         Values=new ChartValues<ObservableValue>{new ObservableValue(333) },
                          DataLabels=false
                     }
                 },
                SeriesList = new ObservableCollection<SeriesModel>
                 {
                     new SeriesModel
                     {
                          ChangeRate=70,
                          IsGrowing=true,
                          SeriesName="B站",
                          SeriesValue=161
                     },
                     new SeriesModel
                     {
                          ChangeRate=70,
                          IsGrowing=true,
                          SeriesName="B站",
                          SeriesValue=161
                     },
                     new SeriesModel
                     {
                          ChangeRate=70,
                          IsGrowing=true,
                          SeriesName="B站",
                          SeriesValue=161
                     },
                     new SeriesModel
                     {
                          ChangeRate=70,
                          IsGrowing=true,
                          SeriesName="B站",
                          SeriesValue=161
                     },
                     new SeriesModel
                     {
                          ChangeRate=70,
                          IsGrowing=false,
                          SeriesName="B站",
                          SeriesValue=161
                     },
                     new SeriesModel
                     {
                          ChangeRate=70,
                          IsGrowing=false,
                          SeriesName="ABCDEFG站",
                          SeriesValue=161
                     }
                 }
            });
            #endregion
            return rList;
        }


        public List<string> GetTeachers()
        {
            //select real_name from users where is_teacher = 1
            List<string> rList = new List<string>();
            rList.Add("他大叔");
            rList.Add("他二叔");
            rList.Add("他三叔");
            rList.Add("他四叔");
            return rList;
        }

        //目前存在问题
        public List<string> GetTeachersAsync()
        {
            //会卡界面,需要用异步方法
            //return await Task.Run(() =>
            //{
            //    List<string> rList = new List<string>();
            //    Thread.Sleep(TimeSpan.FromSeconds(5));
            //    rList.Add("他大叔");
            //    rList.Add("他二叔");
            //    rList.Add("他三叔");
            //    rList.Add("他四叔");
            //    return rList;
            //});

            List<string> rList = new List<string>();
            Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                rList.Add("他大叔");
                rList.Add("他二叔");
                rList.Add("他三叔");
                rList.Add("他四叔");
            });
            return rList;
        }
    }
}
