using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ZzaDesktop
{
    public class AtLeastNCharacterValidationRule : ValidationRule
    {
        public int MinimumStringLength { get; set; }
        public bool LetZeroBeValid { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.GetType() != typeof(string))
                throw new ArgumentException("AtLeastNCharacterValidationRule is meant only to validate a string argument.");
            
            string valueString = value.ToString();

            if (valueString.Length > 0 && valueString.Length < MinimumStringLength)
                return new ValidationResult(false, $"Must be at least {MinimumStringLength} characters");
            else
                return new ValidationResult(true, null);
        }
    }
}
