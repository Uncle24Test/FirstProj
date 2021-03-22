using System;
using System.Windows.Input;

namespace TaShu.CourseManagement.Common
{
    public class CommandBase:ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action<object> DoExecute { get; set; }
        public Func<object, bool> DoCanExecute { get; set; }

        public void Execute(object parm) { DoExecute?.Invoke(parm); }
        public bool CanExecute(object parm) { return (bool)DoCanExecute?.Invoke(parm); }

    }
}
