using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace VisualCOM.Rule
{
    public class CheckBaudRateRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
            {
                if (int.TryParse(value.ToString(), out int result))
                {
                    return ValidationResult.ValidResult;
                }
                else
                {
                    return new ValidationResult(false, "请输入有效的数字");
                }
            }

            return new ValidationResult(false, "值不能为空");
        }
    }
}
