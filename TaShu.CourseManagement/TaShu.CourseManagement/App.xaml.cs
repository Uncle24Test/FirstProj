using System.Windows;
using TaShu.CourseManagement.View;

namespace TaShu.CourseManagement
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (new LoginView().ShowDialog()==true)
            {
                new MainView().ShowDialog();
            }

            //关闭程序  主窗口关闭才会关闭  模式为 ShutdownMode="OnExplicitShutdown"
            Application.Current.Shutdown();
        }
    }
}
