using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaShu.CourseManagement.Common;

namespace TaShu.CourseManagement.Model
{
    public class UserModel : NotifyBase
    {
        private string _Avatar;

        public string Avatar
        {
            get { return _Avatar; }
            set { _Avatar = value; this.DoNotify(); }
        }

        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; this.DoNotify(); }
        }

        private int _Gender;

        public int Gender
        {
            get { return _Gender; }
            set { _Gender = value; this.DoNotify(); }
        }

    }
}
