using TaShu.CourseManagement.Common;

namespace TaShu.CourseManagement.Model
{
    public class LoginModel : NotifyBase
    {
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                this.DoNotify();
            }
        }

        private string _password;

        public string PassWord
        {
            get { return _password; }
            set
            {
                _password = value;
                this.DoNotify();
            }
        }

        private string _ValidateCode;

        public string ValidateCode
        {
            get { return _ValidateCode; }
            set
            {
                _ValidateCode = value;
                this.DoNotify();
            }
        }
    }
}
