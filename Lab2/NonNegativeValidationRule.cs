using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lab2
{
    class NonNegativeValidationRule : ValidationRule
    {
        const string ErrorZeroMessage = "Значение не может быть отрицательным";
        const string ErrorMessage = "Неверное значение";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int num = 0;
            if (!int.TryParse((string)value, out num))
                return new ValidationResult(false, ErrorMessage);
            if (num < 0)
                return new ValidationResult(false, ErrorZeroMessage);
            return ValidationResult.ValidResult;
        }
    }
}
