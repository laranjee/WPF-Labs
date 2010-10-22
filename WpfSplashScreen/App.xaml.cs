using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace WpfSplashScreen
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var splash = new Splash<SplashView>();

            splash.Show();

            Window shell = new Bootstrapper().BootstrapShell(splash);

            splash.Close();
            shell.Show();
        }
    }
}
