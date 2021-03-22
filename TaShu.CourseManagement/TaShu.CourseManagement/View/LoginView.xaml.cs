using System.Windows;
using System.Windows.Input;
using TaShu.CourseManagement.ViewModel;

namespace TaShu.CourseManagement.View
{
    /// <summary>
    /// LoginViewxaml.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel();
        }

        private void WinMove_LeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
