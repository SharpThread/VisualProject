using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace VisualCOM.ValueConvert
{
    public class IconThemeConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool valueTemp = System.Convert.ToBoolean(value);

            if ((bool)valueTemp == true)
            {
               return  PackIconKind.WeatherNight;
            }
            else if ((bool)valueTemp == false)
            {
                return PackIconKind.WhiteBalanceSunny;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
