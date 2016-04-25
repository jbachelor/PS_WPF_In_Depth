using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZzaDesktop.Validation;
using System.Globalization;
using System.Windows.Controls;

namespace ZzaDesktopTests
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void AtLeastNCharacterValidationRulePassesWithEmptyStringWhenZeroCharsIsValid()
        {
            var validationRule = new AtLeastNCharacterValidationRule()
            {
                MinimumStringLength = 4,
                ZeroCharactersIsValid = true
            };

            ValidationResult result = validationRule.Validate(string.Empty, CultureInfo.CurrentCulture);
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void AtLeastNCharacterValidationRuleFailsWithEmptyStringWhenZeroCharsIsInvalid()
        {
            var validationRule = new AtLeastNCharacterValidationRule()
            {
                MinimumStringLength = 4
            };

            ValidationResult result = validationRule.Validate(string.Empty, CultureInfo.CurrentCulture);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void AtLeastNCharacterValidationRulePassesWithNullValue()
        {
            var validationRule = new AtLeastNCharacterValidationRule()
            {
                MinimumStringLength = 4
            };

            ValidationResult result = validationRule.Validate(null, CultureInfo.CurrentCulture);
            Assert.IsTrue(result.IsValid);
        }
        
        [TestMethod]
        public void AtLeastNCharacterValidationRulePassesWithNullValueWhenZeroCharsIsValid()
        {
            var validationRule = new AtLeastNCharacterValidationRule()
            {
                MinimumStringLength = 4,
                ZeroCharactersIsValid = true
            };

            ValidationResult result = validationRule.Validate(null, CultureInfo.CurrentCulture);
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void AtLeastNCharacterValidationRulePassesWithLongEnoughString()
        {
            var validationRule = new AtLeastNCharacterValidationRule()
            {
                MinimumStringLength = 4
            };

            ValidationResult result = validationRule.Validate("1234", CultureInfo.CurrentCulture);
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void AtLeastNCharacterValidationRulePassesWithLongEnoughStringWhenZeroCharsIsValid()
        {
            var validationRule = new AtLeastNCharacterValidationRule()
            {
                MinimumStringLength = 4,
                ZeroCharactersIsValid = true
            };

            ValidationResult result = validationRule.Validate("1234", CultureInfo.CurrentCulture);
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void AtLeastNCharacterValidationRulePassesWithLongString()
        {
            var validationRule = new AtLeastNCharacterValidationRule()
            {
                MinimumStringLength = 5
            };

            ValidationResult result = validationRule.Validate("1234567891011121314151617181920", CultureInfo.CurrentCulture);
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void AtLeastNCharacterValidationRulePassesWithLongStringWhenZeroCharsIsValid()
        {
            var validationRule = new AtLeastNCharacterValidationRule()
            {
                MinimumStringLength = 5,
                ZeroCharactersIsValid = true
            };

            ValidationResult result = validationRule.Validate("1234567891011121314151617181920", CultureInfo.CurrentCulture);
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void AtLeastNCharacterValidationRuleFailsWithShortString()
        {
            var validationRule = new AtLeastNCharacterValidationRule()
            {
                MinimumStringLength = 4
            };

            ValidationResult result = validationRule.Validate("123", CultureInfo.CurrentCulture);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void AtLeastNCharacterValidationRuleFailsWithShortStringWhenZeroCharsIsValid()
        {
            var validationRule = new AtLeastNCharacterValidationRule()
            {
                MinimumStringLength = 4,
                ZeroCharactersIsValid = true
            };

            ValidationResult result = validationRule.Validate("123", CultureInfo.CurrentCulture);
            Assert.IsFalse(result.IsValid);
        }
    }
}
