using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ZzaDesktop
{
    public class BindableBase : INotifyPropertyChanged
    {
        protected virtual void SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, val)) return;
            member = val;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #region INPC members
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        #endregion INPC members
    }
}
