using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace WpfSplashScreen
{
    public abstract class BasePropertyChanged : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected void OnPropertyChanged<TProperty>(Expression<Func<TProperty>> property)
        {
            OnPropertyChanged(property.GetMemberInfo().Name);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}