using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaShu.CourseManagement.Common;
using TaShu.CourseManagement.DataAccess.DataEntity;
using TaShu.CourseManagement.Model;

namespace TaShu.CourseManagement.ViewModel
{
    public class MainViewModel : NotifyBase
    {
        //这种写法也可以实现用户显示
        //public UserEntity User { get; set; } = GlobalValues.USER;
        public UserModel UserInfo { get; set; } = new UserModel();

        private string _SearchText;

        public string SearchText
        {
            get { return _SearchText; }
            set { _SearchText = value; this.DoNotify(); }
        }

        private FrameworkElement _MainContent;

        public FrameworkElement MainContent
        {
            get { return _MainContent; }
            set { _MainContent = value; this.DoNotify(); }
        }

        public CommandBase CloseWindowCommand { get; set; }
        //public CommandBase BigWindowCommand { get; set; }
        //public CommandBase HideWindowCommand { get; set; }

        public CommandBase NavChangedCommand { get; set; }

        public MainViewModel()
        {
            this.CloseWindowCommand = new CommandBase();
            this.CloseWindowCommand.DoExecute = (o) => { (o as Window).Close(); };
            this.CloseWindowCommand.DoCanExecute = (o) => { return true; };

            this.NavChangedCommand = new CommandBase();
            this.NavChangedCommand.DoExecute = DoNavChanged;
            this.NavChangedCommand.DoCanExecute = DoNavCanExecute;

            DoNavCanExecute("FirstPageView");
        }

        private bool DoNavCanExecute(object arg)
        {
            return true;
        }

        private void DoNavChanged(object obj)
        {
            Type type = Type.GetType($"TaShu.CourseManagement.View.{obj.ToString()}");
            ConstructorInfo constructorInfo = type.GetConstructor(Type.EmptyTypes);
            this.MainContent = (FrameworkElement)constructorInfo.Invoke(null);
        }
    }
}
