using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaShu.CourseManagement.Common;
using TaShu.CourseManagement.DataAccess;
using TaShu.CourseManagement.Model;

namespace TaShu.CourseManagement.ViewModel
{
    public class FirstPageViewModel : NotifyBase
    {
        private int _instrumentValue;

        public int InstrumentValue
        {
            get { return _instrumentValue; }
            set { _instrumentValue = value; this.DoNotify(); }
        }

        private int _ItemCount;

        public int ItemCount
        {
            get { return _ItemCount; }
            set { _ItemCount = value; this.DoNotify(); }
        }


        public FirstPageViewModel()
        {
            this.RefreshInstrumentValues();
            initCourseSeriesList();
        }

        public ObservableCollection<CourseSeriesModel> CourseSeriesList { get; set; } = new ObservableCollection<CourseSeriesModel>();
        private void initCourseSeriesList()
        {
            List<CourseSeriesModel> li = LocalDataAccess.GetInstance().GetCoursePlayRecord();
            this.ItemCount = li.Max(l => l.SeriesList.Count);
            foreach (var item in LocalDataAccess.GetInstance().GetCoursePlayRecord())
            {
                CourseSeriesList.Add(item);
            }
        }


        Random ran = new Random();
        bool taskSwitch = true;
        List<Task> taskList = new List<Task>();

        /// <summary>
        /// 自动刷新仪表盘
        /// </summary>
        private void RefreshInstrumentValues()
        {
            Task t = Task.Run(async () =>
            {
                while (taskSwitch)
                {
                    this.InstrumentValue = ran.Next(Math.Max(_instrumentValue - 5, -10), Math.Min(100, _instrumentValue + 5));
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            });
            taskList.Add(t);
        }

        public void Dispose()
        {
            try
            {
                taskSwitch = false;
                Task.WaitAll(taskList.ToArray());
            }
            catch (Exception)
            {
            }
        }
    }
}
