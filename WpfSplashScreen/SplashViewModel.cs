namespace WpfSplashScreen
{
    public class SplashViewModel : BasePropertyChanged
    {
        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                if (value == _message)
                {
                    return;
                }

                _message = value;
                OnPropertyChanged(() => Message);
            }
        }
    }
}