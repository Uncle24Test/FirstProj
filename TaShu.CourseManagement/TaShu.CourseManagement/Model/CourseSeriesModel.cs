using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaShu.CourseManagement.Model
{
    public class CourseSeriesModel
    {
        //不需要及时调整，普通属性
        public string CourseName { get; set; }

        public SeriesCollection SeriesCollection { get; set; }

        public ObservableCollection<SeriesModel> SeriesList { get; set; }
    }
}
