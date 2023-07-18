using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VisualCOM.Rule
{
    public class CheckUtilRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value==null)
                return new ValidationResult(false, "数据不能为空");
            else
            {
                string input=value.ToString();
                foreach (char c in input)
                {
                    if (char.IsDigit(c))
                    {
                        return new ValidationResult(false, "数据格式错误");
                    }
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
