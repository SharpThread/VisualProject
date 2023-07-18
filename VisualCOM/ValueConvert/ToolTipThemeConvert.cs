using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace VisualCOM.ValueConvert
{
    public class ToolTipThemeConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool valueTemp = System.Convert.ToBoolean(value);

            if ((bool)valueTemp == true)
            {
                return "切换到夜晚模式";
            }
            else if ((bool)valueTemp == false)
            {
                return "切换到白天模式";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
