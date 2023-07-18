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
    public class LeftThemeConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool valueTemp = System.Convert.ToBoolean(value);

            if ((bool)valueTemp == true)
            {
                return new SolidColorBrush(Color.FromRgb(255,255,255));
            }
            else if ((bool)valueTemp == false)
            {
                return new SolidColorBrush(Color.FromRgb(46, 50, 62));
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
