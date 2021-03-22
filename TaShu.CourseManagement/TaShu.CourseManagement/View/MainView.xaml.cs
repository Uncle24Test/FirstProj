using System.Windows;
using System.Windows.Input;
using TaShu.CourseManagement.Common;
using TaShu.CourseManagement.ViewModel;

namespace TaShu.CourseManagement.View
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.PrimaryScreenHeight;

            MainViewModel model = new MainViewModel();
            this.DataContext = model;
            model.UserInfo.Avatar = GlobalValues.USER?.Avatar;
            model.UserInfo.UserName = GlobalValues.USER?.RealName;
            model.UserInfo.Gender = GlobalValues.USER == null ? 0 : GlobalValues.USER.Gender;
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                }
                this.DragMove();
            }
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }
    }
}
