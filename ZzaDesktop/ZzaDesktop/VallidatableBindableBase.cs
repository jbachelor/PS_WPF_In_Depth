using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ZzaDesktop
{
    public class ValidatableBindableBase : BindableBase, INotifyDataErrorInfo
    {
        protected Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate { };

        public bool HasErrors
        {
            get { return _propertyErrors.Count > 0; }
        }

        public IEnumerable GetErrors(string propertyName)
        {
                if (_propertyErrors.ContainsKey(propertyName))
                    return _propertyErrors[propertyName];            
            return null;
        }

        protected override void SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
        {
            base.SetProperty<T>(ref member, val, propertyName);  // Call base, since that's where INotifyPropertyChanged is implemented.
            ValidateProperty(propertyName, val);
        }

        private void ValidateProperty<T>(string propertyName, T value)
        {
            var validationResults = new List<ValidationResult>();
            ValidationContext validationContext = new ValidationContext(this);
            validationContext.MemberName = propertyName;
            Validator.TryValidateProperty(value, validationContext, validationResults);

            if (validationResults.Any())
            {
                _propertyErrors[propertyName] = validationResults.Select(error => error.ErrorMessage).ToList();
            }
            else
            {
                _propertyErrors.Remove(propertyName);
            }

            ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
