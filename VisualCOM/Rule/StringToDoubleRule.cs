using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VisualCOM.Rule
{
    public class StringToDoubleRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double result;
            if (!double.TryParse(value.ToString(), out result))
            {
                return new ValidationResult(false, "输入数据有误");
            }
            return ValidationResult.ValidResult;


        }
    }
}
