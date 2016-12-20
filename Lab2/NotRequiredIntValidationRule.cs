using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lab2
{
    class NotRequiredIntValidationRule : ValidationRule
    {
        const string ErrorMessage = "Неверное значение!";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(value as string))
                return ValidationResult.ValidResult;

            int result;
            if (!int.TryParse((string)value, out result))
                return new ValidationResult(false, ErrorMessage);

            return ValidationResult.ValidResult;
        }
    }
}