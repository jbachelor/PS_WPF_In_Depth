using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ZzaDesktop.Validation
{
    public class AtLeastNCharacterValidationRule : ValidationRule
    {
        public int MinimumStringLength { get; set; }
        public bool ZeroCharactersIsValid { get; set; } = false;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()) && ZeroCharactersIsValid)
                return new ValidationResult(true, null);

            if (value.GetType() != typeof(string))
                throw new ArgumentException("AtLeastNCharacterValidationRule is meant only to validate a string argument.");

            var stringLength = value.ToString().Length;

            if (stringLength < MinimumStringLength)
                return new ValidationResult(false, $"Please enter at least {MinimumStringLength} characters");
            else
                return new ValidationResult(true, null);
        }
    }
}
