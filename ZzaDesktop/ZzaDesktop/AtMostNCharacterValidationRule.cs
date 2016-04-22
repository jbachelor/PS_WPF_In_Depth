using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ZzaDesktop
{
    public class AtMostNCharacterValidationRule : ValidationRule
    {
        public int MaximumStringLength { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.GetType() != typeof(string))
                throw new ArgumentException("AtMostNCharacterValidationRule is meant only to validate a string argument.");

            string valueString = value.ToString();

            if (valueString.Length > MaximumStringLength)
                return new ValidationResult(false, $"Less than {MaximumStringLength} characters, please");
            else
                return new ValidationResult(true, null);
        }
    }
}
