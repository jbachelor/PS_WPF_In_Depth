using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ZzaDesktop.Validation
{
    sealed public class AtLeastNCharactersAttribute : ValidationAttribute
    {
        #region Constructors

        public AtLeastNCharactersAttribute(int minimumCharacters) 
            : this(minimumCharacters, $"Must be at least {minimumCharacters} characters") { }

        public AtLeastNCharactersAttribute(int minimumCharacters, string errorMessage)
        {
            _minimumNumberOfCharacters = minimumCharacters;
            _customErrorMessage = errorMessage;
        }

        #endregion Constructors

        #region Fields

        private int _minimumNumberOfCharacters;
        private string _customErrorMessage;

        #endregion Fields

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || value.ToString().Length < _minimumNumberOfCharacters)
            {
                if(string.IsNullOrWhiteSpace(_customErrorMessage))
                    _customErrorMessage = FormatErrorMessage(validationContext.DisplayName);

                return new ValidationResult(_customErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
