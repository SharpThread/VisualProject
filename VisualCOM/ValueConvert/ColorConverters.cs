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
    public class ColorConverters : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
            if (value != null)
            {
                if (bool.Parse(value.ToString()))
                {
                    return new SolidColorBrush((Color)System.Windows.Media.ColorConverter.ConvertFromString("#008000"));
                }
            }
            return new SolidColorBrush((Color)System.Windows.Media.ColorConverter.ConvertFromString("#808080"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
