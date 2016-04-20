using System;
using System.Windows.Input;

namespace ZzaDesktop
{
    public class RelayCommand : ICommand
    {
        private Action targetExecuteMethod;
        private Func<bool> targetCanExecuteMethod;

        public RelayCommand(Action executeMethod)
        {
            targetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            targetExecuteMethod = executeMethod;
            targetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        #region ICommand Members
        public event EventHandler CanExecuteChanged = delegate { };

        public bool CanExecute(object parameter)
        {
            if (targetCanExecuteMethod != null)
                return targetCanExecuteMethod();

            if (targetExecuteMethod != null)
                return true;

            return false;
        }

        public void Execute(object parameter)
        {
            targetExecuteMethod?.Invoke();
        }

        #endregion ICommand Members
    }

    public class RelayCommand<T> : ICommand
    {
        private Action<T> targetExecuteMethod;
        private Func<T, bool> targetCanExecuteMethod;

        public RelayCommand(Action<T> executeMethod)
        {
            targetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            targetExecuteMethod = executeMethod;
            targetCanExecuteMethod = canExecuteMethod;
        }

        #region ICommand Members

        // Beware - should use weak references if command instance lifetime is longer than lifetime of UI objects that get hooked up to command
        // Prism commands solve this in their implementation
        public event EventHandler CanExecuteChanged = delegate { };

        public bool CanExecute(object parameter)
        {
            if (targetCanExecuteMethod != null)
            {
                T tparm = (T)parameter;
                return targetCanExecuteMethod(tparm);
            }
            if (targetExecuteMethod != null)
                return true;

            return false;
        }

        public void Execute(object parameter)
        {
            if (targetExecuteMethod != null)
                targetExecuteMethod((T)parameter);
        }

        #endregion ICommand Members

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
