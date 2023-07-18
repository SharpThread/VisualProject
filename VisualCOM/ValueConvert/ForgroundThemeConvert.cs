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
    public class ForgroundThemeConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool blValue = System.Convert.ToBoolean(value);
            if (blValue == true)
            {
                return new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
            else if (blValue == false)
            {
                return new SolidColorBrush(Color.FromRgb(255,255,255));
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
