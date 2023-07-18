using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace VisualCOM.ValueConvert
{
    public class RightThemeConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool valueTemp = System.Convert.ToBoolean(value);
            if (valueTemp == true)
            {
                return new SolidColorBrush(Color.FromRgb(253, 251, 253));
            }
            else if (valueTemp == false)
            {
                return new SolidColorBrush(Color.FromRgb(34, 37, 46));
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
