using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace WpfSplashScreen
{
    public class Splash<TWindow> : ISplashScreen where TWindow : Window, new()
    {
        private SplashViewModel _viewModel;
        private TWindow _window;

        #region ISplashScreen Members

        public void ShowMessage(string message)
        {
            _viewModel.Message = message;
        }

        #endregion

        public void Show()
        {
            var thread = new Thread(() =>
                                        {
                                            _viewModel = new SplashViewModel();
                                            _window = new TWindow {DataContext = _viewModel};
                                            _window.Show();

                                            _window.Closed += (sender, e) => _window.Dispatcher.InvokeShutdown();

                                            Dispatcher.Run();
                                        });

            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();

            while (_window == null)
            {
                // wait until splah window is created
            }
        }

        public void Close()
        {
            _window.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) (() => _window.Close()));
        }
    }
}