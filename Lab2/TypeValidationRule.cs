using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lab2
{
    class TypeValidationRule : ValidationRule
    {
        const string InvalidTypeError = "Неизвестный тип!";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string type = value as string;
            if (string.IsNullOrEmpty(type) || !Battleship.TypeList.Contains(type))
                return new ValidationResult(false, InvalidTypeError);

            return ValidationResult.ValidResult;
        }
    }
}
