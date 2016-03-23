using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMHookupDemo
{
    public class RelayCommand : ICommand
    {
        Action _TargetExecuteMethod;
        Func<bool> _TargetCanExecuteMethod;

        public RelayCommand(Action executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        #region ICommand Members
        
        public bool CanExecute(object parameter)
        {
            if(_TargetCanExecuteMethod != null)
            {
                return _TargetCanExecuteMethod();
            }

            if(_TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        // NOTE:  Should use weak references if command instance lifetime is longer than lifetime of UI objects.
        // Prism commands solve this in their implementation.
        public event EventHandler CanExecuteChanged = delegate { };
        
        public void Execute(object parameter)
        {
            if(_TargetExecuteMethod != null)
            {
                _TargetExecuteMethod();
            }
        }

        #endregion ICommand Members
    }

    public class RelayCommand<T> : ICommand
    {
        Action<T> _TargetExecuteMethod;

        #region ICommand Members

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        #endregion ICommand Members
    }
}
