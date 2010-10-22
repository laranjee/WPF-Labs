using System.Threading;
using System.Windows;

namespace WpfSplashScreen
{
    public class Bootstrapper
    {
        public Window BootstrapShell(ISplashScreen splashScreen)
        {
            for (int i = 1; i <= 10; i++)
            {
                splashScreen.ShowMessage(string.Format("Loading module {0}...", i));
                Thread.Sleep(500);
            }

            splashScreen.ShowMessage("Starting main window...");
            Thread.Sleep(1000);

            return new MainWindow();
        }
    }
}