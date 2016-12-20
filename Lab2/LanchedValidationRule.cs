using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lab2
{
    class LanchedValidationRule : ValidationRule
    {
        const string ErrorZeroMessage = "Тогда металлических боевых кораблей не было!";
        const string ErrorMessage = "Неверное значение";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int launched = 0;
            if (value == null)
                return ValidationResult.ValidResult;
            if (!int.TryParse((string)value, out launched))
                return new ValidationResult(false, ErrorMessage);
            if (launched < Battleship.FirstIronBattleship)
                return new ValidationResult(false, ErrorZeroMessage);
            return ValidationResult.ValidResult;
        }
    }
}
