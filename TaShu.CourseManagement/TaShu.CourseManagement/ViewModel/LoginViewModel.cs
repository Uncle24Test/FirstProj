using System.Windows;
using TaShu.CourseManagement.Common;
using TaShu.CourseManagement.DataAccess.DataEntity;
using TaShu.CourseManagement.Model;

namespace TaShu.CourseManagement.ViewModel
{
    public class LoginViewModel : NotifyBase
    {
        public CommandBase CloseWindowCommand { get; set; }
        public CommandBase LoginCommand { get; set; }
        public LoginModel LoginModel { get; set; }

        private string _ErrMsg;

        public string ErrMsg
        {
            get { return _ErrMsg; }
            set { _ErrMsg = value; this.DoNotify(); }
        }


        public LoginViewModel()
        {
            this.LoginModel = new LoginModel();
            this.LoginModel.UserName = "他二十四叔";
            this.LoginModel.PassWord = "123456";
            this.LoginModel.ValidateCode = "7364";
            this.CloseWindowCommand = new CommandBase();
            this.CloseWindowCommand.DoExecute = (o) => { (o as Window).Close(); };
            this.CloseWindowCommand.DoCanExecute = (o) => { return true; };

            this.LoginCommand = new CommandBase();
            this.LoginCommand.DoExecute = DoLogin;
            this.LoginCommand.DoCanExecute = (o) => { return true; };
        }

        private void DoLogin(object arg)
        {
            this.ErrMsg = "";
            if (string.IsNullOrEmpty(LoginModel.UserName))
            {
                this.ErrMsg = "请输入用户名!";
                return;
            }

            if (string.IsNullOrEmpty(LoginModel.PassWord))
            {
                this.ErrMsg = "请输入密码!";
                return;
            }

            if (string.IsNullOrEmpty(LoginModel.ValidateCode))
            {
                this.ErrMsg = "请输入验证码!";
                return;
            }

            if (!LoginModel.ValidateCode.Equals("7364"))
            {
                this.ErrMsg = "请输入正确验证码!";
                return;
            }
            UserEntity user = DataAccess.LocalDataAccess.GetInstance().CheckUserInfo(LoginModel.UserName, LoginModel.PassWord);
            GlobalValues.USER = user;

            if (user!=null)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    (arg as Window).DialogResult = true;
                });
            }
            else
            {
                this.ErrMsg = "用户名或密码错误";
            }
        }
    }
}
