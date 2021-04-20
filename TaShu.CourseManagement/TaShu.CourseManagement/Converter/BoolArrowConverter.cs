using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TaShu.CourseManagement.Converter
{
    public class BoolArrowConverter : IValueConverter
    {
        //model 向 view 转换
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value!=null&&bool.Parse(value.ToString()))
            {
                return "↑";
            }
            return "↓";
        }

        //view 向model 转换
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
