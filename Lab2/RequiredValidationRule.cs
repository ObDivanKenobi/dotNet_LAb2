using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lab2
{
    class RequiredValidationRule : ValidationRule
    {
        const string ErrorMessage = "Обязательное поле!";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty((string)value))
                return new ValidationResult(false, ErrorMessage);
            return ValidationResult.ValidResult;
        }
    }
}
